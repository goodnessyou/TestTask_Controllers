using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingUIController : MonoBehaviour
{
    public Slider progressBar; // Ссылка на UI компонент прогресс-бара
    public TMP_Text progressText; // Ссылка на UI компонент текста для отображения прогресса

    public void UpdateProgress(float progress)
    {
        if (progressBar != null)
        {
            progressBar.value = progress;
        }

        if (progressText != null)
        {
            progressText.text = (progress * 100f).ToString("F0") + "%";
        }
    }

    public void SetActive(bool active)
    {
        if (progressBar != null)
        {
            progressBar.gameObject.SetActive(active);
        }
    }
}
