using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AllQuerySettings = AutoService.ConneectClass.AllQuerySettings;

namespace AutoService.OtherForms
{
    public partial class DateToReady : Form
    {
	public DateToReady()
	{
	    InitializeComponent();

	    dtp.MinDate = AllQuerySettings.DateVisit;
	}

	private void button1_Click(object sender, EventArgs e)
	{
	    this.Close();
	}

	private void DateToReady_Load(object sender, EventArgs e)
	{

	}
    }
}
