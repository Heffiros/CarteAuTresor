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

        public override void onTheCell()
        {
            //throw new NotImplementedException();
        }

        
        public override string affCell()
        {
            return "M - ";
            
        }
    }
}
