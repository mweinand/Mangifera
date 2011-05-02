using Microsoft.Phone.Marketplace;
using Microsoft.Phone.Tasks;

namespace Mangifera.Phone.Licensing
{
    public class TrialService : ITrialService
    {
        public bool IsTrial()
        {
            var license = new LicenseInformation();
            return license.IsTrial();
        }

        public void SendUserToMarketplace()
        {
            var detailTask = new MarketplaceDetailTask();
            detailTask.Show();
        }
    }
}
