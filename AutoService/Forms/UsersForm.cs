using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using General = AutoService.ConneectClass.General;

namespace AutoService.Forms
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
            cmbUsersType.Items.Add("Админ");
            cmbUsersType.Items.Add("Мастер");
        }
        // 1 - admin, 2 - user
        private void UsersForm_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            List<Array> Empty = null;
            dtgUsers.DataSource = Empty;

            dtgUsers.DataSource = General.context.Admin.Select(x => new
            {
                x.ID,
                x.Login,
                x.StatusID
            }).Join(General.context.Status, admin => admin.StatusID, status => status.ID, (admin, status) => new { admin, status }).Where(x => x.admin.StatusID == x.status.ID)
            .Select(p => new { p.admin.ID, Логин = p.admin.Login, Режим = p.status.Login }).ToList();
            dtgUsers.Columns[0].Visible = false;
        }

        enum Mode { Admin, User }

        private void dtgUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgUsers.SelectedRows.Count > 0)
                if (dtgUsers.SelectedRows[0].Index != -1)
                {
                    int i_row = dtgUsers.SelectedRows[0].Index;
                    txtlogin.Text = dtgUsers.SelectedRows[0].Cells[1].FormattedValue.ToString().Trim();
                    string str = dtgUsers.SelectedRows[0].Cells[2].FormattedValue.ToString().Trim();
                    try
                    {
                        if (str == "Админ")
                            cmbUsersType.SelectedIndex = 0;
                        else
                            cmbUsersType.SelectedIndex = 1;
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message.ToString());
                    }
                }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtlogin.Text.Trim() != "" && txtPassword.Text.Trim() != "")
                {
                    string res = MD5_Cript(txtPassword.Text.Trim());
                    var user = new Admin() { Login = txtlogin.Text.Trim(), Password = res, StatusID = cmbUsersType.SelectedIndex + 1 };
                    try
                    {
                        General.context.Admin.Add(user);
                        General.context.SaveChanges();
                        RefreshDataGrid();
                        MessageBox.Show("Готово!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message.ToString());
                        //MessageBox.Show("Заполните все поля", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (DbUpdateException exp)
            {
                MessageBox.Show("Такой пользователь уже существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
        }

        private string MD5_Cript(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            string pass = password.Trim();
            byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
            string res = BitConverter.ToString(checkSum).Replace("-", String.Empty);
            return res;
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCorrectUser_Click(object sender, EventArgs e)
        {

            if (dtgUsers.SelectedRows.Count > 0)
                if (dtgUsers.SelectedRows[0].Index != -1)
                {
                    if (txtlogin.Text.Trim() != "" && txtPassword.Text.Trim() != "")
                    {
                        int i_row = dtgUsers.SelectedRows[0].Index;
                        int id = int.Parse(dtgUsers.Rows[i_row].Cells[0].FormattedValue.ToString().Trim());
                        try
                        {
                            // Редактируем выбранную модель
                            var user = General.context.Admin.FirstOrDefault(x => x.ID == id);
                            user.Login = txtlogin.Text.Trim();
                            user.Password = MD5_Cript(txtPassword.Text.Trim());
                            user.StatusID = cmbUsersType.SelectedIndex + 1;

                            General.context.SaveChanges();
                            MessageBox.Show("Готово!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshDataGrid();
                            MessageBox.Show("Готово!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (DbUpdateException)
                        {
                            MessageBox.Show("Такой пользователь уже существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message.ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Выделите строку в таблице!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void removeUser_Click(object sender, EventArgs e)
        {
            if (dtgUsers.SelectedRows.Count > 0)
                if (dtgUsers.SelectedRows[0].Index != -1)
                {
                    int i_row = dtgUsers.SelectedRows[0].Index;
                    int id = int.Parse(dtgUsers.Rows[i_row].Cells[0].FormattedValue.ToString().Trim());
                    try
                    {
                        // Удаляем выбранную модель
                        var user = General.context.Admin.FirstOrDefault(x => x.ID == id);
                        General.context.Admin.Remove(user);
                        General.context.SaveChanges();
                        RefreshDataGrid();
                        MessageBox.Show("Готово!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message.ToString());
                    }
                }
        }

        private void InfoMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы находитесь в окне просмотра/редактирования пользователей.\n" +
       "При добавлении нового пользователя, необходимо заполнить все поля.\n" +
       "При редактировании существующего пользователя пароль не высвечивается.",
       "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}