using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WandelAppWeb.Models
{
    public class Route : Preferences
    {
        public int Difficulty { get; set; }
        public string Name { get; set; }
        public decimal StartLong { get; set; }
        public decimal StartLat { get; set; }
        public decimal EndLong { get; set; }
        public decimal EndLat { get; set; }
        public List<POI> POIList { get; set; }
        public List<RouteSequence> SequenceList { get; set; }
    }
}