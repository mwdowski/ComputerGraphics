using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Coloring.Model
{
    public class ProfileColorAttributes
    {
        public BindedAttribute<string> Name { get; set; }
        public BindedAttribute<float> Gamma { get; set; }
        public BindedAttribute<PointF> White { get; set; }
        public BindedAttribute<PointF> Red { get; set; }
        public BindedAttribute<PointF> Green { get; set; }
        public BindedAttribute<PointF> Blue { get; set; }
    }
}
