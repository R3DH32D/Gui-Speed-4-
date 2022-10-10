using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Gui_Speed_4_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var measureItems = new string[]
            {
            "μ/ρ",
            "κμ/χ",
            "Μΰυ.",
            "Ση.",
            };

            
            cmbFirstType.DataSource = new List<string>(measureItems);
            cmbSecondType.DataSource = new List<string>(measureItems);
            cmbResultType.DataSource = new List<string>(measureItems);
        }
        private MeasureType GetMeasureType(ComboBox comboBox)
        {
            MeasureType measureType;
            switch (comboBox.Text)
            {
                case "μ/ρ":
                    measureType = MeasureType.ms;
                    break;
                case "κμ/χ":
                    measureType = MeasureType.kmh;
                    break;
                case "Μΰυ.":
                    measureType = MeasureType.M;
                    break;
                case "Ση.":
                    measureType = MeasureType.kn;
                    break;
                default:
                    measureType = MeasureType.ms;
                    break;
            }
            return measureType;
        }
        private void Calculate()
        {
            try
            {
                var firstValue = double.Parse(txtFirst.Text);
                var secondValue = double.Parse(txtSecond.Text);

                MeasureType firstType = GetMeasureType(cmbFirstType);
                MeasureType secondType = GetMeasureType(cmbSecondType);
                MeasureType resultType = GetMeasureType(cmbResultType);

                var firstSpeed = new Speed(firstValue, firstType);
                var secondSpeed = new Speed(secondValue, secondType);

                Speed sumSpeed;

                
                switch (cmbOperation.Text)
                {
                    case "+":
                        
                        sumSpeed = firstSpeed + secondSpeed;
                        break;
                    case "-":
                        
                        sumSpeed = firstSpeed - secondSpeed;
                        break;
                    case "*":
                        
                        sumSpeed = firstSpeed * secondSpeed;
                        break;
                    case "<":
                        
                        sumSpeed = firstSpeed < secondSpeed;
                        break;
                    case ">":
                        
                        sumSpeed = firstSpeed > secondSpeed;
                        break;
                    default:
                       
                        sumSpeed = new Speed(0, MeasureType.ms);
                        break;
                }

                txtResult.Text = sumSpeed.To(resultType).Verbose();
            }
            catch (FormatException)
            {
                
            }
        }

        private void txtFirst_TextChanged(object sender, EventArgs e)
        {
                Calculate();
        }

        private void txtSecond_TextChanged(object sender, EventArgs e)
        {
                Calculate();
        }

        private void cmbOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbFirstType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbSecondType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmbResultType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}