using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBase : MonoBehaviour
{
    protected Button button;
    protected WindowController windowController;
    protected virtual void Awake()
    {
        button = GetComponent<Button>();
        if (button == null)
        {
            Debug.LogError("Button component is missing on this GameObject.");
        }

        button.onClick.AddListener(OnButtonClick);

        windowController = FindObjectOfType<WindowController>();
        if (windowController == null)
        {
            Debug.LogError("WindowController not found in the scene.");
        }
    }

    protected abstract void OnButtonClick();
}
