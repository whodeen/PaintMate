using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FilePicker : MonoBehaviour
{
    string path;
    public RawImage image;
    public TextAsset imageAsset;
    public GameObject paintCanvas;
    public Texture2D texture;

    public void Open()
    {
        path = EditorUtility.OpenFilePanel("Load file", "", "png");
        Debug.Log(path);
        if (path.Length != 0)
        {
            LoadImage();
            paintCanvas.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", texture);
            paintCanvas.GetComponent<PaintCanvas>().ResizeCanvas(texture.height, texture.width);
            paintCanvas.GetComponent<PaintInit>().texture = texture;
            paintCanvas.GetComponent<PaintInit>().brushSize *= texture.height;
        }
    }

    void LoadImage()
    {
        WWW www = new WWW("file://" + path);
        texture = www.texture;
    }
}
