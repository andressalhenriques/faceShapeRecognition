using System;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;

namespace FaceTrackingBasics
{
    public partial class Form2 : Form
    {
        Usuarios usuarios = new Usuarios();

        public Form2(bool buttonEditar)
        {
            InitializeComponent();
            panel1.Enabled = false;
            dataGridView1.DataSource = usuarios.ListarUsuarios();// mostra a lista de usuarios no form
            EditarDataGridView();          
            pictureBox4.Visible = false;
        }

        private void EditarDataGridView() // formata o grid
        {
            DataGridViewColumn column = dataGridView1.Columns[0];
            column.Width = 170;
            DataGridViewColumn column2 = dataGridView1.Columns[4];
            column2.Width = 180;
            DataGridViewColumn column3 = dataGridView1.Columns[1];
            column3.Width = 133;
        }

        private void pictureBox6_Click(object sender, EventArgs e) // delete
        {
            if ((textBoxNome.Text == "Nome completo" || textBoxTelefone.Text == "(00)0000-000 ou (00)90000-0000" || textBoxEmail.Text == "Email") ||
                textBoxNome.Text == "" || textBoxEmail.Text == "" || textBoxTelefone.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Por favor selecione o dado que gostaria de deletar");
            }
            else
            {
                string nome = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string id_rosto = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                if (System.Windows.Forms.MessageBox.Show("Você tem certeza que quer deletar a " + nome + "?", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    System.Windows.Forms.MessageBox.Show("Operação cancelada");
                    limpar();
                }
                else
                {
                    usuarios.Deletar(id_rosto);
                    dataGridView1.DataSource = usuarios.ListarUsuarios();
                    limpar();
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e) // editar
        {
            if ((textBoxNome.Text == "Nome completo" || textBoxTelefone.Text == "(00)0000-000 ou (00)90000-0000" || textBoxEmail.Text == "seuemail@gmail.com") ||
                (textBoxNome.Text == "" || textBoxEmail.Text == "" || textBoxTelefone.Text == ""))
            {
                System.Windows.Forms.MessageBox.Show("Selecione um dado para editar");
            }
            else
            {
                pictureBox4.Visible = true;
                panel1.Enabled = true;
                textBoxIdRosto.ReadOnly = true;
                //textBoxNome.Focus();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e) // icone salvar
        {
            try
            {
                Boolean a = VerificaCampos();
                textBoxNome.Focus();
                UsuariosDAO mo = new UsuariosDAO();
                Usuarios crud = new Usuarios();

                if (a == true)
                {

                    int c = usuarios.PesquisarUsuario(textBoxIdRosto.Text);
                    Debug.Print("textBoxIdRosto.Text  = click icone salvar " + textBoxIdRosto.Text);
                    if (c == 1) // se já existe eu atualizo
                    {

                        mo.Nome = textBoxNome.Text;
                        mo.Email = textBoxEmail.Text;
                        mo.Telefone = textBoxTelefone.Text;
                        crud.EditarUsuario(mo, textBoxIdRosto.Text);
                        limpar(); // limpa os campos
                        panel1.Enabled = false;
                        dataGridView1.DataSource = usuarios.ListarUsuarios();
                        pictureBox4.Visible = false;


                    }
                    else // Se não existir cadastra
                    {
                        mo.Nome = textBoxNome.Text;
                        mo.Email = textBoxEmail.Text;
                        mo.Telefone = textBoxTelefone.Text;
                        crud.CadastrarUsuario(mo);
                        limpar();
                        panel1.Enabled = false;
                        dataGridView1.DataSource = usuarios.ListarUsuarios();
                        pictureBox4.Visible = false;
                    }
                }


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool VerificaCampos()
        {
            if (textBoxNome.Text == "" || textBoxNome.Text == "Nome completo")
            {
                errorProviderNome.SetError(textBoxNome, "Campo vazio, entre com o nome");
                textBoxNome.Focus();
                return false;
            }
            else
            {
                errorProviderNome.SetError(textBoxNome, "");
            }

            string nome = textBoxNome.Text;
            var res = new Regex(@"^[\p{L}\s]{5,}");
            if (!res.IsMatch(nome))
            {
                errorProviderNome.SetError(textBoxNome, "Por favor preencha com o nome e sobrenome");
                textBoxNome.Focus();
                return false;
            }
            else
            {
                errorProviderNome.SetError(textBoxNome, "");
            }


            string email = textBoxEmail.Text;
            bool validacao = email.Contains("@") && email.Contains(".");
            if (validacao == false || textBoxEmail.Text == "seuemail@gmail.com")
            {
                errorProviderEmail.SetError(textBoxEmail, "Entre com um email válido");
                textBoxEmail.Focus();
                return false;
            }
            else
            {
                errorProviderEmail.SetError(textBoxEmail, "");
            }

            string telefone = textBoxTelefone.Text;
            var re = new Regex(@"^\([1-9]{2}\)(?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$");
            if (!re.IsMatch(telefone) || textBoxTelefone.Text == "(00)0000-000 ou (00)90000-0000")
            {
                errorProviderTelefone.SetError(textBoxTelefone, "Preencha o telefone corretamente! Celular(00)00000-0000 ou Fixo (00)0000-0000");
                textBoxTelefone.Focus();
                //MessageBox.Show("Preencha o telefone corretamente");
                return false;
            }
            else
            {
                errorProviderTelefone.SetError(textBoxTelefone, "");
            }


            return true;
        }

        public void limpar()
        {
            textBoxIdRosto.Clear();
            textBoxEmail.Text = "Email";
            textBoxTelefone.Text = "(00)0000-000 ou (00)90000-0000";
            textBoxNome.Text = "Nome completo";
        }

        private void textBoxIdRosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                textBoxNome.Focus();
            }
        }

        private void textBoxNome_KeyDown_1(object sender, KeyEventArgs e) // tira o som e muda para o proximo quando aperta tab
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                textBoxTelefone.Focus();
            }
        }

        private void textBoxTelefone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                textBoxEmail.Focus();
            }
        } // tira o som e muda para o proximo quando aperta tab

        private void textBoxEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        } // tira o som e muda para o proximo quando aperta tab



