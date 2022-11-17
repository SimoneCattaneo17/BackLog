using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Client {
    public partial class Form2 : Form {
        public bool[] stato = new bool[3];
        public Form2() {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e) {
            for (int i = 0; i < stato.Length; i++) {
                stato[i] = false;
            }
        }
        private void cerca_Click_1(object sender, EventArgs e) {
            //deve mandare il nome utente al server che verifica l'esistenza
            //queste righe sono solo di dimostrazione
            if (File.Exists("../../Utenti/" + textBox1.Text + ".TXT")) {
                panel1.Visible = true;
            }
            else {
                MessageBox.Show("L'utente " + textBox1.Text + " non esiste.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bottone0_Click(object sender, EventArgs e) {
            buttons(ref stato, ref bottone0, 0);
        }

        private void bottone1_Click(object sender, EventArgs e) {
            buttons(ref stato, ref bottone1, 1);
        }

        private void bottone2_Click(object sender, EventArgs e) {
            buttons(ref stato, ref bottone2, 2);
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
    }
}
