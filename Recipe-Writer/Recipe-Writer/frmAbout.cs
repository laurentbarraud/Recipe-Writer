/// <file>frmAbout.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1</version>
/// <date>March 14th 2025</date>


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
            lblInfosLicence.Text = "Ce logiciel utilise pour la gestion des données le package nuGet SQLite." +
                "\r\n\r\nIl a été développé dans le cadre d'un projet de remplacement de travail de fin d'apprentissage." +
                "\r\nCe logiciel vous est accordé sous licence GNU." +
                "\r\n\r\nMerci de citer l'auteur pour toute amélioration ou utilisation du code.\n" +
                "\r\n\r\n\r\nVersion 1.1 - Mars 2025\nCréé par Laurent Barraud";
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
