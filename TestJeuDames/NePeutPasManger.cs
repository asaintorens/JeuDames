using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JeuDames;
using Morpion;
namespace TestJeuDames
{
    [TestClass]
    public class NePeutPasManger
    {
        [TestMethod]
        public void NePeutPasMangerCarPasDePion()
        {
            JeuDame monJeu = new JeuDame();
            monJeu.EtablirJoueur("alex", "alex²");
            Case maCase = monJeu.plateauJeu.GetCase(new Position(2, 3));
            maCase.Pion = new Pion();
            maCase.Pion.TypePion = TypePion.pionBlanc;

           Assert.AreEqual(false, monJeu.plateauJeu.PeutManger(maCase));
        }

        [TestMethod]
        public void NePeutPasMangerCarDeuxPionAlignésDevant()
        {
            JeuDame monJeu = new JeuDame();
            monJeu.EtablirJoueur("alex", "alex²");
            Case maCase = monJeu.plateauJeu.GetCase(new Position(2, 3));
            maCase.Pion = new Pion();
            maCase.Pion.TypePion = TypePion.pionBlanc;

            Case caseEnnemi1 = monJeu.plateauJeu.GetCase(new Position(3, 4));
            caseEnnemi1.Pion = new Pion();
            caseEnnemi1.Pion.TypePion = TypePion.pionNoir;

            Case caseEnnemi2 = monJeu.plateauJeu.GetCase(new Position(4, 5));
            caseEnnemi2.Pion = new Pion();
            caseEnnemi2.Pion.TypePion = TypePion.pionNoir;

            Assert.AreEqual(false, monJeu.plateauJeu.PeutManger(maCase));
        }

        [TestMethod]
        public void NePeutPasMangerCarDeuxPionAlignésArriere()
        {
            JeuDame monJeu = new JeuDame();
            monJeu.EtablirJoueur("alex", "alex²");
            Case maCase = monJeu.plateauJeu.GetCase(new Position(2, 3));
            maCase.Pion = new Pion();
            maCase.Pion.TypePion = TypePion.pionBlanc;

            Case caseEnnemi1 = monJeu.plateauJeu.GetCase(new Position(1, 2));
            caseEnnemi1.Pion = new Pion();
            caseEnnemi1.Pion.TypePion = TypePion.pionNoir;

            Case caseEnnemi2 = monJeu.plateauJeu.GetCase(new Position(0, 1));
            caseEnnemi2.Pion = new Pion();
            caseEnnemi2.Pion.TypePion = TypePion.pionNoir;

            Assert.AreEqual(false, monJeu.plateauJeu.PeutManger(maCase));
        }

        [TestMethod]
        public void NePeutPasMangerCarHorsLimite()
        {
            JeuDame monJeu = new JeuDame();
            monJeu.EtablirJoueur("alex", "alex²");
            Case maCase = monJeu.plateauJeu.GetCase(new Position(1, 2));
            maCase.Pion = new Pion();
            maCase.Pion.TypePion = TypePion.pionBlanc;

            Case caseEnnemi1 = monJeu.plateauJeu.GetCase(new Position(0, 1));
            caseEnnemi1.Pion = new Pion();
            caseEnnemi1.Pion.TypePion = TypePion.pionNoir;

         

            Assert.AreEqual(false, monJeu.plateauJeu.PeutManger(maCase));
        }

        [TestMethod]
        public void NePeutPasMangerCarHorsLimiteDeuxPions()
        {
            JeuDame monJeu = new JeuDame();
            monJeu.EtablirJoueur("alex", "alex²");
            Case maCase = monJeu.plateauJeu.GetCase(new Position(1, 2));
            maCase.Pion = new Pion();
            maCase.Pion.TypePion = TypePion.pionBlanc;

            Case caseEnnemi1 = monJeu.plateauJeu.GetCase(new Position(0, 1));
            caseEnnemi1.Pion = new Pion();
            caseEnnemi1.Pion.TypePion = TypePion.pionNoir;

            Case caseEnnemi2 = monJeu.plateauJeu.GetCase(new Position(0, 3));
            caseEnnemi2.Pion = new Pion();
            caseEnnemi2.Pion.TypePion = TypePion.pionNoir;

            Assert.AreEqual(false, monJeu.plateauJeu.PeutManger(maCase));
        }

        [TestMethod]
        public void NePeutPasMangerCarDeuxPionsAlignésDontUnBlanc()
        {
            JeuDame monJeu = new JeuDame();
            monJeu.EtablirJoueur("alex", "alex²");
            Case maCase = monJeu.plateauJeu.GetCase(new Position(1, 2));
            maCase.Pion = new Pion();
            maCase.Pion.TypePion = TypePion.pionBlanc;

            Case caseEnnemi1 = monJeu.plateauJeu.GetCase(new Position(2, 3));
            caseEnnemi1.Pion = new Pion();
            caseEnnemi1.Pion.TypePion = TypePion.pionNoir;

            Case caseEnnemi2 = monJeu.plateauJeu.GetCase(new Position(3, 4));
            caseEnnemi2.Pion = new Pion();
            caseEnnemi2.Pion.TypePion = TypePion.pionBlanc;

            Assert.AreEqual(false, monJeu.plateauJeu.PeutManger(maCase));
        }


    }
}
