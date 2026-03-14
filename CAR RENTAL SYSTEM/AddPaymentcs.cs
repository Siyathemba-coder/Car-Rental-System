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
    public partial class AddPaymentcs : Form
    {
        public AddPaymentcs()
        {
            InitializeComponent();
        }

        private void btnAddPayement_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //decimal mustPay = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[5].Value);
                //txtAmountYMP.Text = mustPay.ToString("F2");
                if (validateAmount() && validateInput())
                {
                    errorProvider1.Clear();

               
                    try
                    {
                       
                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                        int rentalId = Convert.ToInt32(selectedRow.Cells[0].Value);
                        decimal amount = decimal.Parse(txtAmount.Text.Trim());
                     
                        string paymentDate = DateTime.Now.ToString("yyyy-MM-dd");
                        this.paymentTableAdapter1.InsertQueryAddedAddedPayment(rentalId, amount, comboPType.Text, "Paid");
                        this.rentalTableAdapter.UpdateQueryByRentStatus("Completed", rentalId);
                        //this.paymentTableAdapter1.FillByStatus(this.carRentalDataSet.Payment,"Paid");
                        //this.rentalTableAdapter1.FillByRented(this.carRentalDataSet.Rental, "Completed");
                        this.RefreshDataGrid();
                        MessageBox.Show("Payment added and rental status updated to Paid successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                } else
                {
                return;
                }
            }
            else
            {
                MessageBox.Show("Please select a rental to add payment for.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ClearFields()
        {
            txtAmount.Clear();
           
            
        }
        public void RefreshDataGrid()
        {
            this.paymentTableAdapter1.FillByStatus(this.carRentalDataSet.Payment, "Paid");
            this.rentalTableAdapter1.FillByRented(this.carRentalDataSet.Rental, "Pending");
        }
        public Boolean validateInput()
        {
          Boolean isValid = true;
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                errorProvider1.SetError(txtAmount, "Enter the Amount");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(comboPType.Text))
            {
                errorProvider1.SetError(comboPType, "Select Payment Type");
                isValid = false;
            }if(string.IsNullOrWhiteSpace(comboPStatus.Text))
            {
                errorProvider1.SetError(comboPStatus, "Select Payment Status");
                isValid = false;
            }
            return isValid;
        }
        public Boolean validateAmount()
        {
            errorProvider1.Clear();
            Boolean isValid = true;
            decimal mustPay = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[5].Value);
            decimal enteredAmount;
            if (!decimal.TryParse(txtAmount.Text, out enteredAmount) || enteredAmount <= 0)
            {
                errorProvider1.SetError(txtAmount, "Enter a valid positive amount");
                isValid = false;
            }
            else if (enteredAmount != mustPay)
            {
                errorProvider1.SetError(txtAmount, "Please enter the exact amount due: " + mustPay.ToString("F2"));
                isValid = false;
            } return isValid;
            //}else if (enteredAmount != mustPay)
            //{
            //    errorProvider1.SetError(txtAmount, "please enter the Exact Amount");
            //    isValid = false;
            //}
            //    return isValid;
        }

        private void AddPaymentcs_Load(object sender, EventArgs e)
        {
            rentalTableAdapter1.FillByRented(carRentalDataSet.Rental, "Pending");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Back3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    