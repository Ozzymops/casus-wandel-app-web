using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WandelAppWeb.Models
{
    public class RouteSequence
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int StepNumber { get; set; }
        public decimal Long { get; set; }
        public decimal Lat { get; set; }
    }
}