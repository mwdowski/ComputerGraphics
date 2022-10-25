using P1_Polygons.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Controls
{
    public class CircleContextMenuStrip : ContextMenuStrip
    {
        public Circle Circle { get; }
        public CircleContextMenuStrip(Circle circle) : base()
        {
            Circle = circle;
            Items.Add("Circle");
            Items.Add("Remove", null, (_, _) => circle.Remove());
        }
    }
}
