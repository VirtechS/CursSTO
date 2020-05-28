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
using Auto_Client = AutoService.ConneectClass.AutoClientSettings;
using General = AutoService.ConneectClass.General;

namespace AutoService.Forms
{
    public partial class CarsForm : Form
    {

        public CarsForm()
        {
            InitializeComponent();

            try
            {
                RefreshDataGrid();
                dtgCars.Columns["CarID"].Visible = false;
                dtgCars.Columns["NameCar"].HeaderText = "Марка";
                dtgCars.Columns["NameCar"].Width = 100;
                dtgCars.Columns["RegisterSign"].HeaderText = "ГРЗ";
                dtgCars.Columns["RegisterSign"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dtgCars.Columns["ColorCar"].HeaderText = "Цвет";
                dtgCars.Columns["ColorCar"].Width = 100;
                dtgCars.Columns["EnNumberCar"].HeaderText = "Номер двигателя";
                dtgCars.Columns["EnNumberCar"].Width = 100;
                dtgCars.Columns["PTSCar"].HeaderText = "Номер тех паспорта";
                dtgCars.Columns["PTSCar"].Width = 100;
                dtgfio.DataSource = null;
            }
            catch (Exception)
            {
                MessageBox.Show("");
            }
        }

        // Формирование склонения слова "марка"

        private string GetWordAuto(int count)
        {
            count = count % 100;
            if (count >= 11 && count <= 19)
                return " автомобилей ";

            count = count % 10;
            switch (count)
            {
                case 1:
                    return " автомобиль ";
                case 2:
                case 3:
                case 4:
                    return " автомобиля ";
                default:
                    return " автомобилей ";
            }

        }
        private string GetWordClient(int count)
        {
            count = count % 100;
            if (count >= 11 && count <= 19)
                return "владельцев ";

            count = count % 10;
            switch (count)
            {
                case 1:
                    return "владелец ";
                case 2:
                case 3:
                case 4:
                    return "владельца ";
                default:
                    return "владельцев ";
            }

        }
        private void GetInfoCountNameCar()
        {
            if (dtgCars.SelectedRows.Count != 0 && dtgCars.RowCount != 1)
                tls.Text = "Найдено " + dtgCars.RowCount.ToString() + " " + GetWordAuto(dtgCars.RowCount) + ". У авто " +
                    dtgCars.SelectedRows[0].Cells[1].Value.ToString().Trim() + " " + dtgCars.SelectedRows[0].Cells[2].Value.ToString().Trim() + " " + dtgCars.SelectedRows[0].Cells[3].Value.ToString().Trim() + " " + dtgCars.SelectedRows[0].Cells[4].Value.ToString().Trim() + " " + dtgCars.SelectedRows[0].Cells[5].Value.ToString().Trim() + " " +
                    dtgfio.RowCount + "-" + GetWordClient(dtgfio.RowCount);
            else
            {
                if (dtgCars.RowCount != 0) tls.Text = "Найден " + 1 + GetWordAuto(1) + ". У авто " +
                   dtgCars.SelectedRows[0].Cells[1].Value.ToString().Trim() + " " + dtgCars.SelectedRows[0].Cells[2].Value.ToString().Trim() + " " + dtgCars.SelectedRows[0].Cells[3].Value.ToString().Trim() + " " + dtgCars.SelectedRows[0].Cells[4].Value.ToString().Trim() + " " + dtgCars.SelectedRows[0].Cells[5].Value.ToString().Trim() + " " +
                   dtgfio.RowCount + "-" + GetWordClient(dtgfio.RowCount);
                else
                    tls.Text = "Найдено " + 0 + GetWordAuto(0);
            }
        }

        private void RefreshDataGrid()
        {
            var result = General.context.Clients.Join(
                General.context.Cars,
                client => client.CarID,
                car => car.ID,
                    (client, car) =>
                        new { client, car }
                ).Join(
                General.context.ModelCars,
                car => car.car.ModelCarID,
                model => model.ID,
                (car, model) => new
                {
                    car,
                    model
                }).Where(ord => ord.car.car.ModelCarID == ord.model.ID).Select(
                x => new
                {
                    CarID = x.car.car.ID,
                    NameCar = x.model.NameCar,
                    RegisterSign = x.car.car.RegisterSign,
                    ColorCar = x.car.car.color,
                    EnNumberCar = x.car.car.EnNumber,
                    PTSCar = x.car.car.pts
                }
                ).Distinct();

            dtgCars.DataSource = result.ToList();

        }
        private void RefreshDtgFio()
        {
            if (dtgCars.SelectedRows.Count != 0)
            {
                int i_row = dtgCars.SelectedRows[0].Index;
                int id_car = Convert.ToInt32(dtgCars.SelectedRows[0].Cells[0].Value);

                var result = General.context.Clients.Select(x => new
                {
                    x.CarID,
                    x.SurName,
                    x.Name,
                    x.Patronymic,
                    x.Birthday,
                    x.Phone
                }).Where(z => z.CarID == id_car);

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
                    dtgCars.Columns[4].Width = 100;

                }
                catch (Exception)
                { }
                GetInfoCountNameCar();
            }
        }
        private void dtgCars_SelectionChanged(object sender, EventArgs e)
        {
            RefreshDtgFio();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string name = txtFind.Text.ToString().Trim();
                if (name != "")
                {
                    var result = General.context.Clients.Join(
                    General.context.Cars,
                    client => client.CarID,
                    car => car.ID,
                        (client, car) =>
                            new { client, car }
                    ).Join(
                    General.context.ModelCars,
                    car => car.car.ModelCarID,
                    model => model.ID,
                    (car, model) => new
                    {
                        car,
                        model
                    }).Where(ord => ord.car.car.ModelCarID == ord.model.ID).Select(
                    x => new
                    {
                        CarID = x.car.car.ID,
                        NameCar = x.model.NameCar,
                        RegisterSign = x.car.car.RegisterSign,
                        ColorCar = x.car.car.color,
                        EnNumberCar = x.car.car.EnNumber,
                        PTSCar = x.car.car.pts
                    }
                    ).Where(x => x.NameCar.Contains(name) || x.RegisterSign.Contains(name) || x.ColorCar.Contains(name) || x.EnNumberCar.Contains(name) || x.PTSCar.Contains(name)).Distinct();
                    dtgCars.DataSource = result.ToList();
                    if (dtgCars.RowCount == 0)
                        dtgfio.DataSource = null;
                }
                else RefreshDataGrid();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
            finally
            {
                GetInfoCountNameCar();
            }
        }

