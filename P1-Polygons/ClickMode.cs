using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons
{
    public enum ClickMode
    {
        Default, AddPolygon, DeletePolygon, CreatingPolygon
    }

    public static class ClickModeText
    {
        private static Dictionary<ClickMode, (string name, string[] controls)> dict = new Dictionary<ClickMode, (string name, string[] controls)>
        {
            { ClickMode.Default, ("Default", new string[]{ "D" }) },
            { ClickMode.AddPolygon, ("Add new polygon", new string[] {
                "Left mouse click - start creating polygon",
                "Right mouse click - abort creating polygon" })},
            { ClickMode.DeletePolygon, ("Delete polygon", new string[] {
                "Left mouse click - choosing polygon to delete",
                "Right mouse click - abort deleting polygon" })},
            { ClickMode.CreatingPolygon, ("Creating new polygon", new string[] {
                "Left mouse click on starting vertex - finish creating polygon",
                "Left mouse click - add another vertex",
                "Right mouse click - abort creating polygon"})}
        };

        public static string GetModeName(ClickMode clickMode) => dict[clickMode].name;
        public static string[] GetModeControlDescription(ClickMode clickMode) => dict[clickMode].controls;
    }
}
