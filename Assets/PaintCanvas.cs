using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCanvas : MonoBehaviour
{
    public GameObject paintInit;
    public Texture2D texture;

    //Crates texture for current object
    public void CreateCanvas()
    {
        texture = new Texture2D(paintInit.GetComponent<PaintInit>().textureWidth, 
            paintInit.GetComponent<PaintInit>().textureWidth);
        texture.filterMode = FilterMode.Point;
        paintInit.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", texture);
        paintInit.GetComponent<PaintInit>().texture = texture;

    }

    //Fills canvas with color
    public void Fill(Color color)
    {
        Color[] pixels = texture.GetPixels();
        for (var i = 0; i < pixels.Length; i++)
        {
            pixels[i] = color;
        }
        paintInit.GetComponent<PaintInit>().texture.SetPixels(pixels);
        paintInit.GetComponent<PaintInit>().texture.Apply();
    }


    //Changes sides ratio of current object according 
    //to input width and height
    public void ResizeCanvas(float width, float height)
    {
        float x;
        float y;

        if (width > height)
        {
            y = width / height;
            x = 1;
        }
        else
        {
            y = 1;
            x = height / width;
        }

        Vector3 currentScale = paintInit.transform.localScale;
        currentScale.x *= x;
        currentScale.y *= y;
        paintInit.transform.localScale = currentScale;
    }

}
