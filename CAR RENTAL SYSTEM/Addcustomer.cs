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
    public partial class Addcustomer : Form
    {
        private int currentCustomerId = 0;
        private bool isEditMode = false;
        private int editingCustomerId = -1;
        private DataRow originalCustomerData;
        public Addcustomer()
        {
            InitializeComponent();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {

                if (validateData())
                {
                    customerTableAdapter1.Insert(
                        txtName.Text.Trim(),
                        txtSurname.Text.Trim(),
                        maskDOB.Text.Trim(),
                        txtEmail.Text.Trim(),
                        maskPhone.Text.Trim(),
                        txtStreet.Text.Trim(),
                        txtCity.Text.Trim(),
                        comboCountry.Text.Trim(),
                        maskLICENSENo.Text.Trim(),
                        maskExDate.Text.Trim(),
                        comboStatus.Text.Trim()
                    );

                    customerTableAdapter1.Fill(carRentalDataSet1.Customer,"Active");

                    ClearForm();

                    MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsValidExpiryDate(string expiryDateText)
        {
            DateTime expiryDate;

            
            if (DateTime.TryParseExact(expiryDateText, "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out expiryDate))
            {
               
                if (expiryDate < DateTime.Now.Date)
                    return false;

                return true; 
            }

            return false; 
        }
        public Boolean validateLicenceNumber(String licenceNumber)
        {
            if (licenceNumber.Length < 9)
            {
                return false;
            }
            return true; 
        }
        public Boolean validateData()
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider1.SetError(txtName, "First Name is required");
                isValid = false;
            }
            else if (txtName.Text.Length > 50)
            {
                errorProvider1.SetError(txtName, "First Name cannot exceed 50 characters");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                errorProvider1.SetError(txtSurname, "Last Name is required");
                isValid = false;
            }
            else if (txtSurname.Text.Length > 50)
            {
                errorProvider1.SetError(txtSurname, "Last Name cannot exceed 50 characters");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(maskDOB.Text))
            {
                errorProvider1.SetError(maskDOB, "Date of Birth is required");
                isValid = false;
            }
            else if (!IsValidDateFormat(maskDOB.Text))
            {
                errorProvider1.SetError(maskDOB, "Date must be in YYYY-MM-DDformat");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Email is required");
                isValid = false;
            }
            else if (!IsValidEmail(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Please enter a valid email address");
                isValid = false;
            }
            else if (txtEmail.Text.Length > 100)
            {
                errorProvider1.SetError(txtEmail, "Email cannot exceed 100 characters");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(maskPhone.Text))
            {
                errorProvider1.SetError(maskPhone, "Phone Number is required");
                isValid = false;
            }
            else if (!IsValidPhoneNumber(maskPhone.Text))
            {
                errorProvider1.SetError(maskPhone, "Phone Number must be 10 digits starting with 0");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtStreet.Text))
            {
                errorProvider1.SetError(txtStreet, "Address is required");
                isValid = false;
            }
            else if (txtStreet.Text.Length > 200)
            {
                errorProvider1.SetError(txtStreet, "Address cannot exceed 200 characters");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                errorProvider1.SetError(txtCity, "City is required");
                isValid = false;
            }
            else if (txtCity.Text.Length > 50)
            {
                errorProvider1.SetError(txtCity, "City cannot exceed 50 characters");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(comboCountry.Text))
            {
                errorProvider1.SetError(comboCountry, "Country is required");
                isValid = false;
            }
         
            if (string.IsNullOrWhiteSpace(maskLICENSENo.Text))
            {
                errorProvider1.SetError(maskLICENSENo, "License Number is required");
                isValid = false;
            }
            else if (maskLICENSENo.Text.Length > 50)
            {
                errorProvider1.SetError(maskLICENSENo, "License Number cannot exceed 50 characters");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(maskExDate.Text))
            {
                errorProvider1.SetError(maskExDate, "License Expiry Date is required");
                isValid = false;
            }
            else if (!IsValidDateFormat(maskExDate.Text))
            {
                errorProvider1.SetError(maskExDate, "Date must be in YYYY-MM-DD format");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(comboStatus.Text))
            {
                errorProvider1.SetError(comboStatus, "Status is required");
                isValid = false;
            }
            if(!IsValidExpiryDate(maskExDate.Text))
            {
                errorProvider1.SetError(maskExDate, "Expiry date cannot be in the past");
                isValid = false;
            }
            else if (comboStatus.Text.Length > 20)
            {
                errorProvider1.SetError(comboStatus, "Status cannot exceed 20 characters");
                isValid = false;
            }
            return isValid;
        }


        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string cleanPhone = phoneNumber.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");

            return cleanPhone.Length == 10 && cleanPhone.All(char.IsDigit) && cleanPhone.StartsWith("0");
        }

        private bool IsValidDateFormat(string dateString)
        {
            DateTime date;
            return DateTime.TryParseExact(dateString, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out date);
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtSurname.Clear();
            maskDOB.Clear();
            txtEmail.Clear();
            maskPhone.Clear();
            txtStreet.Clear();
            txtCity.Clear();
        
            maskLICENSENo.Clear();
            maskExDate.Clear();
           
            errorProvider1.Clear();
            txtName.Focus();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {

            try
            {
                if (validateData())
                {
                    if (!IsValidPhoneNumber(maskPhone.Text))
                    {
                        MessageBox.Show("Phone Number must be 10 digits starting with 0", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        maskPhone.Focus();
                        return;
                    }
                    if(!IsValidEmail(txtEmail.Text))
                    {
                        MessageBox.Show("Please enter a valid email address", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmail.Focus();
                        return;
                    }
                    if (!IsValidDateFormat(maskDOB.Text))
                    {
                        MessageBox.Show("Please enter a valid Date of Birth in yyyy-MM-dd format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        maskDOB.Focus();
                        return;
                    }
                    DateTime expiryDate;
                    if (DateTime.TryParseExact(maskExDate.Text, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out expiryDate))
                    {
                        if (expiryDate < DateTime.Now.Date)
                        {
                            MessageBox.Show("Expiry date cannot be in the past.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            maskExDate.Focus();
                            return;
                        }
                    }
                    if (!validateLicenceNumber(maskLICENSENo.Text))
                    {
                        MessageBox.Show("Please enter a valid License Number with at least 9 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        maskLICENSENo.Focus();
                        return;
                    }
                    this.customerTableAdapter1.UpdateQueryByChange(
                    txtName.Text.Trim(),
                    txtSurname.Text.Trim(),
                    maskDOB.Text.Trim(),
                    txtEmail.Text.Trim(),
                       maskPhone.Text.Trim(),
                       txtStreet.Text.Trim(),
                       txtCity.Text.Trim(),
                       comboCountry.Text,
                       maskLICENSENo.Text.Trim(),
                       maskExDate.Text.Trim(),
                       comboStatus.Text,
                       currentCustomerId
                   );
                    MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
  
        
        //public void SetEditMode(DataRow customerData)
        //{
        //    isEditMode = true;
        //    editingCustomerId = Convert.ToInt32(customerData["CustomerID"]);
        //    originalCustomerData = customerData;
        //    txtName.Text = customerData["FirstName"].ToString();
        //    txtSurname.Text = customerData["LastName"].ToString();
        //    maskDOB.Text = Convert.ToDateTime(customerData["DateOfBirth"]).ToString("MM/dd/yyyy");
        //    txtEmail.Text = customerData["Email"].ToString();
        //    maskPhone.Text = customerData["PhoneNumber"].ToString();
        //    txtStreet.Text = customerData["Address"].ToString();
        //    txtCity.Text = customerData["City"].ToString();
        //   comboCountry.Text = customerData["Country"].ToString();
        //    maskLICENSENo.Text = customerData["LicenseNumber"].ToString();
        //    maskExDate.Text = Convert.ToDateTime(customerData["LicenseExpiryDate"]).ToString("MM/dd/yyyy");
        //    comboStatus.Text = customerData["Status"].ToString();

        //    btnAddCustomer.Text = "UPDATE CUSTOMER";
        //    this.Text = "Edit Customer"; 
        //}
        public void LoadCustomerData(DataGridViewRow selectedRow)
        {
            currentCustomerId = Convert.ToInt32(selectedRow.Cells[0].Value); 
            txtName.Text = selectedRow.Cells[1].Value?.ToString() ?? "";           
            txtSurname.Text = selectedRow.Cells[2].Value?.ToString() ?? "";       
            maskDOB.Text = selectedRow.Cells[3].Value?.ToString() ?? "";           
            txtEmail.Text = selectedRow.Cells[4].Value?.ToString() ?? "";          
            maskPhone.Text = selectedRow.Cells[5].Value?.ToString() ?? "";      
            txtStreet.Text = selectedRow.Cells[6].Value?.ToString() ?? "";       
            txtCity.Text = selectedRow.Cells[7].Value?.ToString() ?? "";          
            comboCountry.Text = selectedRow.Cells[8].Value?.ToString() ?? "";       
            maskLICENSENo.Text = selectedRow.Cells[9].Value?.ToString() ?? "";     
            maskExDate.Text = selectedRow.Cells[10].Value?.ToString() ?? "";       
            comboStatus.Text = selectedRow.Cells[11].Value?.ToString() ?? "";      
        }

        private void Addcustomer_Load(object sender, EventArgs e)
        {

        }

        private void Back2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
