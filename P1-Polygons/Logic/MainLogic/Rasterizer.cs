﻿using P1_Polygons.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Logic.MainLogic
{
    public class Rasterizer
    {
        public readonly Image Image;
        private const float xMin = -1600.0f;
        private const float xMax = 1600.0f;
        private const float yMin = -1000.0f;
        private const float yMax = 1000.0f;

        public Rasterizer(PictureBox canvas)
        {
            Image = canvas.Image;
        }

        public PointF Derasterize(Point point)
        {
            return new PointF(
                point.X * (xMax - xMin) / Image.Width,
                point.Y * (yMax - yMin) / Image.Height);
        }

        public Point Rasterize(PointF point)
        {
            return new Point(
                (int)Math.Round(point.X * (Image.Width) / (xMax - xMin)),
                (int)Math.Round(point.Y * (Image.Height) / (yMax - yMin)));
        }

        public bool ArePointsWithinPixelRadius(PointF a, PointF b, float radius)
        {
            return ArePointsWithinPixelRadius(Rasterize(a), Rasterize(b), radius);
        }

        public bool ArePointsWithinPixelRadius(Point aInt, Point bInt, float radius)
        {
            var xDif = aInt.X - bInt.X;
            var yDif = aInt.Y - bInt.Y;

            return xDif * xDif + yDif * yDif < radius * radius;
        }

        public int PixelDistanceSquared(Point aInt, Point bInt)
        {
            var xDif = aInt.X - bInt.X;
            var yDif = aInt.Y - bInt.Y;

            return xDif * xDif + yDif * yDif;
        }

        public int DistanceSquared(PointF a, PointF b)
        {
            return PixelDistanceSquared(Rasterize(a), Rasterize(b));
        }
    }

    public class EdgePixelDistanceComparer : IComparer<Edge>
    {
        private Point Point { get; }
        public Rasterizer Rasterizer { get; }

        public EdgePixelDistanceComparer(Point point, Rasterizer rasterizer)
        {
            Point = point;
            Rasterizer = rasterizer;
        }

        public int Compare(Edge? x, Edge? y)
        {
            return (x == null || y == null) ? 0 : x.GetPixelDistanceSquared(Point, Rasterizer) - y.GetPixelDistanceSquared(Point, Rasterizer);
        }
    }

    public class VertexPixelDistanceComparer : IComparer<Vertex>
    {
        private Point Point { get; }
        public Rasterizer Rasterizer { get; }

        public VertexPixelDistanceComparer(Point point, Rasterizer rasterizer)
        {
            Point = point;
            Rasterizer = rasterizer;
        }

        public int Compare(Vertex? x, Vertex? y)
        {
            return (x == null || y == null) ? 0 : x.GetPixelDistanceSquared(Point, Rasterizer) - y.GetPixelDistanceSquared(Point, Rasterizer);
        }
    }

    public class CirclePixelDistanceComparer : IComparer<Circle>
    {
        private Point Point { get; }
        public Rasterizer Rasterizer { get; }

        public CirclePixelDistanceComparer(Point point, Rasterizer rasterizer)
        {
            Point = point;
            Rasterizer = rasterizer;
        }

        public int Compare(Circle? x, Circle? y)
        {
            return (x == null || y == null) ? 0 : x.GetPixelDistanceSquared(Point, Rasterizer) - y.GetPixelDistanceSquared(Point, Rasterizer);
        }
    }
}
