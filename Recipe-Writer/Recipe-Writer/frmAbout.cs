using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            txtCredits.Text = "Ce logiciel utilise pour la gestion des données le package nuGet SQLite." +
                "\r\n\r\nIl a été développé dans le cadre d'un projet de remplacement de travail de fin d'apprentissage." +
                "\r\nCe logiciel vous est accordé sous licence GNU." +
                "\r\n Merci de citer l'auteur pour toute amélioration ou utilisation du code.\n" +
                "\r\n\r\n\r\nJuin 2020 - Laurent Barraud - CPNV";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
