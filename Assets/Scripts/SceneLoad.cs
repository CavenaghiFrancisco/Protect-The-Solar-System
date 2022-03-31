using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

public class SceneLoad : MonoBehaviour
{
    public static SceneLoad instance;

    [SerializeField] private GameObject loaderCanvas;
    [SerializeField] private Image progressBar;
    private float target;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void LoadScene(int index)
    {
        target = 0;
        progressBar.fillAmount = 0;

        var scene = SceneManager.LoadSceneAsync(index);
        scene.allowSceneActivation = false;

        loaderCanvas.SetActive(true);

        do
        {
            await Task.Delay(100);
            target = scene.progress;
        } while (scene.progress < 0.9f);

        scene.allowSceneActivation = true;
        loaderCanvas.SetActive(false);
    }

    private void Update()
    {
        progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, target, 3 * Time.deltaTime);
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            if (Time.timeScale != 1)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
