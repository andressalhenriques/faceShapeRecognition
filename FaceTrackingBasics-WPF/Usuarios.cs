using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;

namespace FaceTrackingBasics
{
    class Usuarios
    {
        //String strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lua\Desktop\2\kinect\FaceTrackingBasics-WPF\bin\x86\Debug\dbdados.mdb";
         String strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Andressa\Desktop\kinect\FaceTrackingBasics-WPF\bin\x86\Debug\dbdados.mdb";
        // String strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\2\kinect\FaceTrackingBasics-WPF\bin\x86\Debug\dbdados.mdb";
        //String strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\kinect\FaceTrackingBasics-WPF\bin\x86\Debug\dbdados.mdb";

        Rosto rosto = new Rosto();
        TipoRostoDAO tipoRostoDAO = new TipoRostoDAO();
        Pontos pontos = new Pontos();

        public void CadastrarUsuario(UsuariosDAO usuariosDAO)
        {
 
            String comando = "INSERT INTO cadastrousuario (nome, email, telefone, id_rosto ) VALUES (:nome, :email, :telefone, :id_rosto); ";
            OleDbConnection con = new OleDbConnection(strcon);
            OleDbCommand como = new OleDbCommand(comando, con);

            tipoRostoDAO.Id_TipoRosto = rosto.SelectIdRosto();
            Debug.Print("IdTipoRosto Cadastrar" + tipoRostoDAO.Id_TipoRosto);
            Debug.Print("nome: "+ usuariosDAO.Nome);
            como.Parameters.Add(":nome", OleDbType.VarChar).Value = usuariosDAO.Nome;
            como.Parameters.Add(":email", OleDbType.VarChar).Value = usuariosDAO.Email;
            como.Parameters.Add(":telefone", OleDbType.VarChar).Value = usuariosDAO.Telefone;
            como.Parameters.Add(":id_rosto", OleDbType.VarChar).Value = +tipoRostoDAO.Id_TipoRosto;
            try
            {
                con.Open();
                int id = como.ExecuteNonQuery();
        
                //MessageBox.Show("Usuário cadastrado");
                Debug.Print("Dados cadastrados");

            }
            catch (Exception E)
            {
                Debug.Print("Erro Insert  usuario" + E.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable ListarUsuarios () // lista todos os usuarios para mostrar no form
        {
            OleDbConnection con = new OleDbConnection(strcon);
            String comando = "SELECT DISTINCT c1.nome as Nome, c1.email As Email, c1.telefone As " +
                "Telefone, c1.id_Rosto, tr.FormatoRosto As Formato FROM  cadastrousuario c1, " +
                "tiporosto tr, rosto where c1.id_Rosto = rosto.id_rosto and rosto.id_TipoRosto = " +
                "tr.id_tipoRosto";
            con.Open();
            DataTable dt = new DataTable();
            try
            {              
                OleDbCommand como = new OleDbCommand(comando, con);
                OleDbDataAdapter adp = new OleDbDataAdapter(como);
                dt = new DataTable();
                adp.Fill(dt);
                return dt;
            }catch(Exception E)
            {
                Debug.Print(E.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }


        public DataTable Pesquisar(String busca) // pesquisa no box conforme digita
        {
            DataTable dados = new DataTable();
            Debug.Print("palavra " + busca);
            OleDbConnection con = new OleDbConnection(strcon);
            String comando = "SELECT DISTINCT c1.nome as Nome, c1.email As Email, c1.telefone As " +
                "Telefone, c1.id_Rosto, tr.FormatoRosto As Formato FROM cadastrousuario c1, " +
                "tiporosto tr, rosto WHERE c1.id_Rosto = rosto.id_rosto and rosto.id_TipoRosto = " +
                "tr.id_tipoRosto and nome  LIKE '%' +:busca &'%' ;";

            con.Open();
          
            try
            {
                OleDbCommand como = new OleDbCommand(comando, con);
                OleDbDataAdapter adp = new OleDbDataAdapter(como);   
                como.Parameters.Add(":busca", OleDbType.VarChar).Value = busca;
                adp.Fill(dados);
              
                
                return dados;
            }
            catch (Exception E)
            {
                Debug.Print(E.Message);
            }
            finally
            {
                con.Close();
            }
            return dados;
        }

        public void Deletar(String id_rosto)
        {
            OleDbConnection con = new OleDbConnection(strcon);
            String comando = "delete from cadastrousuario where id_rosto = :id_rosto";

            OleDbCommand como = new OleDbCommand(comando, con);
            como.Parameters.Add(":id_rosto", OleDbType.VarChar).Value = id_rosto;

           
            try
            {
                con.Open();
                como.ExecuteNonQuery();
                MessageBox.Show("Dados deletados com sucesso");

            }
            catch (Exception E)
            {
                Debug.Print(E.Message);
            }
            finally
            {
                con.Close();
            }
        }
        
        

        public void EditarUsuario(UsuariosDAO usuariosDAO, String id)
        {
            int id_rosto = Convert.ToInt32(id);
            Debug.Print("id rosto dentro do editar: " + id_rosto);
            String comando = "UPDATE cadastrousuario set nome = :nome, email = :email, telefone = :telefone where id_rosto = :id_rosto";
            OleDbConnection con = new OleDbConnection(strcon);
            OleDbCommand como = new OleDbCommand(comando, con);

           
            
            como.Parameters.Add(":nome", OleDbType.VarChar).Value = usuariosDAO.Nome;
            como.Parameters.Add(":email", OleDbType.VarChar).Value = usuariosDAO.Email;
            como.Parameters.Add(":telefone", OleDbType.VarChar).Value = usuariosDAO.Telefone;
            como.Parameters.Add(":id_rosto", OleDbType.VarChar).Value = id_rosto;
            try
            {
                con.Open();
                como.ExecuteNonQuery();
                MessageBox.Show("Dado editado");
                Debug.Print("Dado editado");

            }
            catch (Exception E)
            {
                Debug.Print("Erro editar  usuario" + E.Message);
            }
            finally
            {
                con.Close();
            }
        }


        public int PesquisarUsuario(String id)
        {
           
            String comando = "select DISTINCT * from cadastrousuario where id_rosto = :id_rosto";
            OleDbConnection con = new OleDbConnection(strcon);
            OleDbCommand como = new OleDbCommand(comando, con);
            como.Parameters.Add(":pesquisa usuário mostra o id_rosto", OleDbType.VarChar).Value = id;
            try
            {
                con.Open();
                OleDbDataReader cs = como.ExecuteReader();
                if (cs.HasRows == false)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }

            }
            catch (Exception E)
            {
                Debug.Print("Erro buscar  usuario" + E.Message);
            }
            finally
            {
                con.Close();
            }
            return -1;
        }

    }
}
