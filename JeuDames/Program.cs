using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDames
{
    class Program
    {
        static void Main(string[] args)
        {

            JeuDame monJeu = new JeuDame();
            monJeu.EtablirJoueur("alex", "alex²");
            monJeu.InitialiserTerrain();
            monJeu.ToString();
            while(true)
            {
                monJeu.Update();
            }
            Console.Read();
      }
    }
}
