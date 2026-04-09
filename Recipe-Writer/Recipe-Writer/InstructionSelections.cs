/// <file>InstructionSelections.cs</file>
/// <author>Laurent Barraud</author>
/// <version>1.1.4</version>
/// <date>April 9th 2026</date>

using System;
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

