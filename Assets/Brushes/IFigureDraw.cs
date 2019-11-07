using UnityEngine;

namespace Assets
{
    interface IFigureDraw
    {
        void DrawFigure(int size, Color color);
        Color[] GetColors();
    }
}
