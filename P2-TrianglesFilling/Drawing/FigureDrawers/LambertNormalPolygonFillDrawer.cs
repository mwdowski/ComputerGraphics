﻿using P2_TrainglesFilling.Rasterizers;
using P2_TrianglesFilling.Canvases;
using P2_TrianglesFilling.Drawing.ColorProviders;
using P2_TrianglesFilling.FigureDrawers;
using P2_TrianglesFilling.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Drawing.FigureDrawers
{
    public class LambertOneColorNormalPolygonFillDrawer : IFigureDrawer
    {
        protected Rasterizer Rasterizer;
        private readonly Color _color;

        public LambertOneColorNormalPolygonFillDrawer(Rasterizer rasterizer, Color color)
        {
            Rasterizer = rasterizer;
            _color = color;
        }

        public void DrawPolygon(Graphics graphics, ICanvas canvas, Polygon polygon, FigureDrawerArguments argument)
        {
            throw new NotImplementedException();
        }

        public void DrawPolygonSet<TPolygon>(Graphics graphics, ICanvas canvas, PolygonSet<TPolygon> polygonSet, FigureDrawerArguments argument) where TPolygon : Polygon
        {
            throw new NotImplementedException();
        }

        public void DrawPolygonSetWithNormals(Graphics graphics, ICanvas canvas, PolygonSetWithNormals polygonSetWithNormals, FigureDrawerArguments argument)
        {
            foreach (var polygon in polygonSetWithNormals.Polygons)
            {
                polygon.Draw(graphics, canvas, this, argument);
            }
        }

        public void DrawPolygonWithNormals(Graphics graphics, ICanvas canvas, PolygonWithNormals polygonWithNormals, FigureDrawerArguments argument)
        {
            Algorithms.PolygonFilling.FillPolygon(
                canvas,
                polygonWithNormals
                    .Vertices
                    .Select(_ => Rasterizer.RasterizeOrthogonaly(_.Position))
                    .ToList(),
                new LambertWithVerticesColorInterpolationConstantColorProvider(_color, argument, polygonWithNormals, Rasterizer)
            );
        }

        public void DrawVertex(Graphics graphics, ICanvas canvas, Vertex vertex, FigureDrawerArguments argument)
        {
            return;
        }
    }
}