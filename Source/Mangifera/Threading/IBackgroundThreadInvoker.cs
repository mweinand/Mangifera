using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Mangifera.Threading
{
    public interface IBackgroundThreadInvoker
    {
        void Invoke(Action action);
    }

    public class BackgroundThreadInvoker : IBackgroundThreadInvoker
    {
        public void Invoke(Action action)
        {
            ThreadPool.QueueUserWorkItem((s) => action.Invoke());
        }
    }
}
