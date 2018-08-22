using System;
using System.Collections.Generic;
using System.Text;

namespace CarteAuTresor
{
    class TreasureCell : Cell
    {
        public int nbTreasure;

        public TreasureCell(int nbTreasure)
        {
            this.nbTreasure = nbTreasure;
            this.isWalkable = true;
        }

        public override string affCell()
        {
            return nbTreasure.ToString();
        }

        //on Treasure cell delete one if adventure path on this
        public override int  onTheCell()
        {
            if (nbTreasure != 0)
            {
                nbTreasure--;
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
