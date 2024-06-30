using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSceneButton : OpenWindowButton
{
    protected override void OnButtonClick()
    {
        windowController.CloseAllWindows();
        base.OnButtonClick();
        
    }
}
