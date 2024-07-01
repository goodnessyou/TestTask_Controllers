using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenSetup : MonoBehaviour
{
    public Slider progressBar; // Ссылка на UI компонент прогресс-бара
    public TMP_Text progressText; // Ссылка на UI компонент текста для отображения прогресса
    

    private void Start()
    {
        LoadSceneController controller = LoadSceneController.Instance;
        if (controller != null)
        {
            controller.progressBar = progressBar;
            controller.progressText = progressText;
        }
    }
}
