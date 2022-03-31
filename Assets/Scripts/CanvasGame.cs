using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasGame : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private AudioSource click;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject[] planets;
    [SerializeField] private Text text;
    [SerializeField] private Button bttn;
    [SerializeField] private GameObject missionObject;
    private float timeToStart = 400f;

    private void Start()
    {
        float t = Time.time;
        StartCoroutine(Countdown(t));
    }

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
        if (Time.timeScale == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        menu.SetActive(!menu.activeSelf);
    }

    public void QuitGame()
    {
        click.Play();
        Application.Quit();
    }

    public void StartGame()
    {
        click.Play();
        foreach (GameObject planet in planets)
        {
            planet.GetComponent<SphereCollider>().radius = planet.GetComponent<SphereCollider>().radius - 0.2f;
            if (planet.gameObject.name == "Planet")
            {
                planet.GetComponent<SphereCollider>().radius = 0.009999f;
            }
        }
        Time.timeScale = 1;
        player.GetComponent<PlayerController>().enabled = true;
        cam.GetComponent<PlayerCamera>().enabled = true;
        gameObject.transform.GetChild(4).gameObject.SetActive(false);
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        missionObject.SetActive(true);

    }

    private IEnumerator Countdown(float t)
    {
        bttn.interactable = false;
        while(timeToStart - (Time.time - t) > 0)
        {
            text.text = ((int)(((timeToStart - (Time.time - t))/100))).ToString();
            yield return null;
        }
        bttn.interactable = true;
        text.text = "Confirm";
        yield return null;
    }
}
