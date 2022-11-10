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
        public Backlog() {
            InitializeComponent();
        }

        private void Backlog_Load(object sender, EventArgs e) {
            
        }
    }
}




//invece di immagini singole provare a usare una imagelist

//quando si clicca sull'icona si apre una nuova schermata (copia da stash)

//bio in markdown/html
//https://stackoverflow.com/questions/30928/a-wysiwyg-markdown-control-for-windows-forms

//le immagini e i dati dei giochi vengono scaricate e salvate in locale in una cache che a chiusura del programma viene cancellata totalmente
