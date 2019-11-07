using Assets;
using UnityEngine;
using UnityEngine.UI;

public class PaintInit : MonoBehaviour
{
    IFigureDraw figureDraw;
    public Texture2D texture;
    public int textureWidth = 50;
    public int textureHeight = 50;
    public int brushSize;
    public Color brushColor = Color.green;
    public Color backgroundColor = Color.white;
    public Slider slider;
    public ColorPicker picker;

    private void Start()
    {
        texture = GetComponent<PaintCanvas>().texture;
        GetComponent<PaintCanvas>().CreateCanvas();
        GetComponent<PaintCanvas>().ResizeCanvas(textureWidth, textureHeight);
        GetComponent<PaintCanvas>().Fill(backgroundColor);

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

    }

    //Was trying to change brushSize by using OnValueChange,
    //but can't because of bug (not displaying dynamic floats)
    public void ChangeSlider(Slider slider)
    {
        if (texture.width > texture.height)
        {
            slider.maxValue = texture.height;
        }
        else
        {
            slider.maxValue = texture.width;
        }
        brushSize = Mathf.RoundToInt(slider.value);
    }

    //Translates uv texture units into pixels
    Vector2Int uv2PixelCoords (Vector2 uv)
    {
        int x = Mathf.FloorToInt(uv.x * texture.width);
        int y = Mathf.FloorToInt(uv.y * texture.height);
        return new Vector2Int(x, y);
    }

    //Creates a set of pixels at asigned coords
    void Painter (Vector2Int pixelCoords, Color color)
    {
        figureDraw = new RectangleBrush();
        figureDraw.DrawFigure(Mathf.FloorToInt(brushSize), color);
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

  
}

