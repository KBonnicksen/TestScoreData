using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestScoreData
{
    public partial class FrmScoreCalculator : Form
    {
        List<int> scores = new List<int>();

        public FrmScoreCalculator()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if(Int32.TryParse(txtScore.Text, out int currScore) 
                && currScore >= 0
                && currScore <= 100)
            {
                scores.Add(currScore);
                UpdateScoreTotal();
                UpdateScoreCount();
                UpdateAverage();
            }
            else{
                MessageBox.Show("Enter a valid score from 0 - 100.");
            }
            txtScore.Clear();
            txtScore.Focus();
        }

        private void UpdateAverage()
        {
            txtAverage.Text = (scores.Sum() / scores.Count).ToString();
        }

        private void UpdateScoreCount()
        {
            txtScoreCount.Text = scores.Count.ToString();
        }

        private void UpdateScoreTotal()
        {
            txtScoreTotal.Text = scores.Sum().ToString();
        }

        private void BtnDisplayScores_Click(object sender, EventArgs e)
        {
            string toDisplay = string.Join(Environment.NewLine, scores);
            MessageBox.Show(toDisplay, "Sorted Scores");
        }

        private void BtnClearScores_Click(object sender, EventArgs e)
        {
            scores.Clear();
            txtScoreTotal.Clear();
            txtScoreCount.Clear();
            txtAverage.Clear();
        }
    }
}
