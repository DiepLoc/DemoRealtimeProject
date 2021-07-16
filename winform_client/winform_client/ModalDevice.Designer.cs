
namespace winform_client
{
    partial class ModalDevice
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numberPrice = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBrand = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelLoading = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberPrice)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 55);
            this.panel1.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(105, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(230, 27);
            this.txtName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.numberPrice);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(347, 49);
            this.panel2.TabIndex = 3;
            // 
            // numberPrice
            // 
            this.numberPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numberPrice.Location = new System.Drawing.Point(105, 12);
            this.numberPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numberPrice.Name = "numberPrice";
            this.numberPrice.Size = new System.Drawing.Size(230, 27);
            this.numberPrice.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Price";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboBrand);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 114);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(347, 45);
            this.panel3.TabIndex = 4;
            // 
            // comboBrand
            // 
            this.comboBrand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBrand.FormattingEnabled = true;
            this.comboBrand.Location = new System.Drawing.Point(103, 6);
            this.comboBrand.Name = "comboBrand";
            this.comboBrand.Size = new System.Drawing.Size(232, 28);
            this.comboBrand.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Brand";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(103, 3);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(96, 40);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(205, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 40);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.btnSubmit);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 207);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(347, 48);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labelLoading);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(10, 159);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(347, 48);
            this.panel5.TabIndex = 5;
            // 
            // labelLoading
            // 
            this.labelLoading.AutoSize = true;
            this.labelLoading.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelLoading.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelLoading.Location = new System.Drawing.Point(106, 11);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(0, 25);
            this.labelLoading.TabIndex = 0;
            // 
            // ModalDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 265);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ModalDevice";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ModalDevice 2";
            this.Load += new System.EventHandler(this.ModalDevice_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberPrice)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBrand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown numberPrice;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labelLoading;
    }
}