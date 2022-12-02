using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Client {
    public class a {
        public static void ricerca(string n, ListBox l, ref string[] tmp, byte[] msg, byte[] bytes, int bytesRec, int bytesSent, string activeUser, string activeNick, Socket socket) {
            l.Items.Clear();

            msg = Encoding.ASCII.GetBytes(activeUser + ';' + activeNick + ';' + n + ".");

            bytesSent = socket.Send(msg);

            bytesRec = socket.Receive(bytes);

            string data = Encoding.ASCII.GetString(bytes, 0, bytesRec);

            if (data != ".") {
                tmp = data.Split('\n');

                for (int i = 0; i < tmp.Length; i++) {
                    l.Items.Add(tmp[i].Split(';')[0]);
                }
            }
            else {
                MessageBox.Show("Nessun gioco all'interno della categoria selezionata");
            }
        }

        public static void pic(string path, TcpListenerEx tcpListener2, int n) {

            TcpListenerEx tcpListener = new TcpListenerEx(IPAddress.Any, n);
            tcpListener.Start();

            TcpClient tcpClient = tcpListener.AcceptTcpClient();

            StreamReader reader = new StreamReader(tcpClient.GetStream());

            string cmdFileSize = reader.ReadLine();

            string cmdFileName = reader.ReadLine();

            int length = Convert.ToInt32(cmdFileSize);
            byte[] buffer = new byte[length];
            int received = 0;
            int read = 0;
            int size = 1024;
            int remaining = 0;

            while (received < length) {
                remaining = length - received;
                if (remaining < size) {
                    size = remaining;
                }

                read = tcpClient.GetStream().Read(buffer, received, size);
                received += read;
            }

            using (FileStream fStream = new FileStream(path, FileMode.Create)) {
                fStream.Write(buffer, 0, buffer.Length);
                fStream.Flush();
                fStream.Close();
            }

            reader.Close();
            tcpClient.Close();
            tcpClient = null;
            tcpListener.Stop();
            tcpListener = null;

        }
    }

    public class TcpListenerEx : TcpListener {
        public TcpListenerEx(IPEndPoint localEP) : base(localEP) { }

        public TcpListenerEx(IPAddress localaddr, int port) : base(localaddr, port) { }

        public new bool Active {
            get { return base.Active; }
        }
    }
}
