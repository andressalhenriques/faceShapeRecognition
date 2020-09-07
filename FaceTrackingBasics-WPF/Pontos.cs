using System;
using System.Data.OleDb;
using System.Diagnostics;


namespace FaceTrackingBasics
{
    public class Pontos
    {
        // String strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Lua\Desktop\2\kinect\FaceTrackingBasics-WPF\bin\x86\Debug\dbdados.mdb";
        String strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Andressa\Desktop\kinect\FaceTrackingBasics-WPF\bin\x86\Debug\dbdados.mdb";
        //String strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\2\kinect\FaceTrackingBasics-WPF\bin\x86\Debug\dbdados.mdb";
        //String strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\kinect\FaceTrackingBasics-WPF\bin\x86\Debug\dbdados.mdb";

        PontosDAO pontosDAO = new PontosDAO();
        TipoRostoDAO tipoRostoDAO = new TipoRostoDAO();

        public void InsertPontos(PontosDAO pontosDAO)
            {
            String comando = "INSERT INTO pontosfaciais (pontoSupTesta , pontoInfTesta , pontoMaca , pontoLatDir , pontoLatEsq , pontoLinhaBoca , " +
                "pontoLinhaMaxilarDir ,pontoSupQueixo, pontoInfQueixo, pontoDirQueixo, pontoEsqQueixo, pontoLinhaMaxilarEsqY, pontoEsqTesta, " +
                "pontoDirTesta, pontoLinhaMaxilarEsq, pontoNariz, pontoLinhaAuxiliar) VALUES (:pontoSupTesta , :pontoInfTesta , :pontoMaca , :pontoLatDir , :pontoLatEsq , :pontoLinhaBoca , :pontoLinhaMaxilarDir ,:pontoSupQueixo, " +
                ":pontoInfQueixo, :pontoDirQueixo, :pontoEsqQueixo, :PontoLinhaMaxilarEsqY, :pontoEsqTesta, :pontoDirTesta, :pontoLinhaMaxilarEsq, " +
                ":pontoNariz, :pontoLinhaAuxiliar)";
            OleDbConnection con = new OleDbConnection(strcon);
            OleDbCommand como = new OleDbCommand(comando, con);

            como.Parameters.Add(":pontoSupTesta", OleDbType.VarChar).Value = +pontosDAO.TotalPontoSupTesta;
            como.Parameters.Add(":pontoInfTesta", OleDbType.VarChar).Value = +pontosDAO.TotalPontoInfTesta;
            como.Parameters.Add(":pontoMaca", OleDbType.VarChar).Value = +pontosDAO.TotalPontoMaca;
            como.Parameters.Add(":pontoLatDir", OleDbType.VarChar).Value = +pontosDAO.TotalPontoLatDir;
            como.Parameters.Add(":pontoLatEsq", OleDbType.VarChar).Value = +pontosDAO.TotalPontoLatEsq;
            como.Parameters.Add(":pontoLinhaBoca", OleDbType.VarChar).Value = +pontosDAO.TotalPontolinhaBoca;
            como.Parameters.Add(":pontoLinhaMaxilarDir", OleDbType.VarChar).Value = +pontosDAO.TotalPontoLinhaMaxilarDir;
            como.Parameters.Add(":pontoSupQueixo", OleDbType.VarChar).Value = +pontosDAO.TotalPontoSupQueixo;
            como.Parameters.Add(":pontoInfQueixo", OleDbType.VarChar).Value = +pontosDAO.TotalPontoInfQueixo;
            como.Parameters.Add(":pontoDirQueixo", OleDbType.VarChar).Value = +pontosDAO.TotalPontoDirQueixo;
            como.Parameters.Add(":pontoEsqQueixo", OleDbType.VarChar).Value = +pontosDAO.TotalPontoEsqQueixo;
            como.Parameters.Add(":pontoLinhaMaxilarEsqY", OleDbType.VarChar).Value = +pontosDAO.TotalPontoLinhaMaxilarEsqY;
            como.Parameters.Add(":pontoEsqTesta", OleDbType.VarChar).Value = +pontosDAO.TotalPontoTestEsq;
            como.Parameters.Add(":pontoDirTesta", OleDbType.VarChar).Value = +pontosDAO.TotalPontoTestDir;
            como.Parameters.Add(":pontoLinhaMaxilarEsq", OleDbType.VarChar).Value = +pontosDAO.TotalPontoLinhaMaxilarEsq;               
            como.Parameters.Add(":pontoNariz", OleDbType.VarChar).Value = +pontosDAO.TotalPontoNariz;
            como.Parameters.Add(":ponto99", OleDbType.VarChar).Value = +pontosDAO.TotalPontoLinhaAuxiliar;


            // como.Parameters.Add(":contador", OleDbType.VarChar).Value = +mo.Contador;

            try
            {
                con.Open();
                como.ExecuteNonQuery();
                Debug.Print("Cadastro realizado");

            }
            catch (Exception E)
            {
                Debug.Print("não cadastrado");
                Debug.Print(E.Message);
            }
            finally
            {
                con.Close();
            }
            
        }

        public int SelectIdPontos()
        {

            if (tipoRostoDAO.FormatoRosto == "")
            {
                System.Windows.Forms.MessageBox.Show("Formato de rosto não encontra, faça uma nova leitura");
                return -1;
            } else { 
                String comando = "SELECT MAX(id_Pontos) FROM pontosfaciais";
                OleDbConnection con = new OleDbConnection(strcon);
                OleDbCommand como = new OleDbCommand(comando, con);
                try
                {
                    con.Open();
                    pontosDAO.Id_Pontos = (int)como.ExecuteScalar();
                    Debug.Print("select id_Pontos classe pontos" + pontosDAO.Id_Pontos);
                }
                catch (Exception E)
                {
                    Debug.Print(E.Message);
                    return -1;
                }
                finally
                {
                    con.Close();
                }
                return pontosDAO.Id_Pontos;
            }
        }


    }
}
