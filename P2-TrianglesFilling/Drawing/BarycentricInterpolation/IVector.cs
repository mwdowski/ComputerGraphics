using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Drawing.BarycentricInterpolation
{
    public interface IVectorOperationsExecutor<TField, TVector>
    {
        TVector Scale(TVector vector, TField field);
        TVector Add(TVector vector1, TVector vector2);
    }
}
