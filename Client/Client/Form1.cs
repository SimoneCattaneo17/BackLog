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

        public bool[] stato = new bool[3];
        public string activeUser { get; set;}
        public string activeNick { get; set; }

        public Backlog() {
            InitializeComponent();
            textBox2.PasswordChar = '*';

            startclient(this);
        }

        //non so se ha senso
        public static void startclient(Backlog B) {
            B.bytes = new byte[1024];

            try {
                IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 5000);

                B.socket = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                try {
                    B.socket.Connect(remoteEP);
                    Console.WriteLine("Socket connected to {0}",
                        B.socket.RemoteEndPoint.ToString());
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
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        private void Backlog_Load(object sender, EventArgs e) {
            for(int i = 0; i < stato.Length; i++) {
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
                for(int i = 0; i < 3; i++) {
                    if(i != id) {
                        stato[i] = false;
                    }
                }
            }
        }

        private void Login_Click(object sender, EventArgs e) {
            bool success = false;
            string[] str = new string[3];

            //verifica da far fare al server
            foreach (string line in File.ReadLines("../../Login.TXT")) {
                //[0] = username, [1] = nickname, [2] = password
                str = line.Split(',');
                if (str[0] == textBox1.Text && str[2] == textBox2.Text) {
                    activeUser = str[0];
                    activeNick = str[1];
                    success = true;
                    break;
                }
            }

            if (success) {
                label1.Text = activeNick;
                label2.Text = "@" + activeUser;
                panel1.Visible = true;
            }
            else {
                MessageBox.Show("Nome utente o password errati, immetterli nuovamente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void bottone0_Click(object sender, EventArgs e) {
            buttons(ref stato, ref bottone0, 0);
            //caricamento delle copertine
        }

        private void bottone1_Click(object sender, EventArgs e) {
            buttons(ref stato, ref bottone1, 1);
            //caricamento delle copertine
        }

        private void bottone2_Click(object sender, EventArgs e) {
            buttons(ref stato, ref bottone2, 2);
            //caricamento delle copertine
        }

        private void bottone3_Click(object sender, EventArgs e) {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void rjButtons1_Click(object sender, EventArgs e) {
            //prendere dal server la lista di giochi attualmente presenti nell'archivio
            //mandare il gioco scelto al server
        }
    }
}


//aggiungere controlli OVUNQUE per vedere se nella casella di testo c'è scritta roba o no

//invece di immagini singole provare a usare una imagelist

//quando si clicca sull'icona si apre una nuova schermata (copia da stash)

//bio in markdown/html
//https://stackoverflow.com/questions/30928/a-wysiwyg-markdown-control-for-windows-forms

//le immagini e i dati dei giochi vengono scaricate e salvate in locale in una cache che a chiusura del programma viene cancellata totalmente
