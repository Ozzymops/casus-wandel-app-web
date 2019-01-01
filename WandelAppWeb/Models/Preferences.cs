using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WandelAppWeb.Models
{
    public enum HillType { None, Sloped, Steep };
    public enum ForestDensity { None, Thin, Thick };
    public enum RouteFlatness { Flat, Bumpy };
    public enum RoadSigns { None, Some, Many };

    public class Preferences
    {
        public int Id { get; set; }
        public int Length { get; set; }
        public HillType HillType { get; set; }
        public bool Marshiness { get; set; }
        public ForestDensity ForestDensity { get; set; }
        public RouteFlatness RouteFlatness { get; set; }
        public bool RouteAsphalted { get; set; }
        public bool RouteHardened { get; set; }
        public RoadSigns RoadSigns { get; set; }
    }
}