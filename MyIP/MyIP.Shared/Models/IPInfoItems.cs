using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Connectivity;

namespace MyIP.Models
{
    class IPInfoItems : List<IPInfoItem>
    {
        public async Task GetIPInfomation()
        {
            this.Clear();

            var hostnames = new List<HostName>();
            foreach (var hn in NetworkInformation.GetHostNames())
            {
                if (hn.IPInformation != null && hn.IPInformation.NetworkAdapter != null)
                {
                    hostnames.Add(hn);
                }
            }
            
            var f = new ConnectionProfileFilter
            {
                IsConnected = true
            };

            foreach (var cp in await NetworkInformation.FindConnectionProfilesAsync(f))
            {
                foreach (var hn in hostnames.Where(_ => _.IPInformation.NetworkAdapter.NetworkAdapterId == cp.NetworkAdapter.NetworkAdapterId))
                {
                    this.Add(new IPInfoItem(hn, cp));
                }
            }
        }
    }
}
