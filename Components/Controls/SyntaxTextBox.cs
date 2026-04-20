using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FEI.SimStudio.Components.Registers;

namespace FEI.SimStudio.Components.Controls {
	public partial class SyntaxTextBox : UserControl
    {                
        public SyntaxTextBox(): base()
        {            
            InitializeComponent();
            
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            this.UpdateStyles();

            txtbox.Bounds = new Rectangle(5, 5, this.Width - 11, this.Height - 11);
        }

        private void SyntaxTextBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //Okraje
            Functions.FillRoundRectangle(g, Brushes.White, rect, 5);
            if (this.Focused || this.txtbox.Focused)
            {
                Functions.DrawRoundRectangle(g, new Pen(Color.FromArgb(160, Color.Green), 2), Rectangle.Inflate(rect, -1, -1), 5);
            }
            Functions.DrawRoundRectangle(g, Pens.Black, rect, 5);
        }

        //RichTextBox s možnosťou vypnutia vykresľovania pri úprave formátovania
        //pomocou vlastnosti Paint
        public class RTBox : RichTextBox
        {            

            public RTBox(): base()
            {                
                InitializeComponent();                
            }

            //UserControl overrides dispose to clean up the component list.
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if ((components != null))
                    {
                        components.Dispose();
                    }
                }
                base.Dispose(disposing);
            }

            //Required by the Windows Form Designer
            private System.ComponentModel.IContainer components=null;

            [System.Diagnostics.DebuggerStepThrough()]
            private void InitializeComponent()
            {
                //
                //MyRichTextBox
                //
                this.Name = "MyRichTextBox";
                this.Size = new System.Drawing.Size(176, 40);

            }

            private const short WM_PAINT = 15;
            private const int WM_SETREDRAW = 11;
            private const int WM_USER = 1024;
            private const int EM_GETEVENTMASK = (WM_USER + 59);
            private const int EM_SETEVENTMASK = (WM_USER + 69);

            [DllImport("user32", CharSet = CharSet.Auto)]
            private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);

            public bool _Paint = true;
            private int Updating;
            private IntPtr oldEventMask;

            protected override void WndProc(ref System.Windows.Forms.Message m)
            {
                if (m.Msg == WM_PAINT)
                {
                    if (_Paint)
                        base.WndProc(ref m);
                    else
                        m.Result = IntPtr.Zero;
                }
                else
                {
                    base.WndProc(ref m);
                }
            }

            public void BeginUpdate()
            {
                Updating += 1;

                if ((Updating > 1)) return; 

                oldEventMask = SendMessage(this.Handle, EM_SETEVENTMASK, 0, IntPtr.Zero);
                SendMessage(this.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
            }

            public void EndUpdate()
            {
                Updating -= 1;

                if (Updating > 0)
                    return; 


                SendMessage(this.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
                SendMessage(this.Handle, EM_SETEVENTMASK, 0, oldEventMask);
            }

        }

        #region Zvýrazňovanie syntaxy
            #region Triedy na zvýrazňovanie syntaxy
                private struct WordData
                {
                    public string Word;
                    public int Start;
                    public int Length;
                    public WordData(string Word, int Start, int Length)
                    {
                        this.Word = Word;
                        this.Start = Start;
                        this.Length = Length;
                    }
                }

                private class WordBuffer : CollectionBase
                {

                    public WordData this[int index]
                    {
                        get { return (WordData)List[index]; }
                        set { List[index] = value; }
                    }

                    public void Add(WordData word)
                    {
                        List.Add(word);                
                    }
                }

                public struct SyntaxFormat
                {
                    public Color Color;
                    public FontStyle FntStyle;
                    public SyntaxFormat(Color Color, bool Bold, bool Italic, bool Underline)
                    {
                        this.Color = Color;

                        this.FntStyle = FontStyle.Regular;
                        if (Bold)
                            this.FntStyle = this.FntStyle | FontStyle.Bold;
                        if (Italic)
                            this.FntStyle = this.FntStyle | FontStyle.Italic;
                        if (Underline)
                            this.FntStyle = this.FntStyle | FontStyle.Underline;
                    }
                    public SyntaxFormat(Color Color, bool Bold)
                    {
                        this.Color = Color;

                        this.FntStyle = FontStyle.Regular;
                        if (Bold)
                            this.FntStyle = this.FntStyle | FontStyle.Bold;                        
                    }
                    public SyntaxFormat(Color Color)
                    {
                        this.Color = Color;
                        this.FntStyle = FontStyle.Regular;
                    }
                }

                //Typ syntaxe
                public enum SyntaxType
                {
                    WholeWord = 0, //Celé slovo
                    WordStartsWith = 1, //Slovo začínajúce s
                    WordEndsWith = 2  //Slovo končiace na
                }

                //Slovo syntaxe
                public struct SyntaxWord
                {
                    public string Word;
                    public SyntaxFormat Format;
                    public SyntaxType Type;

                    public SyntaxWord(string Word, Color Color, bool Bold, bool Italic, bool Underline)
                    {
                        this.Word = Word.Trim().ToLower();
                        this.Format = new SyntaxFormat(Color, Bold, Italic, Underline);
                        this.Type = SyntaxType.WholeWord;
                    }
                    public SyntaxWord(string Word, Color Color, bool Bold)
                    {
                        this.Word = Word.Trim().ToLower();
                        this.Format = new SyntaxFormat(Color, Bold, false, false);
                        this.Type = SyntaxType.WholeWord;
                    }
                    public SyntaxWord(string Word, Color Color)
                    {
                        this.Word = Word.Trim().ToLower();
                        this.Format = new SyntaxFormat(Color, false, false, false);
                        this.Type = SyntaxType.WholeWord;
                    }

                    public SyntaxWord(string Word, SyntaxType Type, Color Color, bool Bold, bool Italic, bool Underline)
                    {
                        this.Word = Word.Trim().ToLower();
                        this.Format = new SyntaxFormat(Color, Bold, Italic, Underline);
                        this.Type = Type;
                    }
                    public SyntaxWord(string Word, SyntaxType Type, Color Color, bool Bold)
                    {
                        this.Word = Word.Trim().ToLower();
                        this.Format = new SyntaxFormat(Color, Bold, false, false);
                        this.Type = Type;
                    }
                    public SyntaxWord(string Word, SyntaxType Type, Color Color)
                    {
                        this.Word = Word.Trim().ToLower();
                        this.Format = new SyntaxFormat(Color, false, false, false);
                        this.Type = Type;
                    }
                }

                public class SyntaxWordList : CollectionBase
                {
                    public SyntaxFormat fComment;
                    public SyntaxFormat fNumbers;
                    public SyntaxFormat fStrings;                    

                    public void Add(SyntaxWord Word)
                    {
                        this.List.Add(Word);
                    }
                    public SyntaxWord this  [int index]
                    {
                        get { return (SyntaxWord)List[index]; }
                        set { List[index] = value; }
                    }
                    public SyntaxFormat GetSyntaxFormat(string Word)
                    {                
                        //Číslo                      
                        int tmp;
                        if (int.TryParse(Word,out tmp))
                        {
                            return fNumbers;
                        }                        

                        //String
                        if (Word.StartsWith("\"") && Word.EndsWith("\""))
                        {
                            return fStrings;
                        }

                        //Výraz v slovníku príkazov
                        else
                        {
                            Word = Word.Trim().ToLower();
                            for (int a = 0; a <= List.Count - 1; a++)
                            {
                                if (this[a].Type== SyntaxType.WholeWord && this[a].Word == Word)
                                {
                                    return this[a].Format;
                                }
                                else if (this[a].Type == SyntaxType.WordStartsWith && Word.StartsWith(this[a].Word))
                                {
                                    return this[a].Format;
                                }
                                else if (this[a].Type == SyntaxType.WordStartsWith && Word.EndsWith(this[a].Word))
                                {
                                    return this[a].Format;
                                }
                            }
                        }

                        return new SyntaxFormat();
                    }                    
                }

                public SyntaxWordList SyntaxWords = new SyntaxWordList();
            #endregion

            //Regexové pravidlo parsovania textu
            public string RegexParsePattern = "\\w+|[^A-Za-z0-9_ \\f\\t\\v]";

            private WordBuffer ParseLine(string s)
            {
                WordBuffer buffer = new WordBuffer();
                int count = 0;

                Regex r = new Regex(RegexParsePattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                Match m;

                m = r.Match(s);
                do
                {
                    if (!Functions.IsEmpty(m.Value))
                    {
                        buffer.Add(new WordData(m.Value, m.Index, m.Length));

                        count += 1;
                    }

                    m = m.NextMatch();
                }
                while (m.Success);
                return buffer;
            }

            private void HighlightSyntax(bool All)
            {
                txtbox._Paint = false;
                txtbox.BeginUpdate();

                int CurSelStart = txtbox.SelectionStart;
                int CurSelLength = txtbox.SelectionLength;

                int pos;
                int pos2;
                int posE;

                string Text = txtbox.Text;

                if (!All)
                {
                    //Nájde začiatok riadku
                    pos = CurSelStart;
                    while (pos > 0 && Text[pos - 1] != '\n')
                    {
                        pos -= 1;
                    }

                    //Nájde koniec riadku
                    pos2 = CurSelStart;
                    if (pos2 > 0)
                    {
                        while (pos2 < Text.Length && Text[pos2] != '\n')
                        {
                            pos2 += 1;
                        }
                    }
                }
                else
                {
                    pos = 0;
                    pos2 = Text.Length;
                }
                posE = pos2;

                do
                {
                    pos2 = Text.IndexOf('\n', pos);
                    if (pos2 > posE) break; 

                    if (pos2 == -1)
                        pos2 = posE;

                    //Riadok textu
                    string s = Text.Substring(pos, pos2 - pos);

                    //Komentár        
                    if (s.StartsWith("//"))
                    {
                        txtbox.Select(pos, pos2 - pos);
                        txtbox.SelectionColor = SyntaxWords.fComment.Color;
                        txtbox.SelectionFont = new Font(txtbox.SelectionFont, SyntaxWords.fComment.FntStyle);
                    }
                    else
                    {
                        //Komentár        
                        if (s.IndexOf("//") != -1)
                        {
                            int posi = s.IndexOf("//");
                            txtbox.Select(pos+posi, pos2 - (pos+posi));
                            txtbox.SelectionColor = SyntaxWords.fComment.Color;
                            txtbox.SelectionFont = new Font(txtbox.SelectionFont, SyntaxWords.fComment.FntStyle);
                            s = s.Substring(0, posi);
                        }

                        //Rozparsuje text
                        WordBuffer buf = ParseLine(s);

                        //Zvýrazní syntax
                        for (int i = 0; i <= buf.Count - 1; i++)
                        {
                            SyntaxFormat f = SyntaxWords.GetSyntaxFormat(buf[i].Word);
                            Font selFont;

                            txtbox.Select(buf[i].Start + pos, buf[i].Length);
                            txtbox.SelectionColor = f.Color;
                            selFont = txtbox.SelectionFont;
                            if (selFont == null) selFont = txtbox.Font;
                            txtbox.SelectionFont = new Font(selFont, f.FntStyle);
                        }
                    }

                    pos = pos2 + 1;
                }
                while (!(pos2 == posE));

                //Vráti kurzor na pôvodnú pozíciu
                if ((CurSelStart >= 0))
                    txtbox.Select(CurSelStart, CurSelLength);

                txtbox.EndUpdate();
                txtbox._Paint = true;
            }

            public new event TextChangedEventHandler TextChanged;
            public delegate void TextChangedEventHandler(object sender, System.EventArgs e);
            private void txtbox_TextChanged(object sender, System.EventArgs e)
            {
                HighlightSyntax(false);                
                
                if (TextChanged != null) TextChanged(this, e);                
            }
        #endregion

        public new string Text
        {
            get 
            {                
                return txtbox.Text; 
            }
            set
            {
                txtbox.Text = value;
                HighlightSyntax(true);
            }
        }

        public int SelectionStart
        {
            get { return txtbox.SelectionStart; }
            set
            {
                txtbox.SelectionStart = value;                
            }
        }

        public int SelectionLength
        {
            get { return txtbox.SelectionLength; }
            set
            {
                txtbox.SelectionLength = value;
            }
        }

        public string SelectedText
        {
            get { return txtbox.SelectedText; }
            set
            {
                txtbox.SelectedText = value;
            }
        }

        public bool HideSelection
        {
            get { return txtbox.HideSelection; }
            set
            {                
                txtbox.HideSelection = value;
            }
        }

        private void QRichTextBox_GotFocus(object sender, System.EventArgs e)
        {
            this.Invalidate();
            this.Update();
        }

        private void QRichTextBox_LostFocus(object sender, System.EventArgs e)
        {
            this.Invalidate();
            this.Update();
        }

        private void txtbox_LostFocus(object sender, System.EventArgs e)
        {
            this.Invalidate();
            this.Update();
        }

        private void txtbox_GotFocus(object sender, System.EventArgs e)
        {
            this.Invalidate();
            this.Update();
        }

        public void SelectAll()
        {
            txtbox.SelectAll();
        }

        public void Cut()
        {
            txtbox.Cut();
        }

        public void Copy()
        {
            txtbox.Copy();
        }

        public void Paste()
        {
            txtbox.Paste();
        }

        public void Delete()
        {
            txtbox.Text = "";
        }

        public void UpdateHighlight()
        {
            HighlightSyntax(true);
        }

        public void SelectLine(int line)
        {
            int l = 0;
            int i = 0, i2 = 0;

            while (l != line)
            {
                i = txtbox.Text.IndexOf('\n', i + 1);
                l++;
            }
            i2 = txtbox.Text.IndexOf('\n', i+1);
            if (i2 == -1) i2 = txtbox.Text.Length;

            txtbox.Select(i + 1, i2 - 1 - i);

        }
    }

}
