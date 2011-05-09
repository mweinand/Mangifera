using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Windows.Threading;
using Mangifera.Threading;

namespace Mangifera.Messaging.Scheduler
{
    public class CommandScheduler : ICommandScheduler
    {
        private Dictionary<Type, DispatcherTimer> _timers;
        private ICommandBus _commandBus;
        private IUIThreadInvoker _uiThreadInvoker;

        public CommandScheduler(ICommandBus commandBus, IUIThreadInvoker uiThreadInvoker)
        {
            _timers = new Dictionary<Type, DispatcherTimer>();
            _commandBus = commandBus;
            _uiThreadInvoker = uiThreadInvoker;
        }

        public void ConfigureSchedule<T>(TimeSpan interval) where T : ICommand
        {
            var commandType = typeof(T);

            if (!_timers.ContainsKey(commandType))
            {
                var newTimer = new DispatcherTimer();
                newTimer.Tick += (s,e) => {
                    _commandBus.PublishCommand<T>();
                };
                _timers.Add(commandType, newTimer);
            }

            var timer = _timers[commandType];
            
            if (timer.IsEnabled)
            {
                throw new Exception("Stop the timer before configuring");
            }

            timer.Interval = interval;
            
        }

        public void Start<T>() where T : ICommand
        {            
            var commandType = typeof(T);

            if (!_timers.ContainsKey(commandType))
            {
                throw new Exception(String.Format("Schedule for {0} is not configured.", commandType.Name));
            }

            _uiThreadInvoker.Invoke(() =>
            {
                _timers[commandType].Start();
            });
        }

        public void Stop<T>() where T : ICommand
        {
            var commandType = typeof(T);

            if (!_timers.ContainsKey(commandType))
            {
                throw new Exception(String.Format("Schedule for {0} is not configured.", commandType.Name));
            }

            _uiThreadInvoker.Invoke(() =>
            {
                _timers[commandType].Stop();
            });
        }
    }
}
