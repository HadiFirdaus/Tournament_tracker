using System;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private void createPriceButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel(
                    placeNumberValue.Text, 
                    placeNameValue.Text, 
                    priceAmountValue.Text, 
                    pricePercentageValue.Text);
                foreach(IDataConnection db in GlobalConfig.Connections)
                {
                    db.CreatePrize(model);
                }
            }
            else
            {
                MessageBox.Show("Invalid Inputs");
            }

            ClearTextbox();

        }

        private bool ValidateForm()
        {
            bool output = true;
            int placeNumber = 0;
            bool isPlaceNumberValidNum = int.TryParse(placeNumberValue.Text, out placeNumber);
            if (!isPlaceNumberValidNum)
            {
                output = false;
            }
            if(placeNumber < 1)
            {
                output = false;
            }
            if(placeNameValue.Text.Length == 0)
            {
                output = false;
            }

            decimal prizeAmount = 0;
            double prizePercentage = 0;
            bool prizeAmountValid = decimal.TryParse(priceAmountValue.Text, out prizeAmount);
            bool prizePercentageValid = double.TryParse(pricePercentageValue.Text, out prizePercentage);
            if (!prizeAmountValid || !prizePercentageValid)
            {
                output = false;
            }
            if(prizeAmount <= 0 && prizePercentage <= 0)
            {
                output = false;
            }
            if(prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }
            return output;
        }

        private void ClearTextbox()
        {
            placeNumberValue.Text = "";
            placeNameValue.Text = "";
            priceAmountValue.Text = "0";
            pricePercentageValue.Text = "0";
        }

        private void CreatePrizeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
