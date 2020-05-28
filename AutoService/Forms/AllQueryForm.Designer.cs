namespace AutoService.Forms
{
    partial class AllQueryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllQueryForm));
            this.dtgQuery = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlsInfoCountCar = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.infoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdmaster = new System.Windows.Forms.ComboBox();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnfind = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCars = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpReady = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dtpVisit = new System.Windows.Forms.DateTimePicker();
            this.txtFIO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSettingsQuery = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSetDone = new System.Windows.Forms.Button();
            this.dtgListService = new System.Windows.Forms.DataGridView();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgQuery)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListService)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgQuery
            // 
            this.dtgQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgQuery.Location = new System.Drawing.Point(23, 57);
            this.dtgQuery.MultiSelect = false;
            this.dtgQuery.Name = "dtgQuery";
            this.dtgQuery.ReadOnly = true;
            this.dtgQuery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgQuery.Size = new System.Drawing.Size(992, 305);
            this.dtgQuery.TabIndex = 0;
            this.dtgQuery.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgQuery_CellDoubleClick);
            this.dtgQuery.SelectionChanged += new System.EventHandler(this.dtgQuery_SelectionChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsInfoCountCar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 575);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1028, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlsInfoCountCar
            // 
            this.tlsInfoCountCar.Name = "tlsInfoCountCar";
            this.tlsInfoCountCar.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoMenu,
            this.закрытьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1028, 24);
            this.menuStrip1.TabIndex = 18;
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
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(20, 369);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 16);
            this.lblName.TabIndex = 20;
            this.lblName.Text = "Поиск:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdmaster);
            this.groupBox1.Controls.Add(this.btnclear);
            this.groupBox1.Controls.Add(this.btnfind);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbCars);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpReady);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.dtpVisit);
            this.groupBox1.Controls.Add(this.txtFIO);
            this.groupBox1.Location = new System.Drawing.Point(23, 379);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 189);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // cmdmaster
            // 
            this.cmdmaster.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdmaster.FormattingEnabled = true;
            this.cmdmaster.Location = new System.Drawing.Point(78, 83);
            this.cmdmaster.Name = "cmdmaster";
            this.cmdmaster.Size = new System.Drawing.Size(284, 21);
            this.cmdmaster.TabIndex = 16;
            this.cmdmaster.SelectedIndexChanged += new System.EventHandler(this.cmdmaster_SelectedIndexChanged);
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(257, 115);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(130, 28);
            this.btnclear.TabIndex = 15;
            this.btnclear.Text = "Очистить поиск";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnfind
            // 
            this.btnfind.Location = new System.Drawing.Point(257, 149);
            this.btnfind.Name = "btnfind";
            this.btnfind.Size = new System.Drawing.Size(130, 28);
            this.btnfind.TabIndex = 14;
            this.btnfind.Text = "Найти";
            this.btnfind.UseVisualStyleBackColor = true;
            this.btnfind.Click += new System.EventHandler(this.btnfind_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(34, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Авто:";
            // 
            // cmbCars
            // 
            this.cmbCars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCars.FormattingEnabled = true;
            this.cmbCars.Location = new System.Drawing.Point(78, 53);
            this.cmbCars.Name = "cmbCars";
            this.cmbCars.Size = new System.Drawing.Size(284, 21);
            this.cmbCars.TabIndex = 11;
            this.cmbCars.SelectedIndexChanged += new System.EventHandler(this.cmbCars_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(17, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Мастер:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(46, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "До:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(46, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "От:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(0, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Состояние:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(27, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ф.И.О:";
            // 
            // dtpReady
            // 
            this.dtpReady.Location = new System.Drawing.Point(78, 138);
            this.dtpReady.Name = "dtpReady";
            this.dtpReady.Size = new System.Drawing.Size(148, 20);
            this.dtpReady.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(79, 164);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "выполнено";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // dtpVisit
            // 
            this.dtpVisit.Location = new System.Drawing.Point(78, 110);
            this.dtpVisit.Name = "dtpVisit";
            this.dtpVisit.Size = new System.Drawing.Size(148, 20);
            this.dtpVisit.TabIndex = 1;
            this.dtpVisit.Value = new System.DateTime(2016, 8, 25, 0, 0, 0, 0);
            // 
            // txtFIO
            // 
            this.txtFIO.Location = new System.Drawing.Point(78, 26);
            this.txtFIO.Name = "txtFIO";
            this.txtFIO.Size = new System.Drawing.Size(284, 20);
            this.txtFIO.TabIndex = 0;
            this.txtFIO.TextChanged += new System.EventHandler(this.txtFIO_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(20, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "Заявки:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(440, 366);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 16);
            this.label8.TabIndex = 24;
            this.label8.Text = "Услуги:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(138, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 16);
            this.label9.TabIndex = 25;
            this.label9.Text = "Итог:";
            // 
            // btnSettingsQuery
            // 
            this.btnSettingsQuery.Location = new System.Drawing.Point(36, 74);
            this.btnSettingsQuery.Name = "btnSettingsQuery";
            this.btnSettingsQuery.Size = new System.Drawing.Size(100, 50);
            this.btnSettingsQuery.TabIndex = 27;
            this.btnSettingsQuery.Text = "Редактировать";
            this.btnSettingsQuery.UseVisualStyleBackColor = true;
            this.btnSettingsQuery.Click += new System.EventHandler(this.btnSettingsQuery_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(36, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 50);
            this.button2.TabIndex = 28;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSetDone
            // 
            this.btnSetDone.Location = new System.Drawing.Point(36, 134);
            this.btnSetDone.Name = "btnSetDone";
            this.btnSetDone.Size = new System.Drawing.Size(100, 50);
            this.btnSetDone.TabIndex = 29;
            this.btnSetDone.Text = "Выполнить";
            this.btnSetDone.UseVisualStyleBackColor = true;
            this.btnSetDone.Click += new System.EventHandler(this.btnSetDone_Click);
            // 
            // dtgListService
            // 
            this.dtgListService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListService.Location = new System.Drawing.Point(20, 10);
            this.dtgListService.MultiSelect = false;
            this.dtgListService.Name = "dtgListService";
            this.dtgListService.ReadOnly = true;
            this.dtgListService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgListService.Size = new System.Drawing.Size(328, 130);
            this.dtgListService.TabIndex = 30;
            this.dtgListService.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListService_CellDoubleClick);
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPrice.Location = new System.Drawing.Point(189, 154);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(159, 22);
            this.txtPrice.TabIndex = 31;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSettingsQuery);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.btnSetDone);
            this.groupBox2.Location = new System.Drawing.Point(849, 378);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(165, 190);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPrice);
            this.groupBox3.Controls.Add(this.dtgListService);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(439, 379);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(376, 189);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(848, 365);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 16);
            this.label10.TabIndex = 30;
            this.label10.Text = "Управление заявкой:";
            // 
            // AllQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 597);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dtgQuery);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AllQueryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Все заявки";
            this.Load += new System.EventHandler(this.AllQueryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgQuery)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListService)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.DataGridView dtgQuery;
	private System.Windows.Forms.StatusStrip statusStrip1;
	private System.Windows.Forms.ToolStripStatusLabel tlsInfoCountCar;
	private System.Windows.Forms.MenuStrip menuStrip1;
	private System.Windows.Forms.ToolStripMenuItem infoMenu;
	private System.Windows.Forms.Label lblName;
	private System.Windows.Forms.GroupBox groupBox1;
	private System.Windows.Forms.Label label5;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.CheckBox checkBox1;
	private System.Windows.Forms.DateTimePicker dtpReady;
	private System.Windows.Forms.DateTimePicker dtpVisit;
	private System.Windows.Forms.TextBox txtFIO;
	private System.Windows.Forms.Label label6;
	private System.Windows.Forms.Label label7;
	private System.Windows.Forms.ComboBox cmbCars;
	private System.Windows.Forms.Label label8;
	private System.Windows.Forms.Label label9;
	private System.Windows.Forms.Button btnSettingsQuery;
	private System.Windows.Forms.Button button2;
	private System.Windows.Forms.Button btnSetDone;
	private System.Windows.Forms.DataGridView dtgListService;
	private System.Windows.Forms.TextBox txtPrice;
	private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
	private System.Windows.Forms.GroupBox groupBox2;
	private System.Windows.Forms.GroupBox groupBox3;
	private System.Windows.Forms.Label label10;
	private System.Windows.Forms.Button btnfind;
	private System.Windows.Forms.Button btnclear;
	private System.Windows.Forms.ComboBox cmdmaster;
    }
}