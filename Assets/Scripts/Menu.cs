using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject solarSystem;
    [SerializeField] private AudioSource click;


   public void Play() 
    {
        click.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex == 0 ? 1 : 0);
    }

    public void Credits()
    {
        click.Play();
        credits.SetActive(true);
        menu.SetActive(false);
        solarSystem.SetActive(false);
    }

    public void ExitCredits()
    {
        click.Play();
        credits.SetActive(false);
        menu.SetActive(true);
        solarSystem.SetActive(true);
    }

    public void QuitGame()
    {
        click.Play();
        Application.Quit();
    }

    
}
