using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using SFB;

public class FileSaver : MonoBehaviour
{
    string path;
    public GameObject canvas;

    public void Save()
    {
        var texture = canvas.GetComponent<PaintInit>().texture;
        var bytes = texture.EncodeToPNG();
        path = StandaloneFileBrowser.SaveFilePanel("Save file", "", "My texture", "png");

        if (path.Length > 0)
        {
            File.WriteAllBytes(path, bytes);
        }
    }
}
