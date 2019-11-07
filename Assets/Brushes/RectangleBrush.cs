using UnityEngine;

namespace Assets
{
    class RectangleBrush : Brush, IFigureDraw 
    {
        public void DrawFigure (int size, Color color)
        {
            colors = new Color[size * size];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = color;
            }

        }
    }
}
