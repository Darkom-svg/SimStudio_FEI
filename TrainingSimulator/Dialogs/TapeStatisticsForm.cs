using DusanRodina.TuringCore.Simulation;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DusanRodina.FiniteAutomaton.Dialogs {
	public partial class TapeStatisticsForm : Form
    {
        public VirtualTuringMachine tm;
        public int tapeIndex = 0;  //Index pásky v komboboxe
        private List<InfiniteTape> tapes;

        public TapeStatisticsForm()
        {
            InitializeComponent();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTapeStatistics_Load(object sender, EventArgs e)
        {
            cmbTape.SelectedIndex = tapeIndex;                        
        }

        private void cmbTape_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTape.SelectedIndex == 0)
            {
                tapes = tm.OriginalTapes;
            }
            else
            {
                tapes = tm.ActiveTapes;
            }

            UpdateStatistics();
        }

        private void UpdateStatistics()
        {
            int sum = 0;
            Dictionary<string, int> symbolCounts = new Dictionary<string, int>();
            foreach (InfiniteTape tape in tapes)
            {
                Dictionary<string,int> counts = tape.GetSymbolCounts();
                foreach (KeyValuePair<string,int> c in counts)
                {
                    if (symbolCounts.ContainsKey(c.Key))
                    {
                        symbolCounts[c.Key] += c.Value;
                    }
                    else 
                    {
                        symbolCounts.Add(c.Key, c.Value);
                    }
                }

                sum += tape.GetNonBlankCellsCount();
            }
            this.lblCells.Text = sum.ToString();
            

            statisticsListBox.Items.Clear();
            Dictionary<string, int>.Enumerator en = symbolCounts.GetEnumerator();
            while (en.MoveNext())
            {
                statisticsListBox.Items.Add(en.Current.Key + ": " + en.Current.Value.ToString());
            }
        }
    }
 }