namespace AutoService.Forms
{
    partial class ServicesForm
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
	    System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
	    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServicesForm));
	    this.lblName = new System.Windows.Forms.Label();
	    this.btnSettService = new System.Windows.Forms.Button();
	    this.btnAddService = new System.Windows.Forms.Button();
	    this.txtNameService = new System.Windows.Forms.TextBox();
	    this.menuStrip1 = new System.Windows.Forms.MenuStrip();
	    this.infoMenu = new System.Windows.Forms.ToolStripMenuItem();
	    this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	    this.dtgService = new System.Windows.Forms.DataGridView();
	    this.txtDetails = new System.Windows.Forms.TextBox();
	    this.lblPrice2 = new System.Windows.Forms.Label();
	    this.label2 = new System.Windows.Forms.Label();
	    this.statusStrip1 = new System.Windows.Forms.StatusStrip();
	    this.tlsInfoCountCar = new System.Windows.Forms.ToolStripStatusLabel();
	    this.lblPrice1 = new System.Windows.Forms.Label();
	    this.label1 = new System.Windows.Forms.Label();
	    this.checkHold = new System.Windows.Forms.CheckBox();
	    this.label3 = new System.Windows.Forms.Label();
	    this.radioButton4 = new System.Windows.Forms.RadioButton();
	    this.radioButton3 = new System.Windows.Forms.RadioButton();
	    this.radioButton2 = new System.Windows.Forms.RadioButton();
	    this.radioButton1 = new System.Windows.Forms.RadioButton();
	    this.numPrice = new System.Windows.Forms.TextBox();
	    this.menuStrip1.SuspendLayout();
	    ((System.ComponentModel.ISupportInitialize)(this.dtgService)).BeginInit();
	    this.statusStrip1.SuspendLayout();
	    this.SuspendLayout();
	    // 
	    // lblName
	    // 
	    this.lblName.AutoSize = true;
	    this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	    this.lblName.Location = new System.Drawing.Point(13, 37);
	    this.lblName.Name = "lblName";
	    this.lblName.Size = new System.Drawing.Size(56, 18);
	    this.lblName.TabIndex = 21;
	    this.lblName.Text = "Поиск:";
	    // 
	    // btnSettService
	    // 
	    this.btnSettService.Location = new System.Drawing.Point(409, 340);
	    this.btnSettService.Name = "btnSettService";
	    this.btnSettService.Size = new System.Drawing.Size(341, 23);
	    this.btnSettService.TabIndex = 20;
	    this.btnSettService.Text = "Редактировать";
	    this.btnSettService.UseVisualStyleBackColor = true;
	    this.btnSettService.Click += new System.EventHandler(this.btnSettService_Click);
	    // 
	    // btnAddService
	    // 
	    this.btnAddService.Location = new System.Drawing.Point(409, 311);
	    this.btnAddService.Name = "btnAddService";
	    this.btnAddService.Size = new System.Drawing.Size(341, 23);
	    this.btnAddService.TabIndex = 19;
	    this.btnAddService.Text = "Добавить";
	    this.btnAddService.UseVisualStyleBackColor = true;
	    this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
	    // 
	    // txtNameService
	    // 
	    this.txtNameService.Location = new System.Drawing.Point(75, 38);
	    this.txtNameService.Name = "txtNameService";
	    this.txtNameService.Size = new System.Drawing.Size(263, 20);
	    this.txtNameService.TabIndex = 18;
	    this.txtNameService.TextChanged += new System.EventHandler(this.txtNameService_TextChanged);
	    // 
	    // menuStrip1
	    // 
	    this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoMenu,
            this.закрытьToolStripMenuItem});
	    this.menuStrip1.Location = new System.Drawing.Point(0, 0);
	    this.menuStrip1.Name = "menuStrip1";
	    this.menuStrip1.Size = new System.Drawing.Size(762, 24);
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
	    // dtgService
	    // 
	    this.dtgService.AllowUserToResizeColumns = false;
	    this.dtgService.AllowUserToResizeRows = false;
	    this.dtgService.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
	    dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
	    dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
	    dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	    dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
	    dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
	    dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
	    dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
	    this.dtgService.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
	    this.dtgService.GridColor = System.Drawing.SystemColors.ButtonFace;
	    this.dtgService.Location = new System.Drawing.Point(15, 128);
	    this.dtgService.MultiSelect = false;
	    this.dtgService.Name = "dtgService";
	    this.dtgService.ReadOnly = true;
	    this.dtgService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
	    this.dtgService.Size = new System.Drawing.Size(370, 235);
	    this.dtgService.TabIndex = 17;
	    this.dtgService.SelectionChanged += new System.EventHandler(this.dtgService_SelectionChanged);
	    // 
	    // txtDetails
	    // 
	    this.txtDetails.BackColor = System.Drawing.SystemColors.ButtonHighlight;
	    this.txtDetails.Location = new System.Drawing.Point(409, 58);
	    this.txtDetails.Multiline = true;
	    this.txtDetails.Name = "txtDetails";
	    this.txtDetails.ReadOnly = true;
	    this.txtDetails.Size = new System.Drawing.Size(341, 222);
	    this.txtDetails.TabIndex = 23;
	    // 
	    // lblPrice2
	    // 
	    this.lblPrice2.AutoSize = true;
	    this.lblPrice2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	    this.lblPrice2.Location = new System.Drawing.Point(503, 283);
	    this.lblPrice2.Name = "lblPrice2";
	    this.lblPrice2.Size = new System.Drawing.Size(16, 16);
	    this.lblPrice2.TabIndex = 24;
	    this.lblPrice2.Text = "_";
	    // 
	    // label2
	    // 
	    this.label2.AutoSize = true;
	    this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	    this.label2.Location = new System.Drawing.Point(406, 37);
	    this.label2.Name = "label2";
	    this.label2.Size = new System.Drawing.Size(80, 18);
	    this.label2.TabIndex = 25;
	    this.label2.Text = "Описание:";
	    // 
	    // statusStrip1
	    // 
	    this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsInfoCountCar});
	    this.statusStrip1.Location = new System.Drawing.Point(0, 374);
	    this.statusStrip1.Name = "statusStrip1";
	    this.statusStrip1.Size = new System.Drawing.Size(762, 22);
	    this.statusStrip1.SizingGrip = false;
	    this.statusStrip1.TabIndex = 26;
	    this.statusStrip1.Text = "statusStrip1";
	    // 
	    // tlsInfoCountCar
	    // 
	    this.tlsInfoCountCar.Name = "tlsInfoCountCar";
	    this.tlsInfoCountCar.Size = new System.Drawing.Size(0, 17);
	    // 
	    // lblPrice1
	    // 
	    this.lblPrice1.AutoSize = true;
	    this.lblPrice1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	    this.lblPrice1.Location = new System.Drawing.Point(406, 283);
	    this.lblPrice1.Name = "lblPrice1";
	    this.lblPrice1.Size = new System.Drawing.Size(90, 18);
	    this.lblPrice1.TabIndex = 27;
	    this.lblPrice1.Text = "Стоимость:";
	    // 
	    // label1
	    // 
	    this.label1.AutoSize = true;
	    this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	    this.label1.Location = new System.Drawing.Point(19, 65);
	    this.label1.Name = "label1";
	    this.label1.Size = new System.Drawing.Size(47, 18);
	    this.label1.TabIndex = 28;
	    this.label1.Text = "Цена:";
	    // 
	    // checkHold
	    // 
	    this.checkHold.Appearance = System.Windows.Forms.Appearance.Button;
	    this.checkHold.AutoSize = true;
	    this.checkHold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
	    this.checkHold.Image = global::AutoService.Properties.Resources.hold;
	    this.checkHold.Location = new System.Drawing.Point(344, 38);
	    this.checkHold.Name = "checkHold";
	    this.checkHold.Size = new System.Drawing.Size(29, 49);
	    this.checkHold.TabIndex = 32;
	    this.checkHold.Text = "   \r\n    \r\n ";
	    this.checkHold.UseVisualStyleBackColor = false;
	    this.checkHold.CheckedChanged += new System.EventHandler(this.checkHold_CheckedChanged);
	    // 
	    // label3
	    // 
	    this.label3.AutoSize = true;
	    this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	    this.label3.Location = new System.Drawing.Point(19, 101);
	    this.label3.Name = "label3";
	    this.label3.Size = new System.Drawing.Size(50, 15);
	    this.label3.TabIndex = 37;
	    this.label3.Text = "Режим:";
	    // 
	    // radioButton4
	    // 
	    this.radioButton4.Appearance = System.Windows.Forms.Appearance.Button;
	    this.radioButton4.AutoSize = true;
	    this.radioButton4.Checked = true;
	    this.radioButton4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	    this.radioButton4.Location = new System.Drawing.Point(165, 98);
	    this.radioButton4.Name = "radioButton4";
	    this.radioButton4.Size = new System.Drawing.Size(25, 24);
	    this.radioButton4.TabIndex = 51;
	    this.radioButton4.TabStop = true;
	    this.radioButton4.Tag = "∀";
	    this.radioButton4.Text = "∀";
	    this.radioButton4.UseVisualStyleBackColor = true;
	    this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
	    // 
	    // radioButton3
	    // 
	    this.radioButton3.Appearance = System.Windows.Forms.Appearance.Button;
	    this.radioButton3.AutoSize = true;
	    this.radioButton3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	    this.radioButton3.Location = new System.Drawing.Point(105, 98);
	    this.radioButton3.Name = "radioButton3";
	    this.radioButton3.Size = new System.Drawing.Size(24, 24);
	    this.radioButton3.TabIndex = 50;
	    this.radioButton3.Tag = "=";
	    this.radioButton3.Text = "=";
	    this.radioButton3.UseVisualStyleBackColor = true;
	    this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
	    // 
	    // radioButton2
	    // 
	    this.radioButton2.Appearance = System.Windows.Forms.Appearance.Button;
	    this.radioButton2.AutoSize = true;
	    this.radioButton2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	    this.radioButton2.Location = new System.Drawing.Point(135, 98);
	    this.radioButton2.Name = "radioButton2";
	    this.radioButton2.Size = new System.Drawing.Size(24, 24);
	    this.radioButton2.TabIndex = 49;
	    this.radioButton2.Tag = "≤";
	    this.radioButton2.Text = "≤";
	    this.radioButton2.UseVisualStyleBackColor = true;
	    this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
	    // 
	    // radioButton1
	    // 
	    this.radioButton1.Appearance = System.Windows.Forms.Appearance.Button;
	    this.radioButton1.AutoSize = true;
	    this.radioButton1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	    this.radioButton1.Location = new System.Drawing.Point(75, 98);
	    this.radioButton1.Name = "radioButton1";
	    this.radioButton1.Size = new System.Drawing.Size(24, 24);
	    this.radioButton1.TabIndex = 48;
	    this.radioButton1.Tag = "≥";
	    this.radioButton1.Text = "≥";
	    this.radioButton1.UseVisualStyleBackColor = true;
	    this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
	    // 
	    // numPrice
	    // 
	    this.numPrice.Location = new System.Drawing.Point(75, 64);
	    this.numPrice.Name = "numPrice";
	    this.numPrice.Size = new System.Drawing.Size(263, 20);
	    this.numPrice.TabIndex = 52;
	    this.numPrice.TextChanged += new System.EventHandler(this.numPrice_TextChanged);
	    // 
	    // ServicesForm
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.ClientSize = new System.Drawing.Size(762, 396);
	    this.Controls.Add(this.numPrice);
	    this.Controls.Add(this.radioButton4);
	    this.Controls.Add(this.radioButton3);
	    this.Controls.Add(this.radioButton2);
	    this.Controls.Add(this.radioButton1);
	    this.Controls.Add(this.label3);
	    this.Controls.Add(this.checkHold);
	    this.Controls.Add(this.label1);
	    this.Controls.Add(this.lblPrice1);
	    this.Controls.Add(this.statusStrip1);
	    this.Controls.Add(this.label2);
	    this.Controls.Add(this.lblPrice2);
	    this.Controls.Add(this.txtDetails);
	    this.Controls.Add(this.lblName);
	    this.Controls.Add(this.btnSettService);
	    this.Controls.Add(this.btnAddService);
	    this.Controls.Add(this.txtNameService);
	    this.Controls.Add(this.menuStrip1);
	    this.Controls.Add(this.dtgService);
	    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
	    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	    this.MaximizeBox = false;
	    this.Name = "ServicesForm";
	    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	    this.Text = "Услуги";
	    this.Load += new System.EventHandler(this.ServicesForm_Load);
	    this.menuStrip1.ResumeLayout(false);
	    this.menuStrip1.PerformLayout();
	    ((System.ComponentModel.ISupportInitialize)(this.dtgService)).EndInit();
	    this.statusStrip1.ResumeLayout(false);
	    this.statusStrip1.PerformLayout();
	    this.ResumeLayout(false);
	    this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.Label lblName;
	private System.Windows.Forms.Button btnSettService;
	private System.Windows.Forms.Button btnAddService;
	private System.Windows.Forms.TextBox txtNameService;
	private System.Windows.Forms.MenuStrip menuStrip1;
	private System.Windows.Forms.ToolStripMenuItem infoMenu;
	private System.Windows.Forms.DataGridView dtgService;
	private System.Windows.Forms.TextBox txtDetails;
	private System.Windows.Forms.Label lblPrice2;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.StatusStrip statusStrip1;
	private System.Windows.Forms.ToolStripStatusLabel tlsInfoCountCar;
    private System.Windows.Forms.Label lblPrice1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox checkHold;
    private System.Windows.Forms.Label label3;
	private System.Windows.Forms.RadioButton radioButton4;
	private System.Windows.Forms.RadioButton radioButton3;
	private System.Windows.Forms.RadioButton radioButton2;
	private System.Windows.Forms.RadioButton radioButton1;
	private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
	private System.Windows.Forms.TextBox numPrice;
    }
}