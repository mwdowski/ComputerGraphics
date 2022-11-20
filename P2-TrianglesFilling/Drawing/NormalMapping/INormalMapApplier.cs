using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Drawing.NormalMapping
{
    public interface INormalMapApplier
    {
        Vector3 MapNormal(Vector3 normal, int x, int y);
    }
}
