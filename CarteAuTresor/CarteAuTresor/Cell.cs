using System;
using System.Collections.Generic;
using System.Text;

namespace CarteAuTresor
{
    abstract class Cell
    {
        public int x;
        public int y;
        public bool isWakable;


        abstract public int onTheCell();
        
    }
}
