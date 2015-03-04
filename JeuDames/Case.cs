using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JeuDames;

namespace Morpion
{
    public class Case
    {
        public Position Position { get; set; }

        public Pion Pion { get; set; }

        public TypeCase typeCase { get; set; }
        public Case(int compteurX, int compteurY,TypeCase typeCase)
        {
            this.Position = new Position(compteurX,compteurY);
            this.Pion = null;
            this.typeCase = typeCase;
        }


        public override string ToString()
        {
            string res = "";
            if(this.Pion == null)
            {
                res = "#";
            }else
            {
                if (this.Pion.TypePion == TypePion.pionBlanc)
                    res = "B";
                else
                    res = "N";
            }
            return res;
        }



        internal bool TroisCaseAligne()
        {
            throw new NotImplementedException();
        }
    }
}
