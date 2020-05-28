namespace AutoService.Forms
{
    partial class CarsForm
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
	    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarsForm));
	    this.dtgCars = new System.Windows.Forms.DataGridView();
	    this.statusStrip1 = new System.Windows.Forms.StatusStrip();
	    this.tls = new System.Windows.Forms.ToolStripStatusLabel();
	    this.dtgfio = new System.Windows.Forms.DataGridView();
	    this.menuStrip1 = new System.Windows.Forms.MenuStrip();
	    this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	    this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	    this.txtFind = new System.Windows.Forms.TextBox();
	    this.label1 = new System.Windows.Forms.Label();
	    this.btnaddClient = new System.Windows.Forms.Button();
	    ((System.ComponentModel.ISupportInitialize)(this.dtgCars)).BeginInit();
	    this.statusStrip1.SuspendLayout();
	    ((System.ComponentModel.ISupportInitialize)(this.dtgfio)).BeginInit();
	    this.menuStrip1.SuspendLayout();
	    this.SuspendLayout();
	    // 
	    // dtgCars
	    // 
	    this.dtgCars.AllowUserToResizeColumns = false;
	    this.dtgCars.AllowUserToResizeRows = false;
	    this.dtgCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
	    this.dtgCars.Location = new System.Drawing.Point(16, 60);
	    this.dtgCars.MultiSelect = false;
	    this.dtgCars.Name = "dtgCars";
	    this.dtgCars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
	    this.dtgCars.Size = new System.Drawing.Size(274, 121);
	    this.dtgCars.TabIndex = 0;
	    this.dtgCars.SelectionChanged += new System.EventHandler(this.dtgCars_SelectionChanged);
	    // 
	    // statusStrip1
	    // 
	    this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tls});
	    this.statusStrip1.Location = new System.Drawing.Point(0, 221);
	    this.statusStrip1.Name = "statusStrip1";
	    this.statusStrip1.Size = new System.Drawing.Size(858, 22);
	    this.statusStrip1.TabIndex = 2;
	    this.statusStrip1.Text = "statusStrip1";
	    // 
	    // tls
	    // 
	    this.tls.Name = "tls";
	    this.tls.Size = new System.Drawing.Size(0, 17);
	    // 
	    // dtgfio
	    // 
	    this.dtgfio.AllowUserToResizeColumns = false;
	    this.dtgfio.AllowUserToResizeRows = false;
	    this.dtgfio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
	    this.dtgfio.Location = new System.Drawing.Point(296, 60);
	    this.dtgfio.Name = "dtgfio";
	    this.dtgfio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
	    this.dtgfio.Size = new System.Drawing.Size(547, 121);
	    this.dtgfio.TabIndex = 3;
	    // 
	    // menuStrip1
	    // 
	    this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem,
            this.закрытьToolStripMenuItem});
	    this.menuStrip1.Location = new System.Drawing.Point(0, 0);
	    this.menuStrip1.Name = "menuStrip1";
	    this.menuStrip1.Size = new System.Drawing.Size(858, 24);
	    this.menuStrip1.TabIndex = 4;
	    this.menuStrip1.Text = "menuStrip1";
	    // 
	    // справкаToolStripMenuItem
	    // 
	    this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
	    this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
	    this.справкаToolStripMenuItem.Text = "Справка";
	    this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
	    // 
	    // закрытьToolStripMenuItem
	    // 
	    this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
	    this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
	    this.закрытьToolStripMenuItem.Text = "Закрыть";
	    this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
	    // 
	    // txtFind
	    // 
	    this.txtFind.Location = new System.Drawing.Point(70, 36);
	    this.txtFind.Name = "txtFind";
	    this.txtFind.Size = new System.Drawing.Size(220, 20);
	    this.txtFind.TabIndex = 5;
	    this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
	    // 
	    // label1
	    // 
	    this.label1.AutoSize = true;
	    this.label1.Font = new System.Drawing.Font("Agency FB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	    this.label1.Location = new System.Drawing.Point(13, 39);
	    this.label1.Name = "label1";
	    this.label1.Size = new System.Drawing.Size(51, 17);
	    this.label1.TabIndex = 6;
	    this.label1.Text = "Поиск:";
	    // 
	    // btnaddClient
	    // 
	    this.btnaddClient.Location = new System.Drawing.Point(684, 187);
	    this.btnaddClient.Name = "btnaddClient";
	    this.btnaddClient.Size = new System.Drawing.Size(159, 23);
	    this.btnaddClient.TabIndex = 7;
	    this.btnaddClient.Text = "Добавить владельца";
	    this.btnaddClient.UseVisualStyleBackColor = true;
	    this.btnaddClient.Click += new System.EventHandler(this.btnaddClient_Click);
	    // 
	    // CarsForm
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.ClientSize = new System.Drawing.Size(858, 243);
	    this.Controls.Add(this.btnaddClient);
	    this.Controls.Add(this.label1);
	    this.Controls.Add(this.txtFind);
	    this.Controls.Add(this.dtgfio);
	    this.Controls.Add(this.statusStrip1);
	    this.Controls.Add(this.menuStrip1);
	    this.Controls.Add(this.dtgCars);
	    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
	    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	    this.MainMenuStrip = this.menuStrip1;
	    this.MaximizeBox = false;
	    this.Name = "CarsForm";
	    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	    this.Text = "Реестр авто";
	    this.Load += new System.EventHandler(this.CarsForm_Load);
	    ((System.ComponentModel.ISupportInitialize)(this.dtgCars)).EndInit();
	    this.statusStrip1.ResumeLayout(false);
	    this.statusStrip1.PerformLayout();
	    ((System.ComponentModel.ISupportInitialize)(this.dtgfio)).EndInit();
	    this.menuStrip1.ResumeLayout(false);
	    this.menuStrip1.PerformLayout();
	    this.ResumeLayout(false);
	    this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.DataGridView dtgCars;
	private System.Windows.Forms.StatusStrip statusStrip1;
	private System.Windows.Forms.ToolStripStatusLabel tls;
	private System.Windows.Forms.DataGridView dtgfio;
	private System.Windows.Forms.MenuStrip menuStrip1;
	private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
	private System.Windows.Forms.TextBox txtFind;
	private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnaddClient;
	private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
    }
}