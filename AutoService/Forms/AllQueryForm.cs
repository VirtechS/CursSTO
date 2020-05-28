using AutoService.OtherForms;
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
using AllQuerySettings = AutoService.ConneectClass.AllQuerySettings;

namespace AutoService.Forms
{
    public partial class AllQueryForm : Form
    {
        public AllQueryForm()
        {
            InitializeComponent();
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
                        car = p.query.query.client.Cars.ModelCars.NameCar.Trim() + " " + p.query.query.client.Cars.RegisterSign.Trim(),
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
                }).OrderByDescending(order => order.dateVisit).ToList();
                SettingsDataGrid();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

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
        private void GetInfoCount()
        {
            tlsInfoCountCar.Text = "Найдено " + dtgQuery.RowCount.ToString() + " " + GetWord(dtgQuery.RowCount);
        }

        private void SettingsDataGrid()
        {
            dtgQuery.Columns[0].HeaderText = "Клиент";
            dtgQuery.Columns[1].HeaderText = "Авто";
            dtgQuery.Columns[2].HeaderText = "Дата рождения";
            dtgQuery.Columns[4].HeaderText = "Мастер";
            dtgQuery.Columns[5].HeaderText = "Принято";
            dtgQuery.Columns[6].HeaderText = "Выпущено";

            dtgQuery.Columns[0].Width = 175;
            dtgQuery.Columns[1].Width = 160;
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

        private void AllQueryForm_Load(object sender, EventArgs e)
        {
            if (General.mode == (int)General.Status.Admin)
            {
                button2.Enabled = true;
                btnSettingsQuery.Enabled = true;
            }
            else
            if (General.mode == (int)General.Status.User)
            {
                button2.Enabled = false;
                btnSettingsQuery.Enabled = false;
            }
            else { MessageBox.Show("Ошибка разграничения пользователей!", "Предупреждение", MessageBoxButtons.OK); Application.Restart(); }
            RefreshDataGrid();
            GetInfoCount();
            btnfind.Enabled = false;
            cmbCars.Enabled = false;
            cmdmaster.Enabled = false;
            dtpVisit.Enabled = false;
            dtpReady.Enabled = false;
            checkBox1.Enabled = false;
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
                            car = p.query.query.client.Cars.ModelCars.NameCar.Trim() + " " + p.query.query.client.Cars.RegisterSign.Trim(),
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

        private void infoMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В этом окне осуществляется работа со всеми существующими заявками.\nДля получения информации по услуге воспользуйтесь " +
            "двойным щелчком мыши по нужной услуге.\n" +
      "Оформление новых заявок находится в главном окне программы.\n" +
      "Все цены указаны в рублях." +
      "Двойным нажатием по ячейке можно скопировать её значение в буфер обмена."
                , "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
                              ((x.Clients.Cars.ModelCars.NameCar.Trim() + " " + x.Clients.Cars.RegisterSign.Trim()) == carInfo) &&
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
                        MessageBox.Show("Готово!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button2_Click(object sender, EventArgs e)
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
                      ((x.Clients.Cars.ModelCars.NameCar.Trim() + " " + x.Clients.Cars.RegisterSign.Trim()) == carInfo) &&
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

        private void txtFIO_TextChanged(object sender, EventArgs e)
        {
            if (txtFIO.Text.Trim() == "")
            {
                cmbCars.Enabled = false;
                cmbCars.Items.Clear();
                cmdmaster.Enabled = false;
                cmdmaster.Items.Clear();
                dtpVisit.Enabled = false;
                dtpReady.Enabled = false;
                checkBox1.Enabled = false;
            }
            else
            {
                string str = txtFIO.Text;
                str = str.Replace("  ", " ");
                for (int i = 0; i < str.Length; i++)
                    if (!char.IsLetter(str[i]) && str[i] != ' ')
                        str = str.Replace(str[i].ToString(), "");
                txtFIO.Text = str;
                cmbCars.Items.Clear();
                var result = General.context.Clients
                .Join(General.context.Cars, client => client.CarID, car => car.ID, (client, car) => new { client, car }).Where(z => z.car.ID == z.client.CarID)
                .Where(x => x.client.SurName.Trim() + " " + x.client.Name.Trim() + " " + x.client.Patronymic.Trim() == str.Trim())
                .Select(t => t.car.ModelCars.NameCar.Trim() + " " + t.car.RegisterSign.Trim())
                .ToList();
                if (result.Count > 0)
                {
                    cmbCars.Enabled = true;
                    for (int i = 0; i < result.Count; i++) cmbCars.Items.Add(result[i]);
                }
                else
                {
                    cmbCars.Enabled = false;
                    cmbCars.Text = "";
                    cmbCars.Items.Clear();
                    cmdmaster.Enabled = false;
                    cmdmaster.Text = "";
                    cmdmaster.Items.Clear();
                    dtpVisit.Enabled = false;
                    dtpReady.Enabled = false;
                    checkBox1.Enabled = false;
                }
            }

        }

        private void cmbCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = txtFIO.Text.Trim();
            string car = cmbCars.SelectedItem.ToString().Trim();
            if (cmbCars.Items.Count > 0 && car != "")
            {
                cmdmaster.Items.Clear();
                cmdmaster.Text = "";
                var result = General.context.QueryAutoService
                    .Where(t => (t.Clients.SurName.Trim() + " " + t.Clients.Name.Trim() + " " + t.Clients.Patronymic.Trim()) == str &&
                   (t.Clients.Cars.ModelCars.NameCar.Trim() + " " + t.Clients.Cars.RegisterSign.Trim()) == car)
                   .Select(x => new
                   {
                       masterFIO = x.Masters.SurName.Trim() + " " + x.Masters.Name.Trim() + " " + x.Masters.Patronymic.Trim()
                   }).Distinct().ToList();
                if (result.Count > 0)
                {
                    cmdmaster.Enabled = true;
                    for (int i = 0; i < result.Count; i++) cmdmaster.Items.Add(result[i].masterFIO);
                }
            }
            else
            {
                cmdmaster.Enabled = false;
                cmdmaster.Text = "";
                cmdmaster.Items.Clear();
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

        private void cmdmaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdmaster.SelectedIndex >= 0)
            {
                dtpVisit.Enabled = true;
                dtpReady.Enabled = true;
                checkBox1.Enabled = true;
                btnfind.Enabled = true;
            }
            else
            {
                dtpVisit.Enabled = false;
                dtpReady.Enabled = false;
                checkBox1.Enabled = false;
                btnfind.Enabled = false;
            }

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtFIO.Text = "";
            checkBox1.Checked = false;
            btnfind.Enabled = false;
            RefreshDataGrid();
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            string clientFIO = txtFIO.Text.Trim();
            string car = cmbCars.SelectedItem.ToString().Trim();
            string masterFIO = cmdmaster.SelectedItem.ToString().Trim();

            var result = General.context.QueryAutoService
            .Join(General.context.Clients, query => query.ClientID, client => client.ID, (query, client) => new { query, client })
            .Join(General.context.Services, query => query.query.ServiceID, service => service.ID, (query, service) => new { query, service })
            .Join(General.context.Masters, query => query.query.query.MasterID, master => master.ID, (query, master) => new { query, master })
            .GroupBy(p => new
            {
                clientID = p.query.query.client.ID,
                clientFIO = p.query.query.client.SurName.Trim() + " " + p.query.query.client.Name.Trim() + " " + p.query.query.client.Patronymic.Trim(),
                car = p.query.query.client.Cars.ModelCars.NameCar.Trim() + " " + p.query.query.client.Cars.RegisterSign.Trim(),
                bday = p.query.query.client.Birthday,
                clientphone = p.query.query.client.Phone.Trim(),
                masterID = p.master.ID,
                master = p.master.SurName.Trim() + " " + p.master.Name.Trim() + " " + p.master.Patronymic.Trim(),
                dateVisit = p.query.query.query.DateVisit,
                dateReady = p.query.query.query.DateReady,
                done = p.query.query.query.Done
            }).Select(x => new
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
            });
            dtgQuery.DataSource = null;
            dtgQuery.ColumnCount = 0;

            if (checkBox1.Checked)
            {
                // Если заявка готова 
                #region is_readeQuery
                dtgQuery.DataSource = result.Where(t => t.clientFIO == clientFIO && t.master == masterFIO && t.car == car && (t.dateVisit >= dtpVisit.Value) && (t.dateReady <= dtpReady.Value) && t.done == true)
                .OrderByDescending(order => order.dateVisit).ToList();
                #endregion is_noReadeQuery
            }
            else
            {
                // Если заявка не готова
                #region is_readeQuery
                dtgQuery.DataSource = result.Where(t => t.clientFIO == clientFIO && t.master == masterFIO && t.car == car && t.done == false)
                .OrderByDescending(order => order.dateVisit).ToList();
                #endregion is_noReadeQuery
            }
            SettingsDataGrid();
            GetInfoCount();
        }
    }
}
