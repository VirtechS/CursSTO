using AutoService.Forms;
using AutoService.OtherForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using General = AutoService.ConneectClass.General;
using AllQuerySettings = AutoService.ConneectClass.AllQuerySettings;
using System.Text.RegularExpressions;

namespace AutoService
{
    public partial class QueryForm : Form
    {
        public QueryForm()
        {
            InitializeComponent();
            dtpDateBExist.MaxDate = new DateTime(DateTime.Now.Year - 18, 12, 31);
            dtpDateBNew.MaxDate = new DateTime(DateTime.Now.Year - 18, 12, 31);
        }

        // Настройка datagrid
        private void SettingsDataGrid()
        {
            dtgQuery.Columns[0].HeaderText = "Клиент";
            dtgQuery.Columns[1].HeaderText = "Авто";
            dtgQuery.Columns[2].HeaderText = "Дата рождения";
            dtgQuery.Columns[4].HeaderText = "Мастер";
            dtgQuery.Columns[5].HeaderText = "Принято";
            dtgQuery.Columns[6].HeaderText = "Выпущено";

            dtgQuery.Columns[0].Width = 175;
            dtgQuery.Columns[1].Width = 560;
            dtgQuery.Columns[2].Width = 90;
            dtgQuery.Columns[4].Width = 175;
            dtgQuery.Columns[5].Width = 90;
            dtgQuery.Columns[6].Width = 90;
            dtgQuery.Columns[7].Width = 60;

            dtgQuery.Columns[3].Visible = false;
            dtgQuery.Columns[8].Visible = false;
            dtgQuery.Columns[9].Visible = false;

            dtgQuery.Columns.Add("ready", "Состояние");
            dtgQuery.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < dtgQuery.RowCount; i++)
            {
                if (Convert.ToBoolean(dtgQuery.Rows[i].Cells[8].Value) == false)
                    dtgQuery.Rows[i].Cells[10].Value = "В процессе";
                else
                    dtgQuery.Rows[i].Cells[10].Value = "Готово";
            }

        }
        private void RefreshDataGrid()
        {
            try
            {
                var result = General.context.QueryAutoService
                    .Join(General.context.Clients, query => query.ClientID, client => client.ID, (query, client) => new { query, client })
                    .Join(General.context.Services, query => query.query.ServiceID, service => service.ID, (query, service) => new { query, service })
                    .Join(General.context.Masters, query => query.query.query.MasterID, master => master.ID, (query, master) => new { query, master })
                    .GroupBy(p => new
                    {
                        clientID = p.query.query.client.ID,
                        clientFIO = p.query.query.client.SurName.Trim() + " " + p.query.query.client.Name.Trim() + " " + p.query.query.client.Patronymic.Trim(),
                        car = p.query.query.client.Cars.ModelCars.NameCar.Trim() + " " + p.query.query.client.Cars.RegisterSign.Trim() + " | Цвет: " + p.query.query.client.Cars.color.Trim() + " | Номер двигателя: " + p.query.query.client.Cars.EnNumber.Trim() + " | Номер тех паспорта: " + p.query.query.client.Cars.pts.Trim(),
                        bday = p.query.query.client.Birthday,
                        clientphone = p.query.query.client.Phone.Trim(),
                        masterID = p.master.ID,
                        master = p.master.SurName.Trim() + " " + p.master.Name.Trim() + " " + p.master.Patronymic.Trim(),
                        dateVisit = p.query.query.query.DateVisit,
                        dateReady = p.query.query.query.DateReady,
                        done = p.query.query.query.Done
                    });
                dtgQuery.DataSource = null;
                dtgQuery.ColumnCount = 0;
                dtgQuery.DataSource = result.Select(x => new
                {
                    x.Key.clientFIO,
                    x.Key.car,
                    x.Key.bday,
                    x.Key.masterID,
                    x.Key.master,
                    x.Key.dateVisit,
                    x.Key.dateReady,
                    Итог = x.Sum(p => p.query.service.Price).ToString().Trim(),
                    x.Key.done,
                    x.Key.clientID
                }).OrderByDescending(order => order.dateVisit).Where(o => o.done == false).ToList();
                SettingsDataGrid();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

        }
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
        public delegate void Sorted(object sender, EventArgs a);


        private void GetInfoCount()
        {
            tlsInfoCountCar.Text = "Найдено " + dtgQuery.RowCount.ToString() + " " + GetWord(dtgQuery.RowCount);
        }

        // Работа с клиентами
        private void ClientsMenu_Click(object sender, EventArgs e)
        {
            Forms.ClientsForm clients = new Forms.ClientsForm();
            try
            {

                clients.ShowDialog();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
                clients.Close();
            }
        }

        // Работа с авто клиентов
        private void AutoClientsMenu_Click(object sender, EventArgs e)
        {
            Forms.CarsForm clientsCar = new Forms.CarsForm();
            try
            {
                clientsCar.ShowDialog();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
                clientsCar.Close();
            }
            clientsCar.Dispose();
        }
        // Работа с марками авто
        private void MarkAutoMenu_Click(object sender, EventArgs e)
        {
            using (Forms.ModelCarsForm marksAuto = new Forms.ModelCarsForm())
            {
                try
                {
                    marksAuto.ShowDialog();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message.ToString());
                    marksAuto.Close();
                }
            }

        }
        // Работа с мастерами
        private void MastersMenu_Click(object sender, EventArgs e)
        {
            using (Forms.MastersForm masters = new Forms.MastersForm())
            {
                try
                {
                    masters.ShowDialog();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message.ToString());
                    masters.Close();
                }
            }
        }
        // Работа с услугами
        private void ServicesMenu_Click(object sender, EventArgs e)
        {
            Forms.ServicesForm services = new Forms.ServicesForm();
            try
            {
                services.ShowDialog();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
                services.Close();
            }
            services.Dispose();
        }

        private void InfoMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы находитесь в окне просмотра/редактирования заявок.\n" +
        "При добавлении нового клиента, необходимо заполнить данные о владельце авто и выбрать мастера для ремонта.\n" +
        "При добавлении существующего клиента, необходимо вести данные существующего в БД человека и выбрать мастера для ремонта",
        "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void QueryForm_Load(object sender, EventArgs e)
        {
            if (General.mode == (int)General.Status.Admin)
            {
                btndelquery.Enabled = true;
                btnSettingsQuery.Enabled = true;
                usersToolStrim.Enabled = true;
            }
            else
            if (General.mode == (int)General.Status.User)
            {
                btndelquery.Enabled = false;
                btnSettingsQuery.Enabled = false;
                usersToolStrim.Enabled = false;
            }
            else { MessageBox.Show("Ошибка разграничения пользователей!", "Предупреждение", MessageBoxButtons.OK); Application.Restart(); }
            if (General.mode == (int)General.Status.Admin) tlsnickname.Text = "Администратор: " + General.nickname;
            else tlsnickname.Text = "Мастер: " + General.nickname;
            RefreshDataGrid();

        }

        private void ExitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RefreshMenu_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void заявкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AllQueryForm allquery = new AllQueryForm())
            {
                try
                {
                    allquery.ShowDialog();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message.ToString());
                    allquery.Close();
                }
                allquery.Dispose();
            }
        }

        private void txtFioExist_TextChanged(object sender, EventArgs e)
        {
            if (txtFioExist.Text.Trim() == "")
            {
                cmbCarsExist.Enabled = false;
                cmbCarsExist.DataSource = null;
                cmbCarsExist.Items.Clear();
                cmdmasterExist.Enabled = false;
                cmdmasterExist.DataSource = null;
                cmdmasterExist.Items.Clear();
            }
            else
            {
                string str = txtFioExist.Text;
                str = str.Replace("  ", " ");
                for (int i = 0; i < str.Length; i++)
                    if (!char.IsLetter(str[i]) && str[i] != ' ')
                        str = str.Replace(str[i].ToString(), "");
                txtFioExist.Text = str;
                cmbCarsExist.DataSource = null;
                cmbCarsExist.Items.Clear();
                DateTime dt = new DateTime(dtpDateBExist.Value.Year, dtpDateBExist.Value.Month, dtpDateBExist.Value.Day);
                var result = General.context.Clients
                .Join(General.context.Cars, client => client.CarID, car => car.ID, (client, car) => new { client, car }).Where(z => z.car.ID == z.client.CarID)
                .Where(x => x.client.SurName.Trim() + " " + x.client.Name.Trim() + " " + x.client.Patronymic.Trim() == str.Trim() && x.client.Birthday == dt)
                .Select(t => new { t.car.ID, name = t.car.ModelCars.NameCar.Trim() + " " + t.car.RegisterSign.Trim() + " | Цвет: " + t.car.color.Trim() + " | Номер двигателя: " + t.car.EnNumber.Trim() + " | Номер тех паспорта: " + t.car.pts.Trim() })
                .ToList();
                if (result.Count > 0)
                {
                    cmbCarsExist.DataSource = result;
                    cmbCarsExist.DisplayMember = "name";
                    cmbCarsExist.ValueMember = "ID";
                    cmbCarsExist.Enabled = true;
                    cmbCarsExist.SelectedItem = null;
                    cmdmasterExist.SelectedItem = null;
                }
                else
                {
                    btnAddQueryExist.Enabled = false;
                    cmbCarsExist.Enabled = false;
                    cmbCarsExist.Items.Clear();
                    cmbCarsExist.DataSource = null;
                    cmdmasterExist.DataSource = null;
                    cmdmasterExist.Enabled = false;
                    cmdmasterExist.Items.Clear();
                }
            }
        }

        private void cmbCarsExist_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdmasterExist.DataSource = General.context.Masters
            .Select(x => new { x.ID, fio = x.SurName.Trim() + " " + x.Name.Trim() + " " + x.Patronymic.Trim() })
            .OrderBy(t => t.fio)
            .ToList();
            cmdmasterExist.DisplayMember = "fio";
            cmdmasterExist.ValueMember = "ID";
            if (cmbCarsExist.SelectedItem == null) { cmdmasterExist.Enabled = false; }
            else { cmdmasterExist.Enabled = true; cmdmasterExist.SelectedItem = null; }
        }

        private void cmdmasterExist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdmasterExist.SelectedItem != null)
                btnAddQueryExist.Enabled = true;
            else
                btnAddQueryExist.Enabled = false;
            //MessageBox.Show(cmdmasterExist.Items[cmdmasterExist.SelectedIndex].ToString());
        }

        private void txtFioNew_TextChanged(object sender, EventArgs e)
        {
            string str = txtFioNew.Text.Replace("  ", " ");
            for (int i = 0; i < str.Length; i++)
                if (!char.IsLetter(str[i]) && str[i] != ' ')
                    str = str.Replace(str[i].ToString(), "");
            txtFioNew.Text = str;
            if (txtFioNew.Text.Trim() == "")
            {
                cmbCarsNew.Enabled = false;
                cmbCarsNew.DataSource = null;
                cmbCarsNew.Items.Clear();
                cmdmasterNew.Enabled = false;
                cmdmasterNew.DataSource = null;
                cmdmasterNew.Items.Clear();
                txtGRSNew.Text = "";
                txtCOLORNew.Text = "";
                txtEnNumberNew.Text = "";
                txtPTSNew.Text = "";
                txtPhoneNew.Enabled = false;
                txtPhoneNew.Text = "";
            }
            else
            {
                if (cmbCarsNew.DataSource == null)
                {
                    var result = General.context.ModelCars.Select(x => new { x.ID, NameModel = x.NameCar.Trim() }).OrderBy(t => t.NameModel).ToList();
                    cmbCarsNew.DataSource = result;
                    cmbCarsNew.DisplayMember = "NameModel";
                    cmbCarsNew.ValueMember = "ID";
                    cmbCarsNew.SelectedItem = null;
                    cmbCarsNew.Enabled = true;
                }
            }
        }

        private void dtgQuery_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgQuery.SelectedRows.Count > 0)
                if (dtgQuery.SelectedRows[0].Index != -1)
                {
                    int i_row = dtgQuery.SelectedRows[0].Index;
                    string FIOClient = dtgQuery.Rows[i_row].Cells[0].FormattedValue.ToString().TrimStart().TrimEnd();
                    string stringCar = dtgQuery.Rows[i_row].Cells[1].FormattedValue.ToString().TrimStart().TrimEnd();
                    int masterid = Convert.ToInt32(dtgQuery.Rows[i_row].Cells[3].FormattedValue.ToString());
                    DateTime birthday = Convert.ToDateTime(dtgQuery.Rows[i_row].Cells[2].FormattedValue);
                    DateTime dtvisit = Convert.ToDateTime(dtgQuery.Rows[i_row].Cells[5].FormattedValue);
                    string FIOMaster = dtgQuery.Rows[i_row].Cells[4].FormattedValue.ToString().TrimStart().TrimEnd();
                    bool check = Convert.ToBoolean(dtgQuery.Rows[i_row].Cells[8].FormattedValue);

                    DateTime? MyNullableDate = null;

                    if (dtgQuery.Rows[i_row].Cells[6].FormattedValue.ToString().Trim() != "")
                        MyNullableDate = Convert.ToDateTime(dtgQuery.Rows[i_row].Cells[6].FormattedValue);

                    var result = General.context.QueryAutoService
                        .Join(General.context.Clients, query => query.ClientID, client => client.ID, (query, client) => new { query, client })
                        .Join(General.context.Services, query => query.query.ServiceID, service => service.ID, (query, service) => new { query, service })
                        .Join(General.context.Masters, query => query.query.query.MasterID, master => master.ID, (query, master) => new { query, master })
                        .GroupBy(p => new
                        {
                            clientID = p.query.query.client.ID,
                            clientFIO = p.query.query.client.SurName.Trim() + " " + p.query.query.client.Name.Trim() + " " + p.query.query.client.Patronymic.Trim(),
                            car = p.query.query.client.Cars.ModelCars.NameCar.Trim() + " " + p.query.query.client.Cars.RegisterSign.Trim() + " | Цвет: " + p.query.query.client.Cars.color.Trim() + " | Номер двигателя: " + p.query.query.client.Cars.EnNumber.Trim() + " | Номер тех паспорта: " + p.query.query.client.Cars.pts.Trim(),
                            bday = p.query.query.client.Birthday,
                            clientphone = p.query.query.client.Phone.Trim(),
                            masterID = p.master.ID,
                            master = p.master.SurName.Trim() + " " + p.master.Name.Trim() + " " + p.master.Patronymic.Trim(),
                            serviceID = p.query.service.ID,
                            serviceName = p.query.service.Name,
                            servicePrice = p.query.service.Price,
                            serviceDetails = p.query.service.Details,
                            dateVisit = p.query.query.query.DateVisit,
                            dateReady = p.query.query.query.DateReady,
                            done = p.query.query.query.Done
                        }).Where(
                        t =>
                        t.Key.clientFIO == FIOClient &&
                     t.Key.car == stringCar &&
                     t.Key.bday == birthday &&
                     t.Key.masterID == masterid &&
                     t.Key.dateVisit == dtvisit &&
                     t.Key.dateReady == MyNullableDate &&
                     t.Key.master == FIOMaster &&
                     t.Key.done == check
                    ).Select(qwe => new
                    {
                        qwe.Key.serviceID,
                        Услуга = qwe.Key.serviceName.Trim(),
                        Цена = qwe.Key.servicePrice,
                        DetailsService = qwe.Key.serviceDetails.Trim()
                    }).ToList();
                    dtgListService.DataSource = result;

                    dtgListService.Columns[0].Visible = false;
                    dtgListService.Columns[1].Width = 200;
                    dtgListService.Columns[3].Visible = false;
                    dtgListService.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    decimal sum = 0;
                    for (int i = 0; i < dtgListService.RowCount; i++)
                    {
                        sum += Convert.ToDecimal(dtgListService.Rows[i].Cells[2].Value);
                    }
                    txtPrice.Text = sum + " ₽.";
                }
        }

        private void dtgQuery_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgQuery.SelectedRows.Count > 0)
            {
                int i_row = dtgQuery.SelectedRows[0].Index;
                int i_cell = dtgQuery.CurrentCell.ColumnIndex;
                if (dtgQuery.SelectedRows[0].Index >= 0 && dtgQuery.Rows[i_row].Cells[i_cell].FormattedValue.ToString() != "")
                {
                    Clipboard.SetText(dtgQuery.Rows[i_row].Cells[i_cell].FormattedValue.ToString().Trim());
                }
                else
                    MessageBox.Show("Ячейка пуста!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddQueryExist_Click(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(dtpDateBExist.Value.Year, dtpDateBExist.Value.Month, dtpDateBExist.Value.Day);
            string clientfio = txtFioExist.Text.Trim();
            int carID = Convert.ToInt32(cmbCarsExist.SelectedValue);
            string carinfo = General.context.Cars
            .Where(x => x.ID == carID).Select(x => new { name = x.ModelCars.NameCar.Trim() + " " + x.RegisterSign.Trim() + " | Цвет: " + x.color.Trim() + " | Номер двигателя: " + x.EnNumber.Trim() + " | Номер тех паспорта: " + x.pts.Trim() }).Select(x => x.name).First().ToString().Trim();
            int masterID = Convert.ToInt32(cmdmasterExist.SelectedValue);
            string masterfio = General.context.Masters
            .Where(x => x.ID == masterID).Select(x => new { name = x.SurName.Trim() + " " + x.Name.Trim() + " " + x.Patronymic.Trim() }).Select(x => x.name).First().ToString().Trim();

            var result = General.context.Clients.Where(x =>
            x.CarID == carID &&
            (x.SurName.Trim() + " " + x.Name.Trim() + " " + x.Patronymic.Trim()) == clientfio &&
            x.Birthday == dt
            ).Select(x => x.ID).ToList();

            if (result.Count != 0)
            {
                int clientID = result.First();
                int i_row = dtgQuery.SelectedRows[0].Index;
                using (SettingsAllQueryForm sett = new SettingsAllQueryForm())
                {
                    AllQuerySettings.ClientFIO = clientfio;
                    AllQuerySettings.ClientID = clientID;
                    AllQuerySettings.CarInfo = carinfo;
                    AllQuerySettings.Birthday = dt;
                    AllQuerySettings.MasterID = masterID;
                    AllQuerySettings.MasterFIO = masterfio;
                    AllQuerySettings.DateVisit = DateTime.Now;
                    AllQuerySettings.DateForReady = null;
                    AllQuerySettings.Done = false;
                    sett.ShowDialog();
                    RefreshDataGrid();
                    dtgQuery.Rows[i_row].Cells[0].Selected = true;
                    txtFioExist.Text = "";
                    GetInfoCount();
                }
            }
            else
            {
                MessageBox.Show("Клиента с такими данными не существует", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFioExist.Text = "";
            }
        }

        private void dtpDateBExist_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btndelquery_Click(object sender, EventArgs e)
        {
            if (dtgQuery.SelectedRows.Count > 0)
            {
                if (dtgQuery.SelectedRows[0].Index != -1)
                {
                    int i_row = dtgQuery.SelectedRows[0].Index;

                    DateTime dateVisit = Convert.ToDateTime(dtgQuery.Rows[i_row].Cells[5].Value);

                    DateTime? dateforReady = null;
                    if (dtgQuery.Rows[i_row].Cells[6].FormattedValue.ToString().Trim() != "")
                        dateforReady = Convert.ToDateTime(dtgQuery.Rows[i_row].Cells[6].FormattedValue);

                    int masterID = Convert.ToInt32(dtgQuery.Rows[i_row].Cells[3].Value);
                    string clientFIO = dtgQuery.Rows[i_row].Cells[0].FormattedValue.ToString().Trim();
                    string carInfo = dtgQuery.Rows[i_row].Cells[1].FormattedValue.ToString().Trim();
                    bool done = Convert.ToBoolean(dtgQuery.Rows[i_row].Cells[8].FormattedValue.ToString().Trim());
                    var query = General.context.QueryAutoService.Where(
                    x =>
                      ((x.Clients.SurName.Trim() + " " + x.Clients.Name.Trim() + " " + x.Clients.Patronymic.Trim()).Trim() == clientFIO) &&
                      ((x.Clients.Cars.ModelCars.NameCar.Trim() + " " + x.Clients.Cars.RegisterSign.Trim() + " | Цвет: " + x.Clients.Cars.color.Trim() + " | Номер двигателя: " + x.Clients.Cars.EnNumber.Trim() + " | Номер тех паспорта: " + x.Clients.Cars.pts.Trim()) == carInfo) &&
                      (x.MasterID == masterID) &&
                      (x.DateVisit == dateVisit) &&
                      (x.DateReady == dateforReady) &&
                      (x.Done == done)
                      ).ToList();
                    foreach (QueryAutoService s in query)
                    {
                        General.context.QueryAutoService.Remove(s);
                    }

                    General.context.SaveChanges();
                    RefreshDataGrid();
                    if (dtgQuery.RowCount > i_row)
                        dtgQuery.Rows[i_row].Cells[0].Selected = true;
                    GetInfoCount();
                }
            }
            else
            {
                MessageBox.Show("Выделите строку в таблице заявок!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSettingsQuery_Click(object sender, EventArgs e)
        {
            if (dtgQuery.SelectedRows.Count > 0)
            {
                if (dtgQuery.SelectedRows[0].Index != -1)
                {
                    int i_row = dtgQuery.SelectedRows[0].Index;
                    if (!Convert.ToBoolean(dtgQuery.Rows[i_row].Cells[8].FormattedValue.ToString().Trim()))
                        using (SettingsAllQueryForm sett = new SettingsAllQueryForm())
                        {
                            AllQuerySettings.ClientFIO = dtgQuery.Rows[i_row].Cells[0].FormattedValue.ToString().Trim();
                            AllQuerySettings.ClientID = Convert.ToInt32(dtgQuery.Rows[i_row].Cells[9].Value);
                            AllQuerySettings.CarInfo = dtgQuery.Rows[i_row].Cells[1].FormattedValue.ToString().Trim();
                            AllQuerySettings.Birthday = Convert.ToDateTime(dtgQuery.Rows[i_row].Cells[2].Value);
                            AllQuerySettings.MasterID = Convert.ToInt32(dtgQuery.Rows[i_row].Cells[3].Value);
                            AllQuerySettings.MasterFIO = dtgQuery.Rows[i_row].Cells[4].FormattedValue.ToString().Trim();
                            AllQuerySettings.DateVisit = Convert.ToDateTime(dtgQuery.Rows[i_row].Cells[5].Value);
                            if (dtgQuery.Rows[i_row].Cells[6].FormattedValue.ToString().Trim() != "")
                                AllQuerySettings.DateForReady = Convert.ToDateTime(dtgQuery.Rows[i_row].Cells[6].FormattedValue);
                            AllQuerySettings.Done = Convert.ToBoolean(dtgQuery.Rows[i_row].Cells[8].FormattedValue.ToString().Trim());
                            sett.ShowDialog();
                            RefreshDataGrid();
                            dtgQuery.Rows[i_row].Cells[0].Selected = true;
                            GetInfoCount();
                        }
                    else
                    {
                        MessageBox.Show("Данная заявка уже выполнена и не подлежит редактированию!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выделите строку в таблице заявок!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddQueryNew_Click(object sender, EventArgs e)
        {
            try
            {
                int carID = -1;
                int clientID = -1;
                DateTime dt = new DateTime(dtpDateBNew.Value.Year, dtpDateBNew.Value.Month, dtpDateBNew.Value.Day);
                string clientfio = txtFioNew.Text.Trim();
                bool is_car = false, is_client = false;
                int amount = new Regex(" ").Matches(clientfio).Count;

                string[] fio = clientfio.Split(' ');  // surname, name, patron
                var temp_client = General.context.Clients
                        .Where(x => (x.SurName.Trim() + x.Name.Trim() + x.Patronymic.Trim()) == clientfio.Replace(" ", "") && x.Birthday == dt)
                        .ToList();
                if (temp_client.Count == 0)
                {
                    if (amount >= 1)
                    {
                        string carinfo = "";
                        #region Car
                        int modelcarID = Convert.ToInt32(cmbCarsNew.SelectedValue);
                        var cars = General.context.Cars
                            .Where(x => x.ModelCarID == modelcarID && x.RegisterSign.Trim() == txtGRSNew.Text.Trim() && x.color.Trim() == txtCOLORNew.Text.Trim() && x.EnNumber.Trim() == txtEnNumberNew.Text.Trim() && x.pts.Trim() == txtPTSNew.Text.Trim())
                            .ToList();
                        Cars car = new Cars() { ModelCarID = modelcarID, RegisterSign = txtGRSNew.Text.Trim(), color = txtCOLORNew.Text.Trim(),EnNumber = txtEnNumberNew.Text.Trim(),pts = txtPTSNew.Text.Trim()};
                        if (cars.Count == 0)
                        {
                            try
                            {
                                General.context.Cars.Add(car);
                                General.context.SaveChanges();
                                carID = car.ID;
                                carinfo = General.context.ModelCars.Where(z => z.ID == modelcarID).Select(x => x.NameCar).First().ToString().Trim() + " " + car.RegisterSign.Trim() + " | Цвет: " + car.color.Trim() + " | Номер двигателя: " + car.EnNumber.Trim() + " | Номер тех паспорта: " + car.pts.Trim();
                                is_car = true;
                            }
                            catch (Exception)
                            {
                                General.context.Cars.Remove(car);
                                General.context.SaveChanges();
                            }
                        }
                        else
                        {
                            carID = cars.Select(x => x.ID).First();
                            carinfo = General.context.ModelCars.Where(z => z.ID == modelcarID).Select(x => x.NameCar).First().ToString().Trim() + " " + car.RegisterSign.Trim() + " | Цвет: " + car.color.Trim() + " | Номер двигателя: " + car.EnNumber.Trim() + " | Номер тех паспорта: " + car.pts.Trim();
                            is_car = true;
                        }
                        #endregion Car

                        #region Master
                        int masterID = Convert.ToInt32(cmdmasterNew.SelectedValue);
                        string masterfio = General.context.Masters
                            .Where(x => x.ID == masterID).Select(x => new { name = x.SurName.Trim() + " " + x.Name.Trim() + " " + x.Patronymic.Trim() }).Select(x => x.name).First().ToString();
                        #endregion Master

                        #region Client

                        var clients = General.context.Clients.Where(x =>
                           (x.SurName.Trim() + " " + x.Name.Trim() + " " + x.Patronymic.Trim()) == clientfio &&
                           x.Birthday == dt &&
                           x.Phone.Trim() == txtPhoneNew.Text.Trim()
                           ).Select(x => x.ID).ToList();

                        #endregion Clien

                        if (clients.Count == 0)
                        {
                            Clients client = new Clients();
                            client.SurName = fio[0];
                            client.Name = fio[1];
                            if (amount == 2) client.Patronymic = fio[2];
                            client.Birthday = dt;
                            client.Phone = txtPhoneNew.Text.Trim();
                            client.CarID = carID;
                            client.imagename = "noimage.png";
                            try
                            {
                                General.context.Clients.Add(client);
                                General.context.SaveChanges();
                                clientID = client.ID;
                                is_client = true;
                            }
                            catch (Exception)
                            {
                                General.context.Clients.Remove(client);
                                General.context.SaveChanges();
                            }
                            if (is_client && is_car)
                                using (SettingsAllQueryForm sett = new SettingsAllQueryForm())
                                {
                                    int i_row = dtgQuery.SelectedRows[0].Index;
                                    AllQuerySettings.ClientFIO = clientfio;
                                    AllQuerySettings.ClientID = clientID;
                                    AllQuerySettings.CarInfo = carinfo;
                                    AllQuerySettings.Birthday = dt;
                                    AllQuerySettings.MasterID = masterID;
                                    AllQuerySettings.MasterFIO = masterfio;
                                    AllQuerySettings.DateVisit = DateTime.Now;
                                    AllQuerySettings.DateForReady = null;
                                    AllQuerySettings.Done = false;
                                    sett.ShowDialog();
                                    RefreshDataGrid();
                                    dtgQuery.Rows[i_row].Cells[0].Selected = true;
                                    txtFioNew.Text = "";
                                    GetInfoCount();
                                }
                        }
                        else
                        {
                            MessageBox.Show("Клиента с такими данными уже существует", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtFioNew.Text = "";
                        }
                    }
                    else
                        MessageBox.Show("Клиент обязательно должен иметь Имя и Фамилию", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Клиент с таким Ф.И.О и датой рождения уже существует!\n" +
                        "Перейдите во вкладку \"Существующие\".", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
        }

        private void cmbCarsNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCarsNew.SelectedItem != null)
            {
                txtGRSNew.Enabled = true;
                txtCOLORNew.Enabled = true;
                txtEnNumberNew.Enabled = true;
                txtPTSNew.Enabled = true;
                cmdmasterNew.DataSource = General.context.Masters
                .Select(x => new { x.ID, fio = x.SurName.Trim() + " " + x.Name.Trim() + " " + x.Patronymic.Trim() })
                .OrderBy(t => t.fio)
                .ToList();
                cmdmasterNew.DisplayMember = "fio";
                cmdmasterNew.ValueMember = "ID";
                cmdmasterNew.SelectedItem = null;
            }
            else
            {
                txtGRSNew.Enabled = false;
                txtCOLORNew.Enabled = false;
                txtEnNumberNew.Enabled = false;
                txtPTSNew.Enabled = false;
                cmdmasterNew.DataSource = null;
            }
            cmdmasterNew.Enabled = false;
        }

        private void txtGRSNew_TextChanged(object sender, EventArgs e)
        {
            string str = txtGRSNew.Text.Replace("  ", " ");

            if (txtGRSNew.Text.Trim() != "")
                cmdmasterNew.Enabled = true;
            else
            {
                cmdmasterNew.Enabled = false;
                cmdmasterNew.SelectedItem = null;
            }
            txtGRSNew.Text = str;
        }

        private void cmdmasterNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdmasterNew.SelectedItem != null)
            {
                txtPhoneNew.Enabled = true;
                btnAddQueryNew.Enabled = true;
                dtpDateBNew.Enabled = true;
            }
            else
            {
                dtpDateBNew.Enabled = false;
                btnAddQueryNew.Enabled = false;
                txtPhoneNew.Enabled = false;
                txtPhoneNew.Text = "";
            }
        }

        private void txtPhoneNew_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string str = txtPhoneNew.Text.Trim();
                for (int i = 0; i < str.Length; i++)
                    if (!char.IsDigit(str[i]) || str[i] == ' ')
                    {
                        str = str.Replace(str[i].ToString(), "");
                    }
                txtPhoneNew.Text = str.Trim();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
        }

        private void dtgListService_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgListService.SelectedRows[0].Index != -1)
            {
                int i_row = dtgListService.SelectedRows[0].Index;
                MessageBox.Show("-Услуга: " + dtgListService.Rows[i_row].Cells[1].FormattedValue.ToString().Trim() + "\n" +
                    "-Цена: " + dtgListService.Rows[i_row].Cells[2].FormattedValue.ToString().Trim() + " ₽\n" +
                    "-Описание:\n" + dtgListService.Rows[i_row].Cells[3].FormattedValue.ToString().Trim()
                    , "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSetDone_Click(object sender, EventArgs e)
        {
            if (dtgQuery.SelectedRows.Count > 0)
            {
                if (dtgQuery.SelectedRows[0].Index != -1)
                {
                    int i_row = dtgQuery.SelectedRows[0].Index;
                    if (!Convert.ToBoolean(dtgQuery.Rows[i_row].Cells[8].FormattedValue.ToString().Trim()))
                    {
                        AllQuerySettings.DateVisit = Convert.ToDateTime(dtgQuery.Rows[i_row].Cells[5].Value);
                        DateTime dateVisit = Convert.ToDateTime(dtgQuery.Rows[i_row].Cells[5].Value);
                        DateToReady dt = new DateToReady();

                        dt.ShowDialog();
                        DateTime dateforReady = dt.dtp.Value;

                        int masterID = Convert.ToInt32(dtgQuery.Rows[i_row].Cells[3].Value);

                        string clientFIO = dtgQuery.Rows[i_row].Cells[0].FormattedValue.ToString().Trim();
                        string carInfo = dtgQuery.Rows[i_row].Cells[1].FormattedValue.ToString().Trim();

                        var query = General.context.QueryAutoService.Where(
                            x =>
                              ((x.Clients.SurName.Trim() + " " + x.Clients.Name.Trim() + " " + x.Clients.Patronymic.Trim()).Trim() == clientFIO) &&
                              ((x.Clients.Cars.ModelCars.NameCar.Trim() + " " + x.Clients.Cars.RegisterSign.Trim() + " | Цвет: " + x.Clients.Cars.color.Trim() + " | Номер двигателя: " + x.Clients.Cars.EnNumber.Trim() + " | Номер тех паспорта: " + x.Clients.Cars.pts.Trim()) == carInfo) &&
                              (x.MasterID == masterID) &&
                              (x.DateVisit == dateVisit) &&
                              (x.DateReady == null) &&
                              (x.Done == false)
                              ).ToList();
                        foreach (QueryAutoService s in query)
                        {
                            s.DateReady = dateforReady;
                            s.Done = true;
                            General.context.QueryAutoService.Attach(s);
                            General.context.Entry(s).Property(c => c.DateReady).IsModified = true;
                            General.context.Entry(s).Property(c => c.Done).IsModified = true;
                        }

                        General.context.SaveChanges();
                        RefreshDataGrid();
                        dtgQuery.Rows[i_row].Cells[0].Selected = true;
                    }
                    else
                    {
                        MessageBox.Show("Данная заявка уже выполнена и не подлежит редактированию!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выделите строку в таблице заявок!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void dtgQuery_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int a = e.ColumnIndex;

            dtgQuery.Columns[0].Selected = true;

        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersForm myUserForm = new UsersForm();
            myUserForm.ShowDialog();
        }
    }

}
