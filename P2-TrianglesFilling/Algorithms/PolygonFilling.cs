﻿using P2_TrianglesFilling.Canvases;
using P2_TrianglesFilling.Drawing.ColorProviders;

namespace P2_TrianglesFilling.Algorithms
{
    public static class PolygonFilling
    {
        public static void FillPolygon(ICanvas canvas, IList<Point> vertices, IColorProvider colorProvider)
        {
            // TODO: cleanup
            var edges = VerticesListToEdgesList(vertices.DistinctBy(_ => (_.X, _.Y)).ToList());

            var horizonalEdges = edges.Where(_ => _.Start.Y == _.End.Y);
            foreach (var edge in horizonalEdges)
            {
                var startX = Math.Min(edge.Start.X, edge.End.X);
                var endX = Math.Max(edge.Start.X, edge.End.X);

                for (int x = startX; x < endX; x++)
                {
                    canvas.SetPixel(x, edge.Start.Y, colorProvider.GetColor(x, edge.Start.Y));
                }
            }

            edges = edges.Where(_ => _.Start.Y != _.End.Y).ToList();
            if (edges.Count == 0) return;
            var ET = EdgeTable.GetET(edges);
            var AET = new List<EdgeTableEntry>();

            var scanLine = edges.Select(_ => _.YMin).Min();

            while (true)
            {
                if (scanLine >= ET.Size && AET.Count == 0) break;

                // move entries from ET to AET
                AET = AET
                    .Concat(ET[scanLine].AsEnumerable())
                    .OrderBy(_ => _.XMin)
                    .ToList();

                // fill pixels
                for (int i = 0; i < AET.Count; i += 2)
                {
                    var startX = (int)AET[i].XMin;
                    var endX = (int)AET[i + 1].XMin;

                    for (int x = startX; x < endX; x++)
                    {
                        canvas.SetPixel(x, scanLine, colorProvider.GetColor(x, scanLine));
                    }
                }

                // move scanLine
                scanLine++;

                // remove edges that are too low
                AET.RemoveAll(_ => (int)_.YMax == scanLine);

                // update x
                AET.ForEach(_ => _.XMin += _.Slope);
            }
        }

        private static IList<Edge> VerticesListToEdgesList(IList<Point> vertices)
        {
            var edges = new List<Edge>(vertices.Count);

            for (int i = 0; i < vertices.Count - 1; i++)
            {
                edges.Add(new Edge(vertices[i], vertices[i + 1]));
            }
            edges.Add(new Edge(vertices[vertices.Count - 1], vertices[0]));

            return edges;
        }

        private class EdgeTableEntry
        {
            public float YMax;
            public float XMin;
            public float Slope;
            public EdgeTableEntry? Next;

            public void Insert(EdgeTableEntry entry)
            {
                if (Next == null)
                {
                    Next = entry;
                }
                else
                {
                    Next.Insert(entry);
                }
            }
        }

        private class EdgeTable
        {
            private LinkedList<EdgeTableEntry>[] _edgeTable;
            public readonly int Size;

            public EdgeTable(int size)
            {
                Size = size;
                _edgeTable = new LinkedList<EdgeTableEntry>[size];
                for (int i = 0; i < size; i++)
                {
                    _edgeTable[i] = new LinkedList<EdgeTableEntry>();
                }
            }

            public void Insert(EdgeTableEntry entry, int position)
            {
                _edgeTable[position].AddLast(entry);
            }

            public LinkedList<EdgeTableEntry> this[int index] => _edgeTable[index];

            public static EdgeTable GetET(IList<Edge> edges)
            {
                var bucketsMax = edges.Max(edge => Math.Max(edge.Start.Y, edge.End.Y));

                var result = new EdgeTable(bucketsMax + 1);

                foreach (var edge in edges)
                {
                    result.Insert(new EdgeTableEntry { YMax = edge.YMax, XMin = edge.XOfYMin, Slope = edge.Slope }, edge.YMin);
                }

                return result;
            }
        }

        private class Edge
        {
            public Point Start;
            public Point End;

            public Edge(Point start, Point end)
            {
                Start = start;
                End = end;
            }

            public int YMin => Math.Min(Start.Y, End.Y);

            public int YMax => Math.Max(Start.Y, End.Y);

            public int XOfYMin => Start.Y < End.Y ? Start.X : End.X;

            public float Slope
            {
                get
                {
                    var higherX = Start.Y > End.Y ? Start.X : End.X;
                    var lowerX = Start.Y > End.Y ? End.X : Start.X;

                    return (higherX - lowerX) / (float)(YMax - YMin);
                }
            }
        }
    }
}
