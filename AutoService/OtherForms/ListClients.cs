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
using Auto_Client = AutoService.ConneectClass.AutoClientSettings;

namespace AutoService.OtherForms
{
    public partial class ListClients : Form
    {
	public ListClients()
	{
	    InitializeComponent();
	}

	private void btnaddClient_Click(object sender, EventArgs e)
	{
	    if (dtgfio.SelectedRows[0].Index >= 0)
	    {
		int i_row = dtgfio.SelectedRows[0].Index;
		var client = new Clients();
		client.Name = dtgfio.Rows[i_row].Cells[1].FormattedValue.ToString().Trim();
		client.SurName = dtgfio.Rows[i_row].Cells[0].FormattedValue.ToString().Trim();
		client.Patronymic = dtgfio.Rows[i_row].Cells[2].FormattedValue.ToString().Trim();
		client.Phone = dtgfio.Rows[i_row].Cells[4].FormattedValue.ToString().Trim();
		client.CarID = Auto_Client.CarID;
		client.Birthday = Convert.ToDateTime(dtgfio.Rows[i_row].Cells[3].Value);

		try
		{
		    General.context.Clients.Add(client);
		    General.context.SaveChanges();
		    this.Close();
		}
		catch (Exception)
		{
		    General.context.Clients.Remove(client);
		    MessageBox.Show("У этого авто уже имеется выбранный клиент!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	    }
	    else
	    {
		MessageBox.Show("Выберите владельца из таблицы!", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

	private void GetInfoCountNameCar()
	{
	    tlsInfoCountCar.Text = "Найдено " + dtgfio.RowCount.ToString() + GetWord(dtgfio.RowCount);
	}


	private void ListClients_Load(object sender, EventArgs e)
	{
	    try
	    {
		var result = General.context.Clients.GroupBy
		    (
		    x => new { x.Name, x.SurName, x.Patronymic, x.Birthday, x.Phone }
		    ).Select(
		    z => new
		    {
			z.Key.SurName,
			z.Key.Name,
			z.Key.Patronymic,
			z.Key.Birthday,
			z.Key.Phone
		    });
		dtgfio.DataSource = result.ToList();
		GetInfoCountNameCar();
	    }
	    catch (Exception) { }

	    try
	    {
		dtgfio.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dtgfio.Columns["SurName"].HeaderText = "Фамилия";
		dtgfio.Columns["Name"].HeaderText = "Имя";
		dtgfio.Columns["Patronymic"].HeaderText = "Отчество";
		dtgfio.Columns["Birthday"].HeaderText = "Дата Рождения";
		dtgfio.Columns["Phone"].HeaderText = "Телефон";
	    }
	    catch (Exception)
	    { }

	}
    }
}
