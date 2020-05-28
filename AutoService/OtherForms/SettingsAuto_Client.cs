using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Auto_Client = AutoService.ConneectClass.AutoClientSettings;
using General = AutoService.ConneectClass.General;
namespace AutoService.OtherForms
{
    public partial class SettingsAuto_Client : Form
    {
        public SettingsAuto_Client()
        {
            InitializeComponent();
        }

        void RefreshDataGrid()
        {
            var result = General.context.Clients.Select(x => new
            {
                x.CarID,
                x.SurName,
                x.Name,
                x.Patronymic,
                x.Birthday,
                x.Phone
            }).Where(z => z.CarID == Auto_Client.CarID);

            dtgfio.DataSource = result.ToList();
            try
            {
                dtgfio.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dtgfio.Columns["CarID"].Visible = false;
                dtgfio.Columns["SurName"].HeaderText = "Фамилия";
                dtgfio.Columns["Name"].HeaderText = "Имя";
                dtgfio.Columns["Patronymic"].HeaderText = "Отчество";
                dtgfio.Columns["Birthday"].HeaderText = "Дата Рождения";
                dtgfio.Columns["Phone"].HeaderText = "Телефон";

            }
            catch (Exception)
            { }

        }
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В этом окне предоставляется возможность добавления нового владельца авто\n" +
            "(Новый/существующий).\n" +
      "Каждое авто может дожен иметь только уникальных владельцев(без повторений)\n" +
      "Авто может содержать несколько владельцев, независимо от ПТС", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SettingsAuto_Client_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
            txtGRS.Text = Auto_Client.GRS;
            txtModel.Text = Auto_Client.Model;
            txtColor.Text = Auto_Client.PTS;
            txtEnNumber.Text = Auto_Client.EnNumber;
            txtPTS.Text = Auto_Client.PTS;
        }

        // Формирование склонения слова 
        private string GetWord(int count)
        {
            count = count % 100;
            if (count >= 11 && count <= 19)
                return " записей. ";

            count = count % 10;
            switch (count)
            {
                case 1:
                    return " запись. ";
                case 2:
                case 3:
                case 4:
                    return " записи. ";
                default:
                    return " записей. ";
            }
        }

        private void GetInfoCountNameCar()
        {
            tlsInfoCountCar.Text = "Найдено " + dtgfio.RowCount.ToString() + GetWord(dtgfio.RowCount);
        }

        private void btnnewClient_Click(object sender, EventArgs e)
        {
            if (txtname.Text.ToString().Trim() == "" || txtsurname.Text.ToString().Trim() == "" ||
            (DateTime.Now.Year - dtpbirthday.Value.Year) < 18)
            {
                if ((DateTime.Now.Year - dtpbirthday.Value.Year) < 18)
                    MessageBox.Show("Возраст строго 18+!", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Не все поля заполнены, ознакомьтесь со справкой!", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var client = new Clients();
                client.Name = txtname.Text.ToString().Trim();
                client.SurName = txtsurname.Text.ToString().Trim();
                client.Patronymic = txtpatronymic.Text.ToString().Trim();
                client.Phone = txtPhone.Text.ToString().Trim();
                client.CarID = Auto_Client.CarID;
                client.Birthday = dtpbirthday.Value;

                try
                {
                    General.context.Clients.Add(client);
                    General.context.SaveChanges();
                    GetInfoCountNameCar();
                    RefreshDataGrid();
                    MessageBox.Show("Готово!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtname.Text = "";
                    txtsurname.Text = "";
                    txtpatronymic.Text = "";
                    txtPhone.Text = "";
                    dtpbirthday.Value = DateTime.Now;
                }
                catch (Exception)
                {
                    General.context.Clients.Remove(client);
                    MessageBox.Show("Такая запись уже существует!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExistClient_Click(object sender, EventArgs e)
        {
            using (ListClients lstclients = new ListClients())
            {
                lstclients.ShowDialog();
                RefreshDataGrid();
                MessageBox.Show("Готово!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetInfoCountNameCar();
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            string str = txtPhone.Text.Trim();
            for (int i = 0; i < txtPhone.Text.Length; i++)
                if (!char.IsDigit(str[i]) || str[i] == ' ')
                    str = str.Replace(str[i].ToString(), "");
            txtPhone.Text = str;
        }

        private void txtsurname_TextChanged(object sender, EventArgs e)
        {
            string str = txtsurname.Text;
            str = str.Replace("  ", " ");
            for (int i = 0; i < str.Length; i++)
                if (!char.IsLetter(str[i]) && str[i] != ' ')
                    str = str.Replace(str[i].ToString(), "");
            txtsurname.Text = str;
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            string str = txtname.Text;
            str = str.Replace("  ", " ");
            for (int i = 0; i < str.Length; i++)
                if (!char.IsLetter(str[i]) && str[i] != ' ')
                    str = str.Replace(str[i].ToString(), "");
            txtname.Text = str;
        }

        private void txtpatronymic_TextChanged(object sender, EventArgs e)
        {
            string str = txtpatronymic.Text;
            str = str.Replace("  ", " ");
            for (int i = 0; i < str.Length; i++)
                if (!char.IsLetter(str[i]) && str[i] != ' ')
                    str = str.Replace(str[i].ToString(), "");
            txtpatronymic.Text = str;
        }
    }
}
