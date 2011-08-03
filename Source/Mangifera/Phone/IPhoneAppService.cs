using System;

namespace Mangifera.Phone
{
    public interface IPhoneAppService
    {
        void DisablePhoneAutoLock();
        void EnablePhoneAutoLock();
    }
}
