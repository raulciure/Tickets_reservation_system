namespace Tickets_reservation_system.Views
{
	partial class SelectFlightView
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
            this.label1 = new System.Windows.Forms.Label();
            this.departureDataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.returnDataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.departureDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.returnDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(504, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "OUR FLIGHTS";
            // 
            // departureDataGridView
            // 
            this.departureDataGridView.AllowUserToAddRows = false;
            this.departureDataGridView.AllowUserToDeleteRows = false;
            this.departureDataGridView.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.departureDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.departureDataGridView.Location = new System.Drawing.Point(50, 104);
            this.departureDataGridView.Name = "departureDataGridView";
            this.departureDataGridView.ReadOnly = true;
            this.departureDataGridView.RowHeadersWidth = 51;
            this.departureDataGridView.RowTemplate.Height = 24;
            this.departureDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.departureDataGridView.Size = new System.Drawing.Size(1091, 229);
            this.departureDataGridView.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(941, 635);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 75);
            this.button1.TabIndex = 2;
            this.button1.Text = "BOOK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button2.Location = new System.Drawing.Point(50, 674);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 36);
            this.button2.TabIndex = 3;
            this.button2.Text = "CANCEL";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // returnDataGridView
            // 
            this.returnDataGridView.AllowUserToAddRows = false;
            this.returnDataGridView.AllowUserToDeleteRows = false;
            this.returnDataGridView.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.returnDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.returnDataGridView.Location = new System.Drawing.Point(50, 374);
            this.returnDataGridView.Name = "returnDataGridView";
            this.returnDataGridView.ReadOnly = true;
            this.returnDataGridView.RowHeadersWidth = 51;
            this.returnDataGridView.RowTemplate.Height = 24;
            this.returnDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.returnDataGridView.Size = new System.Drawing.Size(1091, 229);
            this.returnDataGridView.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Departure flights";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Return flights";
            // 
            // SelectFlightView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1192, 722);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.returnDataGridView);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.departureDataGridView);
            this.Controls.Add(this.label1);
            this.Name = "SelectFlightView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Flights";
            ((System.ComponentModel.ISupportInitialize)(this.departureDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.returnDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView departureDataGridView;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView returnDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}