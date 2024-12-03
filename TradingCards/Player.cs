using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCards
{
    public class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
        public string PhotoUrl { get; set; }
        public string Position { get; set; }
        public double PointsPerGame { get; set; }
        public double AssistsPerGame { get; set; }
        public double ReboundsPerGame { get; set; }
        public double FieldGoalPercentage { get; set; }
    }
}
