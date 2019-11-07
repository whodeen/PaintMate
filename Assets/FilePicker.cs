using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

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
            paintCanvas.GetComponent<Paint>().ResizeCanvas(texture.height, texture.width);
            paintCanvas.GetComponent<Paint>().texture = texture;
            paintCanvas.GetComponent<Paint>().brushSize *= texture.height;
        }
    }

    void LoadImage()
    {
        WWW www = new WWW("file://" + path);
        texture = www.texture;
    }
}
