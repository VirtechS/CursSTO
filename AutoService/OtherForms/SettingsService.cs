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
using ServiceSettings = AutoService.ConneectClass.ServiceSettings;

namespace AutoService.OtherForms
{
    public partial class SettingsService : Form
    {
        public SettingsService()
        {
            InitializeComponent();
        }

        // Изменение или добавление записи в базу данных
        private void btnSettings_Click(object sender, EventArgs e)
        {
            btnSettings.Text = ServiceSettings.TextBtn;
            ServiceSettings.is_click = false;

            if (ServiceSettings.TextBtn == "Добавить")
            {
                try
                {
                    ServiceSettings.NameService = txtNameService.Text.Trim();
                    ServiceSettings.Discription = txtDetails.Text.Trim();
                    ServiceSettings.Price = numPrice.Value;
                    if (ServiceSettings.NameService != "")
                    {
                        var service = new Services()
                        {
                            Name = ServiceSettings.NameService,
                            Details = ServiceSettings.Discription,
                            Price = ServiceSettings.Price
                        };
                        try
                        {
                            General.context.Services.Add(service);
                            General.context.SaveChanges();
                            MessageBox.Show("Готово!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ServiceSettings.is_click = true;
                            this.Close();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Такая запись уже существует!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            General.context.Services.Remove(service);
                        }
                    }
                    else
                        MessageBox.Show("Пустое поле, ознакомьтесь со справкой!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message.ToString());
                }
            }
            else
            {
                try
                {
                    // Редактируем выбранную модель
                    var service = General.context.Services.FirstOrDefault(x => x.ID == ServiceSettings.ID);
                    service.Name = txtNameService.Text.Trim();
                    service.Details = txtDetails.Text.Trim();
                    service.Price = numPrice.Value;
                    if (txtNameService.Text.Trim() != "")
                    {
                        General.context.SaveChanges();
                        MessageBox.Show("Готово!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ServiceSettings.is_click = true;
                        this.Close();
                    }
                    else
                        MessageBox.Show("Пустое поле, ознакомьтесь со справкой!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message.ToString());
                }
            }
        }

        private void SettingsService_Load(object sender, EventArgs e)
        {
            btnSettings.Text = ServiceSettings.TextBtn;
            ServiceSettings.is_click = false;

            if (btnSettings.Text == "Изменить")
            {
                txtNameService.Text = ServiceSettings.NameService;
                txtDetails.Text = ServiceSettings.Discription;
                numPrice.Value = ServiceSettings.Price;
            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы находитесь в окне редактирования услуг.\n" +
            "Уникальная группа полей: Наименование, цена(регистр букв не учитывается)", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
