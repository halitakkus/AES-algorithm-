using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Application.Packages.Socket.Core.Service;

namespace Application.Packages.Socket.Udp.Service
{
    /// <summary>
    /// Socket service.
    /// </summary>
    public class UdpSocketService : ISocketService
    {
        public async Task<byte[]> Listen(IPEndPoint iPEndPoint)
        {
            var udpClient = new UdpClient(iPEndPoint);
            var receiveResult = await udpClient.ReceiveAsync();

            udpClient.Close();

            return receiveResult.Buffer;
        }

        public async Task<int> Send(byte[] data, IPEndPoint iPEndPoint)
        {
            var udpClient = new UdpClient();
           
           return await udpClient.SendAsync(data,data.Length,iPEndPoint);
        }
    }
}
