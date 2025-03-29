/// <file>frmNewImagePath.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1</version>
/// <date>March 28th 2025</date>

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmNewImagePath : Form
    {
        // Declares the parent form to be able to access its controls
        private frmMain _frmMain = null;

        // Constructor - Adds the parent form as parameter in the form constructor
        public frmNewImagePath(frmMain parentForm)
        {
            // Affects the parent form to an alias
            _frmMain = parentForm;
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            _frmMain.DisplayRecipeInfos(_frmMain._currentDisplayedRecipe.Id);
            this.Close();
        }

        /// <summary>
        /// Checks that the user input doesn't contain accents or special characters
        /// </summary>
        /// <param name="input">the text to check</param>
        /// <returns></returns>
        public static bool hasSpecialChar(string input)
        {
            string specialChar = @" éèàâüöä~'`^\|!#$%&/()=?»«@£§€{}.;<>_,";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            // Checks that the user input doesn't contain accents or special characters
            if (hasSpecialChar(txtNewImagePath.Text))
            {
                MessageBox.Show("Veuillez n'utiliser que les lettres de A à Z sans accents, des traits d'union, underscores ou des chiffres pour le nom du fichier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // If no special characters were used for the name of the file
            else
            {
                // Finds the picture box on the main form
                var frmMainPicBox = _frmMain.Controls.Find("picRecipe", true).FirstOrDefault() as PictureBox;

                // Puts the content of the picturebox into a bitmap
                Bitmap jpgFile = new Bitmap(frmMainPicBox.Image);

                // Asks the user if the old file must be kept or deleted
                var dialogResult = MessageBox.Show("Conserver le fichier de l'ancienne image ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.No)
                {
                    if (System.IO.File.Exists(@Environment.CurrentDirectory + "\\illustrations\\" + _frmMain._currentDisplayedRecipe.ImagePath + ".jpg"))
                    {
                        System.IO.File.Delete(@Environment.CurrentDirectory + "\\illustrations\\" + _frmMain._currentDisplayedRecipe.ImagePath + ".jpg");
                    }
                }

                // Saves the file on disk
                if (System.IO.File.Exists(@Environment.CurrentDirectory + "\\illustrations\\" + txtNewImagePath.Text + ".jpg"))
                {
                    System.IO.File.Delete(@Environment.CurrentDirectory + "\\illustrations\\" + txtNewImagePath.Text + ".jpg");
                }

                jpgFile.Save(@Environment.CurrentDirectory + "\\illustrations\\" + txtNewImagePath.Text + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                // Affects the imagepath to the property in the current recipe object
                _frmMain._currentDisplayedRecipe.ImagePath = txtNewImagePath.Text;

                // Stores the new imagepath value into the database
                _frmMain.dbConn.UpdateImagePath(_frmMain._currentDisplayedRecipe.Id, _frmMain._currentDisplayedRecipe.ImagePath);

                // Disposes of the image file
                jpgFile.Dispose();

                _frmMain.DisplayRecipeInfos(_frmMain._currentDisplayedRecipe.Id);
                this.Close();
            }   
        }

        /// <summary>
        /// Prevents the user to move the window
        /// </summary>
        private void frmNewImagePath_Move(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

    }
}
