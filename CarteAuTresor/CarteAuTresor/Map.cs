using System;
using System.Collections.Generic;
using System.Text;

namespace CarteAuTresor
{
    class Map
    {
        Cell[,] map;

        public Map(String line)
        {
            //TODO : check if we can better access to lineopt[value] and verify if is good number

            line = line.Replace(" ", string.Empty);
            string[] lineOpt = line.Split('-');
            map = new Cell[Int32.Parse(lineOpt[2]), Int32.Parse(lineOpt[1])];
            printMap();
        }


        public bool generateCell(String line)
        {
            return true;
        }


        public void printMap()
        {
            int rowLength = map.GetLength(0);
            int colLength = map.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", /*map[i, j]*/ ".  "));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

    }
}
