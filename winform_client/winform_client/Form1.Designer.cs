
namespace winform_client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReconnect = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextHubs = new System.Windows.Forms.RichTextBox();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.labelPage = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(515, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(71, 39);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReconnect);
            this.panel1.Controls.Add(this.labelMessage);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(586, 39);
            this.panel1.TabIndex = 3;
            // 
            // btnReconnect
            // 
            this.btnReconnect.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReconnect.Location = new System.Drawing.Point(279, 0);
            this.btnReconnect.Name = "btnReconnect";
            this.btnReconnect.Size = new System.Drawing.Size(94, 39);
            this.btnReconnect.TabIndex = 6;
            this.btnReconnect.Text = "Reload";
            this.btnReconnect.UseVisualStyleBackColor = true;
            this.btnReconnect.Click += new System.EventHandler(this.btnReconnect_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMessage.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelMessage.Location = new System.Drawing.Point(0, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(0, 20);
            this.labelMessage.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAdd.Location = new System.Drawing.Point(373, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(71, 39);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(444, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(71, 39);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(20, 59);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(586, 28);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(578, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "all";
            this.tabPage1.Text = "All";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(20, 87);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(586, 343);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.richTextHubs);
            this.panel2.Controls.Add(this.btnPrevious);
            this.panel2.Controls.Add(this.labelPage);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(20, 382);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(586, 48);
            this.panel2.TabIndex = 5;
            // 
            // richTextHubs
            // 
            this.richTextHubs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextHubs.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.richTextHubs.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.richTextHubs.Location = new System.Drawing.Point(0, 0);
            this.richTextHubs.Name = "richTextHubs";
            this.richTextHubs.ReadOnly = true;
            this.richTextHubs.Size = new System.Drawing.Size(448, 48);
            this.richTextHubs.TabIndex = 6;
            this.richTextHubs.Text = "Trying to connect to hubs";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPrevious.Location = new System.Drawing.Point(448, 0);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(46, 48);
            this.btnPrevious.TabIndex = 5;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // labelPage
            // 
            this.labelPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPage.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelPage.Location = new System.Drawing.Point(494, 0);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(50, 48);
            this.labelPage.TabIndex = 3;
            this.labelPage.Text = "0/0";
            this.labelPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNext.Location = new System.Drawing.Point(544, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(42, 48);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.richTextBox1.Location = new System.Drawing.Point(20, 295);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(586, 87);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Device Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.RichTextBox richTextHubs;
        private System.Windows.Forms.Button btnReconnect;
    }
}

