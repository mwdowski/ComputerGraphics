using P3_Coloring.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Coloring.Logic
{
    public class ProgramLogic
    {
        public ProfileColorAttributes? SourceProfile;
        public ProfileColorAttributes? TargetProfile;
        public BindedAttribute<Image?>? SourceImage;
        public BindedAttribute<Image?>? TargetImage;
    }
}
