﻿using P2_TrianglesFilling.Canvases;
using P2_TrianglesFilling.FigureDrawers;
using P2_TrianglesFilling.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Drawing.FigureDrawers
{
    public interface IFigureDrawer
    {
        public void DrawPolygon(Graphics graphics, ICanvas canvas, Polygon polygon, FigureDrawerArguments argument);
        public void DrawPolygonWithNormals(Graphics graphics, ICanvas canvas, PolygonWithNormals polygonWith, FigureDrawerArguments argument);
        public void DrawPolygonSetWithNormals(Graphics graphics, ICanvas canvas, PolygonSetWithNormals polygonSetWithNormals, FigureDrawerArguments argument);
        public void DrawPolygonSet<TPolygon>(Graphics graphics, ICanvas canvas, PolygonSet<TPolygon> polygonSet, FigureDrawerArguments argument) where TPolygon : Polygon;
        public void DrawVertex(Graphics graphics, ICanvas canvas, Vertex vertex, FigureDrawerArguments argument);
    }
}
