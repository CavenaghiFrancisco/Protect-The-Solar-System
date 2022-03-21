using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MPause : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private AudioSource click;

    public void ReturnToMenu()
    {
        click.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void Pause()
    {
        click.Play();
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        menu.SetActive(!menu.activeSelf);
    }

    public void QuitGame()
    {
        click.Play();
        Application.Quit();
    }
}
