using P2_TrianglesFilling.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Loaders
{
    public interface IFileFigureLoader
    {
        Figure? LoadFigureFromFile(string filename);
    }
}
