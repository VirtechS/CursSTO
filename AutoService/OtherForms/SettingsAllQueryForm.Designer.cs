namespace AutoService.OtherForms
{
    partial class SettingsAllQueryForm
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
	    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsAllQueryForm));
	    this.dtgListService = new System.Windows.Forms.DataGridView();
	    this.txtPrice = new System.Windows.Forms.TextBox();
	    this.label9 = new System.Windows.Forms.Label();
	    this.menuStrip1 = new System.Windows.Forms.MenuStrip();
	    this.infoMenu = new System.Windows.Forms.ToolStripMenuItem();
	    this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	    this.dtgAllServices = new System.Windows.Forms.DataGridView();
	    this.btnDelService = new System.Windows.Forms.Button();
	    this.btnAddService = new System.Windows.Forms.Button();
	    this.label8 = new System.Windows.Forms.Label();
	    this.label1 = new System.Windows.Forms.Label();
	    this.btnclose = new System.Windows.Forms.Button();
	    ((System.ComponentModel.ISupportInitialize)(this.dtgListService)).BeginInit();
	    this.menuStrip1.SuspendLayout();
	    ((System.ComponentModel.ISupportInitialize)(this.dtgAllServices)).BeginInit();
	    this.SuspendLayout();
	    // 
	    // dtgListService
	    // 
	    this.dtgListService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
	    this.dtgListService.Location = new System.Drawing.Point(422, 62);
	    this.dtgListService.MultiSelect = false;
	    this.dtgListService.Name = "dtgListService";
	    this.dtgListService.ReadOnly = true;
	    this.dtgListService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
	    this.dtgListService.Size = new System.Drawing.Size(328, 189);
	    this.dtgListService.TabIndex = 31;
	    this.dtgListService.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListService_CellDoubleClick);
	    // 
	    // txtPrice
	    // 
	    this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	    this.txtPrice.Location = new System.Drawing.Point(467, 261);
	    this.txtPrice.Name = "txtPrice";
	    this.txtPrice.ReadOnly = true;
	    this.txtPrice.Size = new System.Drawing.Size(159, 22);
	    this.txtPrice.TabIndex = 33;
	    // 
	    // label9
	    // 
	    this.label9.AutoSize = true;
	    this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	    this.label9.Location = new System.Drawing.Point(419, 264);
	    this.label9.Name = "label9";
	    this.label9.Size = new System.Drawing.Size(47, 16);
	    this.label9.TabIndex = 32;
	    this.label9.Text = "Итог:";
	    // 
	    // menuStrip1
	    // 
	    this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoMenu,
            this.закрытьToolStripMenuItem});
	    this.menuStrip1.Location = new System.Drawing.Point(0, 0);
	    this.menuStrip1.Name = "menuStrip1";
	    this.menuStrip1.Size = new System.Drawing.Size(762, 24);
	    this.menuStrip1.TabIndex = 34;
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
	    // dtgAllServices
	    // 
	    this.dtgAllServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
	    this.dtgAllServices.Location = new System.Drawing.Point(19, 61);
	    this.dtgAllServices.MultiSelect = false;
	    this.dtgAllServices.Name = "dtgAllServices";
	    this.dtgAllServices.ReadOnly = true;
	    this.dtgAllServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
	    this.dtgAllServices.Size = new System.Drawing.Size(334, 189);
	    this.dtgAllServices.TabIndex = 36;
	    this.dtgAllServices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgAllServices_CellDoubleClick);
	    // 
	    // btnDelService
	    // 
	    this.btnDelService.Image = global::AutoService.Properties.Resources.left3;
	    this.btnDelService.Location = new System.Drawing.Point(359, 115);
	    this.btnDelService.Name = "btnDelService";
	    this.btnDelService.Size = new System.Drawing.Size(57, 37);
	    this.btnDelService.TabIndex = 39;
	    this.btnDelService.UseVisualStyleBackColor = true;
	    this.btnDelService.Click += new System.EventHandler(this.btnDelService_Click);
	    this.btnDelService.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDelService_MouseDown);
	    this.btnDelService.MouseLeave += new System.EventHandler(this.btnDelService_MouseLeave);
	    this.btnDelService.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDelService_MouseUp);
	    // 
	    // btnAddService
	    // 
	    this.btnAddService.Image = global::AutoService.Properties.Resources.right;
	    this.btnAddService.Location = new System.Drawing.Point(359, 158);
	    this.btnAddService.Name = "btnAddService";
	    this.btnAddService.Size = new System.Drawing.Size(57, 37);
	    this.btnAddService.TabIndex = 38;
	    this.btnAddService.UseVisualStyleBackColor = true;
	    this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
	    this.btnAddService.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAddService_MouseDown);
	    this.btnAddService.MouseLeave += new System.EventHandler(this.btnAddService_MouseLeave);
	    this.btnAddService.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAddService_MouseUp);
	    // 
	    // label8
	    // 
	    this.label8.AutoSize = true;
	    this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	    this.label8.Location = new System.Drawing.Point(16, 40);
	    this.label8.Name = "label8";
	    this.label8.Size = new System.Drawing.Size(87, 18);
	    this.label8.TabIndex = 40;
	    this.label8.Text = "Все услуги:";
	    // 
	    // label1
	    // 
	    this.label1.AutoSize = true;
	    this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
	    this.label1.Location = new System.Drawing.Point(419, 40);
	    this.label1.Name = "label1";
	    this.label1.Size = new System.Drawing.Size(84, 18);
	    this.label1.TabIndex = 41;
	    this.label1.Text = "По заявке:";
	    // 
	    // btnclose
	    // 
	    this.btnclose.Location = new System.Drawing.Point(632, 261);
	    this.btnclose.Name = "btnclose";
	    this.btnclose.Size = new System.Drawing.Size(118, 23);
	    this.btnclose.TabIndex = 42;
	    this.btnclose.Text = "Готово";
	    this.btnclose.UseVisualStyleBackColor = true;
	    this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
	    // 
	    // SettingsAllQueryForm
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.ClientSize = new System.Drawing.Size(762, 298);
	    this.Controls.Add(this.btnclose);
	    this.Controls.Add(this.label1);
	    this.Controls.Add(this.label8);
	    this.Controls.Add(this.btnDelService);
	    this.Controls.Add(this.btnAddService);
	    this.Controls.Add(this.dtgAllServices);
	    this.Controls.Add(this.menuStrip1);
	    this.Controls.Add(this.txtPrice);
	    this.Controls.Add(this.label9);
	    this.Controls.Add(this.dtgListService);
	    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
	    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	    this.MaximizeBox = false;
	    this.Name = "SettingsAllQueryForm";
	    this.Text = "Редактирование заявки";
	    this.Load += new System.EventHandler(this.SettingsAllQueryForm_Load);
	    ((System.ComponentModel.ISupportInitialize)(this.dtgListService)).EndInit();
	    this.menuStrip1.ResumeLayout(false);
	    this.menuStrip1.PerformLayout();
	    ((System.ComponentModel.ISupportInitialize)(this.dtgAllServices)).EndInit();
	    this.ResumeLayout(false);
	    this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.DataGridView dtgListService;
	private System.Windows.Forms.TextBox txtPrice;
	private System.Windows.Forms.Label label9;
	private System.Windows.Forms.MenuStrip menuStrip1;
	private System.Windows.Forms.ToolStripMenuItem infoMenu;
	private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
	private System.Windows.Forms.DataGridView dtgAllServices;
	private System.Windows.Forms.Button btnAddService;
	private System.Windows.Forms.Button btnDelService;
	private System.Windows.Forms.Label label8;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Button btnclose;
    }
}