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
using ServiceSettings = AutoService.ConneectClass.ServiceSettings;

namespace AutoService.Forms
{
    public partial class ServicesForm : Form
    {
	// Текст для поиска
	private string find = "";
	// Цена для поиска
	private decimal price = 0m;

	public ServicesForm()
	{
	    InitializeComponent();

	    try
	    {
		RefreshDataGrid();
		dtgService.Columns["ID"].Visible = false;
		dtgService.Columns["Details"].Visible = false;
		dtgService.Columns["Price"].Visible = false;
		dtgService.Columns["Name"].HeaderText = "Услуга";
		dtgService.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
	    }
	    catch (Exception e)
	    {
		MessageBox.Show(e.Message.ToString());
	    }

	}
	private void ServicesForm_Load(object sender, EventArgs e)
	{
	    if (General.mode == (int)General.Status.Admin)
	    {
		btnAddService.Enabled = true;
		btnSettService.Enabled = true;
	    }
	    else
	   if (General.mode == (int)General.Status.User)
	    {
		btnAddService.Enabled = false;
		btnSettService.Enabled = false;
	    }
	    else { MessageBox.Show("Ошибка разграничения пользователей!", "Предупреждение", MessageBoxButtons.OK); Application.Restart(); }

	    find = txtNameService.Text.ToString().Trim();
	    GetInfoCount();
	    if (find == "")
	    {
		checkHold.Enabled = false;
		RefreshDataGridName(findtext: find);
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
	// Статистика таблицы
	private void GetInfoCount()
	{
	    tlsInfoCountCar.Text = "Найдено " + dtgService.RowCount.ToString() + GetWord(dtgService.RowCount);
	}
	// Поиск по строке
	private void txtNameService_TextChanged(object sender, EventArgs e)
	{
	    try
	    {
		find = txtNameService.Text.ToString().Trim();

		if (find == "")
		{
		    checkHold.Enabled = false;
		    RefreshDataGridName(findtext: find);
		}
		else
		{
		    checkHold.Enabled = true;

		    if (numPrice.Text.ToString() != "")
			price = Convert.ToInt32(numPrice.Text.ToString());
		    if (checkHold.Checked)
		    {
			RefreshDataGrid(findtext: find, priceservice: price);
		    }
		    else
			RefreshDataGridName(findtext: find);
		}
	    }
	    catch (Exception)
	    { }
	    finally
	    {
		GetInfoCount();
	    }
	}
	// Выбоорка по 2 ключам
	private void RefreshDataGrid(string ch = "", decimal priceservice = 0, string findtext = "")
	{
	    var result = General.context.Services.Select(x => new
	    {
		ID = x.ID,
		Name = x.Name,
		Details = x.Details,
		Price = x.Price
	    });

	    var rwe2 = result.Where(x => x.Name.Trim().Contains(findtext) & x.Price >= priceservice).ToList();
	    foreach (RadioButton rdb in this.Controls.OfType<RadioButton>())
		if (rdb.Checked)
		    ch = rdb.Text.Trim();
	    switch (ch)
	    {
		case "≥":
		    {
			dtgService.DataSource = result.Where(x => x.Name.Contains(findtext) && x.Price >= priceservice).ToList(); break;
		    }
		case "≤":
		    {
			dtgService.DataSource = result.Where(x => x.Name.Contains(findtext) && x.Price <= priceservice).ToList(); break;
		    }
		case "=":
		    {
			dtgService.DataSource = result.Where(x => x.Name.Contains(findtext) && x.Price == priceservice).ToList(); break;
		    }
		case "∀": RefreshDataGridName(findtext); break;
	    }
	}
	// Выборка по имени
	private void RefreshDataGridName(string findtext = "")
	{
	    dtgService.DataSource = General.context.Services.Select(x => new
	    {
		ID = x.ID,
		Name = x.Name,
		Details = x.Details,
		Price = x.Price
	    }).Where(x => x.Name.Contains(find)).ToList();
	}
	// Выборка по цене
	private void RefreshDataGridPrice(decimal priceservice = 0)
	{
	    var result = General.context.Services.Select(x => new
	    {
		ID = x.ID,
		Name = x.Name,
		Details = x.Details,
		Price = x.Price
	    });

	    foreach (RadioButton rdb in this.Controls.OfType<RadioButton>())
		if (rdb.Checked)
		    switch (rdb.Text.ToString().Trim())
		    {
			case "≥":
			    {
				dtgService.DataSource = result.Where(x => x.Price >= priceservice).ToList(); break;
			    }
			case "≤":
			    {
				dtgService.DataSource = result.Where(x => x.Price <= priceservice).ToList(); break;
			    }
			case "=":
			    {
				dtgService.DataSource = result.Where(x => x.Price == priceservice).ToList(); break;
			    }
			case "∀": dtgService.DataSource = result.ToList(); break;
		    }
	}
	// Поиск по цене
	private void numPrice_TextChanged(object sender, EventArgs e)
	{
	    try
	    {
		find = txtNameService.Text.ToString().Trim();
		price = Convert.ToInt32(numPrice.Text.ToString());
		if (checkHold.Checked)
		    RefreshDataGrid(findtext: find, priceservice: price);
		else
		    if (find == "" && price == 0m)
		    RefreshDataGridALL();
		else
		    RefreshDataGridPrice(priceservice: price);
	    }
	    catch (Exception)
	    {

	    }
	    finally
	    {
		GetInfoCount();
	    }
	}

	// Получить всю таблицу
	private void RefreshDataGridALL()
	{
	    dtgService.DataSource = General.context.Services.Select(x => new
	    {
		ID = x.ID,
		Name = x.Name,
		Details = x.Details,
		Price = x.Price
	    }
	    ).ToList();
	}
	// Получить информацию о выделенной услеге
	private void dtgService_SelectionChanged(object sender, EventArgs e)
	{
	    try
	    {
		if (dtgService.SelectedRows.Count > 0)
		{
		    try
		    {
			txtDetails.Text = dtgService.SelectedRows[0].Cells["Details"].FormattedValue.ToString().Trim();
			lblPrice2.Text = dtgService.SelectedRows[0].Cells["Price"].FormattedValue.ToString().Trim() + "р.";
		    }
		    catch (Exception)
		    { }
		}
		else
		{
		    txtDetails.Text = "";
		    lblPrice2.Text = "";
		}
	    }
	    catch (Exception)
	    { }
	}
	// Добавить новую услугу
	private void btnAddService_Click(object sender, EventArgs e)
	{
	    ServiceSettings.TextBtn = "Добавить";
	    SettingsService setservice = new SettingsService();
	    setservice.ShowDialog();

	    if (ServiceSettings.is_click)
	    {
		RefreshDataGridALL();
		for (int i = 0; i < dtgService.RowCount; i++)
		    if (Convert.ToInt32(dtgService.Rows[i].Cells[0].Value) == ServiceSettings.ID)
		    {
			dtgService.Rows[i].Cells[1].Selected = true;
			break;
		    }
		GetInfoCount();
	    }
	}
	// Изменить существующую услугу
	private void btnSettService_Click(object sender, EventArgs e)
	{
	    ServiceSettings.TextBtn = "Изменить";
	    try
	    {
		SettingsService setservice = new SettingsService();

		if (dtgService.SelectedRows[0].Index >= 0)
		{
		    int i_row = dtgService.SelectedRows[0].Index;

		    ServiceSettings.ID = Convert.ToInt32(dtgService.Rows[i_row].Cells["ID"].Value);
		    ServiceSettings.NameService = dtgService.Rows[i_row].Cells[1].FormattedValue.ToString().Trim();
		    ServiceSettings.Discription = dtgService.Rows[i_row].Cells["Details"].FormattedValue.ToString().Trim();
		    ServiceSettings.Price = Convert.ToDecimal(dtgService.Rows[i_row].Cells["Price"].Value);

		    setservice.ShowDialog();
		    if (ServiceSettings.is_click)
		    {
			RefreshDataGridALL();
			for (int i = 0; i < dtgService.RowCount; i++)
			    if (Convert.ToInt32(dtgService.Rows[i].Cells[0].Value) == ServiceSettings.ID)
			    {
				dtgService.Rows[i].Cells[1].Selected = true;
				break;
			    }
		    }
		}
	    }
	    catch (Exception exp)
	    {
		MessageBox.Show(exp.Message.ToString());
	    }
	    finally
	    {
		GetInfoCount();
	    }
	}
	// Связать поиск по имени и цене
	private void checkHold_CheckedChanged(object sender, EventArgs e)
	{
	    try
	    {
		bool is_need = checkHold.Checked;
		find = txtNameService.Text.ToString().Trim();
		if (numPrice.Text.ToString() != "")
		    price = Convert.ToInt32(numPrice.Text.ToString());
		if (is_need)
		{
		    RefreshDataGrid(findtext: find, priceservice: price);
		    checkHold.BackColor = Color.FromArgb(128, 128, 255);
		}
		else
		{
		    checkHold.BackColor = Color.FromArgb(224, 224, 224);
		    if (dtgService.RowCount == 0)
			RefreshDataGridALL();
		}
	    }
	    catch (Exception)
	    {

	    }
	    finally
	    {
		GetInfoCount();
	    }
	}

	private void infoMenu_Click(object sender, EventArgs e)
	{
	    MessageBox.Show("Вы находитесь в окне \"Услуги\".\n" +
		"Имеется возможность поиска как по отдельным полям, так и связанный поиск.\n"
			  , "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
	}

	private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
	{
	    this.Close();
	}

	private void radioButton1_CheckedChanged(object sender, EventArgs e)
	{
	    if (radioButton1.Checked)
	    {
		radioButton1.CheckedChanged += numPrice_TextChanged;
	    }
	}

	private void radioButton3_CheckedChanged(object sender, EventArgs e)
	{
	    if (radioButton3.Checked)
	    {
		radioButton3.CheckedChanged += numPrice_TextChanged;
	    }
	}

	private void radioButton2_CheckedChanged(object sender, EventArgs e)
	{
	    if (radioButton2.Checked)
	    {
		radioButton2.CheckedChanged += numPrice_TextChanged;
	    }
	}

	private void radioButton4_CheckedChanged(object sender, EventArgs e)
	{
	    if (radioButton4.Checked)
	    {
		radioButton4.CheckedChanged += numPrice_TextChanged;
	    }
	}
    }
}
