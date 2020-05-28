namespace AutoService.Forms
{
    partial class ClientsForm
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

	

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientsForm));
            this.txtFind = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtgfio = new System.Windows.Forms.DataGridView();
            this.dtgCars = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewClient = new System.Windows.Forms.Button();
            this.btnSettClient_car = new System.Windows.Forms.Button();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFindDate = new System.Windows.Forms.Button();
            this.dtpClient = new System.Windows.Forms.DateTimePicker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tls = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgfio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCars)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(73, 37);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(489, 20);
            this.txtFind.TabIndex = 10;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem,
            this.закрытьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(861, 24);
            this.menuStrip1.TabIndex = 9;
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
            // dtgfio
            // 
            this.dtgfio.AllowUserToResizeColumns = false;
            this.dtgfio.AllowUserToResizeRows = false;
            this.dtgfio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgfio.Location = new System.Drawing.Point(15, 63);
            this.dtgfio.MultiSelect = false;
            this.dtgfio.Name = "dtgfio";
            this.dtgfio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgfio.Size = new System.Drawing.Size(547, 171);
            this.dtgfio.TabIndex = 12;
            this.dtgfio.SelectionChanged += new System.EventHandler(this.dtgfio_SelectionChanged);
            // 
            // dtgCars
            // 
            this.dtgCars.AllowUserToResizeColumns = false;
            this.dtgCars.AllowUserToResizeRows = false;
            this.dtgCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCars.Location = new System.Drawing.Point(568, 63);
            this.dtgCars.MultiSelect = false;
            this.dtgCars.Name = "dtgCars";
            this.dtgCars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgCars.Size = new System.Drawing.Size(274, 171);
            this.dtgCars.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Agency FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Поиск:";
            // 
            // btnNewClient
            // 
            this.btnNewClient.Location = new System.Drawing.Point(568, 247);
            this.btnNewClient.Name = "btnNewClient";
            this.btnNewClient.Size = new System.Drawing.Size(130, 25);
            this.btnNewClient.TabIndex = 15;
            this.btnNewClient.Text = "Новый клиент";
            this.btnNewClient.UseVisualStyleBackColor = true;
            this.btnNewClient.Click += new System.EventHandler(this.btnNewClient_Click);
            // 
            // btnSettClient_car
            // 
            this.btnSettClient_car.Location = new System.Drawing.Point(712, 247);
            this.btnSettClient_car.Name = "btnSettClient_car";
            this.btnSettClient_car.Size = new System.Drawing.Size(130, 25);
            this.btnSettClient_car.TabIndex = 16;
            this.btnSettClient_car.Text = "Редактировать";
            this.btnSettClient_car.UseVisualStyleBackColor = true;
            this.btnSettClient_car.Click += new System.EventHandler(this.btnSettClient_car_Click);
            // 
            // radioButton4
            // 
            this.radioButton4.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton4.Location = new System.Drawing.Point(121, 247);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(25, 24);
            this.radioButton4.TabIndex = 53;
            this.radioButton4.TabStop = true;
            this.radioButton4.Tag = "∀";
            this.radioButton4.Text = "∀";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(91, 247);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(24, 24);
            this.radioButton3.TabIndex = 52;
            this.radioButton3.Tag = "=";
            this.radioButton3.Text = "=";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(152, 247);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(24, 24);
            this.radioButton2.TabIndex = 51;
            this.radioButton2.Tag = "≤";
            this.radioButton2.Text = "≤";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(182, 247);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(24, 24);
            this.radioButton1.TabIndex = 50;
            this.radioButton1.Tag = "≥";
            this.radioButton1.Text = "≥";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 18);
            this.label3.TabIndex = 49;
            this.label3.Text = "Режим:";
            // 
            // btnFindDate
            // 
            this.btnFindDate.Location = new System.Drawing.Point(359, 247);
            this.btnFindDate.Name = "btnFindDate";
            this.btnFindDate.Size = new System.Drawing.Size(130, 25);
            this.btnFindDate.TabIndex = 48;
            this.btnFindDate.Text = "Найти по дате";
            this.btnFindDate.UseVisualStyleBackColor = true;
            this.btnFindDate.Click += new System.EventHandler(this.btnFindDate_Click);
            // 
            // dtpClient
            // 
            this.dtpClient.Location = new System.Drawing.Point(212, 250);
            this.dtpClient.Name = "dtpClient";
            this.dtpClient.Size = new System.Drawing.Size(141, 20);
            this.dtpClient.TabIndex = 47;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tls});
            this.statusStrip1.Location = new System.Drawing.Point(0, 288);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(861, 22);
            this.statusStrip1.TabIndex = 54;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tls
            // 
            this.tls.Name = "tls";
            this.tls.Size = new System.Drawing.Size(0, 17);
            // 
            // ClientsForm
            // 
            this.ClientSize = new System.Drawing.Size(861, 310);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFindDate);
            this.Controls.Add(this.dtpClient);
            this.Controls.Add(this.btnSettClient_car);
            this.Controls.Add(this.btnNewClient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgCars);
            this.Controls.Add(this.dtgfio);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ClientsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиенты";
            this.Load += new System.EventHandler(this.ClientsForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgfio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCars)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

	}
    private System.Windows.Forms.TextBox txtFind;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
	private System.Windows.Forms.DataGridView dtgfio;
	private System.Windows.Forms.DataGridView dtgCars;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Button btnNewClient;
	private System.Windows.Forms.Button btnSettClient_car;
	private System.Windows.Forms.RadioButton radioButton4;
	private System.Windows.Forms.RadioButton radioButton3;
	private System.Windows.Forms.RadioButton radioButton2;
	private System.Windows.Forms.RadioButton radioButton1;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.Button btnFindDate;
	private System.Windows.Forms.DateTimePicker dtpClient;
	private System.Windows.Forms.StatusStrip statusStrip1;
	private System.Windows.Forms.ToolStripStatusLabel tls;
    }
}