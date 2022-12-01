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
        TcpListenerEx tcpListener = new TcpListenerEx(IPAddress.Any, 1234);

        string[] tmp;
        Socket socket;
        byte[] bytes;
        byte[] bytes2;
        static string data;

        byte[] msg;
        int bytesSent;
        int bytesRec;

        string[] str = new string[3];

        bool[] stato = new bool[3];
        string activeUser { get; set;}
        string activeNick { get; set; }

        public Backlog() {
            InitializeComponent();
            textBox2.PasswordChar = '*';

            Titolo.Text = "";
            genere.Text = "";
            sviluppatore.Text = "";
            voto.Text = "";
            descrizione.Text = "";

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

                a.pic("../../IMG/propic/propic.png", tcpListener);
            }

            if (success) {
                label1.Text = activeNick;
                label2.Text = "@" + activeUser;
                panel1.Visible = true;
                if(File.Exists("../../IMG/propic/propic.png")) {
                    pictureBox1.Image = Image.FromFile("../../IMG/propic/propic.png");
                }
            }
            else {
                MessageBox.Show("Nome utente o password errati, immetterli nuovamente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void pic(string path) {
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

            //reader.Close();
            //tcpClient.Close();
        }

        private void bottone0_Click(object sender, EventArgs e) {
            buttons(ref stato, ref bottone0, 0);

            a.ricerca("1", listBox1, ref tmp, msg, bytes, bytesRec, bytesSent, activeUser, activeNick, socket);

            //string[] str = data.Split('\n');
        }

        private void bottone1_Click(object sender, EventArgs e) {
            buttons(ref stato, ref bottone1, 1);

            a.ricerca("2", listBox1, ref tmp, msg, bytes, bytesRec, bytesSent, activeUser, activeNick, socket);

        }

        private void bottone2_Click(object sender, EventArgs e) {
            buttons(ref stato, ref bottone2, 2);

            a.ricerca("3", listBox1, ref tmp, msg, bytes, bytesRec, bytesSent, activeUser, activeNick, socket);

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

            if(data != ".") {
                tmp = data.Split('\n');

                for (int i = 0; i < tmp.Length; i++) {
                    listBox1.Items.Add(tmp[i].Split(';')[0]);
                }
            }
            else {
                MessageBox.Show("Nessun gioco all'interno della categoria selezionata");
            }
        }

        private void Backlog_FormClosing(object sender, FormClosingEventArgs e) {
            msg = Encoding.ASCII.GetBytes(" ; ;end.");

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
                string temp = listBox1.SelectedItem.ToString();

                msg = Encoding.ASCII.GetBytes("1234" + ';' + temp + ';' + "5.");
                bytesSent = socket.Send(msg);

                string path = "../../IMG/games/" + listBox1.SelectedItem.ToString() + ".png";

                a.pic(path, tcpListener);
                if (File.Exists(path)) {
                    pictureBox2.Image = Image.FromFile(path);
                }
                string[] game = tmp[listBox1.SelectedIndex].Split(';');

                Titolo.Text = game[0];
                genere.Text = game[2];
                sviluppatore.Text = game[3];
                voto.Text = game[4];
                descrizione.Text = game[1];
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void pictureBox2_Click(object sender, EventArgs e) {

        }
    }
}


//invece di immagini singole provare a usare una imagelist

//quando si clicca sull'icona si apre una nuova schermata (copia da stash)

//bio in markdown/html
//https://stackoverflow.com/questions/30928/a-wysiwyg-markdown-control-for-windows-forms
