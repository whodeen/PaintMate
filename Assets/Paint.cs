using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
    public int textureWidth = 20;
    public int textureHeight = 20;

    public Color paintColor = Color.green;
    public Color backgroundColor = Color.white;

    Texture2D texture;

  
    //Paints on ray-collided object
    void WhileMousePressed()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            var pixelCoords = uv2PixelCoords(hitInfo.textureCoord);
            Painter(pixelCoords, paintColor);
        }
    }

    //
    //Summary:
    //Changes sides ratio of current object according 
    //to input width and height
    //
    void ResizeCanvas(float width, float height)
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

        Vector3 currentScale = this.transform.localScale;
        currentScale.x *= x;
        currentScale.y *= y;
        this.transform.localScale = currentScale;
    }

    Vector2Int uv2PixelCoords (Vector2 uv)
    {
        int x = Mathf.FloorToInt(uv.x * texture.width);
        int y = Mathf.FloorToInt(uv.y * texture.height);
        return new Vector2Int(x, y);
    }

    void Painter (Vector2Int pixelCoords, Color color)
    {
            texture.SetPixel(pixelCoords.x, pixelCoords.y,  paintColor);
            texture.Apply();
        
    }
    
    void CreateTexture() {
        texture = new Texture2D(textureWidth, textureHeight);
        texture.filterMode = FilterMode.Point;
        GetComponent<MeshRenderer>().material.SetTexture("_MainTex", texture);
    }

    void Fill(Color color)
    {
        Color[] pixels = texture.GetPixels();
        for (var i = 0; i < pixels.Length; i++)
        {
            pixels[i] = color;
        }
        texture.SetPixels(pixels);
        texture.Apply();
    }

    private void Start()
    {
        CreateTexture();
        ResizeCanvas(textureWidth, textureHeight);
        Fill(backgroundColor);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            WhileMousePressed();
        }
    }

}

