using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using General = AutoService.ConneectClass.General;
using ClientAutoSettings = AutoService.ConneectClass.ClientAutoSettings;
using AutoService.OtherForms;

namespace AutoService.Forms
{
    public partial class ClientsForm : Form
    {
        // Список картинок
        private List<Image> images = new List<Image>();
        // Список имён
        private List<string> nameimages = new List<string>();
        private string namepic = "";

        public ClientsForm()
        {
            InitializeComponent();
        }

        private void RefreshDataGrid()
        {
            var result = General.context.Clients.GroupBy(x => new
            {
                SurName = x.SurName.Trim(),
                Name = x.Name.Trim(),
                Patronymic = x.Patronymic.Trim(),
                x.Birthday,
                Phone = x.Phone.Trim(),
                x.imagename
            }).Select(t => new
            {
                t.Key.SurName,
                t.Key.Name,
                t.Key.Patronymic,
                t.Key.Birthday,
                t.Key.Phone,
                t.Key.imagename
            }).OrderBy(z => z.SurName + z.Name + z.Patronymic);
            dtgfio.DataSource = result.ToList();
            images = ClientAutoSettings.GetPicture(dtgfio, out nameimages);
            GetInfoCount();
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            if (General.mode == (int)General.Status.Admin)
            {
                btnNewClient.Enabled = true;
                btnSettClient_car.Enabled = true;
            }
            else
            if (General.mode == (int)General.Status.User)
            {
                btnNewClient.Enabled = false;
                btnSettClient_car.Enabled = false;
            }
            else { MessageBox.Show("Ошибка разграничения пользователей!", "Предупреждение", MessageBoxButtons.OK); Application.Restart(); }
            RefreshDataGrid();
            dtgfio.Columns[0].HeaderText = "Фамилия";
            dtgfio.Columns[1].HeaderText = "Имя";
            dtgfio.Columns[2].HeaderText = "Отчество";
            dtgfio.Columns[3].HeaderText = "Дата Рождения";
            dtgfio.Columns[4].HeaderText = "Телефон";
            dtgfio.Columns[5].Visible = false;

            dtgfio.Columns[0].Width = 100;
            dtgfio.Columns[1].Width = 100;
            dtgfio.Columns[2].Width = 100;
            dtgfio.Columns[3].Width = 90;
            dtgfio.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dtpClient.MaxDate = new DateTime(DateTime.Now.Year - 18, 12, 31);
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
        // Статистика таблицы
        private void GetInfoCount()
        {
            tls.Text = "Найдено " + dtgfio.RowCount.ToString() + GetWord(dtgfio.RowCount);
        }


        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgfio_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgfio.SelectedRows.Count > 0)
            {
                if (dtgfio.SelectedRows[0].Index != -1)
                {
                    int i_row = dtgfio.SelectedRows[0].Index;

                    string FIO = dtgfio.Rows[i_row].Cells[0].FormattedValue.ToString().Trim() + " " + dtgfio.Rows[i_row].Cells[1].FormattedValue.ToString().Trim() + " " + dtgfio.Rows[i_row].Cells[2].FormattedValue.ToString().Trim();
                    DateTime Birthday = Convert.ToDateTime(dtgfio.Rows[i_row].Cells[3].Value);
                    string Phone = dtgfio.Rows[i_row].Cells[4].FormattedValue.ToString().Trim();
                    string imgname = null;
                    if (dtgfio.Rows[i_row].Cells[5].FormattedValue.ToString().Trim() != "")
                        imgname = dtgfio.Rows[i_row].Cells[5].FormattedValue.ToString().Trim();

                    var result = General.context.Clients.Where(x =>
                    (x.SurName.Trim() + " " + x.Name.Trim() + " " + x.Patronymic.Trim()) == FIO &&
                    x.Birthday == Birthday &&
                    x.Phone.Trim() == Phone &&
                    x.imagename.Trim() == imgname
                    )
                    .Join(General.context.Cars, client => client.CarID, car => car.ID, (client, car) => new { client, car })
                    .Join(General.context.ModelCars, car => car.car.ModelCarID, model => model.ID, (car, model) => new { car, model })
                    .Select(t => new
                    {
                        t.car.car.ID,
                        Марка = t.model.NameCar.Trim(),
                        ГРЗ = t.car.car.RegisterSign.Trim(),
                    }
                 ).ToList();
                    dtgCars.DataSource = result;

                    dtgCars.Columns[0].Visible = false;
                    dtgCars.Columns[1].HeaderText = "Марка";
                    dtgCars.Columns[1].Width = 100;
                    dtgCars.Columns[2].HeaderText = "ГРЗ";
                    dtgCars.Columns[2].Width = 120;
                    dtgCars.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    MessageBox.Show("Выделите строку в таблице заявок!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnSettClient_car_Click(object sender, EventArgs e)
        {
            if (dtgfio.SelectedRows.Count > 0)
            {
                if (dtgfio.SelectedRows[0].Index != -1)
                {
                    int i_row = dtgfio.SelectedRows[0].Index;
                    ClientAutoSettings.TextBtn = "Изменить";
                    ClientAutoSettings.SurnameClient = dtgfio.Rows[i_row].Cells[0].FormattedValue.ToString().Trim();
                    ClientAutoSettings.NameClient = dtgfio.Rows[i_row].Cells[1].FormattedValue.ToString().Trim();
                    ClientAutoSettings.PatronymicClient = dtgfio.Rows[i_row].Cells[2].FormattedValue.ToString().Trim();
                    ClientAutoSettings.BirthdayClient = Convert.ToDateTime(dtgfio.Rows[i_row].Cells[3].Value);
                    ClientAutoSettings.PhoneClient = dtgfio.Rows[i_row].Cells[4].FormattedValue.ToString().Trim();
                    if (dtgfio.Rows[i_row].Cells[5].FormattedValue.ToString().Trim() != "")
                        ClientAutoSettings.namePicture = dtgfio.Rows[i_row].Cells[5].FormattedValue.ToString().Trim();
                    else ClientAutoSettings.namePicture = null;
                    using (SettingsClient_Auto client_auto = new SettingsClient_Auto())
                    {
                        client_auto.ShowDialog();
                        RefreshDataGrid();
                        dtgfio.Rows[i_row].Cells[0].Selected = true;
                    }
                }
            }
        }

        private void btnNewClient_Click(object sender, EventArgs e)
        {
            int i_row = dtgfio.SelectedRows[0].Index;
            ClientAutoSettings.TextBtn = "Добавить";
            using (SettingsClient_Auto client_auto = new SettingsClient_Auto())
            {
                client_auto.ShowDialog();
                RefreshDataGrid();
                dtgfio.Rows[i_row].Cells[0].Selected = true;
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            try
            {
                namepic = txtFind.Text.ToString().Trim();
                var result = General.context.Clients.GroupBy(x => new
                {
                    SurName = x.SurName.Trim(),
                    Name = x.Name.Trim(),
                    Patronymic = x.Patronymic.Trim(),
                    x.Birthday,
                    Phone = x.Phone.Trim(),
                    x.imagename
                }).Select(t => new
                {
                    t.Key.SurName,
                    t.Key.Name,
                    t.Key.Patronymic,
                    t.Key.Birthday,
                    t.Key.Phone,
                    t.Key.imagename
                }).OrderBy(z => z.SurName + z.Name + z.Patronymic).Where(q =>
                   q.Name.Contains(namepic) ||
                               q.SurName.Contains(namepic) ||
                               q.Patronymic.Contains(namepic) ||
                               q.Phone.Contains(namepic));
                dtgfio.DataSource = result.ToList();
                if (dtgfio.RowCount == 0)
                    dtgCars.DataSource = null;
                GetInfoCount();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
        }

        private void btnFindDate_Click(object sender, EventArgs e)
        {
            var result = General.context.Clients.GroupBy(x => new
            {
                SurName = x.SurName.Trim(),
                Name = x.Name.Trim(),
                Patronymic = x.Patronymic.Trim(),
                x.Birthday,
                Phone = x.Phone.Trim(),
                x.imagename
            }).Select(t => new
            {
                t.Key.SurName,
                t.Key.Name,
                t.Key.Patronymic,
                t.Key.Birthday,
                t.Key.Phone,
                t.Key.imagename
            }).OrderBy(z => z.SurName + z.Name + z.Patronymic);
            DateTime Birthday = new DateTime(dtpClient.Value.Year, dtpClient.Value.Month, dtpClient.Value.Day);
            foreach (RadioButton rdb in this.Controls.OfType<RadioButton>())
                if (rdb.Checked)
                    switch (rdb.Text.ToString().Trim())
                    {
                        case "≥":
                            {
                                dtgfio.DataSource = result.Where(x => x.Birthday >= Birthday).ToList(); break;
                            }
                        case "≤":
                            {
                                dtgfio.DataSource = result.Where(x => x.Birthday <= Birthday).ToList(); break;
                            }
                        case "=":
                            {
                                dtgfio.DataSource = result.Where(x => x.Birthday == Birthday).ToList(); break;
                            }
                        case "∀": RefreshDataGrid(); break;
                    }
            GetInfoCount();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В этом окне осуществляется работа с клиентами.\n" +
  "Оформление новых заявок находится в главном окне программы.\n" +
  "Возраст потенциального клиента не младше 18 лет." +
  "Двойным нажатием по ячейке можно скопировать её значение в буфер обмена."
            , "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
