using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class Server {

    public static string data = null;

    public static void StartListening() {
        byte[] bytes = new Byte[1024];

        IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 5000);

        Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        try {
            listener.Bind(localEndPoint);
            listener.Listen(10);

            while (true) {
                Console.WriteLine("Waiting for a connection...");
                Socket handler = listener.Accept();
                data = null;

                while (true) {

                    //byte[] message = Encoding.ASCII.GetBytes(min.ToString() + ";" + max.ToString());
                    //handler.Send(message);

                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf(".") > -1) {
                        break;
                    }
                }

                Console.WriteLine("Number received: {0}", data);

                byte[] msg = Encoding.ASCII.GetBytes(data);

                handler.Send(msg);
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }

        }
        catch (Exception e) {
            Console.WriteLine(e.ToString());
        }

        Console.WriteLine("\nPress ENTER to continue...");
        Console.Read();

    }

    public static int Main(String[] args) {
        StartListening();
        return 0;
    }
}
