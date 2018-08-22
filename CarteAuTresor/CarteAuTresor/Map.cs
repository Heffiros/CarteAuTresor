using System;
using System.Collections.Generic;
using System.Text;

namespace CarteAuTresor
{
    class Map
    {
        public Cell[,] map;
        public int sizeX, sizeY;
        public List<Adventurer> AdventureCell = new List<Adventurer>();
        

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
                Adventurer adventurer = new Adventurer(lineOpt[1], lineOpt[4], lineOpt[5], Int32.Parse(lineOpt[3]), Int32.Parse(lineOpt[2]));
                //map[Int32.Parse(lineOpt[3]), Int32.Parse(lineOpt[2])] = adventurer; 
                AdventureCell.Add(adventurer);
            }
            return true;
        }

        public void mapSimulationPath()
        {
            Simulation simulation = new Simulation();
            int actualX, newX;
            int actualY, newY;
            int i = 0;
            
            //loop simulation continu until all action has been done
            while (AdventureCell.FindAll(adventurer => adventurer.flagAction == true).Count != 0)
            {
                foreach (Adventurer adventurer in AdventureCell)
                {
                    //if we do more loop than action tab size all actions of the adventure has been done
                    if (i > adventurer.roadPath.Length - 1)
                    {
                        adventurer.flagAction = false;
                    }
                    else
                    {
                        char action = adventurer.roadPath[i];
                        if (action == 'A')
                        {
                           
                            //Calcul the new position
                            newX = adventurer.x + simulation.dicOrientation[adventurer.orientation][0];
                            newY = adventurer.y + simulation.dicOrientation[adventurer.orientation][1];

                            //check out of bond and if it is a wakable cell and if user is not on this coord
                            if (simulation.verifNewCord(newX, newY, sizeX, sizeX) && (map[newY, newX] == null || map[newY, newX].isWalkable))
                            {
                                //Atribute new cord on the adventurer
                                adventurer.x = newX;
                                adventurer.y = newY;
                                if (map[newY, newX] != null)
                                {
                                    //Update treasure on cell and adventurer if needed
                                    adventurer.nbTreasure += map[newY, newX].onTheCell();
                                }
                            }
                        }
                        else if (action == 'D')
                        {
                            adventurer.orientation = simulation.findNewOrientation(adventurer.orientation, 1);
                        }
                        else if (action == 'G')
                        {
                            adventurer.orientation = simulation.findNewOrientation(adventurer.orientation, -1);
                        }
                    }
                }
                i++;
            }
        }
        
        //Debug fonction to see map evolution
        public void printMap()
        {
            int rowLength = map.GetLength(0);
            int colLength = map.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Adventurer test = AdventureCell.Find(adventurer => adventurer.x == j && adventurer.y == i);
                    if (test == null)
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
                    else
                    {
                        Console.Write(test.affCell());
                    } 
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }


        //Clean line to have a good parth
        private string[] cleanStringOption(String line)
        {
            line = line.Replace(" ", string.Empty);
            return (line.Split('-'));
        }

        //output file data 
        public string outPutInfo()
        {
            return ("C - " + sizeY + " - " + sizeX);
        }

    }
}
