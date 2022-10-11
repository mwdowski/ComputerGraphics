using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons
{
    public class Polygon
    {
        private List<Edge> edges;
        private List<Point> points;

        public Polygon(List<Edge> edges, List<Point> points)
        {
            this.edges = edges;
            this.points = points;
        }
    }

    public class Edge
    {
        public readonly Point Start;
        public readonly Point End;

        public Edge(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public Edge(float startX, float startY, float endX, float endY) : this(new Point(startX, startY), new Point(endX, endY)) { }
    }

    public class Point
    {
        public PointF Position { get; private set; }
        public Edge? From { get; private set; }
        public Edge? To { get; private set; }

        public Point(PointF position)
        {
            Position = position;
        }

        public Point(float x, float y) : this(new PointF(x, y)) { }
    }
}
