using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class Server {

    public static string data = null;

    public static void StartListening() {
        byte[] bytes = new Byte[1024];

        bool success = false;
        string[] str = new string[3];
        string[] msgSplit = new string[2];

        IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 5000);

        Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        try {
            listener.Bind(localEndPoint);
            listener.Listen(10);

            Console.WriteLine("Server started");

            while (true) {
                //Console.WriteLine("Waiting for a connection...");
                Socket handler = listener.Accept();
                data = null;

                //non esce finche' non riceve un messaggio con il . alla fine
                while (true) {
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf(".") > -1) {
                        break;
                    }
                }

                data = data.Remove(data.Length - 1);
                msgSplit = data.Split(';');

                //Console.WriteLine("Text received: {0}", data);

                switch (msgSplit[2]) {
                    case "0":
                        login(str, msgSplit, success, handler);
                        break;
                    case "1":
                        //giochi completati                      
                        break;
                    case "2":
                        //giochi in corso
                        break;
                    case "3":
                        //giochi in programma
                        break;
                    case "4":
                        //ricerca utente
                        break;
                }
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

    public static void login(string[] str, string[] msgSplit, bool success, Socket handler) {
        foreach (string line in File.ReadLines("../../../Login.TXT")) {
            //[0] = username, [1] = nickname, [2] = password
            str = line.Split(',');
            if (str[0] == msgSplit[0] && str[2] == msgSplit[1]) {
                Console.WriteLine("utente trovato");
                success = true;
                break;
            }
        }
        if (!success) {
            Console.WriteLine("utente non trovato");
            str[1] = " ";
        }

        byte[] msg = Encoding.ASCII.GetBytes(Convert.ToString(success) + ';' + str[1]);

        handler.Send(msg);
        handler.Shutdown(SocketShutdown.Both);
        handler.Close();
        //success = false;
    }
}
