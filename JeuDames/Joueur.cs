using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Morpion
{
    public class Joueur
    {
        public bool Gagnant { get; set; }
        public Pion Pion { get; set; }
        public string Pseudo { get; set; }


        public Joueur()
        {
            this.Pion = new Pion();
            this.Gagnant = false;
        }
    

          



        public void deplacerPion(Plateau lePlateau)
        {
            string inputJoueur = this.SaisirPosition();
            Position position = new Position(inputJoueur);
            lePlateau.placerPion(position,this.Pion);
        }

        private string SaisirPosition()
        {
            Console.WriteLine(this.Pseudo + " Saisir X,Y");
            string res =  Console.ReadLine();
            return res;
        }

        public void SaisirPseudo(int numeroJoueur)
        {
            Console.WriteLine("Joueur numero " + numeroJoueur + ", saisir ton pseudo");
            string inputPseudo = Console.ReadLine();
            this.Pseudo = inputPseudo;
        }

     


    }
}
