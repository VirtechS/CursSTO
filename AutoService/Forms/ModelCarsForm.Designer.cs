namespace AutoService.Forms
{
    partial class ModelCarsForm
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
	    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelCarsForm));
	    this.dtgModelCars = new System.Windows.Forms.DataGridView();
	    this.statusStrip1 = new System.Windows.Forms.StatusStrip();
	    this.tlsInfoCountCar = new System.Windows.Forms.ToolStripStatusLabel();
	    this.txtNameCar = new System.Windows.Forms.TextBox();
	    this.btnAddNameCar = new System.Windows.Forms.Button();
	    this.btnSettNameCar = new System.Windows.Forms.Button();
	    this.lblName = new System.Windows.Forms.Label();
	    this.picBox = new System.Windows.Forms.PictureBox();
	    this.menuStrip1 = new System.Windows.Forms.MenuStrip();
	    this.infoMenu = new System.Windows.Forms.ToolStripMenuItem();
	    this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	    ((System.ComponentModel.ISupportInitialize)(this.dtgModelCars)).BeginInit();
	    this.statusStrip1.SuspendLayout();
	    ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
	    this.menuStrip1.SuspendLayout();
	    this.SuspendLayout();
	    // 
	    // dtgModelCars
	    // 
	    this.dtgModelCars.AllowUserToResizeColumns = false;
	    this.dtgModelCars.AllowUserToResizeRows = false;
	    this.dtgModelCars.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
	    dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
	    dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
	    dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	    dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
	    dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
	    dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
	    dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
	    this.dtgModelCars.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
	    this.dtgModelCars.GridColor = System.Drawing.SystemColors.ButtonFace;
	    this.dtgModelCars.Location = new System.Drawing.Point(69, 72);
	    this.dtgModelCars.MultiSelect = false;
	    this.dtgModelCars.Name = "dtgModelCars";
	    this.dtgModelCars.ReadOnly = true;
	    this.dtgModelCars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
	    this.dtgModelCars.Size = new System.Drawing.Size(227, 302);
	    this.dtgModelCars.TabIndex = 0;
	    this.dtgModelCars.SelectionChanged += new System.EventHandler(this.dtgModelCars_SelectionChanged);
	    // 
	    // statusStrip1
	    // 
	    this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsInfoCountCar});
	    this.statusStrip1.Location = new System.Drawing.Point(0, 386);
	    this.statusStrip1.Name = "statusStrip1";
	    this.statusStrip1.Size = new System.Drawing.Size(612, 22);
	    this.statusStrip1.SizingGrip = false;
	    this.statusStrip1.TabIndex = 9;
	    this.statusStrip1.Text = "statusStrip1";
	    // 
	    // tlsInfoCountCar
	    // 
	    this.tlsInfoCountCar.Name = "tlsInfoCountCar";
	    this.tlsInfoCountCar.Size = new System.Drawing.Size(0, 17);
	    // 
	    // txtNameCar
	    // 
	    this.txtNameCar.Location = new System.Drawing.Point(69, 46);
	    this.txtNameCar.Name = "txtNameCar";
	    this.txtNameCar.Size = new System.Drawing.Size(227, 20);
	    this.txtNameCar.TabIndex = 3;
	    this.txtNameCar.TextChanged += new System.EventHandler(this.txtFindNameCar_TextChanged);
	    // 
	    // btnAddNameCar
	    // 
	    this.btnAddNameCar.Location = new System.Drawing.Point(322, 322);
	    this.btnAddNameCar.Name = "btnAddNameCar";
	    this.btnAddNameCar.Size = new System.Drawing.Size(254, 23);
	    this.btnAddNameCar.TabIndex = 12;
	    this.btnAddNameCar.Text = "Добавить";
	    this.btnAddNameCar.UseVisualStyleBackColor = true;
	    this.btnAddNameCar.Click += new System.EventHandler(this.btnAddNameCar_Click);
	    // 
	    // btnSettNameCar
	    // 
	    this.btnSettNameCar.Location = new System.Drawing.Point(322, 351);
	    this.btnSettNameCar.Name = "btnSettNameCar";
	    this.btnSettNameCar.Size = new System.Drawing.Size(254, 23);
	    this.btnSettNameCar.TabIndex = 13;
	    this.btnSettNameCar.Text = "Редактировать";
	    this.btnSettNameCar.UseVisualStyleBackColor = true;
	    this.btnSettNameCar.Click += new System.EventHandler(this.btnSettNameCar_Click);
	    // 
	    // lblName
	    // 
	    this.lblName.AutoSize = true;
	    this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	    this.lblName.Location = new System.Drawing.Point(6, 48);
	    this.lblName.Name = "lblName";
	    this.lblName.Size = new System.Drawing.Size(57, 18);
	    this.lblName.TabIndex = 14;
	    this.lblName.Text = "Марка:";
	    // 
	    // picBox
	    // 
	    this.picBox.BackColor = System.Drawing.SystemColors.ControlLight;
	    this.picBox.Location = new System.Drawing.Point(322, 72);
	    this.picBox.Name = "picBox";
	    this.picBox.Size = new System.Drawing.Size(254, 235);
	    this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
	    this.picBox.TabIndex = 15;
	    this.picBox.TabStop = false;
	    // 
	    // menuStrip1
	    // 
	    this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoMenu,
            this.закрытьToolStripMenuItem});
	    this.menuStrip1.Location = new System.Drawing.Point(0, 0);
	    this.menuStrip1.Name = "menuStrip1";
	    this.menuStrip1.Size = new System.Drawing.Size(612, 24);
	    this.menuStrip1.TabIndex = 16;
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
	    // ModelCarsForm
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.ClientSize = new System.Drawing.Size(612, 408);
	    this.Controls.Add(this.picBox);
	    this.Controls.Add(this.lblName);
	    this.Controls.Add(this.btnSettNameCar);
	    this.Controls.Add(this.btnAddNameCar);
	    this.Controls.Add(this.txtNameCar);
	    this.Controls.Add(this.statusStrip1);
	    this.Controls.Add(this.menuStrip1);
	    this.Controls.Add(this.dtgModelCars);
	    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
	    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	    this.MainMenuStrip = this.menuStrip1;
	    this.MaximizeBox = false;
	    this.Name = "ModelCarsForm";
	    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
	    this.Text = "Марки авто";
	    this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModelCarsForm_FormClosing);
	    this.Load += new System.EventHandler(this.ModelCarsForm_Load);
	    ((System.ComponentModel.ISupportInitialize)(this.dtgModelCars)).EndInit();
	    this.statusStrip1.ResumeLayout(false);
	    this.statusStrip1.PerformLayout();
	    ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
	    this.menuStrip1.ResumeLayout(false);
	    this.menuStrip1.PerformLayout();
	    this.ResumeLayout(false);
	    this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.DataGridView dtgModelCars;
	private System.Windows.Forms.StatusStrip statusStrip1;
	private System.Windows.Forms.ToolStripStatusLabel tlsInfoCountCar;
	private System.Windows.Forms.TextBox txtNameCar;
	private System.Windows.Forms.Button btnAddNameCar;
	private System.Windows.Forms.Button btnSettNameCar;
	private System.Windows.Forms.Label lblName;
	private System.Windows.Forms.PictureBox picBox;
	private System.Windows.Forms.MenuStrip menuStrip1;
	private System.Windows.Forms.ToolStripMenuItem infoMenu;
	private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
    }
}