using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject lose;
    [SerializeField] private bool inGame = true;
    [SerializeField] private bool firstFrameLose;

    private void Update()
    {
        if (inGame)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = Time.timeScale == 0 ? 1 : 0;
                menu.SetActive(!menu.activeSelf);
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
