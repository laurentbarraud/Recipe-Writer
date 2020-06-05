using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recipe_Writer
{
    public class InstructionSelections
    {
        private int instructionId;
        private Label instructionLabel;

        public int InstructionId 
        {
            get { return instructionId; }
            set { instructionId = value; } 
        }
        public Label InstructionLabel 
        {
            get { return instructionLabel; }
            set { instructionLabel = value; } 
        }
    }

}

