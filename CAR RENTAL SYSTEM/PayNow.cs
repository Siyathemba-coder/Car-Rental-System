using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGIC_LEGENDS_LEADER_CAR_RENTAL_SYSTEM
{
    public partial class PayNow : Form
    {
        private int currentRentalId = 0;
        public PayNow()
        {
            InitializeComponent();
        }

        private void PayNow_Load(object sender, EventArgs e)
        {

        }
        public  void LoadRentData(DataRow row)
        {
           
            txtCarID.Text = row[1].ToString();
            txtCustomerID.Text = row[2].ToString();
            RentalDate.Text = row[3].ToString();
            ReturnDate.Text = row[4].ToString();
            TotalAmount.Text = row[5].ToString();
            Status.Text = row[6].ToString();
            currentRentalId = Convert.ToInt32(row[0]);
        }
        public void ClearFields()
        {
            txtCarID.Clear();
            txtCustomerID.Clear();
            RentalDate.ResetText();
            ReturnDate.ResetText();
            TotalAmount.Clear();
            Status.Clear();
        }
        public Boolean validateInputs()
        {
            decimal enteredAmount;
            Boolean isValid = true;
            errorProvider1.Clear();
            if (String.IsNullOrEmpty(txtAmount1.Text.Trim()))
            {
                errorProvider1.SetError(txtAmount1, "Amount is required.");
                isValid = false;
            }
            if(Convert.ToDecimal(txtAmount1.Text.Trim()) != Convert.ToDecimal(TotalAmount.Text.Trim()))
            {
                errorProvider1.SetError(txtAmount1, "Enter the excact Total Amount."+TotalAmount.Text);
                isValid = false;
            }

            else if (String.IsNullOrEmpty(comboPType1.Text.Trim()))
            {
                errorProvider1.SetError(comboPType1, "Payment Method is required.");
                isValid = false;
            }
            else if (String.IsNullOrEmpty(comboPStatus1.Text.Trim()))
            {
                errorProvider1.SetError(comboPStatus1, "Please select Status");
                isValid = false;
            }
            else if (!decimal.TryParse(txtAmount1.Text, out enteredAmount) || enteredAmount <= 0)
            {
                errorProvider1.SetError(txtAmount1, "Enter a valid positive amount");
                isValid = false;
            }
            else if (Convert.ToDecimal(txtAmount1.Text) != Convert.ToDecimal(TotalAmount.Text.Trim()))
            {
                errorProvider1.SetError(txtAmount1, "please enter the Exact Amount");
                isValid = false;
            }

                return isValid;
        }
        private void btnPayNow_Click(object sender, EventArgs e)
        {
            if (validateInputs())
            {
                try
                {
                    this.paymentTableAdapter1.InsertQueryAddedAddedPayment(currentRentalId, Convert.ToDecimal( txtAmount1.Text.Trim()),comboPType1.Text,comboPStatus1.Text);
                    this.rentalTableAdapter1.UpdateQueryByRentStatus("Completed", currentRentalId);
                    ClearFields();
                    RefreshDataGrid();
                    MessageBox.Show("Payment added and rental status updated to Paid successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured when Addid payment");

                }
            }
            else
            {
                return;
            }
        }
        public void RefreshDataGrid()
        {
            this.paymentTableAdapter1.FillByStatus(this.carRentalDataSet1.Payment, "Paid");
            this.rentalTableAdapter1.FillByRented(this.carRentalDataSet1.Rental, "Pending");
        }

        private void Back10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
