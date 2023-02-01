using Domain;
using System.Runtime.InteropServices;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "USUARIO")
            {
                txtuser.Text = String.Empty;
                txtuser.ForeColor = Color.Black;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == String.Empty)
            {
                txtuser.Text = "USUARIO";
                txtuser.ForeColor = Color.Black;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text== "CONTRASEÑA") 
            {
                txtpass.Text = String.Empty;
                txtpass.ForeColor = Color.Black;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == String.Empty)
            {
                txtpass.Text = "CONTRASEÑA";
                txtpass.ForeColor = Color.Black;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void msgError(string msg)
        {
            lblErrorMessage.Text = msg;
            lblErrorMessage.Visible = true;
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text != "USUARIO")
            {
                if(txtpass.Text!= "CONTRASEÑA") 
                {
                    UserModel user = new UserModel();
                    var validLogin = user.LoginUser(txtuser.Text, txtpass.Text);
                    if (validLogin == true)
                    {
                        msgError("Validacion exitosa!!! ya tienes conexion ssh");
                    }
                    else
                    {
                        msgError("No ingresaste chamo :c");
                        txtpass.Clear();
                        txtuser.Clear();
                    }
                }
                else msgError("Please enter Password");
            }
            else
            {
                msgError("Please enter username");
            }
        }

    }
}