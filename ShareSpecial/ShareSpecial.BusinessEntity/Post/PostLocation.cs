using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.BusinessEntities.Post
{
    public class PostLocation
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Area { get; set; }
        public double? Elevation { get; set; }
        public double? Measure { get; set; }
        public string Text { get; set; }
        public int? CoordinateSystemId { get; set; }
        public int? Dimension { get; set; }
        public int? ElementCount { get; set; }
        public int? PointCount { get; set; }
        public string Name { get; set; }
        public double? Distance { get; set; }
    }
}
