using P1_Polygons.Logic.EdgeRestrictions;
using P1_Polygons.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Logic.MainLogic
{
    public class CircleCreator
    {
        public Rasterizer Rasterizer { get; }
        public Point? PotentialPoint { get; private set; }

        private Pen _pen = new Pen(Color.Black, 1);
        public CircleCreator(Rasterizer rasterizer)
        {
            Rasterizer = rasterizer;
        }

        private PointF? _startingPoint = null;
        private Circle? _circle = null;
        private Graphics graphics;
        public void SelectStartingPoint(Point point)
        {
            _startingPoint = Rasterizer.Derasterize(point);
            _circle = null;
            graphics = Graphics.FromImage(Rasterizer.Image);
        }

        public void Restart()
        {
            _circle = null;
            _startingPoint = null;
            graphics.Dispose();
        }

        public void SelectRadiusPoint(Point point)
        {
            if (_startingPoint != null)
            {
                var radiusPoint = Rasterizer.Derasterize(point);
                _circle = new Circle(PerpendicularityRestriction.Length(_startingPoint.Value, radiusPoint), _startingPoint.Value);
                PotentialPoint = null;
            }
        }

        public void SetPotentialPoint(Point point)
        {
            PotentialPoint = point;
        }

        public Circle? GetCreatedCircle()
        {
            return _circle;
        }

        Pen Pen = new Pen(Brushes.Black, 1);

        public void Draw(Graphics g)
        {
            if (PotentialPoint != null)
            {
                g.DrawLine(_pen, Rasterizer.Rasterize(_startingPoint!.Value), PotentialPoint.Value);
                var c = new Circle(PerpendicularityRestriction.Length(_startingPoint.Value, Rasterizer.Derasterize(PotentialPoint.Value)), _startingPoint.Value);

                var rasterizedCenter = Rasterizer.Rasterize(c.Center);
                var rasterizedRadius = Rasterizer.Rasterize(new PointF(c.Radius, 0)).X;
                g.DrawEllipse(Pen, new Rectangle(
                    rasterizedCenter.X - rasterizedRadius,
                    rasterizedCenter.Y - rasterizedRadius,
                    rasterizedRadius * 2,
                    rasterizedRadius * 2));

            }
        }
    }
}
