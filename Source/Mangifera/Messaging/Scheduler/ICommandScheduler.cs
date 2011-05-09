using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mangifera.Messaging.Scheduler
{
    public interface ICommandScheduler
    {
        void ConfigureSchedule<T>(TimeSpan interval) where T : ICommand;
        void Start<T>() where T : ICommand;
        void Stop<T>() where T : ICommand;
    }
}
