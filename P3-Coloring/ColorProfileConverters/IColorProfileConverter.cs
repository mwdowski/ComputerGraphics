using P3_Coloring.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Coloring.ColorProfileConverter 
{
    public interface IColorProfileConverter
    {
        Image Convert(Image image, ProfileColorAttributes sourceProfile, ProfileColorAttributes targetProfile);
    }
}
