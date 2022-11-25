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

            Console.WriteLine("Server started");

            while (true) {
                Socket handler = listener.Accept();

                ClientManager clientThread = new ClientManager(handler);
                Thread t = new Thread(new ThreadStart(clientThread.doClient));
                t.Start();
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

    public class ClientManager {

        string[] msgSplit = new string[2];
        bool success = false;
        string[] str = new string[3];
        Socket handler;
        byte[] bytes = new Byte[1024];
        String data = "";

        public ClientManager(Socket clientSocket) {
            this.handler = clientSocket;
        }

        public void doClient() {
            bool end = false;
            string path;
            while (!end) {
                //Console.WriteLine("client connesso");
                data = "";

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

                switch (msgSplit[2]) {
                    case "0":
                        login(str, msgSplit, success, handler);
                        break;
                    case "1":
                        path = "../../../Utenti/Completato/" + msgSplit[0] + ".TXT";
                        ricerca(str, msgSplit, handler, path);
                        break;
                    case "2":
                        path = "../../../Utenti/In corso/" + msgSplit[0] + ".TXT";
                        ricerca(str, msgSplit, handler, path);
                        break;
                    case "3":
                        path = "../../../Utenti/In programma/" + msgSplit[0] + ".TXT";
                        ricerca(str, msgSplit, handler, path);
                        break;
                    case "4":
                        //ricerca utente
                        break;
                    case "5":
                        end = true;
                        break;
                }
            }
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
        public void login(string[] str, string[] msgSplit, bool success, Socket handler) {
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
        }

        public void ricerca(string[] str, string[] msgSplit, Socket handler, string path) {
            byte[] msg;

            foreach (string line in File.ReadLines(path)) {
                msg = Encoding.ASCII.GetBytes(line);

                handler.Send(msg);
            }
            msg = Encoding.ASCII.GetBytes("<EOF>");

            handler.Send(msg);

            //handler.Shutdown(SocketShutdown.Both);
            //handler.Close();
        }
    }
}
