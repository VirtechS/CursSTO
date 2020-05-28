namespace AutoService.OtherForms
{
    partial class SettingsMasterForm
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
	    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsMasterForm));
	    this.txtName = new System.Windows.Forms.TextBox();
	    this.txtSurname = new System.Windows.Forms.TextBox();
	    this.txtPatron = new System.Windows.Forms.TextBox();
	    this.label1 = new System.Windows.Forms.Label();
	    this.label2 = new System.Windows.Forms.Label();
	    this.label3 = new System.Windows.Forms.Label();
	    this.label4 = new System.Windows.Forms.Label();
	    this.label5 = new System.Windows.Forms.Label();
	    this.dtpDateBirthday = new System.Windows.Forms.DateTimePicker();
	    this.deletePicture = new System.Windows.Forms.Button();
	    this.btnGetPicture = new System.Windows.Forms.Button();
	    this.btnSettings = new System.Windows.Forms.Button();
	    this.picBox = new System.Windows.Forms.PictureBox();
	    this.FileDilogPicture = new System.Windows.Forms.OpenFileDialog();
	    this.txtPhone = new System.Windows.Forms.TextBox();
	    this.menuStrip1 = new System.Windows.Forms.MenuStrip();
	    this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	    this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	    ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
	    this.menuStrip1.SuspendLayout();
	    this.SuspendLayout();
	    // 
	    // txtName
	    // 
	    this.txtName.Location = new System.Drawing.Point(106, 70);
	    this.txtName.Name = "txtName";
	    this.txtName.Size = new System.Drawing.Size(166, 20);
	    this.txtName.TabIndex = 0;
	    this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
	    // 
	    // txtSurname
	    // 
	    this.txtSurname.Location = new System.Drawing.Point(106, 37);
	    this.txtSurname.Name = "txtSurname";
	    this.txtSurname.Size = new System.Drawing.Size(166, 20);
	    this.txtSurname.TabIndex = 1;
	    this.txtSurname.TextChanged += new System.EventHandler(this.txtSurname_TextChanged);
	    // 
	    // txtPatron
	    // 
	    this.txtPatron.Location = new System.Drawing.Point(106, 103);
	    this.txtPatron.Name = "txtPatron";
	    this.txtPatron.Size = new System.Drawing.Size(166, 20);
	    this.txtPatron.TabIndex = 2;
	    this.txtPatron.TextChanged += new System.EventHandler(this.txtPatron_TextChanged);
	    // 
	    // label1
	    // 
	    this.label1.AutoSize = true;
	    this.label1.Location = new System.Drawing.Point(68, 73);
	    this.label1.Name = "label1";
	    this.label1.Size = new System.Drawing.Size(32, 13);
	    this.label1.TabIndex = 6;
	    this.label1.Text = "Имя:";
	    // 
	    // label2
	    // 
	    this.label2.AutoSize = true;
	    this.label2.Location = new System.Drawing.Point(41, 40);
	    this.label2.Name = "label2";
	    this.label2.Size = new System.Drawing.Size(59, 13);
	    this.label2.TabIndex = 7;
	    this.label2.Text = "Фамилия:";
	    // 
	    // label3
	    // 
	    this.label3.AutoSize = true;
	    this.label3.Location = new System.Drawing.Point(43, 106);
	    this.label3.Name = "label3";
	    this.label3.Size = new System.Drawing.Size(57, 13);
	    this.label3.TabIndex = 8;
	    this.label3.Text = "Отчество:";
	    // 
	    // label4
	    // 
	    this.label4.AutoSize = true;
	    this.label4.Location = new System.Drawing.Point(11, 145);
	    this.label4.Name = "label4";
	    this.label4.Size = new System.Drawing.Size(89, 13);
	    this.label4.TabIndex = 9;
	    this.label4.Text = "Дата рождения:";
	    // 
	    // label5
	    // 
	    this.label5.AutoSize = true;
	    this.label5.Location = new System.Drawing.Point(45, 181);
	    this.label5.Name = "label5";
	    this.label5.Size = new System.Drawing.Size(55, 13);
	    this.label5.TabIndex = 10;
	    this.label5.Text = "Телефон:";
	    // 
	    // dtpDateBirthday
	    // 
	    this.dtpDateBirthday.Location = new System.Drawing.Point(106, 145);
	    this.dtpDateBirthday.Name = "dtpDateBirthday";
	    this.dtpDateBirthday.Size = new System.Drawing.Size(166, 20);
	    this.dtpDateBirthday.TabIndex = 11;
	    this.dtpDateBirthday.Value = new System.DateTime(2017, 6, 6, 1, 50, 2, 0);
	    // 
	    // deletePicture
	    // 
	    this.deletePicture.Location = new System.Drawing.Point(300, 274);
	    this.deletePicture.Name = "deletePicture";
	    this.deletePicture.Size = new System.Drawing.Size(152, 28);
	    this.deletePicture.TabIndex = 21;
	    this.deletePicture.Text = "Удалить изображение";
	    this.deletePicture.UseVisualStyleBackColor = true;
	    this.deletePicture.Click += new System.EventHandler(this.deletePicture_Click);
	    // 
	    // btnGetPicture
	    // 
	    this.btnGetPicture.Location = new System.Drawing.Point(300, 238);
	    this.btnGetPicture.Name = "btnGetPicture";
	    this.btnGetPicture.Size = new System.Drawing.Size(152, 28);
	    this.btnGetPicture.TabIndex = 19;
	    this.btnGetPicture.Text = "Обзор...";
	    this.btnGetPicture.UseVisualStyleBackColor = true;
	    this.btnGetPicture.Click += new System.EventHandler(this.btnGetPicture_Click);
	    // 
	    // btnSettings
	    // 
	    this.btnSettings.Location = new System.Drawing.Point(22, 238);
	    this.btnSettings.Name = "btnSettings";
	    this.btnSettings.Size = new System.Drawing.Size(261, 28);
	    this.btnSettings.TabIndex = 18;
	    this.btnSettings.Text = "button1";
	    this.btnSettings.UseVisualStyleBackColor = true;
	    this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
	    // 
	    // picBox
	    // 
	    this.picBox.BackColor = System.Drawing.SystemColors.ControlLight;
	    this.picBox.Location = new System.Drawing.Point(300, 37);
	    this.picBox.Name = "picBox";
	    this.picBox.Size = new System.Drawing.Size(152, 194);
	    this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
	    this.picBox.TabIndex = 22;
	    this.picBox.TabStop = false;
	    // 
	    // FileDilogPicture
	    // 
	    this.FileDilogPicture.FileName = "openFileDialog1";
	    // 
	    // txtPhone
	    // 
	    this.txtPhone.Location = new System.Drawing.Point(106, 178);
	    this.txtPhone.Name = "txtPhone";
	    this.txtPhone.Size = new System.Drawing.Size(166, 20);
	    this.txtPhone.TabIndex = 23;
	    this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
	    // 
	    // menuStrip1
	    // 
	    this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem,
            this.закрытьToolStripMenuItem});
	    this.menuStrip1.Location = new System.Drawing.Point(0, 0);
	    this.menuStrip1.Name = "menuStrip1";
	    this.menuStrip1.Size = new System.Drawing.Size(464, 24);
	    this.menuStrip1.TabIndex = 24;
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
	    // SettingsMasterForm
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.ClientSize = new System.Drawing.Size(464, 322);
	    this.Controls.Add(this.menuStrip1);
	    this.Controls.Add(this.txtPhone);
	    this.Controls.Add(this.picBox);
	    this.Controls.Add(this.deletePicture);
	    this.Controls.Add(this.btnGetPicture);
	    this.Controls.Add(this.btnSettings);
	    this.Controls.Add(this.dtpDateBirthday);
	    this.Controls.Add(this.label5);
	    this.Controls.Add(this.label4);
	    this.Controls.Add(this.label3);
	    this.Controls.Add(this.label2);
	    this.Controls.Add(this.label1);
	    this.Controls.Add(this.txtPatron);
	    this.Controls.Add(this.txtSurname);
	    this.Controls.Add(this.txtName);
	    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
	    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	    this.MaximizeBox = false;
	    this.Name = "SettingsMasterForm";
	    this.Text = "Редактирование";
	    this.Load += new System.EventHandler(this.SettingsMasterForm_Load);
	    ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
	    this.menuStrip1.ResumeLayout(false);
	    this.menuStrip1.PerformLayout();
	    this.ResumeLayout(false);
	    this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.TextBox txtName;
	private System.Windows.Forms.TextBox txtSurname;
	private System.Windows.Forms.TextBox txtPatron;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.Label label5;
	private System.Windows.Forms.DateTimePicker dtpDateBirthday;
	private System.Windows.Forms.Button deletePicture;
	private System.Windows.Forms.Button btnGetPicture;
	public System.Windows.Forms.Button btnSettings;
	private System.Windows.Forms.PictureBox picBox;
	private System.Windows.Forms.OpenFileDialog FileDilogPicture;
	private System.Windows.Forms.TextBox txtPhone;
	private System.Windows.Forms.MenuStrip menuStrip1;
	private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
	private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
    }
}