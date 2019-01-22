using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WandelAppWeb.Models
{
    public class Route
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int Difficulty { get; set; }
        public string Name { get; set; }
        public decimal Length { get; set; }
        public decimal StartLong { get; set; }
        public decimal StartLat { get; set; }
        public decimal EndLong { get; set; }
        public decimal EndLat { get; set; }
        public bool Marshiness { get; set; }
        public bool RouteAsphalted { get; set; }
        public HillType HillType { get; set; }
        public ForestDensity ForestDensity { get; set; }
        public RouteFlatness RouteFlatness { get; set; }
        public RoadSigns RoadSigns { get; set; }

        // temp. constructor
        public Route()
        {
            Id = 1;
            OwnerId = 1;
            Difficulty = 4;
            Name = "Leuke route";
            Length = (decimal)1.343343;
            StartLong = (decimal)0;
            StartLat = (decimal)0;
            EndLong = (decimal)0;
            EndLat = (decimal)0;
            Marshiness = false;
            RouteAsphalted = false;
            HillType = HillType.Sloped;
            ForestDensity = ForestDensity.Thick;
            RouteFlatness = RouteFlatness.Bumpy;

        }
    }
}