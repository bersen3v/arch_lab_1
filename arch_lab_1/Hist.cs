using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace arch_lab_1
{
    public partial class Hist : Form
    {
        Logic logic = Logic.GetInstance();
        public Hist()
        {
            InitializeComponent();


            chart1.Series.Clear();
            Dictionary<string, int> res = logic.GetSpecialityMap();
            int x = 0;
            foreach (string key in res.Keys)
            {
                var dataPointSeries = new Series
                {
                    Name = key,
                    Color = Color.Red,
                    ChartType = SeriesChartType.Column
                };

                dataPointSeries.Points.AddXY(x++, res[key]);
                chart1.Series.Add(dataPointSeries);
            }

            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
