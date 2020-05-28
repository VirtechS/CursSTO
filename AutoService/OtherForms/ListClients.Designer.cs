namespace AutoService.OtherForms
{
    partial class ListClients
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
	    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListClients));
	    this.btnaddClient = new System.Windows.Forms.Button();
	    this.dtgfio = new System.Windows.Forms.DataGridView();
	    this.statusStrip1 = new System.Windows.Forms.StatusStrip();
	    this.tlsInfoCountCar = new System.Windows.Forms.ToolStripStatusLabel();
	    ((System.ComponentModel.ISupportInitialize)(this.dtgfio)).BeginInit();
	    this.statusStrip1.SuspendLayout();
	    this.SuspendLayout();
	    // 
	    // btnaddClient
	    // 
	    this.btnaddClient.Location = new System.Drawing.Point(400, 197);
	    this.btnaddClient.Name = "btnaddClient";
	    this.btnaddClient.Size = new System.Drawing.Size(159, 23);
	    this.btnaddClient.TabIndex = 9;
	    this.btnaddClient.Text = "Добавить владельца";
	    this.btnaddClient.UseVisualStyleBackColor = true;
	    this.btnaddClient.Click += new System.EventHandler(this.btnaddClient_Click);
	    // 
	    // dtgfio
	    // 
	    this.dtgfio.AllowUserToResizeColumns = false;
	    this.dtgfio.AllowUserToResizeRows = false;
	    this.dtgfio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
	    this.dtgfio.Location = new System.Drawing.Point(12, 22);
	    this.dtgfio.Name = "dtgfio";
	    this.dtgfio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
	    this.dtgfio.Size = new System.Drawing.Size(547, 169);
	    this.dtgfio.TabIndex = 8;
	    // 
	    // statusStrip1
	    // 
	    this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsInfoCountCar});
	    this.statusStrip1.Location = new System.Drawing.Point(0, 239);
	    this.statusStrip1.Name = "statusStrip1";
	    this.statusStrip1.Size = new System.Drawing.Size(575, 22);
	    this.statusStrip1.SizingGrip = false;
	    this.statusStrip1.TabIndex = 10;
	    this.statusStrip1.Text = "statusStrip1";
	    // 
	    // tlsInfoCountCar
	    // 
	    this.tlsInfoCountCar.Name = "tlsInfoCountCar";
	    this.tlsInfoCountCar.Size = new System.Drawing.Size(0, 17);
	    // 
	    // ListClients
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.ClientSize = new System.Drawing.Size(575, 261);
	    this.Controls.Add(this.statusStrip1);
	    this.Controls.Add(this.btnaddClient);
	    this.Controls.Add(this.dtgfio);
	    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
	    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	    this.MaximizeBox = false;
	    this.Name = "ListClients";
	    this.Text = "Список клиентов";
	    this.Load += new System.EventHandler(this.ListClients_Load);
	    ((System.ComponentModel.ISupportInitialize)(this.dtgfio)).EndInit();
	    this.statusStrip1.ResumeLayout(false);
	    this.statusStrip1.PerformLayout();
	    this.ResumeLayout(false);
	    this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.Button btnaddClient;
	private System.Windows.Forms.DataGridView dtgfio;
	private System.Windows.Forms.StatusStrip statusStrip1;
	private System.Windows.Forms.ToolStripStatusLabel tlsInfoCountCar;
    }
}