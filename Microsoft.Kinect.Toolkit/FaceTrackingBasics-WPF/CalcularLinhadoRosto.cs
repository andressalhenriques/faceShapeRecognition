using System;
using System.Diagnostics;

namespace FaceTrackingBasics
{
    public class CalcularLinhadoRosto
    {
        PontosDAO pontosDAO = new PontosDAO();

        public float CalcLinhaRosto(float TPontoTestEsq, float TPontoLinhaMaxilarEsq, float TPontoLinhaAuxiliar)
        {

            if ( (TPontoTestEsq * 0.9 < TPontoLinhaAuxiliar && TPontoTestEsq * 1.1 > TPontoLinhaAuxiliar) && 
                (TPontoTestEsq * 0.9 < TPontoLinhaMaxilarEsq && TPontoTestEsq * 1.1 > TPontoLinhaMaxilarEsq) && 
                (TPontoLinhaAuxiliar * 0.9 < TPontoLinhaMaxilarEsq && TPontoLinhaAuxiliar * 1.1 > TPontoLinhaMaxilarEsq)) {
                pontosDAO.TipoLinha = 2; 
                Debug.Print("linha 2 - reta");

  

            } else if ((TPontoTestEsq * 0.9 < TPontoLinhaMaxilarEsq && TPontoTestEsq * 1.1 > TPontoLinhaMaxilarEsq) 
                && (TPontoLinhaAuxiliar < TPontoTestEsq * 0.9 && TPontoLinhaAuxiliar < TPontoLinhaMaxilarEsq * 0.9)) 
            {
                pontosDAO.TipoLinha = 1; 
                Debug.Print("linha 1 - curva");
            }
            else
            {

                pontosDAO.TipoLinha = 3; 
                Debug.Print("linha 3 - inclinada");
            }
            return pontosDAO.TipoLinha;
        }

    }
}
