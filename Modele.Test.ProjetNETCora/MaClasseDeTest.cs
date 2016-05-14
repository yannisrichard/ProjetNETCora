using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cours1_TestUnitaire
{
    [TestClass]
    public class MaClasseDeTest
    {
        [TestMethod]
        public void Cosinus_Avec0_Retourne1()
        {
            double cosinus0 = Math.Cos(0);
            Assert.IsTrue(cosinus0 == 1);
        }

        [TestMethod]
        public void Cosinus_Avec1_Retourne0()
        {
            double cosinus1 = Math.Cos(45);
            Assert.IsTrue(cosinus1 == 0);
        }
    }
}
