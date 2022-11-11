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

namespace Client { 

    public partial class Backlog : Form {
        public bool[] stato = new bool[3];

        public Backlog() {
            InitializeComponent();
        }

        private void Backlog_Load(object sender, EventArgs e) {
            for(int i = 0; i < stato.Length; i++) {
                stato[i] = false;
            }
        }

        private void rjButtons2_Click(object sender, EventArgs e) {
            buttons(ref stato, ref bottone0, 0);
        }

        private void rjButtons3_Click(object sender, EventArgs e) {
            buttons(ref stato, ref bottone1, 1);
        }

        private void rjButtons4_Click(object sender, EventArgs e) {
            buttons(ref stato, ref bottone2, 2);
        }

        private void rjButtons5_Click(object sender, EventArgs e) {

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
    }
}




//invece di immagini singole provare a usare una imagelist

//quando si clicca sull'icona si apre una nuova schermata (copia da stash)

//bio in markdown/html
//https://stackoverflow.com/questions/30928/a-wysiwyg-markdown-control-for-windows-forms

//le immagini e i dati dei giochi vengono scaricate e salvate in locale in una cache che a chiusura del programma viene cancellata totalmente
