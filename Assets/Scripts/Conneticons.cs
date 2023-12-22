using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class Conneticons : MonoBehaviour
{
    private int port = 13000;
    private IPAddress localAddr = IPAddress.Parse("127.0.0.1");
    private void Start()
    {
        using (var clinet = new TcpClient())
        {
            clinet.Connect(localAddr, port);

            using NetworkStream stream = clinet.GetStream();

            byte[] msg = Encoding.UTF8.GetBytes("Hello World!");

            stream.Write(msg, 0, msg.Length);

            byte[] buffer = new byte[255];

            stream.Read(buffer, 0, buffer.Length);

            Debug.Log(Encoding.UTF8.GetString(buffer));

        }
    }

}
