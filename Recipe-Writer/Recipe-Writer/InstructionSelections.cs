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
        private int instructionRank;
        private Label instructionLabel;

        public int InstructionRank 
        {
            get { return instructionRank; }
            set { instructionRank = value; } 
        }
        public Label InstructionLabel 
        {
            get { return instructionLabel; }
            set { instructionLabel = value; } 
        }
    }

}

