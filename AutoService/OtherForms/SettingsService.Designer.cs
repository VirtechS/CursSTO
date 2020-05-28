namespace AutoService.OtherForms
{
    partial class SettingsService
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
	    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsService));
	    this.label2 = new System.Windows.Forms.Label();
	    this.label1 = new System.Windows.Forms.Label();
	    this.txtDetails = new System.Windows.Forms.TextBox();
	    this.lblName = new System.Windows.Forms.Label();
	    this.txtNameService = new System.Windows.Forms.TextBox();
	    this.numPrice = new System.Windows.Forms.NumericUpDown();
	    this.label3 = new System.Windows.Forms.Label();
	    this.btnSettings = new System.Windows.Forms.Button();
	    this.menuStrip1 = new System.Windows.Forms.MenuStrip();
	    this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	    this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	    ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
	    this.menuStrip1.SuspendLayout();
	    this.SuspendLayout();
	    // 
	    // label2
	    // 
	    this.label2.AutoSize = true;
	    this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	    this.label2.Location = new System.Drawing.Point(12, 75);
	    this.label2.Name = "label2";
	    this.label2.Size = new System.Drawing.Size(76, 16);
	    this.label2.TabIndex = 30;
	    this.label2.Text = "Описание:";
	    // 
	    // label1
	    // 
	    this.label1.AutoSize = true;
	    this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	    this.label1.Location = new System.Drawing.Point(12, 245);
	    this.label1.Name = "label1";
	    this.label1.Size = new System.Drawing.Size(81, 16);
	    this.label1.TabIndex = 29;
	    this.label1.Text = "Стоимость:";
	    // 
	    // txtDetails
	    // 
	    this.txtDetails.Location = new System.Drawing.Point(12, 94);
	    this.txtDetails.Multiline = true;
	    this.txtDetails.Name = "txtDetails";
	    this.txtDetails.Size = new System.Drawing.Size(454, 127);
	    this.txtDetails.TabIndex = 28;
	    // 
	    // lblName
	    // 
	    this.lblName.AutoSize = true;
	    this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	    this.lblName.Location = new System.Drawing.Point(32, 31);
	    this.lblName.Name = "lblName";
	    this.lblName.Size = new System.Drawing.Size(158, 16);
	    this.lblName.TabIndex = 27;
	    this.lblName.Text = "Наименование услуги:";
	    // 
	    // txtNameService
	    // 
	    this.txtNameService.Location = new System.Drawing.Point(196, 31);
	    this.txtNameService.Multiline = true;
	    this.txtNameService.Name = "txtNameService";
	    this.txtNameService.Size = new System.Drawing.Size(270, 47);
	    this.txtNameService.TabIndex = 26;
	    // 
	    // numPrice
	    // 
	    this.numPrice.Location = new System.Drawing.Point(15, 264);
	    this.numPrice.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
	    this.numPrice.Name = "numPrice";
	    this.numPrice.Size = new System.Drawing.Size(214, 20);
	    this.numPrice.TabIndex = 32;
	    // 
	    // label3
	    // 
	    this.label3.AutoSize = true;
	    this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	    this.label3.Location = new System.Drawing.Point(235, 266);
	    this.label3.Name = "label3";
	    this.label3.Size = new System.Drawing.Size(18, 13);
	    this.label3.TabIndex = 33;
	    this.label3.Text = "р.";
	    // 
	    // btnSettings
	    // 
	    this.btnSettings.Location = new System.Drawing.Point(277, 256);
	    this.btnSettings.Name = "btnSettings";
	    this.btnSettings.Size = new System.Drawing.Size(189, 32);
	    this.btnSettings.TabIndex = 34;
	    this.btnSettings.Text = "button1";
	    this.btnSettings.UseVisualStyleBackColor = true;
	    this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
	    // 
	    // menuStrip1
	    // 
	    this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem,
            this.закрытьToolStripMenuItem});
	    this.menuStrip1.Location = new System.Drawing.Point(0, 0);
	    this.menuStrip1.Name = "menuStrip1";
	    this.menuStrip1.Size = new System.Drawing.Size(479, 24);
	    this.menuStrip1.TabIndex = 35;
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
	    // 
	    // SettingsService
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.ClientSize = new System.Drawing.Size(479, 303);
	    this.Controls.Add(this.menuStrip1);
	    this.Controls.Add(this.btnSettings);
	    this.Controls.Add(this.label3);
	    this.Controls.Add(this.numPrice);
	    this.Controls.Add(this.label2);
	    this.Controls.Add(this.label1);
	    this.Controls.Add(this.txtDetails);
	    this.Controls.Add(this.lblName);
	    this.Controls.Add(this.txtNameService);
	    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
	    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	    this.MaximizeBox = false;
	    this.Name = "SettingsService";
	    this.Text = "Редактирование";
	    this.Load += new System.EventHandler(this.SettingsService_Load);
	    ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
	    this.menuStrip1.ResumeLayout(false);
	    this.menuStrip1.PerformLayout();
	    this.ResumeLayout(false);
	    this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.TextBox txtDetails;
	private System.Windows.Forms.Label lblName;
	private System.Windows.Forms.TextBox txtNameService;
	private System.Windows.Forms.NumericUpDown numPrice;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.Button btnSettings;
	private System.Windows.Forms.MenuStrip menuStrip1;
	private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
    }
}