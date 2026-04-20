using System.Windows.Forms;
using FEI.SimStudio.Components.Controls;

namespace FEI.SimStudio.Components.Dialogs {
	public static class Finding
    {
        public static bool Find(SyntaxTextBox textBox, string find, bool ignoreCase, bool wholeWords, int direction)
        {
            string txt = textBox.Text;            
            int i;

            //Ignorova� ve�kos� p�smen
            if (ignoreCase)
            {
                txt = txt.ToLower();
                find = find.ToLower();
            }

            //Vyh�ad�vanie nadol
            if (direction==0)
            {
                i = textBox.SelectionStart + textBox.SelectionLength;
                //Iba cel� slov�
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
            //Vyh�ad�vanie nahor
            else
            {
                i = textBox.SelectionStart;
                //Iba cel� slov�
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
                MessageBox.Show("H�adan� v�raz '" + find + "' sa nena�iel.");
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