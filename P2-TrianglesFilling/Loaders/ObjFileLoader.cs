using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjLoader.Loader.Loaders;
using P2_TrianglesFilling.Model;
using System.Numerics;

namespace P2_TrianglesFilling.Loaders
{
    public class ObjFileLoader : IFileFigureLoader
    {
        private ObjLoaderFactory _objLoaderFactory;

        public ObjFileLoader()
        {
            _objLoaderFactory = new ObjLoaderFactory();
        }

        public Figure? LoadFigureFromFile(string filename)
        {
            var _loader = _objLoaderFactory.Create();
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                var loadResult = _loader.Load(stream);

                if (loadResult == null) return null;
                if (loadResult.Groups.Count < 1) return null;

                var group = loadResult.Groups[0];
                var polygonSet = new PolygonSetWithNormals();

                foreach (var vertex in loadResult.Vertices)
                {
                    var newVertex = new Vertex(new Vector3(vertex.X, vertex.Y, vertex.Z));
                    polygonSet.Vertices.Add(newVertex);
                }

                foreach (var normal in loadResult.Normals)
                {
                    var newNormal = new Vertex(new Vector3(normal.X, normal.Y, normal.Z));
                    polygonSet.Normals.Add(newNormal);
                }

                foreach (var face in group.Faces)
                {
                    var newPolygon = new PolygonWithNormals();

                    for (int i = 0; i < face.Count; i++)
                    {
                        var faceVertex = face[i];

                        newPolygon.Vertices.Add(polygonSet.Vertices[faceVertex.VertexIndex - 1]);
                        newPolygon.Normals.Add(polygonSet.Normals[faceVertex.NormalIndex - 1]);
                    }

                    polygonSet.Polygons.Add(newPolygon);
                }

                return polygonSet;
            }
        }
    }
}
