using Cosmos.HAL;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4;

namespace OdinOS
{
    internal class Net
    {
        //These are all just to get the IP Address of the host
        public static NetworkDevice networkDevice;
        public static void Start()
        {            
            Kernel.useNetwork = true;
            networkDevice = NetworkDevice.GetDeviceByName("eth0");
            IPConfig.Enable(networkDevice, new Address(192, 168, 0, 1), new Address(255, 255, 255, 0), new Address(192, 168, 1, 254));
            if (NetworkConfiguration.CurrentAddress != null)
            {
                Kernel.useNetwork = true;
            }
        }

        public static string GetInfo()
        {
            if (!Kernel.useNetwork) { Start(); }
            return " IP Address: " + NetworkConfiguration.CurrentAddress?.ToString() ?? "Not available";
        }
    }
}
