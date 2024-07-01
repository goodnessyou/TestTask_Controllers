using UnityEngine;

public class OpenSceneButton : ButtonBase
{
    private LoadSceneController loadSceneController;
    [SerializeField] private string targetScene;

    protected override void Awake()
    {
        base.Awake();
        loadSceneController = FindObjectOfType<LoadSceneController>();
        if (loadSceneController == null)
        {
            Debug.LogError("LoadSceneController not found in the scene.");
        }
    } 
    protected override void OnButtonClick()
    {
        loadSceneController.LoadScene(targetScene);
    }
}
