using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paint : MonoBehaviour
{
    Texture2D texture;
    IFigureDraw figureDraw;
    public int textureWidth = 50;
    public int textureHeight = 50;
    public int brushSize = 10;
    public Color brushColor = Color.green;
    public Color backgroundColor = Color.white;
    public Slider slider;
    public ColorPicker picker;

    public void ChangeSlider(Slider slider)
    {
        brushSize = Mathf.RoundToInt(slider.value);
    }

    public void CreateCanvas()
    {
        texture = new Texture2D(textureWidth, textureHeight);
        texture.filterMode = FilterMode.Point;
        GetComponent<MeshRenderer>().material.SetTexture("_MainTex", texture);
    }

    public void UploadCanvas()
    {

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
        figureDraw = new RectangleBrush();
        figureDraw.DrawFigure(brushSize, color);
        int width = (int)Mathf.Sqrt(brushSize);
        int height = width;
        texture.SetPixels(pixelCoords.x, pixelCoords.y, width, height, figureDraw.GetColors());
        texture.Apply();
    }

    //Paints on ray-collided object
    void WhileMousePressed()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            var pixelCoords = uv2PixelCoords(hitInfo.textureCoord);
            Painter(pixelCoords, brushColor);
        }
    }

    private void Start()
    {
        CreateCanvas();
        ResizeCanvas(textureWidth, textureHeight);
        Fill(backgroundColor);

        picker.onValueChanged.AddListener(color =>
        {
            brushColor = color;
            Debug.Log(color);
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            WhileMousePressed();
        }

        //Was trying to change brushSize by using OnValueChange,
        //but can't because of bug (not displaying dynamic floats)
        brushSize = Mathf.RoundToInt(slider.value);
    }

}

