using System;
using System.Data.OleDb;
using System.Diagnostics;

namespace FaceTrackingBasics
{
    class TipoRosto
    {
        // String strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lua\Desktop\2\kinect\FaceTrackingBasics-WPF\bin\x86\Debug\dbdados.mdb";
        String strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Andressa\Desktop\kinect\FaceTrackingBasics-WPF\bin\x86\Debug\dbdados.mdb";
        //String strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\2\kinect\FaceTrackingBasics-WPF\bin\x86\Debug\dbdados.mdb";
        //String strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\kinect\FaceTrackingBasics-WPF\bin\x86\Debug\dbdados.mdb";

        TipoRostoDAO tipoRostoDAO = new TipoRostoDAO();

        public int SelectIdTipoRosto()
        {
           
            String comando = "SELECT MAX(id_TipoRosto) FROM tipoRosto";
            OleDbConnection con = new OleDbConnection(strcon);
            OleDbCommand como = new OleDbCommand(comando, con);
            try
            {
                con.Open();
                tipoRostoDAO.Id_TipoRosto = (int)como.ExecuteScalar();
                Debug.Print("  id_TipoRosto - select" + tipoRostoDAO.Id_TipoRosto);
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
            return tipoRostoDAO.Id_TipoRosto;

        }




        public void InsertTipoRosto(String formato)

        {
            Debug.Print("Tipo de rosto no tipo rosto: " + formato);
            String comando = "INSERT INTO tipoRosto (FormatoRosto) VALUES (:formatoRosto)";
            OleDbConnection con = new OleDbConnection(strcon);
            OleDbCommand como = new OleDbCommand(comando, con);
            como.Parameters.Add(":formatoRosto", OleDbType.VarChar).Value = formato;

            try
            {
                con.Open();
                como.ExecuteNonQuery();
                Debug.Print("Tipo de rosto cadastrado");
            }
            catch (Exception E)
            {
                Debug.Print("Erro Insert Tipo Rosto" + E.Message);
            }
            finally
            {
                con.Close();
            }

        }
    }
}
