using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;

namespace WindowsFormsApp2
{
    public partial class FormSignal : Form
    {
        public float values;
        public static readonly float RANGE_MIN = -400f;
        public static readonly float RANGE_MAX = 400f;
        public FormSignal()
        {
            InitializeComponent();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form FormDécomposition = new FormDécomposition();
            FormDécomposition.Show();
            this.Hide();
        }        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            UpdateGraph(tb.Text);

        }
        private void UpdateGraph(string text)
        {
            var values = text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            ChartValues<float> content = new ChartValues<float>();
            foreach (string s in values)
            {
                if (float.TryParse(s, out float f))
                {
                    content.Add(f);
                }
                else
                {
                    cartesianChart1.Series = new SeriesCollection
                    {
                        new LineSeries
                        {
                            Values = new ChartValues<float>()
                        }
                    };
                    return;
                }
            }
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = content
                }
            };
        }

        private void FormSignal_Load_1(object sender, EventArgs e)
        {
            CultureInfo customCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = customCulture;

            var rand = new Random();
            List<float> values = new List<float>();
            for (int i = 0; i < 30; i++)
            {
                double sample = rand.NextDouble();
                double scaled = (sample * (RANGE_MAX + Math.Abs(RANGE_MIN))) + RANGE_MIN;
                values.Add((float)scaled);
            }
            string text = string.Join(", ", values);
            UpdateGraph(text);
            textBox1.Text = text;
        }
    }
};

    

