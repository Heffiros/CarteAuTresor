using System;
using System.Collections.Generic;
using System.Text;

namespace CarteAuTresor
{
    class TreasureCell : Cell
    {
        private int nbTreasure;

        public TreasureCell(int nbTreasure)
        {
            this.nbTreasure = nbTreasure;
            this.isWalkable = true;
        }

        public override string affCell()
        {
            return "T(" + nbTreasure.ToString() + ")    ";
        }

        public override int onTheCell()
        {
            throw new NotImplementedException();
        }
    }
}
