namespace LOGIC_LEGENDS_LEADER_CAR_RENTAL_SYSTEM
{
    partial class AddCar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddCar = new System.Windows.Forms.Button();
            this.txtbrand = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.maskYear = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.maskPlatenumber = new System.Windows.Forms.MaskedTextBox();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.txtPPD = new System.Windows.Forms.TextBox();
            this.carsTableAdapter1 = new LOGIC_LEGENDS_LEADER_CAR_RENTAL_SYSTEM.CarRentalDataSetTableAdapters.CarsTableAdapter();
            this.carRentalDataSet1 = new LOGIC_LEGENDS_LEADER_CAR_RENTAL_SYSTEM.CarRentalDataSet();
            this.btnSaveCarChanges = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.back1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.carRentalDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Brand";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Model";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(65, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "YearOfManu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(65, 397);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Plate Number";
            // 
            // btnAddCar
            // 
            this.btnAddCar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnAddCar.ForeColor = System.Drawing.Color.Lime;
            this.btnAddCar.Location = new System.Drawing.Point(784, 504);
            this.btnAddCar.Name = "btnAddCar";
            this.btnAddCar.Size = new System.Drawing.Size(169, 50);
            this.btnAddCar.TabIndex = 4;
            this.btnAddCar.Text = "ADD";
            this.btnAddCar.UseVisualStyleBackColor = false;
            this.btnAddCar.Click += new System.EventHandler(this.btnAddCar_Click);
            // 
            // txtbrand
            // 
            this.txtbrand.BackColor = System.Drawing.Color.Gainsboro;
            this.txtbrand.Location = new System.Drawing.Point(215, 135);
            this.txtbrand.Name = "txtbrand";
            this.txtbrand.Size = new System.Drawing.Size(299, 22);
            this.txtbrand.TabIndex = 5;
            // 
            // txtModel
            // 
            this.txtModel.BackColor = System.Drawing.Color.Gainsboro;
            this.txtModel.Location = new System.Drawing.Point(215, 213);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(299, 22);
            this.txtModel.TabIndex = 6;
            // 
            // maskYear
            // 
            this.maskYear.BackColor = System.Drawing.Color.Gainsboro;
            this.maskYear.Location = new System.Drawing.Point(224, 299);
            this.maskYear.Mask = "0000";
            this.maskYear.Name = "maskYear";
            this.maskYear.Size = new System.Drawing.Size(290, 22);
            this.maskYear.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(65, 486);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(65, 567);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "Price per day";
            // 
            // maskPlatenumber
            // 
            this.maskPlatenumber.BackColor = System.Drawing.Color.Gainsboro;
            this.maskPlatenumber.Location = new System.Drawing.Point(224, 398);
            this.maskPlatenumber.Mask = "LLL000LL";
            this.maskPlatenumber.Name = "maskPlatenumber";
            this.maskPlatenumber.Size = new System.Drawing.Size(290, 22);
            this.maskPlatenumber.TabIndex = 10;
            // 
            // comboStatus
            // 
            this.comboStatus.BackColor = System.Drawing.Color.Gainsboro;
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Items.AddRange(new object[] {
            "Available",
            "Maintanance",
            "Rented"});
            this.comboStatus.Location = new System.Drawing.Point(224, 484);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(290, 24);
            this.comboStatus.TabIndex = 11;
            // 
            // txtPPD
            // 
            this.txtPPD.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPPD.Location = new System.Drawing.Point(224, 568);
            this.txtPPD.Name = "txtPPD";
            this.txtPPD.Size = new System.Drawing.Size(299, 22);
            this.txtPPD.TabIndex = 12;
            // 
            // carsTableAdapter1
            // 
            this.carsTableAdapter1.ClearBeforeFill = true;
            // 
            // carRentalDataSet1
            // 
            this.carRentalDataSet1.DataSetName = "CarRentalDataSet";
            this.carRentalDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSaveCarChanges
            // 
            this.btnSaveCarChanges.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSaveCarChanges.ForeColor = System.Drawing.Color.Lime;
            this.btnSaveCarChanges.Location = new System.Drawing.Point(619, 504);
            this.btnSaveCarChanges.Name = "btnSaveCarChanges";
            this.btnSaveCarChanges.Size = new System.Drawing.Size(146, 50);
            this.btnSaveCarChanges.TabIndex = 13;
            this.btnSaveCarChanges.Text = "SAVE CHANGES";
            this.btnSaveCarChanges.UseVisualStyleBackColor = false;
            this.btnSaveCarChanges.Click += new System.EventHandler(this.btnSaveCarChanges_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(306, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(406, 32);
            this.label7.TabIndex = 14;
            this.label7.Text = "ENTER CAR DETAILS HERE";
            // 
            // back1
            // 
            this.back1.Location = new System.Drawing.Point(96, 662);
            this.back1.Name = "back1";
            this.back1.Size = new System.Drawing.Size(75, 23);
            this.back1.TabIndex = 15;
            this.back1.Text = "Back";
            this.back1.UseVisualStyleBackColor = true;
            this.back1.Click += new System.EventHandler(this.back1_Click);
            // 
            // AddCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LOGIC_LEGENDS_LEADER_CAR_RENTAL_SYSTEM.Properties.Resources.cars3;
            this.ClientSize = new System.Drawing.Size(1374, 895);
            this.Controls.Add(this.back1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSaveCarChanges);
            this.Controls.Add(this.txtPPD);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.maskPlatenumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maskYear);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtbrand);
            this.Controls.Add(this.btnAddCar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddCar";
            this.Text = "AddCar";
            this.Load += new System.EventHandler(this.AddCar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.carRentalDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddCar;
        private System.Windows.Forms.TextBox txtbrand;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.MaskedTextBox maskYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox maskPlatenumber;
        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.TextBox txtPPD;
        private CarRentalDataSetTableAdapters.CarsTableAdapter carsTableAdapter1;
        private CarRentalDataSet carRentalDataSet1;
        private System.Windows.Forms.Button btnSaveCarChanges;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button back1;
    }
}