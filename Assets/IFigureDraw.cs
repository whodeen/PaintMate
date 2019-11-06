using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    interface IFigureDraw
    {
        void DrawFigure(int size, Color color);
        Color[] GetColors();
    }
}
