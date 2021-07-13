using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_api_backend.Hubs.Clients
{
    public interface IDeviceClient
    {
        Task ReceiveMessage(string message);
        Task ReloadData(string newSignal);

    }
}