        private void textBoxTelefone_Leave(object sender, EventArgs e)
        {
            if (textBoxTelefone.Text == "")
            {
                textBoxTelefone.Text = "(00)0000-000 ou (00)90000-0000";
                textBoxTelefone.ForeColor = Color.Silver;
            }
        }

        private void textBoxTelefone_Enter(object sender, EventArgs e)
        {
            if (textBoxTelefone.Text == "(00)0000-000 ou (00)90000-0000")
            {
                textBoxTelefone.Text = "";
                textBoxTelefone.ForeColor = Color.Black;
            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "")
            {
                textBoxEmail.Text = "seuemail@gmail.com";
                textBoxEmail.ForeColor = Color.Silver;
            }

        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "seuemail@gmail.com")
            {
                textBoxEmail.Text = "";
                textBoxEmail.ForeColor = Color.Black;
            }
        }

        private void textBoxNome_Enter_1(object sender, EventArgs e)
        {
            if (textBoxNome.Text == "Nome completo")
            {
                textBoxNome.Text = "";
                textBoxNome.ForeColor = Color.Black;
            }
        }

        private void textBoxNome_Leave_1(object sender, EventArgs e)
        {
            if (textBoxNome.Text == "")
            {
                textBoxNome.Text = "Nome completo";
                textBoxNome.ForeColor = Color.Silver;
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBoxNome.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxTelefone.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxEmail.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxIdRosto.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            panel1.Enabled = false;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e) // fechar
        {
            System.Windows.Forms.Application.Exit();
        }

        private void textBoxSearch_KeyDown_1(object sender, KeyEventArgs e) // pesquisa enquanto digita
        {
            Usuarios usuarios = new Usuarios();
            dataGridView1.DataSource = usuarios.Pesquisar(textBoxSearch.Text);
        }
    }
}
