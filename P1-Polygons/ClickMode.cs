using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Polygons
{
    public enum ClickModes
    {
        Default, AddPolygon, DeletePolygon, AddingPolygon, MovingFigure, SelectingPerpendicularEdge, AddCircle, AddingCircle, DeleteCircle, ResizeCircle
    }

    public static class ClickModeText
    {
        private static Dictionary<ClickModes, (string name, string[] controls)> dict = new Dictionary<ClickModes, (string name, string[] controls)>
        {
            { ClickModes.Default, ("Default", new string[] {
                "Left click on vertex - start dragging vertex",
                "Left click on edge - start dragging edge",
                "Left click on circle - resize circle",
                "Right click on figure - open figure context menu",
                "Middle click on edge or vertex or circle - start moving polygon or circle"})},
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
                "Release click - finish moving"})},
            { ClickModes.SelectingPerpendicularEdge, ("Selecting other edge", new string[] {
                "Left click on edge - Connect selected edges with perpendicularity restriction",
                "Right click - abort selecting edge"})},
            { ClickModes.AddCircle, ("Add new circle", new string[] {
                "Left click - choose circle center",
                "Right click - abort crearting circle"})},
            { ClickModes.AddingCircle, ("Adding circle", new string[] {
                "Left click - choose circle radius",
                "Right click - abort crearting circle"})},
            { ClickModes.DeleteCircle, ("Delete circle", new string[] {
                "Left click on circle edge - choosing circle to delete",
                "Right click - abort deleting circle"})},
            { ClickModes.ResizeCircle, ("Resize circle", new string[] {
                "Drag - resize circle"})},
        };

        public static string GetModeName(ClickModes clickMode) => dict[clickMode].name;
        public static string[] GetModeControlDescription(ClickModes clickMode) => dict[clickMode].controls;
    }
}
