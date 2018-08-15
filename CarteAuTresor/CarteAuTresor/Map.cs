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
            string[] lineOpt = cleanStringOption(line);
            map = new Cell[Int32.Parse(lineOpt[2]), Int32.Parse(lineOpt[1])];
        }


        public bool generateCell(String line)
        {
            string[] lineOpt = cleanStringOption(line);
            
            if (lineOpt[0] == "M")
            {
                map[Int32.Parse(lineOpt[2]), Int32.Parse(lineOpt[1])] = new MountainCell();
            }
            else if (lineOpt[0] == "T")
            {   
                map[Int32.Parse(lineOpt[2]), Int32.Parse(lineOpt[1])] = new TreasureCell(Int32.Parse(lineOpt[3]));
            }
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
                    if (map[i, j] != null)
                    {
                        Console.Write(map[i, j].affCell());
                    }
                    else
                    {
                        Console.Write(string.Format("{0} ", /*map[i, j]*/ ".  "));
                    }
                    
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }


        private string[] cleanStringOption(String line)
        {
            line = line.Replace(" ", string.Empty);
            return (line.Split('-'));
        }

    }
}
