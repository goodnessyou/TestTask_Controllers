using System;
using UnityEngine;

public interface IWindowController
{
    void OpenWindow(GameObject windowPrefab);
    void CloseWindow();
    event Action<IWindow> OnWindowOpened;
    event Action<IWindow> OnWindowClosed;
}
