using System;
using System.Collections.Generic;
using System.Text;

namespace CarteAuTresor
{
    class MountainCell : Cell
    {
        public MountainCell()
        {
            this.isWalkable = false;
        }

        //no tresor on mountain cell
        public override int onTheCell()
        {
            return 0;
        }

        
        public override string affCell()
        {
            return "M - ";
            
        }
    }
}
