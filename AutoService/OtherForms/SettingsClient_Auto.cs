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
using System.Data.Entity.Infrastructure;

namespace AutoService.OtherForms
{
    public partial class SettingsClient_Auto : Form
    {
        private string namepic = null;
        private bool is_correct = false;
        private bool is_click = false;
        int newclientID = -1;

        public SettingsClient_Auto()
        {
            InitializeComponent();
        }


        private void Inicio_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!is_correct && is_click)
                {
                    var client = General.context.Clients.Where(x => x.ID == newclientID).FirstOrDefault();
                    General.context.Clients.Remove(client);
                    General.context.SaveChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при удалении временной записи", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SettingsClient_Auto_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(Inicio_FormClosing_1);
            txtGRS.Enabled = false;
            dtpDateBirthday.MaxDate = new DateTime(DateTime.Now.Year - 18, 12, 31);
            btnSettings.Text = ClientAutoSettings.TextBtn;
            ClientAutoSettings.is_click = false;

            RefreshDataGridAllCars();
            RefReshDataGrid();
            var res = General.context.ModelCars.Select(x => new { NameModel = x.NameCar.Trim() }).OrderBy(t => t.NameModel).ToList();
            for (int i = 0; i < res.Count; i++)
                cmbmodel.Items.Add(res[i].NameModel);

            if (btnSettings.Text == "Изменить")
            {
                is_correct = true;
                dtpDateBirthday.Value = ClientAutoSettings.BirthdayClient;
                txtName.Text = ClientAutoSettings.NameClient;
                txtSurname.Text = ClientAutoSettings.SurnameClient;
                txtPatron.Text = ClientAutoSettings.PatronymicClient;
                txtPhone.Text = ClientAutoSettings.PhoneClient;
                try
                {
                    if (ClientAutoSettings.namePicture.Trim() == "")
                    {
                        picBox.Image = Image.FromFile(General.pathNoImage);
                    }
                    else
                        picBox.Image = Image.FromFile(General.directory + "\\images\\Клиенты\\" + ClientAutoSettings.namePicture);
                }
                catch (Exception)
                {
                    picBox.Image = Image.FromFile(General.pathNoImage);
                }
            }
            else
            {
                dtgCars.DataSource = null;

                btnaddOldCar.Enabled = false;
                groupNewCar.Enabled = false;
                ClientAutoSettings.namePicture = "noimage.png";
            }

        }

