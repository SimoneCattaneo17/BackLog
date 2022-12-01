using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

public class Server {

    public static string data = null;

    public static void StartListening() {
        byte[] bytes = new Byte[100000];

        

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
        byte[] bytes = new Byte[100000];
        String data = "";

        public ClientManager(Socket clientSocket) {
            this.handler = clientSocket;
        }

        public void doClient() {
            bool end = false;
            string path;
            while (!end) {
                try {
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
                            ricerca(handler, path);
                            break;
                        case "2":
                            path = "../../../Utenti/In corso/" + msgSplit[0] + ".TXT";
                            ricerca(handler, path);
                            break;
                        case "3":
                            path = "../../../Utenti/In programma/" + msgSplit[0] + ".TXT";
                            ricerca(handler, path);
                            break;
                        case "4":
                            ricercaUtente();
                            break;
                        case "5":
                            pic("../../../games/" + msgSplit[1] + ".png", Convert.ToInt32(msgSplit[0]));
                            break;
                        case "end":
                            end = true;
                            break;
                    }
                }
                catch {
                    Console.WriteLine("client disconnesso");
                    end = true;
                    break;
                }
            }
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
        public void ricercaUtente() {
            foreach (string line in File.ReadLines("../../../Login.TXT")) {
                str = line.Split(',');
                if (str[0] == msgSplit[0]) {
                    success = true;
                    break;
                }
            }

            byte[] msg = Encoding.ASCII.GetBytes(Convert.ToString(success) + ';' + str[1]);

            handler.Send(msg);

            pic("../../../Utenti/propic/" + str[0] + ".png", 5050);
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

            //inizia qui
            string fileName = "../../../Utenti/propic/" + str[0] + ".png";
            pic(fileName, 1234);
        }
        private void pic(string fileName, int port) {
            TcpClient tcpClient = new TcpClient("127.0.0.1", port);
            StreamWriter sWriter = new StreamWriter(tcpClient.GetStream());
            if(File.Exists(fileName)) {
                bytes = File.ReadAllBytes(fileName);

                sWriter.WriteLine(bytes.Length.ToString());
                sWriter.Flush();

                sWriter.WriteLine("./tmp.png");
                sWriter.Flush();

                tcpClient.Client.SendFile(fileName);

                sWriter.Close();
                tcpClient.Close();
            }
        }

        public void ricerca(Socket handler, string path) {
            string a = "";
            byte[] msg;
            if (File.Exists(path)) {
                foreach (string line in File.ReadLines(path)) {
                    a += line + "\n";
                }
            }
            else {
                a = ".";
            }

            msg = Encoding.ASCII.GetBytes(a);

            handler.Send(msg);
        }
    }
}
