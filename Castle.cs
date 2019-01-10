using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoldiersInCastle
{
    public class Castle
    {
        public int ID { get; set; }
        public int CastleOne { get; set; }
        public int CastleTwo { get; set; }
        public int CastleThree { get; set; }
        public int CastleFour { get; set; }
        public int CastleFive { get; set; }
        public int CastleSix { get; set; }
        public int CastleSeven { get; set; }
        public int CastleEight { get; set; }
        public int CastleNine { get; set; }
        public int CastleTen { get; set; }
        public int TotalWins { get; set; }
        public int TotalLosses { get; set; }
        public int TotalTies { get; set; }
        public int Rank { get; set; }

        public static Castle FrontDataObject(Castles.CastlesRow row)
        {
            Castle cas = new Castle();
            cas.ID = row.Id;
            cas.CastleOne = row.CastleOne;
            cas.CastleTwo = row.CastleTwo;
            cas.CastleThree = row.CastleThree;
            cas.CastleFour = row.CastleFour;
            cas.CastleFive = row.CastleFive;
            cas.CastleSix = row.CastleSix;
            cas.CastleSeven = row.CastleSeven;
            cas.CastleEight = row.CastleEight;
            cas.CastleNine = row.CastleNine;
            cas.CastleTen = row.CastleTen;
            cas.TotalWins = row.IsTotalWinsNull() ? 0 : row.TotalWins;
            cas.TotalLosses = row.IsTotalLossesNull() ? 0 : row.TotalLosses;
            cas.TotalTies = row.IsTotalTiedNull() ? 0 : row.TotalTied;
            cas.Rank = row.IsRankNull() ? 0 : row.Rank;
            return cas;
        }
        public static void toDataObject(Castle cas, Castles.CastlesRow row)
        {
            row.TotalWins = cas.TotalWins;
            row.TotalLosses = cas.TotalLosses;
            row.TotalTied = cas.TotalTies;
        }
    }
}
