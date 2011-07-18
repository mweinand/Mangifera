using System;

namespace Mangifera.Threading
{
    public interface IUIThreadInvoker
    {
        void Invoke(Action action);
    }
}
