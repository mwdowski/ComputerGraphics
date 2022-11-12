﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P2_TrianglesFilling.Canvases;
using P2_TrianglesFilling.Drawing.FigureDrawers;
using P2_TrianglesFilling.FigureDrawers;

namespace P2_TrianglesFilling.Model
{
    public class PolygonWithNormals : Polygon
    {
        public List<Vertex> Normals { get; private set; }

        public PolygonWithNormals() : base()
        {
            Normals = new();
        }

        public override void Draw(Graphics graphics, ICanvas canvas, IFigureDrawer drawer, FigureDrawerArguments argument)
        {
            drawer.DrawPolygonWithNormals(graphics, canvas, this, argument);
        }
    }
}
