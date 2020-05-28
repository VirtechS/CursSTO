namespace AutoService.Forms
{
    partial class UsersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersForm));
            this.btnCorrectUser = new System.Windows.Forms.Button();
            this.dtgUsers = new System.Windows.Forms.DataGridView();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlsInfoCountCar = new System.Windows.Forms.ToolStripStatusLabel();
            this.removeUser = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtlogin = new System.Windows.Forms.TextBox();
            this.cmbUsersType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUsers)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCorrectUser
            // 
            this.btnCorrectUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCorrectUser.Location = new System.Drawing.Point(313, 186);
            this.btnCorrectUser.Name = "btnCorrectUser";
            this.btnCorrectUser.Size = new System.Drawing.Size(99, 37);
            this.btnCorrectUser.TabIndex = 44;
            this.btnCorrectUser.Text = "Изменить";
            this.btnCorrectUser.UseVisualStyleBackColor = false;
            this.btnCorrectUser.Click += new System.EventHandler(this.btnCorrectUser_Click);
            // 
            // dtgUsers
            // 
            this.dtgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgUsers.Location = new System.Drawing.Point(12, 41);
            this.dtgUsers.MultiSelect = false;
            this.dtgUsers.Name = "dtgUsers";
            this.dtgUsers.ReadOnly = true;
            this.dtgUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgUsers.Size = new System.Drawing.Size(252, 225);
            this.dtgUsers.TabIndex = 35;
            this.dtgUsers.SelectionChanged += new System.EventHandler(this.dtgUsers_SelectionChanged);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddUser.Location = new System.Drawing.Point(313, 143);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(99, 37);
            this.btnAddUser.TabIndex = 43;
            this.btnAddUser.Text = "Добавить";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem,
            this.InfoMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(469, 24);
            this.menuStrip1.TabIndex = 37;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // InfoMenu
            // 
            this.InfoMenu.Name = "InfoMenu";
            this.InfoMenu.Size = new System.Drawing.Size(65, 20);
            this.InfoMenu.Text = "Справка";
            this.InfoMenu.Click += new System.EventHandler(this.InfoMenu_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsInfoCountCar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 282);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(469, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 38;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlsInfoCountCar
            // 
            this.tlsInfoCountCar.Name = "tlsInfoCountCar";
            this.tlsInfoCountCar.Size = new System.Drawing.Size(0, 17);
            // 
            // removeUser
            // 
            this.removeUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.removeUser.Location = new System.Drawing.Point(313, 229);
            this.removeUser.Name = "removeUser";
            this.removeUser.Size = new System.Drawing.Size(99, 37);
            this.removeUser.TabIndex = 45;
            this.removeUser.Text = "Удалить";
            this.removeUser.UseVisualStyleBackColor = false;
            this.removeUser.Click += new System.EventHandler(this.removeUser_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPassword.Location = new System.Drawing.Point(284, 71);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(156, 22);
            this.txtPassword.TabIndex = 41;
            // 
            // txtlogin
            // 
            this.txtlogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtlogin.Location = new System.Drawing.Point(284, 41);
            this.txtlogin.Name = "txtlogin";
            this.txtlogin.Size = new System.Drawing.Size(156, 22);
            this.txtlogin.TabIndex = 40;
            // 
            // cmbUsersType
            // 
            this.cmbUsersType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsersType.FormattingEnabled = true;
            this.cmbUsersType.Location = new System.Drawing.Point(284, 101);
            this.cmbUsersType.Name = "cmbUsersType";
            this.cmbUsersType.Size = new System.Drawing.Size(156, 21);
            this.cmbUsersType.TabIndex = 42;
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 304);
            this.Controls.Add(this.cmbUsersType);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtlogin);
            this.Controls.Add(this.removeUser);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.dtgUsers);
            this.Controls.Add(this.btnCorrectUser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пользователи";
            this.Load += new System.EventHandler(this.UsersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgUsers)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCorrectUser;
        public System.Windows.Forms.DataGridView dtgUsers;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem InfoMenu;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlsInfoCountCar;
        private System.Windows.Forms.Button removeUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtlogin;
        private System.Windows.Forms.ComboBox cmbUsersType;
    }
}