using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//importar a classe
using System.Runtime.InteropServices;


namespace PadariaCarmel
{
    public partial class frmCalcula : Form
    {
        //Criando variáveis para controle do menu
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);

        public frmCalcula()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            // Close();
            Application.Exit();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNum1.Text = "";
            txtNum2.Clear();
            lblResposta.Text = "";

            rdbSoma.Checked = false;
            rdbSubtracao.Checked = false;
            rdbDivisao.Checked = false;
            rdbMultiplicacao.Checked = false;

            txtNum1.Focus();
        }

        private void btnCalcula_Click(object sender, EventArgs e)
        {
            double num1, num2, resp = 0;

            /*num1 = double.Parse(txtNum1.Text);
            num2 = double.Parse(txtNum2.Text);*/

            if (rdbSoma.Checked || rdbSubtracao.Checked || rdbMultiplicacao.Checked || rdbDivisao.Checked)
            {
                try
                {
                    num1 = Convert.ToDouble(txtNum1.Text);
                    num2 = Convert.ToDouble(txtNum2.Text);

                    if (rdbSoma.Checked)
                    {
                        resp = num1 + num2;
                    }
                    else if (rdbSubtracao.Checked)
                    {
                        resp = num1 - num2;
                    }
                    else if (rdbMultiplicacao.Checked)
                    {
                        resp = num1 * num2;
                    }
                    else
                    {
                        if (num2 == 0)
                        {
                            MessageBox.Show("Impossível por 0");

                            txtNum1.Text = "";
                            txtNum2.Text = "";
                            rdbDivisao.Checked = false;

                            txtNum1.Focus();

                            lblResposta.Text = "";
                        }
                        else
                        {
                            resp = num1 / num2;
                        }
                    }

                    lblResposta.Text = resp.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Favor inserie somene números");
                    txtNum1.Text = "";
                    txtNum2.Text = "";
                    txtNum1.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por favor selecione uma operação",
                    "Mensagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void frmCalcula_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }
    }
}
