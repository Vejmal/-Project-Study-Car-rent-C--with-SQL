using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wypozyczalnia_Samochodow
{
    public partial class StronaGlowna : Form
    {
        public StronaGlowna()
        {
            InitializeComponent();
        }

        private void ONasButton_Click(object sender, EventArgs e)
        {
            ONas on1 = new ONas();
            this.Hide();
            on1.ShowDialog();
        }

        private void NaszaFlotaButton_Click(object sender, EventArgs e)
        {
            NaszaFlota nf1 = new NaszaFlota();
            this.Hide();
            nf1.ShowDialog();
        }

        private void HistoriaFirmyButton_Click(object sender, EventArgs e)
        {
            HistoriaFirmy hf1 = new HistoriaFirmy();
            this.Hide();
            hf1.ShowDialog();
        }

        private void DoradztwoButton_Click(object sender, EventArgs e)
        {
            Doradztwo d1 = new Doradztwo();
            this.Hide();
            d1.ShowDialog();
        }

        private void KontaktButton_Click(object sender, EventArgs e)
        {
            Kontakt k1 = new Kontakt();
            this.Hide();
            k1.ShowDialog();
        }
    }
}
