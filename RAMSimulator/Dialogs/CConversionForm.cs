using DusanRodina.RandomAccessMachine.Conversion;
using DusanRodina.SimStudio.Components;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DusanRodina.RandomAccessMachine.Dialogs {
	public partial class CConversionForm : Form
    {
        public string resCode = "";
        public bool OKPressed = false;

        public CConversionForm()
        {
            InitializeComponent();
        }


        private void frmCConversion_Load(object sender, EventArgs e)
        {
            //Formátovanie inštrukcií
            txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("int", Color.Blue, true));
            txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("if", Color.Blue, true));
            txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("else", Color.Blue, true));
            txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("while", Color.Blue, true));
            txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("for", Color.Blue, true));
            txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("print", Color.Blue, true));
            txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("switch", Color.Blue, true));            

            //Ďalšie formátovanie
            txtCode.SyntaxWords.fStrings = new SyntaxTextBox.SyntaxFormat(Color.DarkRed, true);
            txtCode.SyntaxWords.fNumbers = new SyntaxTextBox.SyntaxFormat(Color.DarkBlue, true);
            txtCode.SyntaxWords.fComment = new SyntaxTextBox.SyntaxFormat(Color.DarkGreen);
        }
 

        private void bOK_Click(object sender, EventArgs e)
        {
            IntermediateCode ic = C_ConvertToICode(txtCode.Text);
            Convertor convertor = new Convertor();            

            string code = convertor.ConvertToRAMCode(ic);
            resCode = code;            
            OKPressed = true;
            this.Close();
        }        

        private IntermediateCode C_ConvertToICode(string code)
        {            
            IntermediateCode ic = new IntermediateCode();
            CConvertor convertor = new CConvertor();

            ic.maincode = convertor.ConvertBlock(ic, "main", code);
            return ic;
        }        

    }      

}