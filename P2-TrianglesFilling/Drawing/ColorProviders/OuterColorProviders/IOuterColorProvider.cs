using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Drawing.ColorProviders.OuterColorProviders
{
    public interface IOuterColorProvider : IColorProvider
    {
        void SetInnerColorProvider(IColorProvider colorProvider);
    }
}
