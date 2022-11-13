using P2_TrianglesFilling.Canvases;
using P2_TrianglesFilling.Drawing.ColorProviders;
using System.Drawing.Printing;
using System.Numerics;

namespace P2_TrianglesFilling.FigureDrawers
{
    public static class Algorithms
    {
        public static class PolygonFilling
        {
            public static void FillPolygon(ICanvas canvas, IList<Point> vertices, IColorProvider colorProvider)
            {
                // TODO: cleanup
                var edges = VerticesListToEdgesList(vertices);

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
                    AET.RemoveAll(_ => ((int)_.YMax) == scanLine);

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

                        return (float)(higherX - lowerX) / (float)(YMax - YMin);
                    }
                }
            }
        }

        public static class LambertLightModel
        {
            public static Color GetLambertColor(Color color, Color I_L, Vector3 normalVector, Vector3 lightVector, int m, float k_d, float k_s)
            {
                return Color.FromArgb(
                    ScaleFloatToByte(GetLambertOneComponent(ScaleByteToFloat(color.R), ScaleByteToFloat(I_L.R), normalVector, lightVector, m, k_d, k_s)),
                    ScaleFloatToByte(GetLambertOneComponent(ScaleByteToFloat(color.G), ScaleByteToFloat(I_L.G), normalVector, lightVector, m, k_d, k_s)),
                    ScaleFloatToByte(GetLambertOneComponent(ScaleByteToFloat(color.B), ScaleByteToFloat(I_L.B), normalVector, lightVector, m, k_d, k_s))
                );
            }

            private static float GetLambertOneComponent(float objectColor, float lightColor, Vector3 normalVector, Vector3 lightVector, int m, float k_d, float k_s)
            {
                return GetLambertLightComponent(objectColor, lightColor, normalVector, k_d, lightVector)
                     + GetLambertReflectionComponent(objectColor, lightColor, normalVector, k_s, m, lightVector);
            }

            private static float ScaleByteToFloat(byte b)
            {
                return b / 255f;
            }

            private static byte ScaleFloatToByte(float f)
            {
                return (byte)((f > 1 ? 1 : (f < 0 ? 0 : f)) * 255);
            }

            private static float GetLambertLightComponent(float objectColor, float lightColor, Vector3 normalVector, float k_d, Vector3 lightVector)
            {
                return k_d * objectColor * lightColor * PositiveOrZero(CosAngle(normalVector, lightVector));
            }

            private static float GetLambertReflectionComponent(float objectColor, float lightColor, Vector3 normalVector, float k_s, int m, Vector3 lightVector)
            {
                var reflectionVector = 2 * Vector3.Dot(normalVector, lightVector) * normalVector - lightVector;
                return k_s * objectColor * lightColor * PositiveOrZero((float)Math.Pow(CosAngle(normalVector, reflectionVector), m));
            }

            private static float CosAngle(Vector3 a, Vector3 b)
            {
                return Vector3.Dot(a, b) / a.Length() / b.Length();
            }

            private static float PositiveOrZero(float value)
            {
                return value > 0 ? value : 0;
            }
        }
    }
}
