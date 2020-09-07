using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FaceTrackingBasics;

namespace Testformato
{
    [TestClass]
    public class UnitTest1
    {
        Pontos pontosMock = Telerik.JustMock.Mock.Create<Pontos>();
        PontosDAO pontosDAO = new PontosDAO();
        CalcularLinhadoRosto linhadoRosto = new CalcularLinhadoRosto();

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
