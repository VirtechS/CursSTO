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
using SettingsMasters = AutoService.ConneectClass.MastersSettings;

namespace AutoService.Forms
{
    public partial class MastersForm : Form
    {
        // Список картинок
        private List<Image> images = new List<Image>();
        // Список имён
        private List<string> nameimages = new List<string>();
        private string namepic = "";

        public MastersForm()
        {
            InitializeComponent();

            try
            {
                RefreshDataGrid();
                dtgMasters.Columns[0].Visible = false;
                dtgMasters.Columns[6].Visible = false;
                dtgMasters.Columns["Name"].HeaderText = "Имя";
                dtgMasters.Columns["Name"].Width = 110;
                dtgMasters.Columns["SurName"].HeaderText = "Фамилия";
                dtgMasters.Columns["Patronymic"].HeaderText = "Отчество";
                dtgMasters.Columns["Phone"].HeaderText = "Телефон";
                dtgMasters.Columns["Phone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dtgMasters.Columns["Birthday"].HeaderText = "Дата рождения";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }


        }

        private void RefreshDataGrid(string findtext = "")
        {
            try { 
            dtgMasters.DataSource = (from Masters in General.context.Masters
                                     where
                                    Masters.Name.Contains(findtext) ||
                                    Masters.SurName.Contains(findtext) ||
                                    Masters.Patronymic.Contains(findtext) ||
                                    Masters.Phone.Contains(findtext)
                                     select new
                                     {
                                         Masters.ID,
                                         Masters.SurName,
                                         Masters.Name,
                                         Masters.Patronymic,
                                         Masters.Birthday,
                                         Masters.Phone,
                                         Masters.imagename
                                     }).ToList();
            if (dtgMasters.RowCount > 0)
                dtgMasters.Rows[0].Selected = true;
            images = SettingsMasters.GetPicture(dtgMasters, out nameimages);
        }catch(Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
}

        // Формирование склонения слова "марка"
        private string GetWord(int count)
        {
            count = count % 100;
            if (count >= 11 && count <= 19)
                return " запискей.";

            count = count % 10;
            switch (count)
            {
                case 1:
                    return " запись.";
                case 2:
                case 3:
                case 4:
                    return " записи. ";
                default:
                    return " записей. ";
            }
        }

        private void MastersForm_Load(object sender, EventArgs e)
        {
            try
            {
                dtpClient.MaxDate = new DateTime(DateTime.Now.Year - 18, 12, 31);
                if (General.mode == (int)General.Status.Admin)
                {
                    btnAddMaster.Enabled = true;
                    btnSettMaaster.Enabled = true;
                }
                else
                if (General.mode == (int)General.Status.User)
                {
                    btnAddMaster.Enabled = false;
                    btnSettMaaster.Enabled = false;
                }
                else { MessageBox.Show("Ошибка разграничения пользователей!", "Предупреждение", MessageBoxButtons.OK); Application.Restart(); }
                GetInfoCount();
                dtgMasters.ClearSelection();
            }catch(Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
        }

        private void GetInfoCount()
        {
            tlsInfoCount.Text = "В базе найдено " + dtgMasters.RowCount.ToString() + " " + GetWord(dtgMasters.RowCount);
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            try
            {
                namepic = txtFind.Text.ToString().Trim();
                RefreshDataGrid(namepic);
                if (nameimages.Count == 0)
                {
                    picBox.Image = Image.FromFile(General.pathNoImage);
                }
                else
                {
                    picBox.Image = images[0];
                }
                GetInfoCount();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
        }

        private void dtgMasters_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgMasters.SelectedRows.Count > 0)
                {
                    try
                    {
                        namepic = dtgMasters.SelectedRows[0].Cells["imagename"].FormattedValue.ToString().Trim();
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

        private void btnSettMaaster_Click(object sender, EventArgs e)
        {
            SettingsMasters.TextBtn = "Изменить";

            try
            {
                SettingsMasterForm setmasters = new SettingsMasterForm();

                if (dtgMasters.SelectedRows[0].Index >= 0)
                {
                    int i_row = dtgMasters.SelectedRows[0].Index;

                    SettingsMasters.ID = Convert.ToInt32(dtgMasters.Rows[i_row].Cells[0].Value);
                    SettingsMasters.SurnameMaster = dtgMasters.Rows[i_row].Cells[1].Value.ToString();
                    SettingsMasters.NameMaster = dtgMasters.Rows[i_row].Cells[2].Value.ToString();
                    SettingsMasters.PatronymicMaster = dtgMasters.Rows[i_row].Cells[3].FormattedValue.ToString().Trim();
                    SettingsMasters.BirthdayMaster = Convert.ToDateTime(dtgMasters.Rows[i_row].Cells[4].Value);
                    SettingsMasters.PhoneMaster = dtgMasters.Rows[i_row].Cells[5].FormattedValue.ToString().Trim();
                    SettingsMasters.namePicture = dtgMasters.Rows[i_row].Cells[6].FormattedValue.ToString().Trim();

                    setmasters.ShowDialog();
                    if (SettingsMasters.is_click)
                    {
                        RefreshDataGrid();
                        for (int i = 0; i < dtgMasters.RowCount; i++)
                            if (Convert.ToInt32(dtgMasters.Rows[i].Cells[0].Value) == SettingsMasters.ID)
                            {
                                dtgMasters.Rows[i].Cells[1].Selected = true;
                                break;
                            }
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Неправильное расположение файла!", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddMaster_Click(object sender, EventArgs e)
        {
            SettingsMasters.TextBtn = "Добавить";
            SettingsMasterForm setmarka = new SettingsMasterForm();
            setmarka.ShowDialog();

            if (SettingsMasters.is_click)
            {
                RefreshDataGrid();
                for (int i = 0; i < dtgMasters.RowCount; i++)
                    if (Convert.ToInt32(dtgMasters.Rows[i].Cells[0].Value) == SettingsMasters.ID)
                    {
                        dtgMasters.Rows[i].Cells[1].Selected = true;
                        break;
                    }
                SettingsMasters.namePicture = "";
            }
        }

        private void MastersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtgMasters.Dispose();
            nameimages.Clear();
            images.Clear();
        }

        private void infoMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В этом окне осуществляется работа с персоналом автосервиса.\n" +
          "Поиск осуществляется по всем полям, кроме даты.\nДля поиска по дате воспользуйтесь" +
          "элементом управления, находящимся под таблицей.\n" +
          "При поиске необходимо выбрать соответствующий режим-условие(для даты)."
                , "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFindDate_Click(object sender, EventArgs e)
        {
            var result = General.context.Masters.Select
            (x => new
            {
                x.ID,
                x.SurName,
                x.Name,
                x.Patronymic,
                x.Birthday,
                x.Phone,
                x.imagename
            });
            DateTime Birthday = new DateTime(dtpClient.Value.Year, dtpClient.Value.Month, dtpClient.Value.Day);
            foreach (RadioButton rdb in this.Controls.OfType<RadioButton>())
                if (rdb.Checked)
                    switch (rdb.Text.ToString().Trim())
                    {
                        case "≥":
                            {
                                dtgMasters.DataSource = result.Where(x => x.Birthday >= Birthday).Select
                (x => new
                {
                    x.ID,
                    x.SurName,
                    x.Name,
                    x.Patronymic,
                    x.Birthday,
                    x.Phone,
                    x.imagename
                }).ToList(); break;
                            }
                        case "≤":
                            {
                                dtgMasters.DataSource = result.Where(x => x.Birthday <= Birthday).Select
                (x => new
                {
                    x.ID,
                    x.SurName,
                    x.Name,
                    x.Patronymic,
                    x.Birthday,
                    x.Phone,
                    x.imagename
                }).ToList(); break;
                            }
                        case "=":
                            {
                                dtgMasters.DataSource = result.Where(x => x.Birthday == Birthday).Select
                (x => new
                {
                    x.ID,
                    x.SurName,
                    x.Name,
                    x.Patronymic,
                    x.Birthday,
                    x.Phone,
                    x.imagename
                }).ToList(); break;
                            }
                        case "∀": RefreshDataGrid(); break;
                    }
            images = SettingsMasters.GetPicture(dtgMasters, out nameimages);
            if (dtgMasters.RowCount != 0) picBox.Image = SettingsMasters.CrutchImage(dtgMasters.Rows[0].Cells[6].FormattedValue.ToString().Trim());
            GetInfoCount();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}

