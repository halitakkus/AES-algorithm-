using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Packages.Socket.Core.Service
{
    /// <summary>
    /// Hash service provides generate and compare methods signatures.
    /// </summary>
    public interface ISocketService
    {
        /// <summary>
        /// Send message with udp or tcp.
        /// </summary>
        /// <param name="plainSocket">Plain byte for socked.</param>
        /// <returns></returns>
        Task<int> Send(byte[] data, IPEndPoint iPEndPoint);
        /// <summary>
        /// Receive data with udp or tcp.
        /// </summary>
        /// <returns></returns>
        Task<byte[]> Listen(IPEndPoint iPEndPoint);
    }
}
