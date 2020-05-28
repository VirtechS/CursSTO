namespace AutoService.Forms
{
    partial class MastersForm
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
	    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MastersForm));
	    this.label1 = new System.Windows.Forms.Label();
	    this.txtFind = new System.Windows.Forms.TextBox();
	    this.dtgMasters = new System.Windows.Forms.DataGridView();
	    this.btnSettMaaster = new System.Windows.Forms.Button();
	    this.btnAddMaster = new System.Windows.Forms.Button();
	    this.statusStrip1 = new System.Windows.Forms.StatusStrip();
	    this.tlsInfoCount = new System.Windows.Forms.ToolStripStatusLabel();
	    this.dtpClient = new System.Windows.Forms.DateTimePicker();
	    this.btnFindDate = new System.Windows.Forms.Button();
	    this.picBox = new System.Windows.Forms.PictureBox();
	    this.menuStrip1 = new System.Windows.Forms.MenuStrip();
	    this.infoMenu = new System.Windows.Forms.ToolStripMenuItem();
	    this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	    this.radioButton4 = new System.Windows.Forms.RadioButton();
	    this.radioButton3 = new System.Windows.Forms.RadioButton();
	    this.radioButton2 = new System.Windows.Forms.RadioButton();
	    this.radioButton1 = new System.Windows.Forms.RadioButton();
	    this.label3 = new System.Windows.Forms.Label();
	    ((System.ComponentModel.ISupportInitialize)(this.dtgMasters)).BeginInit();
	    this.statusStrip1.SuspendLayout();
	    ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
	    this.menuStrip1.SuspendLayout();
	    this.SuspendLayout();
	    // 
	    // label1
	    // 
	    this.label1.AutoSize = true;
	    this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	    this.label1.Location = new System.Drawing.Point(24, 38);
	    this.label1.Name = "label1";
	    this.label1.Size = new System.Drawing.Size(56, 18);
	    this.label1.TabIndex = 10;
	    this.label1.Text = "Поиск:";
	    // 
	    // txtFind
	    // 
	    this.txtFind.Location = new System.Drawing.Point(86, 38);
	    this.txtFind.Name = "txtFind";
	    this.txtFind.Size = new System.Drawing.Size(553, 20);
	    this.txtFind.TabIndex = 9;
	    this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
	    // 
	    // dtgMasters
	    // 
	    this.dtgMasters.AllowUserToResizeColumns = false;
	    this.dtgMasters.AllowUserToResizeRows = false;
	    this.dtgMasters.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
	    this.dtgMasters.GridColor = System.Drawing.SystemColors.ButtonFace;
	    this.dtgMasters.Location = new System.Drawing.Point(27, 64);
	    this.dtgMasters.MultiSelect = false;
	    this.dtgMasters.Name = "dtgMasters";
	    this.dtgMasters.ReadOnly = true;
	    this.dtgMasters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
	    this.dtgMasters.Size = new System.Drawing.Size(612, 267);
	    this.dtgMasters.TabIndex = 7;
	    this.dtgMasters.SelectionChanged += new System.EventHandler(this.dtgMasters_SelectionChanged);
	    // 
	    // btnSettMaaster
	    // 
	    this.btnSettMaaster.Location = new System.Drawing.Point(664, 301);
	    this.btnSettMaaster.Name = "btnSettMaaster";
	    this.btnSettMaaster.Size = new System.Drawing.Size(152, 30);
	    this.btnSettMaaster.TabIndex = 17;
	    this.btnSettMaaster.Text = "Редактировать";
	    this.btnSettMaaster.UseVisualStyleBackColor = true;
	    this.btnSettMaaster.Click += new System.EventHandler(this.btnSettMaaster_Click);
	    // 
	    // btnAddMaster
	    // 
	    this.btnAddMaster.Location = new System.Drawing.Point(664, 265);
	    this.btnAddMaster.Name = "btnAddMaster";
	    this.btnAddMaster.Size = new System.Drawing.Size(152, 30);
	    this.btnAddMaster.TabIndex = 16;
	    this.btnAddMaster.Text = "Добавить";
	    this.btnAddMaster.UseVisualStyleBackColor = true;
	    this.btnAddMaster.Click += new System.EventHandler(this.btnAddMaster_Click);
	    // 
	    // statusStrip1
	    // 
	    this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsInfoCount});
	    this.statusStrip1.Location = new System.Drawing.Point(0, 376);
	    this.statusStrip1.Name = "statusStrip1";
	    this.statusStrip1.Size = new System.Drawing.Size(837, 22);
	    this.statusStrip1.SizingGrip = false;
	    this.statusStrip1.TabIndex = 19;
	    this.statusStrip1.Text = "statusStrip1";
	    // 
	    // tlsInfoCount
	    // 
	    this.tlsInfoCount.Name = "tlsInfoCount";
	    this.tlsInfoCount.Size = new System.Drawing.Size(0, 17);
	    // 
	    // dtpClient
	    // 
	    this.dtpClient.Location = new System.Drawing.Point(224, 345);
	    this.dtpClient.Name = "dtpClient";
	    this.dtpClient.Size = new System.Drawing.Size(141, 20);
	    this.dtpClient.TabIndex = 20;
	    // 
	    // btnFindDate
	    // 
	    this.btnFindDate.Location = new System.Drawing.Point(371, 342);
	    this.btnFindDate.Name = "btnFindDate";
	    this.btnFindDate.Size = new System.Drawing.Size(141, 25);
	    this.btnFindDate.TabIndex = 21;
	    this.btnFindDate.Text = "Найти по дате";
	    this.btnFindDate.UseVisualStyleBackColor = true;
	    this.btnFindDate.Click += new System.EventHandler(this.btnFindDate_Click);
	    // 
	    // picBox
	    // 
	    this.picBox.BackColor = System.Drawing.SystemColors.ControlLight;
	    this.picBox.Location = new System.Drawing.Point(664, 64);
	    this.picBox.Name = "picBox";
	    this.picBox.Size = new System.Drawing.Size(152, 194);
	    this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
	    this.picBox.TabIndex = 18;
	    this.picBox.TabStop = false;
	    // 
	    // menuStrip1
	    // 
	    this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoMenu,
            this.закрытьToolStripMenuItem});
	    this.menuStrip1.Location = new System.Drawing.Point(0, 0);
	    this.menuStrip1.Name = "menuStrip1";
	    this.menuStrip1.Size = new System.Drawing.Size(837, 24);
	    this.menuStrip1.TabIndex = 22;
	    this.menuStrip1.Text = "menuStrip1";
	    // 
	    // infoMenu
	    // 
	    this.infoMenu.Name = "infoMenu";
	    this.infoMenu.Size = new System.Drawing.Size(65, 20);
	    this.infoMenu.Text = "Справка";
	    this.infoMenu.Click += new System.EventHandler(this.infoMenu_Click);
	    // 
	    // закрытьToolStripMenuItem
	    // 
	    this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
	    this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
	    this.закрытьToolStripMenuItem.Text = "Закрыть";
	    this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
	    // 
	    // radioButton4
	    // 
	    this.radioButton4.Appearance = System.Windows.Forms.Appearance.Button;
	    this.radioButton4.AutoSize = true;
	    this.radioButton4.Checked = true;
	    this.radioButton4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	    this.radioButton4.Location = new System.Drawing.Point(133, 342);
	    this.radioButton4.Name = "radioButton4";
	    this.radioButton4.Size = new System.Drawing.Size(25, 24);
	    this.radioButton4.TabIndex = 46;
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
	    this.radioButton3.Location = new System.Drawing.Point(103, 342);
	    this.radioButton3.Name = "radioButton3";
	    this.radioButton3.Size = new System.Drawing.Size(24, 24);
	    this.radioButton3.TabIndex = 45;
	    this.radioButton3.Tag = "=";
	    this.radioButton3.Text = "=";
	    this.radioButton3.UseVisualStyleBackColor = true;
	    // 
	    // radioButton2
	    // 
	    this.radioButton2.Appearance = System.Windows.Forms.Appearance.Button;
	    this.radioButton2.AutoSize = true;
	    this.radioButton2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	    this.radioButton2.Location = new System.Drawing.Point(164, 342);
	    this.radioButton2.Name = "radioButton2";
	    this.radioButton2.Size = new System.Drawing.Size(24, 24);
	    this.radioButton2.TabIndex = 44;
	    this.radioButton2.Tag = "≤";
	    this.radioButton2.Text = "≤";
	    this.radioButton2.UseVisualStyleBackColor = true;
	    // 
	    // radioButton1
	    // 
	    this.radioButton1.Appearance = System.Windows.Forms.Appearance.Button;
	    this.radioButton1.AutoSize = true;
	    this.radioButton1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	    this.radioButton1.Location = new System.Drawing.Point(194, 342);
	    this.radioButton1.Name = "radioButton1";
	    this.radioButton1.Size = new System.Drawing.Size(24, 24);
	    this.radioButton1.TabIndex = 43;
	    this.radioButton1.Tag = "≥";
	    this.radioButton1.Text = "≥";
	    this.radioButton1.UseVisualStyleBackColor = true;
	    // 
	    // label3
	    // 
	    this.label3.AutoSize = true;
	    this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	    this.label3.Location = new System.Drawing.Point(24, 342);
	    this.label3.Name = "label3";
	    this.label3.Size = new System.Drawing.Size(60, 18);
	    this.label3.TabIndex = 42;
	    this.label3.Text = "Режим:";
	    // 
	    // MastersForm
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.ClientSize = new System.Drawing.Size(837, 398);
	    this.Controls.Add(this.radioButton4);
	    this.Controls.Add(this.radioButton3);
	    this.Controls.Add(this.radioButton2);
	    this.Controls.Add(this.radioButton1);
	    this.Controls.Add(this.label3);
	    this.Controls.Add(this.menuStrip1);
	    this.Controls.Add(this.btnFindDate);
	    this.Controls.Add(this.dtpClient);
	    this.Controls.Add(this.statusStrip1);
	    this.Controls.Add(this.picBox);
	    this.Controls.Add(this.btnSettMaaster);
	    this.Controls.Add(this.btnAddMaster);
	    this.Controls.Add(this.label1);
	    this.Controls.Add(this.txtFind);
	    this.Controls.Add(this.dtgMasters);
	    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
	    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	    this.MaximizeBox = false;
	    this.Name = "MastersForm";
	    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	    this.Text = "Мастера";
	    this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MastersForm_FormClosing);
	    this.Load += new System.EventHandler(this.MastersForm_Load);
	    ((System.ComponentModel.ISupportInitialize)(this.dtgMasters)).EndInit();
	    this.statusStrip1.ResumeLayout(false);
	    this.statusStrip1.PerformLayout();
	    ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
	    this.menuStrip1.ResumeLayout(false);
	    this.menuStrip1.PerformLayout();
	    this.ResumeLayout(false);
	    this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.TextBox txtFind;
	private System.Windows.Forms.DataGridView dtgMasters;
	private System.Windows.Forms.PictureBox picBox;
	private System.Windows.Forms.Button btnSettMaaster;
	private System.Windows.Forms.Button btnAddMaster;
	private System.Windows.Forms.StatusStrip statusStrip1;
	private System.Windows.Forms.ToolStripStatusLabel tlsInfoCount;
	private System.Windows.Forms.DateTimePicker dtpClient;
	private System.Windows.Forms.Button btnFindDate;
	private System.Windows.Forms.MenuStrip menuStrip1;
	private System.Windows.Forms.ToolStripMenuItem infoMenu;
	private System.Windows.Forms.RadioButton radioButton4;
	private System.Windows.Forms.RadioButton radioButton3;
	private System.Windows.Forms.RadioButton radioButton2;
	private System.Windows.Forms.RadioButton radioButton1;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
    }
}