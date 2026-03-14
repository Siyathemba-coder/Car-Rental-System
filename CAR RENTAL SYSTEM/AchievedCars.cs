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
    public partial class AchievedCars : Form
    {
        public AchievedCars()
        {
            InitializeComponent();
        }

        private void btnReturnCar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int carId = Convert.ToInt32(selectedRow.Cells[0].Value);
                try
                {
                    this.carsTableAdapter.UpdateQueryByCarStatus("Available", carId);
                    this.carsTableAdapter.Fill(this.carRentalDataSet.Cars, "Maintanance");
                    MessageBox.Show("Car status updated to Available successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating car status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a car to return.", "No Car Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void AchievedCars_Load(object sender, EventArgs e)
        {
            carsTableAdapter.Fill(carRentalDataSet.Cars, "Maintanance");
        }

        private void Back4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
