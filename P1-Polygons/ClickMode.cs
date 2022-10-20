using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons
{
    public enum ClickModes
    {
        Default, AddPolygon, DeletePolygon, AddingPolygon, MovingFigure
    }

    public static class ClickModeText
    {
        private static Dictionary<ClickModes, (string name, string[] controls)> dict = new Dictionary<ClickModes, (string name, string[] controls)>
        {
            { ClickModes.Default, ("Default", new string[] {
                "Left click on vertex - start dragging vertex",
                "Left click on edge - start dragging edge",
                "Right click on edge - open edge context menu",
                "Middle click on edge or vertex - start moving polygon"})},
            { ClickModes.AddPolygon, ("Add new polygon", new string[] {
                "Left click - start creating polygon",
                "Right click - abort creating polygon" })},
            { ClickModes.DeletePolygon, ("Delete polygon", new string[] {
                "Left click - choosing polygon to delete",
                "Right click - abort deleting polygon" })},
            { ClickModes.AddingPolygon, ("Adding new polygon", new string[] {
                "Left click on starting vertex - finish creating polygon",
                "Left click - add another vertex",
                "Right click - abort creating polygon"})},
            { ClickModes.MovingFigure, ("Moving figure", new string[] {
                "Release click - finish moving"})}
        };

        public static string GetModeName(ClickModes clickMode) => dict[clickMode].name;
        public static string[] GetModeControlDescription(ClickModes clickMode) => dict[clickMode].controls;
    }
}
