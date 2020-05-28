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

namespace AutoService.OtherForms
{
    public partial class SettingsMasterForm : Form
    {
	public SettingsMasterForm()
	{
	    InitializeComponent();
            dtpDateBirthday.MaxDate = new DateTime(DateTime.Now.Year - 18, 12, 31);
        }

	private void txtPhone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
	{

	}

	private void SettingsMasterForm_Load(object sender, EventArgs e)
	{
	    btnSettings.Text = SettingsMasters.TextBtn;
	    SettingsMasters.is_click = false;

	    if (btnSettings.Text == "Изменить")
	    {
		dtpDateBirthday.Value = SettingsMasters.BirthdayMaster;
		txtName.Text = SettingsMasters.NameMaster;
		txtSurname.Text = SettingsMasters.SurnameMaster;
		txtPatron.Text = SettingsMasters.PatronymicMaster;
		txtPhone.Text = SettingsMasters.PhoneMaster;
		try
		{
		    if (SettingsMasters.namePicture.Trim() == "")
		    {
			picBox.Image = Image.FromFile(General.directory + "\\images\\noimage.png");
		    }
		    else
			picBox.Image = Image.FromFile(General.directory + "\\images\\Мастера\\" + SettingsMasters.namePicture);
		}
		catch (Exception)
		{
		    picBox.Image = Image.FromFile(General.pathNoImage);
		}
	    }
	    else
	    {
		SettingsMasters.namePicture = "noimage.png";
	    }
	}

	private void btnGetPicture_Click(object sender, EventArgs e)
	{
	    try
	    {
		FileDilogPicture.DefaultExt = "png";
		FileDilogPicture.FileName = "";
		FileDilogPicture.InitialDirectory = General.directory + "\\images\\Мастера";
		FileDilogPicture.Filter = "Image files (*.png)|*.png|All files (*.*)|*.*";
		FileDilogPicture.ShowDialog();
		if (FileDilogPicture.SafeFileName != "")
		{
		    picBox.Image = Image.FromFile(General.directory + "\\images\\Мастера\\" + FileDilogPicture.SafeFileName);
		    SettingsMasters.namePicture = FileDilogPicture.SafeFileName;
		}
	    }
	    catch (Exception)
	    {
		MessageBox.Show("Неправильное расположение файла!", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
	    }

	}

	private void deletePicture_Click(object sender, EventArgs e)
	{
	    SettingsMasters.namePicture = "noimage.png";
	    picBox.Image = Image.FromFile(General.directory + "\\images\\noimage.png");
	}

	private void btnSettings_Click(object sender, EventArgs e)
	{
	    DateTime dt = DateTime.Now;
	    if (SettingsMasters.TextBtn == "Добавить")
	    {
		var masters = new Masters();
		try
		{
		    SettingsMasters.NameMaster = txtName.Text.ToString().Trim();
		    SettingsMasters.SurnameMaster = txtSurname.Text.ToString().Trim();
		    SettingsMasters.PatronymicMaster = txtPatron.Text.ToString().Trim();
		    SettingsMasters.BirthdayMaster = dtpDateBirthday.Value;
		    SettingsMasters.PhoneMaster = txtPhone.Text.ToString();

		    if (!(SettingsMasters.NameMaster == "" || SettingsMasters.SurnameMaster == "" ||
		    (dt.Year - SettingsMasters.BirthdayMaster.Year) < 18))
		    {
			// Формируем новую модель

			masters.Name = SettingsMasters.NameMaster;
			masters.SurName = SettingsMasters.SurnameMaster;
			masters.Patronymic = SettingsMasters.PatronymicMaster;
			masters.Birthday = SettingsMasters.BirthdayMaster;
			masters.Phone = SettingsMasters.PhoneMaster;

			if (SettingsMasters.namePicture.Trim() == "")
			    masters.imagename = General.directory + "\\images\\noimage.png";
			else
			    masters.imagename = SettingsMasters.namePicture;
			try
			{
			    General.context.Masters.Add(masters);
			    General.context.SaveChanges();
			    MessageBox.Show("Готово!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
			    SettingsMasters.is_click = true;
			    this.Close();
			}
			catch (Exception)
			{
			    MessageBox.Show("Такая запись уже существует!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
			    General.context.Masters.Remove(masters);
			}

		    }
		    else
		    {
			if ((dt.Year - SettingsMasters.BirthdayMaster.Year) < 18)
			    MessageBox.Show("Возраст строго 18+!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
			else
			    MessageBox.Show("Пустое поле!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
		    }
		}
		catch (Exception exc)
		{
		    MessageBox.Show(exc.Message.ToString());
		    General.context.Masters.Remove(masters);
		}
	    }
	    else
	    {
		try
		{
		    // Редактируем выбранную модель
		    var masters = General.context.Masters.FirstOrDefault(x => x.ID == SettingsMasters.ID);
		    masters.Name = txtName.Text.ToString().Trim();
		    masters.SurName = txtSurname.Text.ToString().Trim();
		    masters.Patronymic = txtPatron.Text.ToString().Trim();
		    masters.Birthday = dtpDateBirthday.Value;
		    masters.Phone = txtPhone.Text.ToString();
		    masters.imagename = SettingsMasters.namePicture;

		    if (txtName.Text.ToString().Trim() != "" && (dt.Year - dtpDateBirthday.Value.Year) >= 18
			&& txtSurname.Text.ToString().Trim() != "")
		    {
			General.context.SaveChanges();
			SettingsMasters.is_click = true;
			this.Close();
		    }
		    else
			MessageBox.Show("Пустое поле, ознакомьтесь со справкой!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


		}
		catch (Exception exp)
		{
		    MessageBox.Show(exp.Message.ToString());
		    //MessageBox.Show("Выделите строку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

	    }
	}

	private void txtPhone_TextChanged(object sender, EventArgs e)
	{
	    string str = txtPhone.Text.Trim();
	    for (int i = 0; i < txtPhone.Text.Length; i++)
		if (!char.IsDigit(str[i]) || str[i]==' ')
		   str = str.Replace(str[i].ToString(), "");
	    txtPhone.Text = str;
	}

	private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
	{
	    MessageBox.Show("Вы находитесь в окне редактирования модели.\n" +
		       "Изображение для профиля необходимо выбрать из предложенного пути.\n" +
	 "Уникальная группа полей:Ф.И.О, Дата рождения, (регистр букв не учитывается)", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
	}

	private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
	{
	    this.Close();
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
    }
}
