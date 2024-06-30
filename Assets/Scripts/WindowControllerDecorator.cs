using System;
using UnityEngine;

public abstract class WindowControllerDecorator : IWindowController
{
    protected IWindowController _decoratedWindowController;

    public WindowControllerDecorator(IWindowController decoratedWindowController)
    {
        _decoratedWindowController = decoratedWindowController;
    }

    public virtual void OpenWindow(GameObject windowPrefab)
    {
        _decoratedWindowController.OpenWindow(windowPrefab);
    }

    public virtual void CloseWindow()
    {
        _decoratedWindowController.CloseWindow();
    }

    public event Action<IWindow> OnWindowOpened
    {
        add { _decoratedWindowController.OnWindowOpened += value; }
        remove { _decoratedWindowController.OnWindowOpened -= value; }
    }

    public event Action<IWindow> OnWindowClosed
    {
        add { _decoratedWindowController.OnWindowClosed += value; }
        remove { _decoratedWindowController.OnWindowClosed -= value; }
    }
}