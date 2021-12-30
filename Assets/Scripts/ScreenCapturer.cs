using System;
using System.IO;
using UnityEngine;

public class ScreenCapturer : MonoBehaviour
{
    [SerializeField] private KeyCode _captureKeyCode = KeyCode.None;

    [SerializeField] private string _fileName = string.Empty;
    [SerializeField] private string _fileExtension = string.Empty;

    private string _path;

    private void Awake()
    {
        _path = Application.persistentDataPath;
        Debug.LogErrorFormat("Path: {0}", _path);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_captureKeyCode)) Capture();
    }

    private void Capture()
    {
        string fileName = string.Format("{0}-{1}", _fileName, DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss"));
        string filePath = Path.Combine(_path, String.Format("{0}.{1}", fileName, _fileExtension));
        ScreenCapture.CaptureScreenshot(filePath);
    }
}
