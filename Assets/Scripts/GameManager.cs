using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject lose;
    [SerializeField] private bool inGame = true;
    [SerializeField] private bool firstFrameLose;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] planets;

    private void Start()
    {
        foreach (GameObject planet in planets)
        {
            planet.GetComponent<SphereCollider>().radius = planet.GetComponent<SphereCollider>().radius + 0.2f;
            if(planet.gameObject.name == "Planet")
            {
                planet.GetComponent<SphereCollider>().radius = 0.02f;
            }
        }
        foreach (GameObject enemy in enemies)
        {
            enemy.AddComponent<EnemySpawner>();
        }
        Time.timeScale = 100;

    }

    private void Update()
    {
        if (inGame)
        {
           if(Input.GetButtonDown("Pause") && Time.timeScale == 1)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                menu.SetActive(true);
                Debug.Log("aparezco");
            }
        }
        else
        {
            Time.timeScale = 0;
            if (firstFrameLose == false)
            {
                firstFrameLose = true;
                lose.SetActive(true);
            }
        }
        
    }

    public void SetInGame(bool inGame)
    {
        this.inGame = inGame;
    }

    public bool GetInGame()
    {
        return inGame;
    }
}