        private void CarsForm_Load(object sender, EventArgs e)
        {
            if (General.mode == (int)General.Status.Admin)
            {
                btnaddClient.Enabled = true; ;
            }
            else
            if (General.mode == (int)General.Status.User)
            {
                btnaddClient.Enabled = false;
            }
            else { MessageBox.Show("Ошибка разграничения пользователей!", "Предупреждение", MessageBoxButtons.OK); Application.Restart(); }
            GetInfoCountNameCar();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В данном окне выводится информация о владельцах авто.\n" +
        "Для добавления нового владельца воспользуйтесь соответствующей кнопкой.", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnaddClient_Click(object sender, EventArgs e)
        {

            if (dtgCars.SelectedRows[0].Index >= 0)
            {
                int i_row = dtgCars.SelectedRows[0].Index;

                Auto_Client.CarID = Convert.ToInt32(dtgCars.Rows[i_row].Cells[0].Value);
                Auto_Client.Model = dtgCars.Rows[i_row].Cells[1].Value.ToString();
                Auto_Client.GRS = dtgCars.Rows[i_row].Cells[2].Value.ToString();
                Auto_Client.COLOR = dtgCars.Rows[i_row].Cells[3].Value.ToString();
                Auto_Client.EnNumber = dtgCars.Rows[i_row].Cells[4].Value.ToString();
                Auto_Client.PTS = dtgCars.Rows[i_row].Cells[5].Value.ToString();

                using (SettingsAuto_Client autoclient = new SettingsAuto_Client())
                {
                    autoclient.ShowDialog();
                    RefreshDtgFio();
                }
            }
            else
            {

            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
