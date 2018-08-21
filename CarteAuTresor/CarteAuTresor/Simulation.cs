using System;
using System.Collections.Generic;
using System.Text;

namespace CarteAuTresor
{
    class Simulation
    {
        public Dictionary<char, int[]> dicOrientation = new Dictionary<char, int[]>();
        public string allOrientation = "NESO";

        public Simulation()
        {
            fillOrientationDic();
        }

        private void fillOrientationDic()
        {
            dicOrientation.Add('N', new int[] { 0, -1 });
            dicOrientation.Add('E', new int[] { 1, 0 });
            dicOrientation.Add('S', new int[] { 0, 1 });
            dicOrientation.Add('O', new int[] { -1, 0 });
        }

        //Check if we are not out of bounds
        public bool verifNewCord(int x, int y, int sizeX, int sizeY)
        {
            if (x > sizeX - 1 || y > sizeY - 1)
            {
                Console.WriteLine("perdu");
                return false;
            } else
            {
                return true;
            }
        }

        //Find the new orientation of the adventurer
        public char findNewOrientation(char orientation, int add)
        {
            int keyIndex = allOrientation.IndexOf(orientation) + add;
            if (keyIndex > allOrientation.Length - 1)
            {
                return allOrientation[0];
            } else
            {
                return allOrientation[keyIndex];
            }
        }
    }
}
