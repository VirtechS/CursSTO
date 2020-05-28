using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using General = AutoService.ConneectClass.General;
using MarkaAutoSettings = AutoService.ConneectClass.MarkaAutoSettings;

namespace AutoService
{
    public partial class SettingsMarka : Form
    {
        public SettingsMarka()
        {
            InitializeComponent();
        }

        private void SettingsMasters_Load(object sender, EventArgs e)
        {
            btnSettings.Text = MarkaAutoSettings.TextBtn;
            MarkaAutoSettings.is_click = false;

            if (btnSettings.Text == "Изменить")
            {
                txtNameCar.Text = MarkaAutoSettings.NameCar;
                if (MarkaAutoSettings.namePicture.Trim() == "")
                    picBox.Image = Image.FromFile(General.directory + "\\images\\noimage.png");
                else
                    picBox.Image = Image.FromFile(General.directory + "\\images\\Марки\\" + MarkaAutoSettings.namePicture);
            }
            else
            {
                MarkaAutoSettings.namePicture = "noimage.png";
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (MarkaAutoSettings.TextBtn == "Добавить")
            {
                try
                {
                    MarkaAutoSettings.NameCar = txtNameCar.Text.ToString().Trim();
                    if (MarkaAutoSettings.NameCar != "")
                    {
                        // Формируем новую модель
                        var modelcars = new ModelCars()
                        {
                            NameCar = MarkaAutoSettings.NameCar
                        };
                        if (MarkaAutoSettings.namePicture.Trim() == "")
                            modelcars.imagename = General.directory + "\\images\\noimage.png";
                        else
                            modelcars.imagename = MarkaAutoSettings.namePicture;
                        try
                        {
                            General.context.ModelCars.Add(modelcars);
                            General.context.SaveChanges();
                            MessageBox.Show("Готово!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MarkaAutoSettings.is_click = true;
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Такая запись уже существует!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            General.context.ModelCars.Remove(modelcars);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Пустое поле!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (DbUpdateException)
                {
                    MessageBox.Show("Ошибка обновления БД!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message.ToString());
                    MarkaAutoSettings.NameCar = "";
                }

            }
            else
            {
                try
                {
                    // Редактируем выбранную модель
                    var modelcars = General.context.ModelCars.FirstOrDefault(x => x.ID == MarkaAutoSettings.ID);
                    modelcars.NameCar = txtNameCar.Text.ToString().Trim();
                    modelcars.imagename = MarkaAutoSettings.namePicture;

                    if (txtNameCar.Text.ToString().Trim() != "")
                    {
                        General.context.SaveChanges();
                        MessageBox.Show("Готово!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MarkaAutoSettings.is_click = true;
                        this.Close();
                    }
                    else
                        MessageBox.Show("Пустое поле, ознакомьтесь со справкой!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (DbUpdateException)
                {
                    MessageBox.Show("Ошибка обновления БД!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.Close();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message.ToString());
                }

            }

        }

        private void btnGetPicture_Click(object sender, EventArgs e)
        {
            try
            {
                FileDilogPicture.DefaultExt = "png";
                FileDilogPicture.FileName = "";
                FileDilogPicture.InitialDirectory = General.directory + "\\images\\Марки\\";
                FileDilogPicture.Filter = "Image files (*.png)|*.png|All files (*.*)|*.*";
                FileDilogPicture.ShowDialog();
                if (FileDilogPicture.SafeFileName != "")
                {
                    picBox.Image = Image.FromFile(General.directory + "\\images\\Марки\\" + FileDilogPicture.SafeFileName);
                    MarkaAutoSettings.namePicture = FileDilogPicture.SafeFileName;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неправильное расположение файла!", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deletePicture_Click(object sender, EventArgs e)
        {
            MarkaAutoSettings.namePicture = "noimage.png";
            picBox.Image = Image.FromFile(General.directory + "\\images\\Марки\\noimage.png");

        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы находитесь в окне редактирования модел.\n" +
               "Изображение для логотипа марки необходимо выбрать из предложенного пути.\n" +
         "Наименования марок должны быть уникальными(регистр букв не учитывается)", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
