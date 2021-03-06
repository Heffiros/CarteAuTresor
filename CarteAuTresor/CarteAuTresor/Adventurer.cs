﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarteAuTresor
{
    class Adventurer
    {
        
        private string name;
        public string roadPath;
        public char orientation;
        public int x;
        public int y;
        public bool flagAction = true;
        public int nbTreasure = 0;
        public bool isWalkable;

        public Adventurer(string name, string orientation, string roadPath, int x, int y)
        {
            this.name = name;
            this.orientation = orientation[0];
            this.roadPath = roadPath;
            this.x = x;
            this.y = y;
            this.isWalkable = true;
        }
               

        public  string affCell()
        {
            return name + " - " +  y  +  " - " + x  + " - "+ orientation + " - " + nbTreasure  ;
        }

        public  void  adventurerProfile()
        {
            Console.WriteLine("L'aventurier : " + name + " est orienté plein : " + orientation + "sa route est : " + roadPath);
            Console.ReadLine();
        }
    }
}
