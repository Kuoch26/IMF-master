using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FormRecomposition : Form
    {
        public FormRecomposition()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form FormDécomposition = new FormDécomposition();
            FormDécomposition.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form FormSignal = new FormSignal();
            FormSignal.Show();
            this.Hide();
        }
    }
}
