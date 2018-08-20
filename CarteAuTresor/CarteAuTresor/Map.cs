using System;
using System.Collections.Generic;
using System.Text;

namespace CarteAuTresor
{
    class Map
    {
        Cell[,] map;
        int sizeX, sizeY;
        List<AdventurerCell> AdventureCell = new List<AdventurerCell>();
        

        public Map(String line)
        {
            //TODO : check if we can better access to lineopt[value] and verify if is valid number
            string[] lineOpt = cleanStringOption(line);
            map = new Cell[Int32.Parse(lineOpt[2]), Int32.Parse(lineOpt[1])];
            sizeX = Int32.Parse(lineOpt[2]);
            sizeY = Int32.Parse(lineOpt[1]);
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
            else if (lineOpt[0] == "A")
            {
                AdventurerCell adventurer = new AdventurerCell(lineOpt[1], lineOpt[4], lineOpt[5], Int32.Parse(lineOpt[2]), Int32.Parse(lineOpt[3]));
                map[Int32.Parse(lineOpt[3]), Int32.Parse(lineOpt[2])] = adventurer; 
                AdventureCell.Add(adventurer);
            }
            return true;
        }

        public void mapSimulationPath()
        {
            int actualX, newX;
            int actualY, newY;
            Simulation simulation = new Simulation();

            foreach (AdventurerCell adventurer in AdventureCell)
            {
                foreach (char action in adventurer.roadPath)
                {
                    if (action == 'A')
                    {
                        //Console.WriteLine("On bouge");
                        actualX = adventurer.x;
                        actualY = adventurer.y;
                        newX = actualX + simulation.dicOrientation[adventurer.orientation][0];
                        newY = actualY + simulation.dicOrientation[adventurer.orientation][1];
                        if (simulation.verifNewCord(newX, newY, sizeX, sizeY))
                        {
                            map[actualY, actualX] = null;
                            map[newY, newX] = adventurer;
                            adventurer.x = newX;
                            adventurer.y = newY;
                        } 
                    }
                    else if (action == 'D')
                    {
                        adventurer.orientation =  simulation.findNewOrientation(adventurer.orientation, 1);
                        //adventurer.adventurerProfile();
                    }
                    else if (action == 'G')
                    {
                        adventurer.orientation = simulation.findNewOrientation(adventurer.orientation, -1);
                        //adventurer.adventurerProfile();
                    }
                    this.printMap();
                }
            }
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
                        Console.Write(string.Format("{0} ", /*map[i, j]*/ "   .   "));
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
