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
            { ClickMode.Default, ("Default", new string[] {
                "Left click on vertex - start dragging vertex",
                "Right click on edge - open edge context menu"})},
            { ClickMode.AddPolygon, ("Add new polygon", new string[] {
                "Left click - start creating polygon",
                "Right click - abort creating polygon" })},
            { ClickMode.DeletePolygon, ("Delete polygon", new string[] {
                "Left click - choosing polygon to delete",
                "Right click - abort deleting polygon" })},
            { ClickMode.CreatingPolygon, ("Creating new polygon", new string[] {
                "Left click on starting vertex - finish creating polygon",
                "Left click - add another vertex",
                "Right click - abort creating polygon"})}
        };

        public static string GetModeName(ClickMode clickMode) => dict[clickMode].name;
        public static string[] GetModeControlDescription(ClickMode clickMode) => dict[clickMode].controls;
    }
}
