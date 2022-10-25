using P1_Polygons.Controls;
using P1_Polygons.Logic.EdgeRestrictions;
using P1_Polygons.Logic.MainLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons.Model
{
    public class Circle : Figure
    {
        public float Radius { get; set; }
        public PointF Center;

        public Circle(float radius, PointF center)
        {
            Radius = radius;
            Center = center;
        }

        public override float GetDistanceSquared(PointF point)
        {
            var xDif = point.X - Center.X + Radius;
            var yDif = point.Y - Center.Y + Radius;

            return xDif * xDif + yDif * yDif;
        }

        public override int GetPixelDistanceSquared(Point point, Rasterizer rasterizer)
        {
            return Math.Abs(
                rasterizer.PixelDistanceSquared(rasterizer.Rasterize(Center), point) -
                rasterizer.PixelDistanceSquared(new Point(), rasterizer.Rasterize(new PointF(0, Radius))));
        }

        public override Polygon GetPolygon()
        {
            return null;
        }

        public override void MoveBy(PointF vector)
        {
            Center.X += vector.X;
            Center.Y += vector.Y;
        }

        public override void MoveByConsideringRestrictions(PointF vector, Vertex.Direction? direction = null)
        {
            MoveBy(vector);
        }

        public override void Remove()
        {
            return;
        }

        public override void ShowContextMenu(MainWindow mainWindow, Point point)
        {
            var circleContextMenuStrip = new CircleContextMenuStrip(this);
            circleContextMenuStrip.Show(mainWindow.pictureBox, point);
        }

        public void Resize(Point point, Rasterizer rasterizer)
        {
            var dp = rasterizer.Derasterize(point);
            Radius = PerpendicularityRestriction.Length(dp, Center);
        }
    }
}
