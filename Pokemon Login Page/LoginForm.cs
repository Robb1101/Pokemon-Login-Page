﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pokemon_Login_Page
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-14QPJQA\SQLEXPRESS;Initial Catalog=users;Integrated Security=True");

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            String username, user_password;

            username = Usernametxt.Text;
            user_password = Passwordtxt.Text;

            try
            {
                String querry = "SELECT * FROM users WHERE user_name = '" +Usernametxt.Text+ "' AND password = '" +Passwordtxt.Text+ "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = Usernametxt.Text;
                    user_password = Passwordtxt.Text;

                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Invalid Username and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Username.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");

            }
            finally
            {
                conn.Close();
            }
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked==true)
            {
                Passwordtxt.UseSystemPasswordChar = false;
            }
            else
            {
                Passwordtxt.UseSystemPasswordChar = true;
            }
        }
        public bool switchToRegisterform = false;

        private void RegLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registerform registerform = new Registerform();
            registerform.Show();
            this.Hide();
        }

    }

}
    


