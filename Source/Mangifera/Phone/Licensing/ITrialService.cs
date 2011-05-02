namespace Mangifera.Phone.Licensing
{
    public interface ITrialService
    {
        bool IsTrial();
        void SendUserToMarketplace();
    }
}