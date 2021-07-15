using Microsoft.AspNetCore.SignalR;
using net_api_backend.Hubs.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_api_backend.Hubs
{
    public class DeviceHub : Hub<IDeviceClient>
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.ReceiveMessage(message);
        }

        public async Task RequestReloadData()
        {

            await Clients.All.ReloadData(DateTime.Now.ToString("yyyyMMddHHmmss"));
        }
    }
}
