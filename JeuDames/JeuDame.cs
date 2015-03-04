using Morpion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JeuDames
{
  public  class JeuDame
    {

      public Joueur joueur1;
        public Joueur joueur2;
        public Plateau plateauJeu;

        public bool AfficherInterfaceDebut;
        public bool AfficherInterfaceEnJeu;
        public bool animationEnCours;

        public Joueur joueurALaMain;

        public JeuDame()
        {
            this.AfficherInterfaceDebut = true;
            this.AfficherInterfaceEnJeu = false;
            this.animationEnCours = false;
            this.plateauJeu = new Plateau(10, 10);
            

        }
        public void EtablirJoueur(string pseudoJ1,string pseudoJ2)
        {
            this.joueur1 = new Joueur();
            this.joueur2 = new Joueur();

            this.joueur1.Pseudo = pseudoJ1;
            this.joueur1.Pion = new Pion();
            this.joueur1.Pion.TypePion = TypePion.pionBlanc;
            this.joueur2.Pseudo = pseudoJ2;

            this.joueur2.Pion = new Pion();
            this.joueur2.Pion.TypePion = TypePion.pionNoir;

            this.joueurALaMain = this.joueur1;
        }

        public void LancerPartie()
        {
            this.AfficherInterfaceDebut = false;
            this.AfficherInterfaceEnJeu = true;
        }

        public void Update()
        {
            try
            {
                AfficherJoueurCourant();

                if (this.plateauJeu.caseSelectionne == null)
                {

                    Console.WriteLine("Selectionnez votre pion à jouer X,Y");
                    string position = Console.ReadLine().ToString();

                    Position positionSelectionne = new Position(position);
                    this.plateauJeu.SelectionnerCase(positionSelectionne, joueurALaMain);

                }else
                {
                    Console.WriteLine("Déplacer votre pion ou annuler votre selection. (X,Y ou 'Annuler'");
                    string input = Console.ReadLine();
                    if (input == "Annuler")
                    {
                        this.plateauJeu.caseSelectionne = null;
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
         
        }

        private void AfficherJoueurCourant()
        {
            
                Console.WriteLine(this.joueurALaMain.Pseudo + " a la main.");

           
        }

        public override string ToString()
        {
            for (int indexLigne = 0; indexLigne < 10; indexLigne++)
            {
                

                for (int indexColonne = 0; indexColonne < 10; indexColonne++)
                {
                    Console.Write(this.plateauJeu.GetCase(new Position(indexColonne, indexLigne)).ToString() + "|");

                }
                Console.WriteLine("");
            }
            return "";
         }

      public void ToStringPosition()
        { 
      }



      public void InitialiserTerrain()
      {
          this.plateauJeu.GenererPion();
      }
    }
}
