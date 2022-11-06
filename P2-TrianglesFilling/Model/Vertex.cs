﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using P2_TrianglesFilling.Canvases;
using P2_TrianglesFilling.FigureDrawers;

namespace P2_TrianglesFilling.Model
{
    public class Vertex : Figure
    {
        public Vector3 Position { get; private set; }

        public Vertex(Vector3 position)
        {
            Position = position;
        }

        public override void Draw(Graphics graphics, ICanvas canvas, IFigureDrawer drawer)
        {
            drawer.DrawVertex(graphics, canvas, this);
        }
    }
}