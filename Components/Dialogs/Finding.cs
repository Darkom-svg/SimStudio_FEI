using System.Windows.Forms;
namespace DusanRodina.SimStudio.Components.Dialogs {
	public static class Finding
    {
        public static bool Find(SyntaxTextBox textBox, string find, bool ignoreCase, bool wholeWords, int direction)
        {
            string txt = textBox.Text;            
            int i;

            //Ignorovaù veækosù pÌsmen
            if (ignoreCase)
            {
                txt = txt.ToLower();
                find = find.ToLower();
            }

            //Vyhæad·vanie nadol
            if (direction==0)
            {
                i = textBox.SelectionStart + textBox.SelectionLength;
                //Iba celÈ slov·
                if (wholeWords)
                {
                    i--;
                    do
                    {
                        i = txt.IndexOf(find, i + 1);
                    } while (i != -1 && !(!char.IsLetterOrDigit(txt[i - 1]) && (i == find.Length - 1 || !char.IsLetterOrDigit(txt[i + find.Length]))));
                }
                else
                {
                    i = txt.IndexOf(find, i);
                }
            }
            //Vyhæad·vanie nahor
            else
            {
                i = textBox.SelectionStart;
                //Iba celÈ slov·
                if (wholeWords)
                {
                    i++;
                    do
                    {
                        i = txt.LastIndexOf(find, i - 1);
                    } while (i != -1 && !(!char.IsLetterOrDigit(txt[i - 1]) && (i == find.Length - 1 || !char.IsLetterOrDigit(txt[i + find.Length]))));
                }
                else
                {
                    i = txt.LastIndexOf(find, i);
                }
            }

            if (i == -1)
            {
                MessageBox.Show("Hæadan˝ v˝raz '" + find + "' sa nenaöiel.");
                return false;
            }
            else
            {
                textBox.SelectionStart = i;
                textBox.SelectionLength = find.Length;
                return true;
            }
        }
    }
}