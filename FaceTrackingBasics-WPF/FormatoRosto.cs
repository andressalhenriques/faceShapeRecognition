using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FaceTrackingBasics
{
    public class FormatoRosto
    {
        PontosDAO pontosDAO = new PontosDAO();
        TipoRostoDAO tipoRostoDAO = new TipoRostoDAO();
        
        public String Identificar(float totalPontoSupTesta, float totalPontoInfTesta, float totalPontoMaca, float totalPontoLatDir, float totalPontoLatEsq,
            float totalPontolinhaBoca, float totalPontoLinhaMaxilarDir,float totalPontoSupQueixo, float totalPontoInfQueixo, float totalPontoDirQueixo, 
            float totalPontoEsqQueixo, float totalPontoLinhaMaxilarEsqY, float totalPontoTestEsq, float totalPontoTestDir, float totalPontoLinhaMaxilarEsq, 
            float totalPontoNariz, float totalPontoLinhaAuxiliar, float linha, float formatoQueixo) {

            //calculo da tamanho da testa com o ponto y
            pontosDAO.TamanhoTesta = Math.Abs(totalPontoSupTesta - totalPontoInfTesta);
            Debug.Print("TamanhoKKK da testa: " + pontosDAO.TamanhoTesta);


            // calculo da tamanho da queixo com o ponto y
            pontosDAO.TamanhoQueixo = Math.Abs(totalPontoSupQueixo - totalPontoInfQueixo);
            Debug.Print("Tamanho da queixo: " + pontosDAO.TamanhoQueixo);


            // calculo da largura do rosto com o ponto x
            pontosDAO.LarguraRosto = Math.Abs(totalPontoLatDir - totalPontoLatEsq);
            Debug.Print("Largura: " + pontosDAO.LarguraRosto);

            // calculo altura do rosto com ponto em y              
            pontosDAO.AlturaRosto = Math.Abs​​(totalPontoSupTesta - totalPontoInfQueixo);
            Debug.Print("Altura: " + pontosDAO.AlturaRosto);

            // calculo da diferença entre a largura e altura
            pontosDAO.DifAlteLarg = Math.Abs​​(pontosDAO.AlturaRosto - pontosDAO.LarguraRosto);
            Debug.Print("Diferença entre a largura e altura: " + pontosDAO.DifAlteLarg);

            // calculo da largura da mandibula
            pontosDAO.PontoLarguraMaxilar = Math.Abs​​(totalPontoLinhaMaxilarDir - totalPontoLinhaMaxilarEsq);
            Debug.Print("Largura do maxilar: " + pontosDAO.PontoLarguraMaxilar);


            // calculo da largura da testa
            pontosDAO.PontoLarguratesta = Math.Abs​​(totalPontoTestDir - totalPontoTestEsq);
            Debug.Print("Largura da testa: " + pontosDAO.PontoLarguratesta);


            // calculo da largura do arco com pontos em x
            pontosDAO.PontoLarguraArco = Math.Abs​​(totalPontoMaca - totalPontoNariz);
            Debug.Print("Largura arco: " + pontosDAO.PontoLarguraArco);
        
            float x;
            float y;
            float z;
            x = ((Math.Abs(pontosDAO.AlturaRosto) / 3) * 2);
            Debug.Print("x " + x);
            z = x * 1.10f;
            Debug.Print("z " + z);
            y = x * 0.9f;
            Debug.Print("y " + y);

                       
            if (linha == 1) {
                if (pontosDAO.LarguraRosto > (pontosDAO.AlturaRosto* 0.9) && pontosDAO.LarguraRosto < (pontosDAO.AlturaRosto* 1.10)) 
                {
                    tipoRostoDAO.FormatoRosto = "redondo";
                }
                else if (pontosDAO.LarguraRosto > y && pontosDAO.LarguraRosto < z)
                {
                    tipoRostoDAO.FormatoRosto = "oval";
                }
                else
                {
                    tipoRostoDAO.FormatoRosto = "nenhum";
                }
            } else if (linha == 2)
            {
                if (pontosDAO.LarguraRosto > (pontosDAO.AlturaRosto* 0.9) && pontosDAO.LarguraRosto < (pontosDAO.AlturaRosto* 1.10) && totalPontolinhaBoca > totalPontoLinhaMaxilarEsqY) 
                {
                    tipoRostoDAO.FormatoRosto = "quadrado";
                }
                else if (totalPontoLinhaMaxilarEsqY == totalPontolinhaBoca || totalPontolinhaBoca < totalPontoLinhaMaxilarEsqY) 
                {
                    tipoRostoDAO.FormatoRosto = "hexagonal com lateral reta";
                }
                else if( totalPontolinhaBoca > totalPontoLinhaMaxilarEsqY && (pontosDAO.LarguraRosto > y && pontosDAO.LarguraRosto < z))
                {
                    tipoRostoDAO.FormatoRosto = "retangular";
                } else
                {
                    tipoRostoDAO.FormatoRosto = "nenhum";
                }
            }
            else if (linha == 3) {
                if (formatoQueixo == 1 && pontosDAO.PontoLarguratesta <= (pontosDAO.PontoLarguraArco * 2))
                {
                    tipoRostoDAO.FormatoRosto = "losangular";
                }
                else if (pontosDAO.PontoLarguratesta < pontosDAO.PontoLarguraMaxilar) 
                {
                    tipoRostoDAO.FormatoRosto = "triangular"; 
                }
                else if(formatoQueixo == 0) 
                {
                    tipoRostoDAO.FormatoRosto = "hexagonal com base reta";
                }
                else if (pontosDAO.PontoLarguratesta > (pontosDAO.PontoLarguraArco * 2) && formatoQueixo == 1)
                {
                    tipoRostoDAO.FormatoRosto = "triangular invertido";
                }
                else
                {
                    tipoRostoDAO.FormatoRosto = "nenhum";
                }
            } else
            {
                tipoRostoDAO.FormatoRosto = "nenhum";
            }
            return tipoRostoDAO.FormatoRosto;
        }
    }
}
