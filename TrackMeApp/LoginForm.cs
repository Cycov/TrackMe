using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackMeApp
{
    public partial class LoginForm : MaterialForm
    {
        public int UserId;

        public LoginForm()
        {
            InitializeComponent();
            UserId = int.MinValue;
        }

        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(emailTb.Text) && !String.IsNullOrWhiteSpace(passwordTb.Text))
            {
                var responseString = await Extensions.HttpPostAsync(Properties.Settings.Default.loginRequestUri,
                    new Dictionary<string, string>
                    {
                       { "user", emailTb.Text },
                       { "pass", passwordTb.Text }
                    });
                
                int value;
                if (!String.IsNullOrWhiteSpace(responseString) && int.TryParse(responseString, out value))
                {
                    UserId = value;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Invalid credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
