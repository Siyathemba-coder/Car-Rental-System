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
    public partial class CancelledRents : Form
    {
        public CancelledRents()
        {
            InitializeComponent();
        }

        private void CancelledRents_Load(object sender, EventArgs e)
        {
            rentalTableAdapter.FillByRented(carRentalDataSet.Rental, "Cancelled");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count>0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int rentalId = Convert.ToInt32(selectedRow.Cells[0].Value);
                int carId = Convert.ToInt32(selectedRow.Cells[1].Value);
                try
                {
                    this.rentalTableAdapter.UpdateQueryByRentStatus("Completed", rentalId);
                    this.carsTableAdapter1.UpdateQueryByCarStatus("Rented", carId);
                    this.rentalTableAdapter.FillByRented(this.carRentalDataSet.Rental, "Cancelled");
                    this.carsTableAdapter1.Fill(this.carRentalDataSet.Cars, "Available");
                    dataGridView1.Refresh();
                    MessageBox.Show("Rental status updated  and car status updated to Rented successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating statuses: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a rental to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Back9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
