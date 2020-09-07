using System;
using System.Data.OleDb;
using System.Diagnostics;

namespace FaceTrackingBasics
{
    class Rosto
    {

        // String strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lua\Desktop\2\kinect\FaceTrackingBasics-WPF\bin\x86\Debug\dbdados.mdb";
        String strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Andressa\Desktop\kinect\FaceTrackingBasics-WPF\bin\x86\Debug\dbdados.mdb";
        //String strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\2\kinect\FaceTrackingBasics-WPF\bin\x86\Debug\dbdados.mdb";
        //String strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\kinect\FaceTrackingBasics-WPF\bin\x86\Debug\dbdados.mdb";
        Pontos pontos = new Pontos();
        TipoRosto tipoRosto = new TipoRosto();
        TipoRostoDAO tipoRostoDao = new TipoRostoDAO();
        PontosDAO pontosDAO = new PontosDAO();
        RostoDAO rostoDAO = new RostoDAO();

        public void InsertRosto()
        {
            String comando = "INSERT INTO Rosto (id_Pontos, id_TipoRosto ) VALUES (:id_Pontos, :id_TipoRosto)";
            OleDbConnection con = new OleDbConnection(strcon);
            OleDbCommand como = new OleDbCommand(comando, con);

            tipoRostoDao.Id_TipoRosto = tipoRosto.SelectIdTipoRosto();
            pontosDAO.Id_Pontos = pontos.SelectIdPontos();
            como.Parameters.Add(":id_Pontos", OleDbType.VarChar).Value = +pontosDAO.Id_Pontos;
            como.Parameters.Add(":id_TipoRosto", OleDbType.VarChar).Value = +tipoRostoDao.Id_TipoRosto;
            Debug.Print("Inserst rosto select o id pontos:" + pontosDAO.Id_Pontos);
            Debug.Print("Inserst rosto select o id TipoRosto:" + tipoRostoDao.Id_TipoRosto);

            try
            {
                con.Open();
                como.ExecuteNonQuery();

                Debug.Print("rosto cadastrado");
            }
            catch (Exception E)
            {
                Debug.Print("Erro Insert  Rosto" + E.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public int SelectIdRosto()
        {
          
            String comando = "SELECT MAX(id_rosto) FROM rosto";
            OleDbConnection con = new OleDbConnection(strcon);
            OleDbCommand como = new OleDbCommand(comando, con);
            try
            {
                con.Open();
                rostoDAO.Id_Rosto = (int)como.ExecuteScalar();

                Debug.Print("  select id_rosto classe rosto" + rostoDAO.Id_Rosto);
            }
            catch (Exception E)
            {
                Debug.Print(E.Message);
                return -2;
            }
            finally
            {
                con.Close();
            }
            return rostoDAO.Id_Rosto;

        }
    }
}
