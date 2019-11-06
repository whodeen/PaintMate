using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    class CircleBrush : Brush, IFigureDraw
    {
        public void DrawFigure(int size, Color color)
        {
            //int center = Mathf.FloorToInt(size / 2);
            //int radius = size / 2;
            //colors = new Color[size * size];
            //for (int i = 0; i < colors.Length; i++)
            //{
            //    int y = Mathf.FloorToInt(i / size);
            //    int x = Mathf.FloorToInt(i % size);
            //    Debug.Log("x:" + x + "y:" + y);
            //    float circleFunctionResult = (float)(Math.Pow(x - center, 2) + Math.Pow((y - center), 2));
            //    if (circleFunctionResult > (Math.Pow(radius, 2)))
            //    {
            //        colors[i] = Color.blue;
            //    }
            //    else
            //    {
            //        colors[i] = Color.red;
            //    }

            //}

        }
    }
}
