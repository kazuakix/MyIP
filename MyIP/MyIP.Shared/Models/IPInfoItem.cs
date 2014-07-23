using Windows.Networking;
using Windows.Networking.Connectivity;

namespace MyIP.Models
{
    public class IPInfoItem
    {
        public bool                         IsWLAN                          { get; set; }
        public bool                         IsWWAN                          { get; set; }
        public string                       InterfaceType                   { get; set; }
        public string                       InterfaceName                   { get; set; }
        public string                       IPType                          { get; set; }
        public string                       IPAddress                       { get; set; }
        public NetworkConnectivityLevel     NetworkConnectivityLevel        { get; set; }
        public string                       NetworkConnectivityLevelString  { get; set; }

        public IPInfoItem()
        {
        }
        public IPInfoItem(HostName hostName, ConnectionProfile connectionProfile)
        {
            if (hostName == null || connectionProfile == null) return;

            IsWLAN = connectionProfile.IsWlanConnectionProfile;
            IsWWAN = connectionProfile.IsWwanConnectionProfile;

            if (IsWLAN)
            {
                this.InterfaceType = "WiFi";
                this.InterfaceName = connectionProfile.ProfileName;
            }
            else if (IsWWAN)
            {
                this.InterfaceType = "mobile";
                this.InterfaceName = connectionProfile.WwanConnectionProfileDetails.AccessPointName;
            }

            this.IPType     = hostName.Type.ToString();
            this.IPAddress  = hostName.DisplayName;

            this.NetworkConnectivityLevel = connectionProfile.GetNetworkConnectivityLevel();
            switch (this.NetworkConnectivityLevel)
            {
                case NetworkConnectivityLevel.LocalAccess:
                    this.NetworkConnectivityLevelString = "Local network access only";
                    break;
                case NetworkConnectivityLevel.ConstrainedInternetAccess:
                    this.NetworkConnectivityLevelString = "Limited internet access";
                    break;
                case NetworkConnectivityLevel.InternetAccess:
                    this.NetworkConnectivityLevelString = "Local and Internet access";
                    break;
                default:
                    this.NetworkConnectivityLevelString = "No connectivity";
                    break;
            }
        }
    }
}
