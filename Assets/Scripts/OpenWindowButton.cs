using UnityEngine;

public class OpenWindowButton : ButtonBase
{
    [SerializeField] protected GameObject targetWindowPrefab;


    protected override void OnButtonClick()
    {
        
        if (targetWindowPrefab != null)
        {
            windowController.OpenWindow(targetWindowPrefab);
        }
        else
        {
            Debug.LogError("Window prefab is not assigned.");
        }
    }
}
