using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Encriptacion
{

    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios(); 
            usuario.Nombre = txtNombre.Text;
            usuario.Usuario = txtUsuario.Text;
            usuario.Password = txtPassword.Text;
            usuario.Conpassword = txtConPassword.Text;

            try
            {
                Controlador control = new Controlador();
                string respuesta = control.controladorRegistro(usuario);

                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Usuario registrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '•';
        }

        private void BtMostrar_Click(object sender, EventArgs e)
        {
            BtOcultar.BringToFront();
            txtPassword.PasswordChar = '\0';
        }

        private void BtOcultar_Click(object sender, EventArgs e)
        {
            BtMostrar.BringToFront();
            txtPassword.PasswordChar = '•';

        }

        private void BtConfirmarMostrar_Click(object sender, EventArgs e)
        {
            BtConfirmarOcultar.BringToFront();
            txtConPassword.PasswordChar = '\0';
        }

        private void BtConfirmarOcultar_Click(object sender, EventArgs e)
        {
            BtConfirmarMostrar.BringToFront();
            txtConPassword.PasswordChar = '•';

        }

        private void txtConPassword_TextChanged(object sender, EventArgs e)
        {
            txtConPassword.PasswordChar = '•';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;

            if (!string.IsNullOrEmpty(usuario))
            {
                Modelo modelo = new Modelo(); // Crear una instancia del modelo.
                string password = modelo.ObtenerPasswordPorUsuario(usuario);

                // Mostrar la contraseña en textBox1.
                textBox1.Text = password;
            }
            else
            {
                // Limpiar textBox1 si el campo de usuario está vacío.
                textBox1.Text = string.Empty;
            }
        }

        private void BtnDecifrar_Click(object sender, EventArgs e)
        {
            string contraseña = textBox1.Text;
            
            if(!string.IsNullOrEmpty(contraseña))
            {
                Controlador controlador = new Controlador();
                String descifrar = controlador.Descriptar(contraseña);

                //Mostrar la contraseña en 
                textBox2.Text = descifrar;
            }else
            {
                //Limpiamos textBox2 si el campo de usuario está vacío.
                textBox2.Text = string.Empty;
            }
        }
    }
}
