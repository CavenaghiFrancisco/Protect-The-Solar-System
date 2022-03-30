using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject menu;
    [SerializeField] private AudioSource click;


   public void Play(int index) 
    {
        click.Play();
        SceneLoad.instance.LoadScene(index);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void Credits()
    {
        click.Play();
        credits.SetActive(true);
        menu.SetActive(false);
    }

    public void ExitCredits()
    {
        click.Play();
        credits.SetActive(false);
        menu.SetActive(true);
    }

    public void QuitGame()
    {
        click.Play();
        Application.Quit();
    }

    
}
