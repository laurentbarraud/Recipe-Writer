/// <file>frmNewImagePath.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.3</version>
/// <date>February 26th 2026</date>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public partial class frmNewImagePath : Form
    {
        // Maps each button to its original image file path
        private readonly Dictionary<Button, string> _buttonOriginalImagePaths = new Dictionary<Button, string>();

        // Declares the parent form to be able to access its controls
        private frmMain _frmMain = null;

        // Constructor - Adds the parent form as parameter in the form constructor
        public frmNewImagePath(frmMain parentForm)
        {
            // Affects the parent form to an alias
            _frmMain = parentForm;
            InitializeComponent();
        }

        private void frmNewImagePath_Load(object sender, EventArgs e)
        {
            // Sets the directory path for the resources folder, where all the button images are stored
            string resourcesDir = Path.Combine(Application.StartupPath, "Resources");

            // Sets the path for each button image by combining the resources directory path with the specific image filename
            string cmdCancelPath = Path.Combine(resourcesDir, "delete.png");
            string cmdValidatePath = Path.Combine(resourcesDir, "validate.png");

            // Assigns the background images to the buttons using the loaded paths
            cmdCancel.BackgroundImage = Image.FromFile(cmdCancelPath);
            cmdValidate.BackgroundImage = Image.FromFile(cmdValidatePath);

            // Fills the truth table that links each button to its original image path, 
            // for later restoration on mouse leave
            _buttonOriginalImagePaths[cmdCancel] = cmdCancelPath;
            _buttonOriginalImagePaths[cmdValidate] = cmdValidatePath;

            // Buttons hover event
            cmdCancel.MouseEnter += _frmMain.Button_MouseEnter;
            cmdCancel.MouseLeave += _frmMain.Button_MouseLeave;
            cmdValidate.MouseEnter += _frmMain.Button_MouseEnter;
            cmdValidate.MouseLeave += _frmMain.Button_MouseLeave;
        }
 
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            _frmMain.DisplayRecipeInfos(_frmMain._currentDisplayedRecipe.Id);
            this.Close();
        }

        private void cmdValidate_Click(object sender, EventArgs e)
        {
            // Checks that the user input doesn't contain accents or special characters
            if (hasSpecialChar(txtNewImagePath.Text))
            {
                MessageBox.Show(strings.ErrorMustUseOnlyLettersForTheFileName, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // If no special characters were used for the name of the file
            else
            {
                // Finds the picture box on the main form
                var frmMainPicBox = _frmMain.Controls.Find("picRecipe", true).FirstOrDefault() as PictureBox;

                // Puts the content of the picturebox into a bitmap
                Bitmap jpgFile = new Bitmap(frmMainPicBox.Image);

                // Asks the user if the old file must be kept or deleted
                var dialogResult = MessageBox.Show(strings.ConfirmKeepOldImageFile, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
    }
}
