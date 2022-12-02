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
    public partial class Form2 : Form {
        TcpListenerEx tcpListener = new TcpListenerEx(IPAddress.Any, 5050);

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
        string activeUser { get; set; }
        string activeNick { get; set; }
        public Form2() {
            InitializeComponent();

            startclient(this);
        }

        private void Form2_Load(object sender, EventArgs e) {
            for (int i = 0; i < stato.Length; i++) {
                stato[i] = false;
            }
        }

        public static void startclient(Form2 B) {
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

        private void cerca_Click_1(object sender, EventArgs e) {
            bool success = false;

            msg = Encoding.ASCII.GetBytes(textBox1.Text + ';' + "x" + ';' + "4" + ".");
            bytesSent = socket.Send(msg);

            bytesRec = socket.Receive(bytes);

            data = Encoding.ASCII.GetString(bytes, 0, bytesRec);

            str = data.ToString().Split(';');

            if (str[0] == "True") {
                activeUser = textBox1.Text;
                activeNick = str[1];
                success = true;

                a.pic("../../IMG/propic/propic_" + activeUser + ".png", tcpListener, 5050);

                if (success) {
                    label1.Text = activeNick;
                    label2.Text = "@" + activeUser;
                    panel1.Visible = true;
                    if (File.Exists("../../IMG/propic/propic_" + activeUser + ".png")) {
                        pictureBox1.Image = Image.FromFile("../../IMG/propic/propic_" + activeUser + ".png");
                    }
                }
                else {
                    MessageBox.Show("Utente non trovato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                }

                activeUser = textBox1.Text;
                activeNick = "";
            }
        }

        private void bottone0_Click(object sender, EventArgs e) {
            buttons(ref stato, ref bottone0, 0);
            a.ricerca("1", listBox1, ref tmp, msg, bytes, bytesRec, bytesSent, activeUser, activeNick, socket);
        }

        private void bottone1_Click(object sender, EventArgs e) {
            buttons(ref stato, ref bottone1, 1);
            a.ricerca("2", listBox1, ref tmp, msg, bytes, bytesRec, bytesSent, activeUser, activeNick, socket);
        }

        private void bottone2_Click(object sender, EventArgs e) {
            buttons(ref stato, ref bottone2, 2);
            a.ricerca("3", listBox1, ref tmp, msg, bytes, bytesRec, bytesSent, activeUser, activeNick, socket);
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e) {
                if (listBox1.SelectedItem != null) {
                string temp = listBox1.SelectedItem.ToString();

                msg = Encoding.ASCII.GetBytes("5050" + ';' + temp + ';' + "5.");
                bytesSent = socket.Send(msg);

                Directory.CreateDirectory("../../IMG/games/" + activeUser + "/");

                string path = "../../IMG/games/" + activeUser + "/" + listBox1.SelectedItem.ToString() + ".png";

                a.pic(path, tcpListener, 5050);
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

        private void bottone3_Click(object sender, EventArgs e) {
            textBox1.Text = "";
            panel1.Visible = false;
        }
    }
}
