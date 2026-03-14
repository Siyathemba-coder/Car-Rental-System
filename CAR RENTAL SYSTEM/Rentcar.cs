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
    public partial class Rentcar : Form
    {
        public Rentcar()
        {
            InitializeComponent();
        }
        int carId = 0;
        int customerId = 0;
        String returnDate = "";
        private void btnRent_Click(object sender, EventArgs e)

        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView2.SelectedRows.Count > 0)
            {
                if (validateInput())
                {
                    try
                    {

                        int numOfDays = int.Parse(txtNumOfDays.Text.Trim());
                        decimal pricePerDay = decimal.Parse(dataGridView2.SelectedRows[0].Cells[6].Value.ToString());
                        decimal TotalCost = (numOfDays * pricePerDay);
                        txtTotalCost.Text = TotalCost.ToString("F2");
                        DateTime returnDate = DateTime.Now.AddDays(numOfDays);
                        textBox4.Text = returnDate.ToString("yyyy-MM-dd");
                        carId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
                        customerId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                        string returnDateString = returnDate.ToString("yyyy-MM-dd");
                        this.rentalTableAdapter1.InsertQueryRent(carId, customerId, returnDateString, TotalCost);
                        DataTable inserted = this.rentalTableAdapter1.GetLastRentalRow2();
                        DataRow row = inserted.Rows[0];
                        this.carsTableAdapter.UpdateQueryByCarStatus("Rented", carId);
                        this.carsTableAdapter.Fill(this.carRentalDataSet.Cars, "Available");

                        this.rentalTableAdapter1.FillByRented(this.carRentalDataSet.Rental, "Completed");
                        if (radioNow.Checked || radioReturn.Checked)
                        {
                            if (radioReturn.Checked)
                            {
                                MessageBox.Show("Car rented successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               ClearFields();
                            }
                            else
                            {
                                PayNow paymentcs = new PayNow();
                                ClearFields();
                                paymentcs.LoadRentData(row);
                                paymentcs.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a payment option.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please select both a car and a customer to proceed with the rental.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          
        }
        public Boolean validateInput()
        {
            Boolean isValid = true;
            errorProvider1.Clear();
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a car.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNumOfDays.Text))
            {
                errorProvider1.SetError(txtNumOfDays, "Number of days is required.");
                isValid = false;
            }
            if (!int.TryParse(txtNumOfDays.Text.Trim(), out int numOfDays) || numOfDays <= 0)
            {
                errorProvider1.SetError(txtNumOfDays, "Enter a valid positive integer for the number of days.");
                isValid = false;
            }
           
            if (!radioNow.Checked && !radioReturn.Checked)
            {
                errorProvider1.SetError(radioNow, "Please select a payment option.");
                errorProvider1.SetError(radioReturn, "Please select a payment option.");
                isValid = false;
               
            }
            return isValid;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        public void ClearFields()
        {
            txtNumOfDays.Clear();
            txtTotalCost.Clear();
            textBox4.Clear();
            errorProvider1.Clear();
            radioNow.Checked = false;
            radioReturn.Checked = false;
        }
        private void Rentcar_Load(object sender, EventArgs e)
        {
            carsTableAdapter.Fill(this.carRentalDataSet.Cars, "Available");
            customerTableAdapter.Fill(this.carRentalDataSet.Customer, "Active");
        }

        private void txtSearchRentClient_TextChanged(object sender, EventArgs e)
        {
            customerTableAdapter.FillByName(carRentalDataSet.Customer, "%" + txtSearchRentClient.Text + "%");
            if (string.IsNullOrWhiteSpace(txtSearchRentClient.Text))
            {
                customerTableAdapter.Fill(this.carRentalDataSet.Customer, "Active");
            }
        }

        private void txtSearchRentCar_TextChanged(object sender, EventArgs e)
        {
            carsTableAdapter.FillByCarName(carRentalDataSet.Cars, "%" + txtSearchRentCar.Text + "%");
            if (string.IsNullOrWhiteSpace(txtSearchRentCar.Text))
            {
                carsTableAdapter.Fill(this.carRentalDataSet.Cars, "Available");
            }
        }

        private void Back6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
