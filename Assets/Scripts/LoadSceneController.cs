using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class LoadSceneController : MonoBehaviour
{
    public static LoadSceneController Instance;

    public Slider progressBar; // Ссылка на UI компонент прогресс-бара
    public TMP_Text progressText; // Ссылка на UI компонент текста для отображения прогресса

    private string targetSceneName;
    private const float minLoadingTime = 3.0f;
    private LoadingUIController loadingUIController;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Если это первая сцена, загружаем Menu
        if (SceneManager.GetActiveScene().name == "LoadingScene")
        {
            LoadScene("MenuScene");
        }
    }

    // Метод для загрузки сцены по имени
    public void LoadScene(string sceneName)
    {
        targetSceneName = sceneName;
        StartCoroutine(LoadLoadingScene());
    }

    // Загрузка сцены Loading
    private IEnumerator LoadLoadingScene()
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync("LoadingScene");
        while (!loadingOperation.isDone)
        {
            yield return null;
        }

        // Найти и установить LoadingUIController
        loadingUIController = FindObjectOfType<LoadingUIController>();
        if (loadingUIController != null)
        {
            loadingUIController.SetActive(true);
        }

        // Начать загрузку целевой сцены
        StartCoroutine(LoadTargetSceneAsync());
    }

    // Асинхронная загрузка целевой сцены
    private IEnumerator LoadTargetSceneAsync()
    {
        float startTime = Time.time;

        AsyncOperation operation = SceneManager.LoadSceneAsync(targetSceneName);
        operation.allowSceneActivation = false;

        // Пока сцена не загружена, обновляем прогресс
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            UpdateProgress(progress);

            // Проверяем, выполнены ли условия для завершения загрузки
            if (operation.progress >= 0.9f && Time.time - startTime >= minLoadingTime)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }

        if (loadingUIController != null)
        {
            loadingUIController.SetActive(false);
        }
    }

    // Метод для обновления прогресса на UI
    private void UpdateProgress(float progress)
    {
        if (loadingUIController != null)
        {
            loadingUIController.UpdateProgress(progress);
        }
    }
}