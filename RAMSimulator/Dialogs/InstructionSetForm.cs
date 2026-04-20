using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FEI.SimStudio.Components;
using FEI.RandomAccessMachine.Simulation;

namespace FEI.RandomAccessMachine.Dialogs {
	public partial class InstructionSetForm : Form
    {
        private List<InstructionType> allowedInstructions = new List<InstructionType>();
        public List<InstructionType> AllowedInstructions
        {
            get { return allowedInstructions; }
            set { allowedInstructions = value; }
        }

        public InstructionSetForm()
        {
            InitializeComponent();
        }

        private void BindInstructions()
        {
            instructionsCheckedListBox.Items.Add(new ObjectItem("Accept", InstructionType.Accept));
            instructionsCheckedListBox.Items.Add(new ObjectItem("Add", InstructionType.Add));
            //instructionsCheckedListBox.Items.Add(new ObjectItem("BlockBegin", InstructionType.BlockBegin));
            //instructionsCheckedListBox.Items.Add(new ObjectItem("BlockEnd", InstructionType.BlockEnd));
            instructionsCheckedListBox.Items.Add(new ObjectItem("Div", InstructionType.Div));
            instructionsCheckedListBox.Items.Add(new ObjectItem("Do", InstructionType.Do));
            //instructionsCheckedListBox.Items.Add(new ObjectItem("DoWhileBlockBegin", InstructionType.DoWhileBlockBegin));
            //instructionsCheckedListBox.Items.Add(new ObjectItem("DoWhileBlockEnd", InstructionType.DoWhileBlockEnd));
            instructionsCheckedListBox.Items.Add(new ObjectItem("Halt", InstructionType.Halt));
            instructionsCheckedListBox.Items.Add(new ObjectItem("ChangeIR", InstructionType.ChangeIR));
            instructionsCheckedListBox.Items.Add(new ObjectItem("If", InstructionType.If));            
            instructionsCheckedListBox.Items.Add(new ObjectItem("JGZero", InstructionType.JGZero));
            instructionsCheckedListBox.Items.Add(new ObjectItem("Jump", InstructionType.Jump));
            instructionsCheckedListBox.Items.Add(new ObjectItem("JZero", InstructionType.JZero));
            instructionsCheckedListBox.Items.Add(new ObjectItem("Load", InstructionType.Load));
            instructionsCheckedListBox.Items.Add(new ObjectItem("Mult", InstructionType.Mult));
            instructionsCheckedListBox.Items.Add(new ObjectItem("Nop", InstructionType.Nop));
            instructionsCheckedListBox.Items.Add(new ObjectItem("Pop", InstructionType.Pop));
            instructionsCheckedListBox.Items.Add(new ObjectItem("Print", InstructionType.Print));
            instructionsCheckedListBox.Items.Add(new ObjectItem("Push", InstructionType.Push));
            instructionsCheckedListBox.Items.Add(new ObjectItem("Read", InstructionType.Read));
            instructionsCheckedListBox.Items.Add(new ObjectItem("Reject", InstructionType.Reject));
            instructionsCheckedListBox.Items.Add(new ObjectItem("Store", InstructionType.Store));
            instructionsCheckedListBox.Items.Add(new ObjectItem("Subs", InstructionType.Subs));
            instructionsCheckedListBox.Items.Add(new ObjectItem("While", InstructionType.While));
            //instructionsCheckedListBox.Items.Add(new ObjectItem("WhileBlockBegin", InstructionType.WhileBlockBegin));
            //instructionsCheckedListBox.Items.Add(new ObjectItem("WhileBlockEnd", InstructionType.WhileBlockEnd));
            instructionsCheckedListBox.Items.Add(new ObjectItem("Write", InstructionType.Write));

            for (int i = 0; i < instructionsCheckedListBox.Items.Count; i++)
            {
                var type = (InstructionType)((ObjectItem)instructionsCheckedListBox.Items[i]).Value;
                instructionsCheckedListBox.SetItemChecked(i, allowedInstructions.Contains(type));
            }
        }

        private void InstructionSetForm_Load(object sender, EventArgs e)
        {
            BindInstructions();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            allowedInstructions.Clear();
            for (int i = 0; i < instructionsCheckedListBox.Items.Count; i++)
            {
                if (instructionsCheckedListBox.GetItemChecked(i))
                {
                    var type = (InstructionType)((ObjectItem)instructionsCheckedListBox.Items[i]).Value;
                    allowedInstructions.Add(type);
                }
            }
        }

        private void allowAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < instructionsCheckedListBox.Items.Count; i++)
            {
                instructionsCheckedListBox.SetItemChecked(i, true);
            }
        }
    }
}
