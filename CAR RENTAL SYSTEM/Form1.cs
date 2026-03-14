using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGIC_LEGENDS_LEADER_CAR_RENTAL_SYSTEM
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Addcustomer addcustomer = new Addcustomer();
            addcustomer.Show();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

            this.paymentTableAdapter.FillByStatus(this.carRentalDataSet.Payment, "Paid"); 
            this.rentalTableAdapter.FillByRented(this.carRentalDataSet.Rental, "Completed");
            this.carsTableAdapter.Fill(this.carRentalDataSet.Cars,"Available");
            this.customerTableAdapter.Fill(this.carRentalDataSet.Customer,"Active");

        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            
            customerTableAdapter.FillByName(carRentalDataSet.Customer, "%" + txtSearchByName.Text + "%");
            if (string.IsNullOrWhiteSpace(txtSearchByName.Text))
            {
                customerTableAdapter.Fill(this.carRentalDataSet.Customer, "Active");
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Addcustomer addcustomer = new Addcustomer();
            addcustomer.Show();
        }


        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                Addcustomer editForm = new Addcustomer();
                editForm.LoadCustomerData(selectedRow);
                editForm.ShowDialog();
                this.customerTableAdapter.Fill(this.carRentalDataSet.Customer, "Active");
            }
            else
            {
                MessageBox.Show("Please select a customer to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to deactivate this customer?",
                                      "Confirm Deactivation",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return;
                }
                else
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    int customerId = Convert.ToInt32(selectedRow.Cells[0].Value);
                    try
                    {
                        this.customerTableAdapter.UpdateQueryByStatus("Inactive", customerId);
                        this.customerTableAdapter.Fill(this.carRentalDataSet.Customer, "Active");
                        dataGridView1.Refresh();
                        MessageBox.Show("Customer status updated to Inactive successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating customer status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to deactivate.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnViewAchivedCars_Click(object sender, EventArgs e)
        {
            AchievedCars achievedCars = new AchievedCars();
            achievedCars.Show();
        }

        private void btnViewAchivedCust_Click(object sender, EventArgs e)
        {
            AchirvedCust achirvedCustomer = new AchirvedCust();
            achirvedCustomer.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.customerTableAdapter.Fill(this.carRentalDataSet.Customer, "Active");
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            AddCar addCar = new AddCar();
            addCar.Show();
        }

        private void btnRefreshCars_Click(object sender, EventArgs e)
        {
          this.carsTableAdapter.Fill(this.carRentalDataSet.Cars,"Available");
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                AddCar editForm = new AddCar();
                editForm.LoadCarData(selectedRow);
                editForm.ShowDialog();
                this.carsTableAdapter.Fill(this.carRentalDataSet.Cars, "Available");
            }
            else
            {
                MessageBox.Show("Please select a Car to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchCarbyName_TextChanged(object sender, EventArgs e)
        {
            carsTableAdapter.FillByCarName(carRentalDataSet.Cars, "%" + txtSearchCarbyName.Text + "%");
            if (string.IsNullOrWhiteSpace(txtSearchCarbyName.Text))
            {
                carsTableAdapter.Fill(this.carRentalDataSet.Cars, "Available");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
                if (dataGridView2.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to deactivate this Car?", "Confirm Deactivation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                    int carId = Convert.ToInt32(selectedRow.Cells[0].Value);
                    try
                    {
                        this.carsTableAdapter.UpdateQueryByCarStatus("Maintanance", carId);
                        this.carsTableAdapter.Fill(this.carRentalDataSet.Cars, "Available");
                        dataGridView2.Refresh();
                        MessageBox.Show("Car status updated to Inactive successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating Car status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please select a Car to deactivate.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Rentcar rentcar = new Rentcar();
            rentcar.Show();
        }

        private void btnCancelRent_Click(object sender, EventArgs e)
        {
            if(dataGridView3.SelectedRows.Count>0)
            {
                DialogResult result= MessageBox.Show("Are you sure you want to cancel this rental?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return; 
                }
                else
                {
                    DataGridViewRow selectedRow = dataGridView3.SelectedRows[0];
                    int rentalId = Convert.ToInt32(selectedRow.Cells[0].Value);
                    int carId = Convert.ToInt32(selectedRow.Cells[1].Value);
                    try
                    {
                        this.rentalTableAdapter.UpdateQueryByRentStatus("Cancelled", rentalId);
                        this.carsTableAdapter.UpdateQueryByCarStatus("Available", carId);
                        this.carsTableAdapter.Fill(this.carRentalDataSet.Cars, "Available");
                        this.rentalTableAdapter.FillByRented(this.carRentalDataSet.Rental, "Completed");
                        dataGridView1.Refresh();
                        MessageBox.Show("Rental cancelled and car status updated to Available successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error cancelling rental: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a rental to cancel.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnViewCancelledRents_Click(object sender, EventArgs e)
        {
            CancelledRents cancelledRents = new CancelledRents();
            cancelledRents.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddPaymentcs addPaymentcs = new AddPaymentcs();
            addPaymentcs.Show();
        }
        
        private void button11_Click(object sender, EventArgs e)
        {
            

            if (dataGridView4.SelectedRows.Count>0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to mark this payment as Canceled?", "Confirm Canceled", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return;
                }
                else
                {
                    DataGridViewRow selectedRow = dataGridView4.SelectedRows[0];
                    int paymentId = Convert.ToInt32(selectedRow.Cells[0].Value);
                    int rentalId = Convert.ToInt32(selectedRow.Cells[1].Value);
                    try
                    {
                        this.paymentTableAdapter.UpdateQueryByStatus("Canceled", paymentId);
                        this.rentalTableAdapter.UpdateQueryByRentStatus("Pending", rentalId);
                        this.paymentTableAdapter.FillByStatus(this.carRentalDataSet.Payment, "Paid");
                        this.rentalTableAdapter.FillByRented(this.carRentalDataSet.Rental, "Completed");
                        dataGridView4.Refresh();
                        MessageBox.Show("Payment status updated to Deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating payment status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a payment to mark as Paid.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CancelledPayments cancelledPayments = new CancelledPayments();
            cancelledPayments.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(IsValidDateFormat(txtSearchByPaymentDate.Text))
            {
                paymentTableAdapter.SearchByPaymentDate(carRentalDataSet.Payment, txtSearchByPaymentDate.Text);
            }
            else
            {
                paymentTableAdapter.FillByStatus(carRentalDataSet.Payment, "Paid");
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
        private bool IsValidDateFormat(string dateString)
        {
            DateTime date;
            return DateTime.TryParseExact(dateString, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out date);
        }

        private void txtseacrchbyRentaldate_TextChanged(object sender, EventArgs e)
        {
           if( IsValidDateFormat(txtSearchRentaldate.Text))
            {
               
                rentalTableAdapter.SearchByRentaIDate(carRentalDataSet.Rental, txtSearchRentaldate.Text);
            }
            else
            {
                rentalTableAdapter.FillByRented(carRentalDataSet.Rental, "Completed");
            }
        }

        private void RefreshPayement_Click(object sender, EventArgs e)
        {
            this.paymentTableAdapter.FillByStatus(this.carRentalDataSet.Payment, "Paid");
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void RentedCars_Click(object sender, EventArgs e)
        {
            this.carsTableAdapter.Fill(this.carRentalDataSet.Cars, "Rented");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.rentalTableAdapter.FillByRented(carRentalDataSet.Rental, "Completed");
        }
    }
}
