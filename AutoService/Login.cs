using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using General = AutoService.ConneectClass.General;

namespace AutoService
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            tls.Text = "Добро пожаловать!";
            Opacity = 0;
            Timer timer = new Timer();
            timer.Tick += new EventHandler((sender, e) =>
            {
                if ((Opacity += 0.15d) == 1) timer.Stop();
            });
            timer.Interval = 100;
            timer.Start();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(General.directory);
            try
            {
                if (txtlogin.Text.Trim() != "" && txtPassword.Text.Trim() != "")
                {
                    MD5 md5 = new MD5CryptoServiceProvider();
                    string pass = txtPassword.Text.Trim();
                    byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
                    string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                    General.mode = General.context.Admin
                    .Where(x => x.Login == txtlogin.Text.Trim() && x.Password.Trim() == result)
                    .Select(t => t.StatusID)
                    .FirstOrDefault();
                    if (General.mode == 1 || General.mode == 2) // admin 1, user 2
                        using (QueryForm prog = new QueryForm())
                        {
                            this.Visible = false;
                            General.nickname = txtlogin.Text.Trim();
                            tls.Text = "Добро пожаловать!";
                            txtlogin.Text = "";
                            txtPassword.Text = "";
                            prog.ShowDialog();
                            try
                            {
                                this.Visible = true;
                            }
                            catch (Exception exp) { MessageBox.Show(exp.Message.ToString()); }
                        }
                    else
                    {
                        SystemSounds.Exclamation.Play();
                        tls.Text = "Неверный логин или пароль!";
                    }

                }
            }
            catch (Exception /*exp*/)
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("Ошибка подключения к базе даннах!\nОбратитесь к администратору!");
            }
        }
    }
}
