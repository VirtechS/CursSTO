using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using General = AutoService.ConneectClass.General;
using MarkaAutoSettings = AutoService.ConneectClass.MarkaAutoSettings;


namespace AutoService.Forms
{
    public partial class ModelCarsForm : Form
    {
        // Список картинок
        private List<Image> images = new List<Image>();
        // Список имён
        private List<string> nameimages = new List<string>();
        private string namepic = "";

        public ModelCarsForm()
        {
            InitializeComponent();
            try
            {
                RefreshDataGrid();
                dtgModelCars.Columns["ID"].Visible = false;
                dtgModelCars.Columns["imagename"].Visible = false;
                dtgModelCars.Columns["NameCar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dtgModelCars.Columns["NameCar"].HeaderText = "Марки авто";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

        }

        private void ModelCarsForm_Load(object sender, EventArgs e)
        {
            if (General.mode == (int)General.Status.Admin)
            {
                btnAddNameCar.Enabled = true;
                btnSettNameCar.Enabled = true;
            }
            else
           if (General.mode == (int)General.Status.User)
            {
                btnAddNameCar.Enabled = false;
                btnSettNameCar.Enabled = false;
            }
            else { MessageBox.Show("Ошибка разграничения пользователей!", "Предупреждение", MessageBoxButtons.OK); Application.Restart(); }
            GetInfoCountNameCar();
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
            tlsInfoCountCar.Text = "Найдено " + dtgModelCars.RowCount.ToString() + GetWord(dtgModelCars.RowCount);
        }

        private void RefreshDataGrid(string findtext = "")
        {
            dtgModelCars.DataSource = General.context.ModelCars.Select(x => new
            {
                ID = x.ID,
                NameCar = x.NameCar,
                imagename = x.imagename
            }
            ).Where(x => x.NameCar.Contains(findtext)).OrderBy(x => x.NameCar).ToList();

            images = MarkaAutoSettings.GetPicture(dtgModelCars, out nameimages);
            GC.Collect((int)GCCollectionMode.Optimized);
        }

        // Отображение информации о выделенном поле
        private void dtgModelCars_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgModelCars.SelectedRows.Count > 0)
                {
                    try
                    {
                        namepic = dtgModelCars.SelectedRows[0].Cells[2].FormattedValue.ToString().Trim();
                        int index = nameimages.FindIndex(x => x == namepic);
                        picBox.Image = images[index];
                    }
                    catch (Exception)
                    {
                        picBox.Image = Image.FromFile(General.pathNoImage);
                    }
                }
            }
            catch (Exception)
            {
                picBox.Image = Image.FromFile(General.pathNoImage);
            }
        }

        // Найти авто по имени
        private void btnFindCar_Click(object sender, EventArgs e)
        {
            try
            {
                namepic = txtNameCar.Text.ToString().Trim();
                RefreshDataGrid(namepic);
                GetInfoCountNameCar();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }

        }

        private void btnDelNameCar_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(dtgModelCars.SelectedRows[0].Cells[0].Value);

                var modelcars = General.context.ModelCars.FirstOrDefault(x => x.ID == index);
                General.context.ModelCars.Remove(modelcars);

                General.context.SaveChanges();
                dtgModelCars.DataSource = General.context.ModelCars.ToList();
                GetInfoCountNameCar();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }

        }

        private void txtFindNameCar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                namepic = txtNameCar.Text.ToString().Trim();
                RefreshDataGrid(namepic);
                if (nameimages.Count == 0)
                {
                    picBox.Image = Image.FromFile(General.pathNoImage);
                }
                else
                {
                    picBox.Image = images[0];
                }
                GetInfoCountNameCar();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
        }

        private void btnAddNameCar_Click(object sender, EventArgs e)
        {
            MarkaAutoSettings.TextBtn = "Добавить";
            SettingsMarka setmarka = new SettingsMarka();
            setmarka.ShowDialog();

            string newName = "";
            if (MarkaAutoSettings.is_click)
            {
                RefreshDataGrid();
                newName = MarkaAutoSettings.NameCar;
                for (int i = 0; i < dtgModelCars.RowCount; i++)
                    if (dtgModelCars.Rows[i].Cells[1].Value.ToString().Trim() == newName)
                    {
                        dtgModelCars.Rows[i].Cells[1].Selected = true;
                        break;
                    }
                MarkaAutoSettings.namePicture = "";
            }
        }

        private void btnSettNameCar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgModelCars.SelectedRows[0].Index >= 0)
                {
                    int i_row = dtgModelCars.SelectedRows[0].Index;
                    MarkaAutoSettings.TextBtn = "Изменить";
                    MarkaAutoSettings.NameCar = dtgModelCars.Rows[i_row].Cells[1].Value.ToString();
                    MarkaAutoSettings.ID = Convert.ToInt32(dtgModelCars.Rows[i_row].Cells[0].Value);
                    MarkaAutoSettings.logo = picBox.Image;
                    MarkaAutoSettings.namePicture = dtgModelCars.Rows[i_row].Cells[2].FormattedValue.ToString().Trim();
                    SettingsMarka setmarka = new SettingsMarka();

                    setmarka.ShowDialog();
                    if (MarkaAutoSettings.is_click)
                    {
                        RefreshDataGrid();
                        for (int i = 0; i < dtgModelCars.RowCount; i++)
                        {
                            if (Convert.ToInt32(dtgModelCars.Rows[i].Cells[0].Value) == MarkaAutoSettings.ID)
                            {
                                dtgModelCars.Rows[i].Cells[1].Selected = true;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неправильное расположение файла!", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ModelCarsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtgModelCars.Dispose();
            nameimages.Clear();
            images.Clear();
            GC.Collect((int)GCCollectionMode.Optimized);
            GC.WaitForPendingFinalizers();
        }

        private void infoMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Записи в таблице должны быть уникальными.\n" +
            "Если для марки не указано изображение, то вместо логотипа появится \"i\".\n",
            "Инструкция по использованию", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
