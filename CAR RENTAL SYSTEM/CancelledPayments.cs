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
    public partial class CancelledPayments : Form
    {
        public CancelledPayments()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int paymentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                DialogResult result = MessageBox.Show("Are you sure you want to activate this payment record?", "Confirm Activation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    paymentTableAdapter1.UpdateQueryByStatus("Active", paymentId);
                    paymentTableAdapter1.FillByStatus(carRentalDataSet.Payment, "Canceled");
                    this.Refresh();
                    MessageBox.Show("Payment record activated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
            else
            {
                MessageBox.Show("Please select a payment record to Activate.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CancelledPayments_Load(object sender, EventArgs e)
        {
            paymentTableAdapter1.FillByStatus(carRentalDataSet.Payment, "Canceled");
        }

        private void Back7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
