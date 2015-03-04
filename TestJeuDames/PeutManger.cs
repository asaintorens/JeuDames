using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JeuDames;
using Morpion;

namespace TestJeuDames
{
    [TestClass]
   public  class PeutManger
    {
        [TestMethod]
        public void PeutMangerEnArriere()
        {
            JeuDame monJeu = new JeuDame();
            monJeu.EtablirJoueur("alex", "alex²");

            Case maCase = monJeu.plateauJeu.GetCase(new Position(3, 4));
            maCase.Pion = new Pion();
            maCase.Pion.TypePion = TypePion.pionBlanc;

            Case pion1 = monJeu.plateauJeu.GetCase(new Position(4, 3));
            pion1.Pion = new Pion();
            pion1.Pion.TypePion = TypePion.pionNoir;

            Assert.AreEqual(true, monJeu.plateauJeu.PeutManger(maCase));
        }

        [TestMethod]
        public void PeutMangerEnAvant()
        {
            JeuDame monJeu = new JeuDame();
            monJeu.EtablirJoueur("alex", "alex²");

            Case maCase = monJeu.plateauJeu.GetCase(new Position(3, 4));
            maCase.Pion = new Pion();
            maCase.Pion.TypePion = TypePion.pionBlanc;

            Case pion1 = monJeu.plateauJeu.GetCase(new Position(4, 5));
            pion1.Pion = new Pion();
            pion1.Pion.TypePion = TypePion.pionNoir;

            Assert.AreEqual(true, monJeu.plateauJeu.PeutManger(maCase));
        }
    }
}
