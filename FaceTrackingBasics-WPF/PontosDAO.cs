using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaceTrackingBasics
{
    public class PontosDAO
    {
        public int Id_Pontos { get; set; }
        public float PontoSupTesta { get; set; }
        public float PontoInfTesta { get; set; }
        public float PontoMaca { get; set; }
        public float PontoLatDir { get; set; }
        public float PontoLatEsq { get; set; }
        public float PontolinhaBoca { get; set; }
        public float PontoLinhaMaxilarDir { get; set; }
        public float PontoSupQueixo { get; set; }
        public float PontoInfQueixo { get; set; }
        public float PontoDirQueixo { get; set; }
        public float PontoEsqQueixo { get; set; }
        public int Contador = 0;
        public float PontoLinhaMaxilarEsqY { get; set; }
        public float PontoLarguraMaxilar { get; set; }
        public float PontoEsqTesta { get; set; }
        public float PontoLarguratesta { get; set; }
        public float PontoDirTesta { get; set; }
        
        public float PontoLinhaMaxilarEsq { get; set; }
        
        public float PontoNariz { get; set; }
        public float PontoLarguraArco{ get; set; }
        public float PontoLinhaInclinada { get; set; }
        public float TamanhoTesta { get; set; }
        public float TamanhoQueixo { get; set; }
        public float FormatoQueixo { get; set; }

        public float LarguraRosto { get; set; }
        public float AlturaRosto { get; set; }
        public float DifAlteLarg { get; set; }

        public float MediaLinhaReta;
        public float MediaLinhaCurva;
        public float PontoLinhaAuxiliar;
        public float AuxliarLinhaRetaUm;
        public float AuxliarLinhaRetaDois;
        public float AuxliarLinhaRetaTres;

        public float TipoLinha;
       

        public float AuxliarLinhaCurvaUm;
        public float AuxliarLinhaCurvaTres;


        //public float TotalPontoSupTesta = 0;
        //public float TotalPontoInfTesta = 0;
        //public float TotalPontoSupQueixo = 0;
        //public float TotalPontoInfQueixo = 0;
        //public float TotalPontoLatDir = 0;
        //public float TotalPontoLatEsq = 0;
        //public float TotalPontoDirQueixo = 0;
        //public float TotalPontoEsqQueixo = 0;
        //public float TotalPontoLinhaMaxilarEsq = 0;
        //public float TotalPontoLinhaMaxilarDir = 0;
        //public float TotalPontoTestDir = 0;
        //public float TotalPontoTestEsq = 0;
        //public float TotalPontolinhaBoca = 0;
        //public float TotalPontoMaca = 0;
        //public float TotalPontoNariz = 0;
        //public float TotalPontoLinhaMaxilarEsqY = 0;
        //public float TotalPontoLinha99 = 0;

        public float TotalPontoSupTesta { get; set; }
        public float TotalPontoInfTesta { get; set; }
        public float TotalPontoSupQueixo { get; set; }
        public float TotalPontoInfQueixo { get; set; }
        public float TotalPontoLatDir { get; set; }
        public float TotalPontoLatEsq { get; set; }
        public float TotalPontoDirQueixo { get; set; }


        public float TotalPontoEsqQueixo { get; set; }
        public float TotalPontoLinhaMaxilarEsq { get; set; }
        public float TotalPontoLinhaMaxilarDir { get; set; }
        public float TotalPontoTestDir { get; set; }
        public float TotalPontoTestEsq { get; set; }
        public float TotalPontolinhaBoca { get; set; }
        public float TotalPontoMaca { get; set; }
        public float TotalPontoNariz { get; set; }
        public float TotalPontoLinhaMaxilarEsqY { get; set; }
        public float TotalPontoLinhaAuxiliar { get; set; }
    }
}
