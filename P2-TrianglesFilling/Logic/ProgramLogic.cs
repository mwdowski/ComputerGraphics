using ObjLoader.Loader.Loaders;
using P2_TrianglesFilling.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Logic
{
    public class ProgramLogic
    {
        public IFileFigureLoader FigureLoader { get; private set; }

        public ProgramLogic()
        {
            FigureLoader = new ObjFileLoader();
        }
    }
}
