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

namespace AutoService.OtherForms
{
    public partial class SettingsAllQueryForm : Form
    {
	public SettingsAllQueryForm()
	{
	    InitializeComponent();
	    dtgAllServices.DataSource = General.context.Services.Select(x => new { x.ID, Услуга = x.Name, Цена = x.Price, x.Details }).ToList();
	    dtgAllServices.Columns[0].Visible = false;
	    dtgAllServices.Columns[1].Width = 200;
	    dtgAllServices.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
	    dtgAllServices.Columns[3].Visible = false;
	}

	private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
	{
	    this.Close();
	}

	private void RefreshDataGridService()
	{
	    DateTime dt = new DateTime(AllQuerySettings.DateVisit.Year, AllQuerySettings.DateVisit.Month, AllQuerySettings.DateVisit.Day);

	    var result = General.context.QueryAutoService
		    .Join(General.context.Clients, query => query.ClientID, client => client.ID, (query, client) => new { query, client })
		    .Join(General.context.Services, query => query.query.ServiceID, service => service.ID, (query, service) => new { query, service })
		    .Join(General.context.Masters, query => query.query.query.MasterID, master => master.ID, (query, master) => new { query, master })
		    .GroupBy(p => new
		    {
			clientFIO = p.query.query.client.SurName.Trim() + " " + p.query.query.client.Name.Trim() + " " + p.query.query.client.Patronymic.Trim(),
			car = p.query.query.client.Cars.ModelCars.NameCar.Trim() + " " + p.query.query.client.Cars.RegisterSign.Trim() + " | Цвет: " + p.query.query.client.Cars.color.Trim() + " | Номер двигателя: " + p.query.query.client.Cars.EnNumber.Trim() + " | Номер тех паспорта: " + p.query.query.client.Cars.pts.Trim(),

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
		    t.Key.clientFIO == AllQuerySettings.ClientFIO &&
		 t.Key.car == AllQuerySettings.CarInfo &&
		 t.Key.bday == AllQuerySettings.Birthday &&
	     t.Key.masterID == AllQuerySettings.MasterID &&
		 t.Key.dateVisit == dt &&
		 t.Key.dateReady == AllQuerySettings.DateForReady &&
	     t.Key.master == AllQuerySettings.MasterFIO &&
	     t.Key.done == AllQuerySettings.Done
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
	    dtgListService.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
	    dtgListService.Columns[3].Visible = false;
	    decimal sum = 0;
	    for (int i = 0; i < dtgListService.RowCount; i++)
	    {
		sum += Convert.ToDecimal(dtgListService.Rows[i].Cells[2].Value);
	    }
	    txtPrice.Text = sum + " ₽.";
	}

	private void SettingsAllQueryForm_Load(object sender, EventArgs e)
	{
	    RefreshDataGridService();
	}

	private void dtgAllServices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
	    if (dtgAllServices.SelectedRows.Count > 0)
		if (dtgAllServices.SelectedRows[0].Index != -1)
		{
		    int i_row = dtgAllServices.SelectedRows[0].Index;
		    MessageBox.Show("-Услуга: " + dtgAllServices.Rows[i_row].Cells[1].FormattedValue.ToString().Trim() + "\n" +
			"-Цена: " + dtgAllServices.Rows[i_row].Cells[2].FormattedValue.ToString().Trim() + " ₽\n" +
			"-Описание:\n" + dtgAllServices.Rows[i_row].Cells[3].FormattedValue.ToString().Trim()
			, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
	private void infoMenu_Click(object sender, EventArgs e)
	{
	    MessageBox.Show("В этом окне осуществляется работа с услугами по заявке.\n" +
		"Для получения информации по услуге воспользуйтесь " +
	    "двойным щелчком мыши по нужной услуге.\n" +
	    "Оформление новых заявок находится в главном окне программы.\n" +
	    "Все цены указаны в рублях.\n" +
     "Все изменения сохранятся автоматически."
	, "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
	}

// Настройка цветов кнопок при нажатии
#region SettingsButtons
	
	private void btnDelService_MouseDown(object sender, MouseEventArgs e)
	{
	    btnDelService.BackColor = Color.FromArgb(128, 128, 255);
	}
	private void btnDelService_MouseUp(object sender, MouseEventArgs e)
	{
	    btnDelService.BackColor = Color.FromArgb(224, 224, 224);
	}
	private void btnAddService_MouseDown(object sender, MouseEventArgs e)
	{
	    btnAddService.BackColor = Color.FromArgb(128, 128, 255);
	}
	private void btnAddService_MouseUp(object sender, MouseEventArgs e)
	{
	    btnAddService.BackColor = Color.FromArgb(224, 224, 224);
	}
	private void btnDelService_MouseLeave(object sender, EventArgs e)
	{
	    btnDelService.BackColor = Color.FromArgb(224, 224, 224);
	}
	private void btnAddService_MouseLeave(object sender, EventArgs e)
	{
	    btnAddService.BackColor = Color.FromArgb(224, 224, 224);
	}
#endregion SettingsButtons

	private void btnAddService_Click(object sender, EventArgs e)
	{
	    if (dtgAllServices.SelectedRows.Count > 0)
		if (dtgAllServices.SelectedRows[0].Index != -1)
		{
		    int i_row = dtgAllServices.SelectedRows[0].Index;
		    int serviceID = Convert.ToInt32(dtgAllServices.Rows[i_row].Cells[0].FormattedValue);
		    var query = new QueryAutoService()
		    {
			ClientID = AllQuerySettings.ClientID,
			MasterID = AllQuerySettings.MasterID,
			ServiceID = serviceID,
			DateVisit = AllQuerySettings.DateVisit,
			DateReady = AllQuerySettings.DateForReady,
			Done = false
		    };
		    try
		    {
			General.context.QueryAutoService.Add(query);
			General.context.SaveChanges();
			RefreshDataGridService();
		    }
		    catch (Exception)
		    {
			General.context.QueryAutoService.Remove(query);
			MessageBox.Show("Эта позиция уже существует в заявке!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		    }
		}
	}
	private void btnDelService_Click(object sender, EventArgs e)
	{
	    DateTime dt = new DateTime(AllQuerySettings.DateVisit.Year, AllQuerySettings.DateVisit.Month, AllQuerySettings.DateVisit.Day);
	    if (dtgListService.SelectedRows.Count > 0)
		if (dtgListService.SelectedRows[0].Index != -1)
		{
		    int i_row = dtgListService.SelectedRows[0].Index;
		    int serviceID = Convert.ToInt32(dtgListService.Rows[i_row].Cells[0].FormattedValue);
		    var query = General.context.QueryAutoService
			.Where(t => t.ClientID == AllQuerySettings.ClientID && t.MasterID == AllQuerySettings.MasterID && t.ServiceID == serviceID &&
			t.DateVisit == dt && t.DateReady == AllQuerySettings.DateForReady && t.Done == AllQuerySettings.Done).FirstOrDefault();
		    try
		    {
			General.context.QueryAutoService.Remove(query);
			General.context.SaveChanges();
			RefreshDataGridService();
		    }
		    catch (Exception exp)
		    {
			MessageBox.Show(exp.Message.ToString());
			//MessageBox.Show("Эта позиция уже существует в заявке!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		    }
		}
	}

	private void btnclose_Click(object sender, EventArgs e)
	{
	    this.Close();
	}

	private void dtgListService_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
	    if (dtgListService.SelectedRows.Count > 0)
		if (dtgListService.SelectedRows[0].Index != -1)
		{
		    int i_row = dtgListService.SelectedRows[0].Index;
		    MessageBox.Show("-Услуга: " + dtgListService.Rows[i_row].Cells[1].FormattedValue.ToString().Trim() + "\n" +
			"-Цена: " + dtgListService.Rows[i_row].Cells[2].FormattedValue.ToString().Trim() + " ₽\n" +
			"-Описание:\n" + dtgListService.Rows[i_row].Cells[3].FormattedValue.ToString().Trim()
			, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
    }
}
