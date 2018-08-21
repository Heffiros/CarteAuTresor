using System;
using System.Collections.Generic;
using System.Text;

namespace CarteAuTresor
{
    abstract class Cell
    {
        public int x;
        public int y;
        public bool isWalkable;


        abstract public void onTheCell();
        abstract public string affCell();
    }
}
