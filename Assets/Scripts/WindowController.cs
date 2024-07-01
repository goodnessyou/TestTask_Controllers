using System;
using System.Collections.Generic;
using UnityEngine;


public class WindowController : MonoBehaviour, IWindowController
{
    private Stack<IWindow> windowStack = new Stack<IWindow>();
    public event Action<IWindow> OnWindowOpened;
    public event Action<IWindow> OnWindowClosed;
    
    [SerializeField] private GameObject startWindowPrefab;

    private void Start() 
    {
        OpenWindow(startWindowPrefab);
    }

    public void OpenWindow(GameObject windowPrefab)
    {
        if (windowStack.Count > 0)
        {
            windowStack.Peek().Close();
        }

        var windowInstance = Instantiate(windowPrefab).GetComponent<IWindow>();
        if (windowInstance == null)
        {
            Debug.LogError("The window prefab does not contain a component that implements IWindow.");
            return;
        }
        windowInstance.Initialize(windowPrefab.name);
        windowInstance.Open();
        windowStack.Push(windowInstance);
        OnWindowOpened?.Invoke(windowInstance);
    }

    public void CloseWindow()
    {
        if (windowStack.Count > 0)
        {
            var window = windowStack.Pop();
            window.Close();
            Destroy(((MonoBehaviour)window).gameObject);
            OnWindowClosed?.Invoke(window);

            if (windowStack.Count > 0)
            {
                windowStack.Peek().Open();
            }
        }
    }
}
