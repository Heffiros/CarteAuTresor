using System;
using System.Collections.Generic;
using System.Text;

namespace CarteAuTresor
{
    class AdventurerCell : Cell
    {
        
        private string name;
        public string roadPath;
        public char orientation;
        public int x;
        public int y;
        public bool flagAction = true;


        public AdventurerCell(string name, string orientation, string roadPath, int x, int y)
        {
            this.name = name;
            this.orientation = orientation[0];
            this.roadPath = roadPath;
            this.x = x;
            this.y = y;
            this.isWalkable = true;
        }

        public override void onTheCell()
        {
            throw new NotImplementedException();
        }

        public override string affCell()
        {
            return "A("+ name + ")    " ;
        }

        public  void  adventurerProfile()
        {
            Console.WriteLine("L'aventurier : " + name + " est orienté plein : " + orientation + "sa route est : " + roadPath);
            Console.ReadLine();
        }
    }
}
