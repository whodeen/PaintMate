using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class FileSaver : MonoBehaviour
{
    string path;
    public GameObject canvas;

    public void Save()
    {
        var texture = canvas.GetComponent<Paint>().texture;
        var bytes = texture.EncodeToPNG();
        path = EditorUtility.SaveFilePanel("Save file", "", "My texture", "png");

        if (path.Length > 0)
        {
            File.WriteAllBytes(path, bytes);
        }
    }
}
