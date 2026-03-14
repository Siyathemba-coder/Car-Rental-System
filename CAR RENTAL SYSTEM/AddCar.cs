using LOGIC_LEGENDS_LEADER_CAR_RENTAL_SYSTEM.CarRentalDataSetTableAdapters;
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
    public partial class AddCar : Form
    {
        private int currentCarId = 0;
        public AddCar()
        {
            InitializeComponent();
        }
        public Boolean vaildateYear(string year)
        {
            if (int.TryParse(year, out int yr))
            {
                if (yr >= 1900 && yr <= DateTime.Now.Year)
                {
                    return true;
                }
            }
            return false;
        }
        private void btnAddCar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateInputs())
                {
                    
                    MessageBox.Show("Car added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.carsTableAdapter1.InsertQueryAdded(txtbrand.Text.Trim(), Model: txtModel.Text.Trim(),Convert.ToInt32(maskYear.Text), PlateNumber: maskPlatenumber.Text.Trim(), PricePerDay: decimal.Parse(txtPPD.Text), Status: "Available");  
                    this.carsTableAdapter1.Fill(this.carRentalDataSet1.Cars,"Available");
                    this.ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public void ClearFields()
        {
            txtbrand.Clear();
            txtModel.Clear();
            maskYear.Clear();
            maskPlatenumber.Clear();
            txtPPD.Clear();
        }
        public Boolean validateInputs()
        {

            errorProvider1.Clear();
            Boolean isValid = true;
            if (string.IsNullOrWhiteSpace(txtbrand.Text))
            {
                errorProvider1.SetError(txtbrand, "fill the brand name");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtModel.Text))
            {
                errorProvider1.SetError(txtModel, "Enter the model");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(maskYear.Text))
            {
                errorProvider1.SetError(maskYear, "Enter the Year of Manufacture");
                isValid = false;

            }
            if (string.IsNullOrWhiteSpace(maskPlatenumber.Text))
            {
                errorProvider1.SetError(maskPlatenumber, "Enter Plate Number");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(txtPPD.Text))
            {
                errorProvider1.SetError(txtPPD, "Enyter Pricae Per Day");
                isValid = false;
            }
            if (!vaildateYear(maskYear.Text))
            {

                errorProvider1.SetError(maskYear, "Please enter a valid year between 1900 and the current year.");
                maskYear.Focus();
                isValid = false;
            }
            if (!validatePlateNumber(maskPlatenumber.Text))
            {
                errorProvider1.SetError(maskPlatenumber, "Please enter a valid plate number with at least 8 characters.");
                maskPlatenumber.Focus();
                isValid = false;
            }if (!decimal.TryParse(txtPPD.Text, out decimal price) || price < 0)
            {
                errorProvider1.SetError(txtPPD, "Please enter a valid positive number for Price Per Day.");
                txtPPD.Focus();
                isValid = false;
            }if (comboStatus.SelectedItem == null)
            {
                errorProvider1.SetError(comboStatus, "Please select a status.");
                comboStatus.Focus();
                isValid = false;
            }
            return isValid;
        }

        private void AddCar_Load(object sender, EventArgs e)
        {

        }

        private void btnSaveCarChanges_Click(object sender, EventArgs e)
        {

            try
            {
                if (validateInputs())
                {
                    this.carsTableAdapter1.UpdateQueryCarChange(
                        txtbrand.Text.Trim(),
                        txtModel.Text.Trim(),
                        int.Parse(maskYear.Text.Trim()),
                        maskPlatenumber.Text.Trim(),
                        comboStatus.Text,
                        decimal.Parse(txtPPD.Text.Trim()),
                        currentCarId
                    );
                    MessageBox.Show("Car updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating car: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public Boolean validatePlateNumber(string plateNumber)
        {
            if (plateNumber.Length < 8)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void LoadCarData(DataGridViewRow selectedRow)
        {
            txtbrand.Text = selectedRow.Cells[1].Value.ToString();
            txtModel.Text = selectedRow.Cells[2].Value.ToString();
            maskYear.Text = selectedRow.Cells[3].Value.ToString();
            maskPlatenumber.Text = selectedRow.Cells[4].Value.ToString();
            txtPPD.Text = selectedRow.Cells[6].Value.ToString();
            comboStatus.Text = selectedRow.Cells[5].Value.ToString();
            currentCarId = Convert.ToInt32(selectedRow.Cells[0].Value);
        }

        private void back1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
