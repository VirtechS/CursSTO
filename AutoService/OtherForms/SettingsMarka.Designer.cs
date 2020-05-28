namespace AutoService
{
    partial class SettingsMarka
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
	    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsMarka));
	    this.btnSettings = new System.Windows.Forms.Button();
	    this.txtNameCar = new System.Windows.Forms.TextBox();
	    this.lblName = new System.Windows.Forms.Label();
	    this.btnGetPicture = new System.Windows.Forms.Button();
	    this.picBox = new System.Windows.Forms.PictureBox();
	    this.FileDilogPicture = new System.Windows.Forms.OpenFileDialog();
	    this.deletePicture = new System.Windows.Forms.Button();
	    this.menuStrip1 = new System.Windows.Forms.MenuStrip();
	    this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	    this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	    ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
	    this.menuStrip1.SuspendLayout();
	    this.SuspendLayout();
	    // 
	    // btnSettings
	    // 
	    this.btnSettings.Location = new System.Drawing.Point(198, 311);
	    this.btnSettings.Name = "btnSettings";
	    this.btnSettings.Size = new System.Drawing.Size(172, 56);
	    this.btnSettings.TabIndex = 0;
	    this.btnSettings.Text = "button1";
	    this.btnSettings.UseVisualStyleBackColor = true;
	    this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
	    // 
	    // txtNameCar
	    // 
	    this.txtNameCar.Location = new System.Drawing.Point(67, 44);
	    this.txtNameCar.Name = "txtNameCar";
	    this.txtNameCar.Size = new System.Drawing.Size(254, 20);
	    this.txtNameCar.TabIndex = 4;
	    // 
	    // lblName
	    // 
	    this.lblName.AutoSize = true;
	    this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	    this.lblName.Location = new System.Drawing.Point(12, 46);
	    this.lblName.Name = "lblName";
	    this.lblName.Size = new System.Drawing.Size(53, 16);
	    this.lblName.TabIndex = 5;
	    this.lblName.Text = "Марка:";
	    // 
	    // btnGetPicture
	    // 
	    this.btnGetPicture.Location = new System.Drawing.Point(21, 311);
	    this.btnGetPicture.Name = "btnGetPicture";
	    this.btnGetPicture.Size = new System.Drawing.Size(171, 25);
	    this.btnGetPicture.TabIndex = 6;
	    this.btnGetPicture.Text = "Обзор...";
	    this.btnGetPicture.UseVisualStyleBackColor = true;
	    this.btnGetPicture.Click += new System.EventHandler(this.btnGetPicture_Click);
	    // 
	    // picBox
	    // 
	    this.picBox.BackColor = System.Drawing.SystemColors.ControlLight;
	    this.picBox.Location = new System.Drawing.Point(67, 70);
	    this.picBox.Name = "picBox";
	    this.picBox.Size = new System.Drawing.Size(254, 235);
	    this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
	    this.picBox.TabIndex = 16;
	    this.picBox.TabStop = false;
	    // 
	    // FileDilogPicture
	    // 
	    this.FileDilogPicture.FileName = "openFileDialog1";
	    // 
	    // deletePicture
	    // 
	    this.deletePicture.Location = new System.Drawing.Point(21, 342);
	    this.deletePicture.Name = "deletePicture";
	    this.deletePicture.Size = new System.Drawing.Size(171, 25);
	    this.deletePicture.TabIndex = 17;
	    this.deletePicture.Text = "Удалить изображение";
	    this.deletePicture.UseVisualStyleBackColor = true;
	    this.deletePicture.Click += new System.EventHandler(this.deletePicture_Click);
	    // 
	    // menuStrip1
	    // 
	    this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem,
            this.закрытьToolStripMenuItem});
	    this.menuStrip1.Location = new System.Drawing.Point(0, 0);
	    this.menuStrip1.Name = "menuStrip1";
	    this.menuStrip1.Size = new System.Drawing.Size(390, 24);
	    this.menuStrip1.TabIndex = 18;
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
	    // SettingsMarka
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.ClientSize = new System.Drawing.Size(390, 378);
	    this.Controls.Add(this.menuStrip1);
	    this.Controls.Add(this.deletePicture);
	    this.Controls.Add(this.picBox);
	    this.Controls.Add(this.btnGetPicture);
	    this.Controls.Add(this.lblName);
	    this.Controls.Add(this.txtNameCar);
	    this.Controls.Add(this.btnSettings);
	    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	    this.Name = "SettingsMarka";
	    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
	    this.Text = "Редактирование";
	    this.Load += new System.EventHandler(this.SettingsMasters_Load);
	    ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
	    this.menuStrip1.ResumeLayout(false);
	    this.menuStrip1.PerformLayout();
	    this.ResumeLayout(false);
	    this.PerformLayout();

	}

	#endregion

	public System.Windows.Forms.Button btnSettings;
	private System.Windows.Forms.Label lblName;
	public System.Windows.Forms.TextBox txtNameCar;
	private System.Windows.Forms.Button btnGetPicture;
	private System.Windows.Forms.PictureBox picBox;
	private System.Windows.Forms.OpenFileDialog FileDilogPicture;
	private System.Windows.Forms.Button deletePicture;
	private System.Windows.Forms.MenuStrip menuStrip1;
	private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
    }
}