        private void RefreshDataGridAllCars()
        {
            dtgAllCars.DataSource = General.context.Cars
            .Select(x => new
            {
                id = x.ID,
                model = x.ModelCars.NameCar.Trim(),
                grs = x.RegisterSign.Trim()
            })
            .OrderBy(order => order.model)
            .ToList();
            dtgAllCars.Columns[0].Visible = false;
            dtgAllCars.Columns[1].HeaderText = "Марка";
            dtgAllCars.Columns[1].Width = 100;
            dtgAllCars.Columns[2].HeaderText = "ГРЗ";
            dtgAllCars.Columns[2].Width = 120;
            dtgAllCars.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void RefReshDataGrid()
        {
            string FIO = ClientAutoSettings.SurnameClient + " " + ClientAutoSettings.NameClient + " " + ClientAutoSettings.PatronymicClient;
            DateTime Birthday = ClientAutoSettings.BirthdayClient;
            string Phone = ClientAutoSettings.PhoneClient;
            string imgname = null;
            if (ClientAutoSettings.namePicture != "")
                imgname = ClientAutoSettings.namePicture;

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
         ).OrderBy(order => order.Марка).ToList();
            dtgCars.DataSource = result;

            dtgCars.Columns[0].Visible = false;
            dtgCars.Columns[1].HeaderText = "Марка";
            dtgCars.Columns[1].Width = 100;
            dtgCars.Columns[2].HeaderText = "ГРЗ";
            dtgCars.Columns[2].Width = 120;
            dtgCars.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void btnGetPicture_Click(object sender, EventArgs e)
        {
            try
            {
                FileDilogPicture.DefaultExt = "png";
                FileDilogPicture.FileName = "";
                FileDilogPicture.InitialDirectory = General.directory + "\\images\\Клиенты";
                FileDilogPicture.Filter = "Image files (*.png)|*.png|All files (*.*)|*.*";
                FileDilogPicture.ShowDialog();
                if (FileDilogPicture.SafeFileName != "")
                {
                    picBox.Image = Image.FromFile(General.directory + "\\images\\Клиенты\\" + FileDilogPicture.SafeFileName);
                    namepic = FileDilogPicture.SafeFileName;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неправильное расположение файла!", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (btnSettings.Text == "Изменить")
            {
                try
                {
                    // Редактируем выбранного пользователя
                    var query = General.context.Clients.Where(x =>
                         ((x.SurName.Trim() + " " + x.Name.Trim() + " " + x.Patronymic.Trim()) == (ClientAutoSettings.SurnameClient + " " + ClientAutoSettings.NameClient + " " + ClientAutoSettings.PatronymicClient)) &&
                         (x.Birthday == ClientAutoSettings.BirthdayClient) &&
                         x.Phone == ClientAutoSettings.PhoneClient &&
                         x.imagename == ClientAutoSettings.namePicture
                          ).ToList();
                    foreach (Clients s in query)
                    {
                        s.SurName = txtSurname.Text.Trim();
                        s.Name = txtName.Text.Trim();
                        s.Patronymic = txtPatron.Text.Trim();
                        s.Phone = txtPhone.Text.Trim();
                        s.imagename = namepic;
                        s.Birthday = dtpDateBirthday.Value;

                        General.context.Clients.Attach(s);

                        General.context.Entry(s).Property(c => c.SurName).IsModified = true;
                        General.context.Entry(s).Property(c => c.Name).IsModified = true;
                        General.context.Entry(s).Property(c => c.Patronymic).IsModified = true;
                        General.context.Entry(s).Property(c => c.Phone).IsModified = true;
                        General.context.Entry(s).Property(c => c.imagename).IsModified = true;
                        General.context.Entry(s).Property(c => c.Birthday).IsModified = true;
                    }

                    General.context.SaveChanges();
                    ClientAutoSettings.SurnameClient = txtSurname.Text.Trim();
                    ClientAutoSettings.NameClient = txtName.Text.Trim();
                    ClientAutoSettings.PatronymicClient = txtPatron.Text.Trim();
                    ClientAutoSettings.PhoneClient = txtPhone.Text.Trim();
                    ClientAutoSettings.BirthdayClient = dtpDateBirthday.Value;
                    ClientAutoSettings.namePicture = namepic;
                    MessageBox.Show("Готово!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message.ToString());
                    //MessageBox.Show("Выделите строку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    this.Close();
                }
            }
            else
            {
                if (txtName.Text.Trim() != "" && txtSurname.Text.Trim() != "")
                {
                    try
                    {
                        if (DateTime.Now.Year - dtpDateBirthday.Value.Year >= 18)
                        {
                            Clients client = new Clients();
                            client.SurName = txtSurname.Text.Trim();
                            client.Name = txtName.Text.Trim();
                            client.Patronymic = txtPatron.Text.Trim();
                            client.Phone = txtPhone.Text.Trim();
                            client.imagename = namepic;
                            client.Birthday = dtpDateBirthday.Value;
                            client.CarID = 1;

                            General.context.Clients.Add(client);
                            General.context.SaveChanges();
                            ClientAutoSettings.BirthdayClient = dtpDateBirthday.Value;
                            ClientAutoSettings.NameClient = txtName.Text;
                            ClientAutoSettings.SurnameClient = txtSurname.Text;
                            ClientAutoSettings.PatronymicClient = txtPatron.Text;
                            ClientAutoSettings.PhoneClient = txtPhone.Text;
                            ClientAutoSettings.namePicture = namepic;

                            newclientID = client.ID;
                            is_click = true;
                            groupNewCar.Enabled = true;
                            btnaddOldCar.Enabled = true;
                            MessageBox.Show("Готово!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnSettings.Text = "Изменить";
                        }
                        else MessageBox.Show("Возраст 18+!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (DbUpdateException )
                    {                       
                        MessageBox.Show("Ошибка обновления БД!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.Close();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.GetType().ToString());                       
                        //MessageBox.Show("Выделите строку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    MessageBox.Show("Поля \"Имя\" и \"Фамилия\" обязательны для заполнения.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cmbmodel_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGRS.Enabled = true;
        }

        private void btnExistClient_Click(object sender, EventArgs e)
        {
            if (cmbmodel.SelectedIndex != -1)
            {
                string model = cmbmodel.SelectedItem.ToString().Trim();
                int newindex = 0;
                Cars car = new Cars();
                Clients client = new Clients();

                if (btnSettings.Text == "Добавить")
                {
                    try
                    {
                        if (txtGRS.Text.Trim() != "")
                        {
                            car.ModelCarID = Convert.ToInt32(General.context.ModelCars.Where(x => x.NameCar == model).Select(x => x.ID).FirstOrDefault());
                            car.RegisterSign = txtGRS.Text.Trim();
                            General.context.Cars.Add(car);
                            General.context.SaveChanges();
                            newindex = car.ID;
                            var tempclient = General.context.Clients.Where(x => x.ID == newclientID).FirstOrDefault();
                            tempclient.CarID = newindex;

                            General.context.Clients.Attach(tempclient);
                            General.context.Entry(tempclient).Property(c => c.CarID).IsModified = true;
                            General.context.SaveChanges();
                            RefReshDataGrid();
                            RefreshDataGridAllCars();
                            txtGRS.Text = "";
                            cmbmodel.SelectedItem = null;
                            is_correct = true;
                        }
                    }
                    catch (Exception)
                    {
                        General.context.Cars.Remove(car);
                        General.context.Clients.Remove(client);
                        General.context.SaveChanges();
                        MessageBox.Show("Такой автомобиль уже существует", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    try
                    {
                        if (txtGRS.Text.Trim() != "")
                        {
                            car.ModelCarID = Convert.ToInt32(General.context.ModelCars.Where(x => x.NameCar == model).Select(x => x.ID).FirstOrDefault());
                            car.RegisterSign = txtGRS.Text.Trim();
                            try
                            {
                                General.context.Cars.Add(car);
                                General.context.SaveChanges();
                                newindex = car.ID;

                                client.SurName = ClientAutoSettings.SurnameClient;
                                client.Name = ClientAutoSettings.NameClient;
                                client.Patronymic = ClientAutoSettings.PatronymicClient;
                                client.Birthday = ClientAutoSettings.BirthdayClient;
                                client.Phone = ClientAutoSettings.PhoneClient;
                                client.imagename = ClientAutoSettings.namePicture;
                                client.CarID = newindex;

                                try
                                {
                                    General.context.Clients.Add(client);
                                    General.context.SaveChanges();

                                    RefReshDataGrid();
                                    RefreshDataGridAllCars();
                                }
                                catch (Exception)
                                {
                                    General.context.Clients.Remove(client);
                                    General.context.SaveChanges();
                                    MessageBox.Show("Это авто уже имеется в наличии у этого клиента", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception)
                            {
                                General.context.Cars.Remove(car);
                                General.context.SaveChanges();
                                MessageBox.Show("Такой автомобиль уже существует", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите ГРЗ", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                    catch (Exception exp)
                    {
                        General.context.Clients.Remove(client);
                        General.context.Cars.Remove(car);
                        General.context.SaveChanges();
                        MessageBox.Show(exp.Message.ToString());
                    }
                    finally
                    {
                        cmbmodel.SelectedItem = null;
                        txtGRS.Text = "";
                        txtGRS.Enabled = false;
                    }
                }
            }
            else
                MessageBox.Show("Авто не выбрано!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnaddOldCar_Click(object sender, EventArgs e)
        {
            if (dtgAllCars.SelectedRows.Count > 0)
                if (dtgAllCars.SelectedRows[0].Index >= 0)
                {
                    int index_car = Convert.ToInt32(dtgAllCars.SelectedRows[0].Cells[0].FormattedValue.ToString());
                    Clients client = new Clients();

                    client.SurName = ClientAutoSettings.SurnameClient;
                    client.Name = ClientAutoSettings.NameClient;
                    client.Patronymic = ClientAutoSettings.PatronymicClient;
                    client.Birthday = ClientAutoSettings.BirthdayClient;
                    client.Phone = ClientAutoSettings.PhoneClient;
                    client.imagename = ClientAutoSettings.namePicture;
                    client.CarID = index_car;

                    try
                    {
                        General.context.Clients.Add(client);
                        General.context.SaveChanges();
                        newclientID = client.ID;
                        RefReshDataGrid();
                        RefreshDataGridAllCars();
                        MessageBox.Show("Готово!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        General.context.Clients.Remove(client);
                        General.context.SaveChanges();
                        MessageBox.Show("Клиент уже владее этим авто", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    is_correct = true;
                }

        }

        private void SettingsClient_Auto_Leave(object sender, EventArgs e)
        {

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

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            string str = txtSurname.Text;
            str = str.Replace("  ", " ");
            for (int i = 0; i < str.Length; i++)
                if (!char.IsLetter(str[i]) && str[i] != ' ')
                    str = str.Replace(str[i].ToString(), "");
            txtSurname.Text = str;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            string str = txtName.Text;
            str = str.Replace("  ", " ");
            for (int i = 0; i < str.Length; i++)
                if (!char.IsLetter(str[i]) && str[i] != ' ')
                    str = str.Replace(str[i].ToString(), "");
            txtName.Text = str;
        }

        private void txtPatron_TextChanged(object sender, EventArgs e)
        {
            string str = txtPatron.Text;
            str = str.Replace("  ", " ");
            for (int i = 0; i < str.Length; i++)
                if (!char.IsLetter(str[i]) && str[i] != ' ')
                    str = str.Replace(str[i].ToString(), "");
            txtPatron.Text = str;
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В этом окне предоставляется возможность добавления нового владельца авто\n" +
"Каждое авто может дожен иметь только уникальных владельцев(без повторений)\n" +
"Авто может содержать несколько владельцев, независимо от ПТС", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
