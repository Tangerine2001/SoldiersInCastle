using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoldiersInCastle
{
    class Program
    {
        static void Main(string[] args)
        {
            calculateResults();   
        }

        public static void TestAddSoldiers()
        {
            for (int c1 = 10; c1 >= 0; c1--)
            {
                for (int c2 = 10 - c1; c2 >= 0; c2--)
                {
                    for (int c3 = 10 - c1 - c2; c3 >= 0; c3--)
                    {
                        for (int c4 = 10 - c1 - c2 - c3; c4 >= 0; c4--)
                        {
                            for (int c5 = 10 - c1 - c2 - c3 -c4; c5 >= 0; c5--)
                            {
                                for (int c6 = 10 - c1 - c2 - c3 - c4 - c5; c6 >= 0; c6--)
                                {
                                    for (int c7 = 10 - c1 - c2 - c3 - c4 - c5 - c6; c7 >= 0; c7--)
                                    {
                                        for (int c8 = 10 - c1 - c2 - c3 - c4 - c5 - c6 - c7; c8 >= 0; c8--)
                                        {
                                            for (int c9 = 10 - c1 - c2 - c3 - c4 - c5 - c6 -c7 - c8; c9 >= 0; c9--)
                                            {
                                                int c10 = 10 - c1 - c2 - c3 - c4 - c5 - c6 - c7 - c8 - c9;
                                                    Castles.CastlesDataTable table = new Castles.CastlesDataTable();
                                                    Castles.CastlesRow row = table.NewCastlesRow();
                                                    row.CastleOne = c1;
                                                    row.CastleTwo = c2;
                                                    row.CastleThree= c3;
                                                    row.CastleFour = c4;
                                                    row.CastleFive = c5;
                                                    row.CastleSix = c6;
                                                    row.CastleSeven = c7;
                                                    row.CastleEight = c8;
                                                    row.CastleNine = c9;
                                                    row.CastleTen = c10;
                                                    table.AddCastlesRow(row);
                                                    CastlesTableAdapters.CastlesTableAdapter adapter = new CastlesTableAdapters.CastlesTableAdapter();
                                                    adapter.Update(table);
                                                    table.AcceptChanges();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void addSoldiers()
        {
            for ( int c1 = 100; c1 >= 0; c1--)
            {
                for (int c2 = 100 - c1; c2 > 0; c2--)
                {
                    for(int c3 = 0; c3 <= 100 - c1 - c2; c3++)
                    {
                        for (int c4 = 0; c4 <= 100 - c1 - c2 - c3; c4++)
                        {
                            for (int c5 = 0; c5 <= 100 - c1 - c2 - c3 - c4; c5++)
                            {
                                for (int c6 = 0; c6 <= 100 - c1 - c2 - c3 - c4 - c5; c6++)
                                {
                                    for (int c7 = 0; c7 <= 100 - c1 - c2 - c3 - c4 - c5 - c6; c7++)
                                    {
                                        for (int c8 = 0; c8 <= 100 - c1 - c2 - c3 - c4 - c5 - c6 - c7; c8++)
                                        {
                                            for (int c9 = 0; c9 <= 100 - c1 - c2 - c3 - c4 - c5 - c6 - c7 - c8; c9++)
                                            {
                                                for (int c10 = 0; c10 <= 100 - c1 - c2 - c3 - c4 - c5 - c6 - c7 - c8 - c9; c10++)
                                                {
                                                    // insert to table

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void calculateResults()
        {
            using (CastlesTableAdapters.CastlesTableAdapter adapter = new CastlesTableAdapters.CastlesTableAdapter())
            {
                Castles.CastlesDataTable table = new Castles.CastlesDataTable();
                Castles.CastlesDataTable compareToTable = new Castles.CastlesDataTable();
                //Castles.CastlesDataTable compareToTables = new Castles.CastlesDataTable();
                adapter.FillByRange(table, 0, 0);
                adapter.Fill(compareToTable);


                #region ToDo stuff

                //Castle castleFrom = new Castle();
                //castleFrom = Castle.FrontDataObject(table[0]);
                
                //adapter.FillByNotID(compareToTables, 1);
                List<Castle> castles = new List<Castle>();
                foreach (Castles.CastlesRow row in table)
                { 
                    Castle castle = new Castle();
                    castle = Castle.FrontDataObject(row);
                    castles.Add(castle);
                }

                List<Castle> allCastles = new List<Castle>();
                foreach (Castles.CastlesRow row in compareToTable)
                {
                    Castle cas = new Castle();
                    cas = Castle.FrontDataObject(row);
                    allCastles.Add(cas);
                }

                addPoints(castles, allCastles);
                foreach (Castles.CastlesRow row in table)
                {
                    Castle castle = castles.Where(x => x.ID == row.Id).FirstOrDefault();
                    Castle.toDataObject(castle, row);
                }
                #endregion
                
                adapter.Update(table);
                table.AcceptChanges();
            }
        }
        public static void addPoints(List<Castle> castles, List<Castle> allCastles)
        {
            
            foreach (Castle castleFrom in castles)
            {                     
                #region compare to other castles
                foreach (Castle castleTo in allCastles.Where(x => x.ID != castleFrom.ID))
                {
                    int castleFromTotalPoints = 0;
                    int castleToTotalPoints = 0;

                    if (castleFrom.CastleOne > castleTo.CastleOne)
                        castleFromTotalPoints += 1;
                    else if (castleFrom.CastleOne < castleTo.CastleOne)
                        castleToTotalPoints += 1;

                    if (castleFrom.CastleTwo > castleTo.CastleTwo)
                        castleFromTotalPoints += 2;
                    else if (castleFrom.CastleTwo < castleTo.CastleTwo)
                        castleToTotalPoints += 2;

                    if (castleFrom.CastleThree > castleTo.CastleThree)
                        castleFromTotalPoints += 3;
                    else if (castleFrom.CastleThree < castleTo.CastleThree)
                        castleToTotalPoints += 3;

                    if (castleFrom.CastleFour > castleTo.CastleFour)
                        castleFromTotalPoints += 4;
                    else if (castleFrom.CastleFour < castleTo.CastleFour)
                        castleToTotalPoints += 4;

                    if (castleFrom.CastleFive > castleTo.CastleFive)
                        castleFromTotalPoints += 5;
                    else if (castleFrom.CastleFive < castleTo.CastleFive)
                        castleToTotalPoints += 5;

                    if (castleFrom.CastleSix > castleTo.CastleSix)
                        castleFromTotalPoints += 6;
                    else if (castleFrom.CastleSix < castleTo.CastleSix)
                        castleToTotalPoints += 6;

                    if (castleFrom.CastleSeven > castleTo.CastleSeven)
                        castleFromTotalPoints += 7;
                    else if (castleFrom.CastleSeven < castleTo.CastleSeven)
                        castleToTotalPoints += 7;

                    if (castleFrom.CastleEight > castleTo.CastleEight)
                        castleFromTotalPoints += 8;
                    else if (castleFrom.CastleEight < castleTo.CastleEight)
                        castleToTotalPoints += 8;

                    if (castleFrom.CastleNine > castleTo.CastleNine)
                        castleFromTotalPoints += 9;
                    else if (castleFrom.CastleNine < castleTo.CastleNine)
                        castleToTotalPoints += 9;

                    if (castleFrom.CastleTen > castleTo.CastleTen)
                        castleFromTotalPoints += 10;
                    else if (castleFrom.CastleTen < castleTo.CastleTen)
                        castleToTotalPoints += 10;

                    if (castleFromTotalPoints > castleToTotalPoints)
                        castleFrom.TotalWins += 1;
                    else if (castleFromTotalPoints < castleToTotalPoints)
                        castleFrom.TotalLosses += 1;
                    else
                        castleFrom.TotalTies += 1;
                }
                #endregion
            }
        }
    }
}
