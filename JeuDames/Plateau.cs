using JeuDames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Morpion
{
    public class Plateau
    {
        private int NombreCaseX;
        private int NombreCaseY;
        public Case caseSelectionne;
        public List<Case> ListeCase { get; set; }

        public Plateau(int nombreCaseX, int nombreCaseY)
        {
            this.NombreCaseX = nombreCaseX;
            this.NombreCaseY = nombreCaseY;
            this.ListeCase = new List<Case>();

            GenererCase(nombreCaseX, nombreCaseY);
            
        }

        public void GenererPion()
        {
            foreach (var uneCase in this.ListeCase)
            {
                if (uneCase.typeCase == TypeCase.noir)
                {
                    if (uneCase.Position.Y < 4)
                    {
                        uneCase.Pion = new Pion();
                        uneCase.Pion.TypePion = TypePion.pionBlanc;
                    }
                    else
                    {
                        if (uneCase.Position.Y > 5)
                        {
                            uneCase.Pion = new Pion();
                            uneCase.Pion.TypePion = TypePion.pionNoir;
                        }
                    }
                }
            }
        }

        private void GenererCase(int nombreCaseX, int nombreCaseY)
        {
            bool couleurCase = true;
            TypeCase typeCase = TypeCase.blanc;
            for (int compteurX = 0; compteurX < nombreCaseX; compteurX++)
            {
                for (int compteurY = 0; compteurY < nombreCaseY; compteurY++)
                {
                    if (couleurCase)
                    {
                        typeCase = TypeCase.blanc;
                        couleurCase = false;
                    }
                    else
                    {
                        typeCase = TypeCase.noir;
                        couleurCase = true;
                    }
                    Case uneCase = new Case(compteurX, compteurY, typeCase);
                    ListeCase.Add(uneCase);
                }

                if (couleurCase)
                {
                    typeCase = TypeCase.blanc;
                    couleurCase = false;
                }
                else
                {
                    typeCase = TypeCase.noir;
                    couleurCase = true;
                }
            }
        }

        public void placerPion(Position position, Pion pion)
        {
            Case uneCase = this.GetCase(position);
            if (uneCase != null)
            {
                if (uneCase.Pion == null)
                {
                    uneCase.Pion = pion;
                    this.caseSelectionne = uneCase;
                }
                else
                    throw new Exception("Cette case est déjà utilisé.");
            }
            else
                throw new Exception("Cette case n'existe pas.");
        }

        public Case GetCase(Position position)
        {
            Case caseRes = null;
            foreach (Case uneCase in this.ListeCase)
            {
                if (uneCase.Position.Compare(position))
                {
                    caseRes = uneCase;
                }

            }
            return caseRes;
        }

        public bool EstPlein()
        {
            int nombreCaseRemplies = 0;
            foreach (Case uneCase in this.ListeCase)
            {
                if (uneCase.Pion != null)
                {
                    nombreCaseRemplies++;
                }
            }
            return nombreCaseRemplies == this.NombreCaseX * this.NombreCaseY;
        }

        internal Case DerniereCase()
        {
            throw new NotImplementedException();
        }







        public Case DerniereCasePose()
        {
            return this.caseSelectionne;
        }

        internal void EtablirCaseSelectionne(int x, int y, Pion pion)
        {
            Case uneCase = GetCase(x, y);
            if (uneCase.Pion == null)
                throw new Exception("Pas de pion a cet endroit");
            else
                if (uneCase.Pion.TypePion.ToString() != pion.TypePion.ToString())
                {
                    throw new Exception("Ce pion n'est pas le votre");
                }

            this.caseSelectionne = uneCase;
        }

        private Case GetCase(int x, int y)
        {
            throw new NotImplementedException();
        }

        internal void SelectionnerCase(Position positionSelectionne, Joueur joueurCourant)
        {
            try
            {
                Case maCase = this.GetCase(positionSelectionne);
                if (maCase == null)
                    throw new Exception("Cette case n'existe pas");
                if (maCase.Pion == null)
                    throw new Exception("Il n'y a pas de pion sur cette case");
                if (maCase.Pion.TypePion != joueurCourant.Pion.TypePion)
                    throw new Exception("Ce pion n'est pas le votre.");

                this.caseSelectionne = maCase;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public bool PeutManger(Case uneCase)
        {

            bool peutMangerEnAvant = this.PeutMangerDansLaDirection(uneCase,(int)TypeDirection.Avant);
            bool peutMangerEnArriere = this.PeutMangerDansLaDirection(uneCase, (int)TypeDirection.Arriere);






            return (peutMangerEnAvant || peutMangerEnArriere);
        }



     

        private bool PeutMangerDansLaDirection(Case uneCase, int direction)
        {
            bool mangerGauche = false;
            bool mangerDroite = false;
            Case caseGauche = this.GetCase(new Position(uneCase.Position.X - 1, uneCase.Position.Y + (int)uneCase.Pion.TypePion*direction));
            Case caseDroite = this.GetCase(new Position(uneCase.Position.X + 1, uneCase.Position.Y + (int)uneCase.Pion.TypePion*direction));

            if (caseGauche.Pion != null)
            {
                if (caseGauche.Pion.TypePion != uneCase.Pion.TypePion)
                {
                    Case caseGaucheDerriere = this.GetCase(new Position(caseGauche.Position.X - 1, caseGauche.Position.Y + (int)uneCase.Pion.TypePion*direction));
                    if (caseGaucheDerriere != null)
                    {
                        if (caseGaucheDerriere.Pion == null)
                            mangerGauche = true;
                    }
                }

            }
            if (caseDroite.Pion != null)
            {
                if (caseDroite.Pion.TypePion != uneCase.Pion.TypePion)
                {
                    Case caseDroiteDerriere = this.GetCase(new Position(caseDroite.Position.X + 1, caseDroite.Position.Y + (int)uneCase.Pion.TypePion*direction));
                    if (caseDroiteDerriere != null)
                    {
                        if (caseDroiteDerriere.Pion == null)
                            mangerDroite = true;
                    }
                }

            }
            return (mangerGauche || mangerDroite);
        }
    }
}
