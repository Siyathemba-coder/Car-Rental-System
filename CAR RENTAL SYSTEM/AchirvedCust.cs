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
    public partial class AchirvedCust : Form
    {
        public AchirvedCust()
        {
            InitializeComponent();
        }

        private void AchirvedCust_Load(object sender, EventArgs e)
        {
            
           this.customerTableAdapter.FillByInactive(carRentalDataSet.Customer,"Inactive");

        }

        private void btnReturnCust_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            { 
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int customerId = Convert.ToInt32(selectedRow.Cells[0].Value);

                
                try
                {
                    
                    this.customerTableAdapter.UpdateQueryByStatus("Active", customerId);
                    this.customerTableAdapter.Fill(this.carRentalDataSet.Customer, "Inactive");
                    dataGridView1.Refresh();
                    MessageBox.Show("Customer status updated to Active successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating customer status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to Activate.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeletePermanent_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int customerId = Convert.ToInt32(selectedRow.Cells[0].Value);
                
                var confirmResult = MessageBox.Show("Are you sure to permanently delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {

                        this.customerTableAdapter.DeleteCustomerPermanentQuery(customerId);
                        this.customerTableAdapter.Fill(this.carRentalDataSet.Customer, "Inactive");
                        dataGridView1.Refresh();
                        MessageBox.Show("Customer permanently deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Back5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
