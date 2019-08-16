using System;
using Gtk;
using MySQL_Script;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void onBtnLoginClick(object sender, EventArgs e)
    {
        DAO conn = new DAO();
        if (txtHost.Text == string.Empty)
        {
            System.Windows.Forms.MessageBox.Show("Digite um Host válido!");
            return;
        }
        else if (txtUser.Text == string.Empty)
        {
            System.Windows.Forms.MessageBox.Show("Digite um username válido!");
            return;
        }
        else if (txtPassword.Text == string.Empty)
        {
            System.Windows.Forms.MessageBox.Show("Digite um password válido!");
            return;
        }

        conn.hostname = txtHost.Text.Trim();
        conn.username = txtUser.Text.Trim();
        conn.password = txtPassword.Text.Trim();
        Boolean conectado = conn.Connect();

        if (conectado)
        {
            conn.ShowDatabases();
        }
    }
}
