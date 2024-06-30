using UnityEngine;

public class WindowBase : MonoBehaviour, IWindow, IWindowStatus
{
    public string Id { get; private set; }
    public bool IsOpen { get; private set; }

    public virtual void Initialize(string id)
    {
        Id = id;
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
        IsOpen = true;
        Debug.Log($"Window {Id} opened.");
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
        IsOpen = false;
        Debug.Log($"Window {Id} closed.");
    }

    private void OnDestroy()
    {
        Debug.Log($"Window {Id} destroyed.");
    }
}
