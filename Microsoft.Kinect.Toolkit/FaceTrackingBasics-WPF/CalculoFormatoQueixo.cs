using System;
using System.Diagnostics;


namespace FaceTrackingBasics
{
    public class CalculoFormatoQueixo
    {
        PontosDAO pontosDAO = new PontosDAO();

        public float Calculoqueixo(float TPontoLinhaMaxilarEsqY, float TPontoInfQueixo)
        {

            if (TPontoLinhaMaxilarEsqY * 1.15 > TPontoInfQueixo)
            {
                pontosDAO.FormatoQueixo = 0;
                Debug.Print("queixo reto");
            }
            else
            {
                pontosDAO.FormatoQueixo = 1;
                Debug.Print("queixo V");
            }
            return pontosDAO.FormatoQueixo;
        }
    }
}
