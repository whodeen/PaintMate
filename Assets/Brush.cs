﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush
{
    public Color[] colors;
    public int Size { get; set; }

    public Color[] GetColors()
    {
        return this.colors;
    }
}
