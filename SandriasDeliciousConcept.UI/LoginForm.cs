using Microsoft.Data.SqlClient;
using SandriasDeliciousConcept.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SandriasDeliciousConcept.UI;

public partial class LoginForm : Form
{
    private readonly IUserService _users;
    public CurrentUser? LoggedInUser { get; private set; }

    public LoginForm(IUserService users)
    {
        InitializeComponent();
        _users = users;
    }

    private void btnLogin_Click(object? sender, EventArgs e)
    {
        lblError.Text = "";
        if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
        {
            lblError.Text = "Enter your username and password.";
            return;
        }

        try
        {
            var user = _users.Login(txtUsername.Text.Trim(), txtPassword.Text);
            if (user is null)
            {
                lblError.Text = "Wrong username or password.";
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }
            LoggedInUser = user;
            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            lblError.Text = "Could not log in: " + ex.Message;
        }
    }
}
