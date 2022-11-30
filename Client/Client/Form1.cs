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

    public partial class Backlog : Form {
        Socket socket;
        byte[] bytes;
        byte[] bytes2;
        public static string data;

        byte[] msg;
        int bytesSent;
        int bytesRec;

        string[] str = new string[3];

        public bool[] stato = new bool[3];
        public string activeUser { get; set;}
        public string activeNick { get; set; }

        public Backlog() {
            InitializeComponent();
            textBox2.PasswordChar = '*';

            startclient(this);
        }
        public static void startclient(Backlog B) {
            B.bytes = new byte[100000];
            B.bytes2 = new byte[100000];
            try {
                IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 5000);

                B.socket = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                try {
                    B.socket.Connect(remoteEP);
                    B.socket.RemoteEndPoint.ToString();
                }
                catch (ArgumentNullException ane) {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se) {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e) {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }
                //break;
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        private void Login_Click(object sender, EventArgs e) {
            bool success = false;

            if (textBox1.Text != null && textBox2.Text != null) {
                msg = Encoding.ASCII.GetBytes(textBox1.Text + ';' + textBox2.Text + ';' + "0" + ".");
                bytesSent = socket.Send(msg);

                bytesRec = socket.Receive(bytes);

                data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                str = data.ToString().Split(';');

                if (str[0] == "True") {
                    activeUser = textBox1.Text;
                    activeNick = str[1];
                    success = true;
                }

                TcpListener tcpListener = new TcpListener(IPAddress.Any, 1234);
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

                using (FileStream fStream = new FileStream(Path.GetFileName(cmdFileName), FileMode.Create)) {
                    fStream.Write(buffer, 0, buffer.Length);
                    fStream.Flush();
                    fStream.Close();
                }
            }

            if (success) {
                label1.Text = activeNick;
                label2.Text = "@" + activeUser;
                panel1.Visible = true;
                pictureBox1.Image = Image.FromFile("./propic.png");
            }
            else {
                MessageBox.Show("Nome utente o password errati, immetterli nuovamente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void bottone0_Click(object sender, EventArgs e) {
            buttons(ref stato, ref bottone0, 0);

            ricerca("1");

            //string[] str = data.Split('\n');
        }

        private void bottone1_Click(object sender, EventArgs e) {
            buttons(ref stato, ref bottone1, 1);

            ricerca("2");
        }

        private void bottone2_Click(object sender, EventArgs e) {
            buttons(ref stato, ref bottone2, 2);

            ricerca("3");
        }

        private void bottone3_Click(object sender, EventArgs e) {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void rjButtons1_Click(object sender, EventArgs e) {
            //prendere dal server la lista di giochi attualmente presenti nell'archivio
            //mandare il gioco scelto al server
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }

        private void Backlog_Load(object sender, EventArgs e) {
            CheckForIllegalCrossThreadCalls = false;

            for (int i = 0; i < stato.Length; i++) {
                stato[i] = false;
            }
        }

        private void buttons(ref bool[] stato, ref RJButtons button, int id) {
            if (!stato[id]) {
                button.BackColor = Color.MediumSlateBlue;
                stato[id] = true;
                //vedere di usare altro al posto di uno switch che fa schifo
                switch (id) {
                    case 0:
                        bottone1.BackColor = Color.Black;
                        bottone2.BackColor = Color.Black;
                        break;
                    case 1:
                        bottone0.BackColor = Color.Black;
                        bottone2.BackColor = Color.Black;
                        break;
                    case 2:
                        bottone0.BackColor = Color.Black;
                        bottone1.BackColor = Color.Black;
                        break;
                }
                for (int i = 0; i < 3; i++) {
                    if (i != id) {
                        stato[i] = false;
                    }
                }
            }
        }

        private void ricerca(string n) {
            listBox1.Items.Clear();

            msg = Encoding.ASCII.GetBytes(activeUser + ';' + activeNick + ';' + n + ".");

            bytesSent = socket.Send(msg);

            bytesRec = socket.Receive(bytes);

            data = Encoding.ASCII.GetString(bytes, 0, bytesRec);

            Console.WriteLine(data);

            string[] tmp = data.Split('\n');
            
            for (int i = 0; i < tmp.Length; i++) {
                listBox1.Items.Add(tmp[i].Split(';')[0]);
            }
        }

        private void Backlog_FormClosing(object sender, FormClosingEventArgs e) {
            msg = Encoding.ASCII.GetBytes(" ; ;6.");

            try {
                bytesSent = socket.Send(msg);
            }
            catch (Exception exc) {
                Console.Write(exc.ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void listBox1_Click(object sender, EventArgs e) {
            
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (listBox1.SelectedItem != null) {
                string tmp = listBox1.SelectedItem.ToString();

                msg = Encoding.ASCII.GetBytes(activeUser + ';' + tmp + ';' + "5.");

                bytesSent = socket.Send(msg);

                //ricezione immagine del gioco selezionato, gli altri dati sono già nella stringa spezzata dopo averla ricevuta
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }
    }
}


//invece di immagini singole provare a usare una imagelist

//quando si clicca sull'icona si apre una nuova schermata (copia da stash)

//bio in markdown/html
//https://stackoverflow.com/questions/30928/a-wysiwyg-markdown-control-for-windows-forms
