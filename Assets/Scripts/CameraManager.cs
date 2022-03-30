using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject[] cameras;
    [SerializeField] private int currentCamera;
    [SerializeField] private GameObject player;
    [SerializeField] private Text text;
    [SerializeField] private GameObject staticVideo;
    [SerializeField] private float seconds;
    [SerializeField] private bool startSeconds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentCamera--;
            if(currentCamera < 0)
            {
                currentCamera = cameras.Length-1;
            }
            ActiveCamera();
            startSeconds = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentCamera++;
            if (currentCamera > cameras.Length-1)
            {
                currentCamera = 0;
            }
            ActiveCamera();
            startSeconds = true;
        }
        if (startSeconds)
        {
            seconds += Time.deltaTime;
        }
        if(seconds > 0.2)
        {
            staticVideo.SetActive(false);
            startSeconds = false;
            seconds = 0;
        }
    }

    void ActiveCamera()
    {
        staticVideo.SetActive(true);
        foreach (GameObject camera in cameras)
        {
            camera.SetActive(false);
            cameras[currentCamera].SetActive(true);
            if(currentCamera != 0)
            {
                player.GetComponent<PlayerController>().enabled = false;
            }
            else
            {
                player.GetComponent<PlayerController>().enabled = true;
            }
        }
        switch (currentCamera)
        {
            case 0:
                text.text = "Player큦 View";
                break;
            case 1:
                text.text = "Mercury큦 View";
                break;
            case 2:
                text.text = "Venus큦 View";
                break;
            case 3:
                text.text = "Earth큦 View";
                break;
            case 4:
                text.text = "Mars큦 View";
                break;
            case 5:
                text.text = "Jupiter큦 View";
                break;
            case 6:
                text.text = "Saturn큦 View";
                break;
            case 7:
                text.text = "Uranus큦 View";
                break;
            case 8:
                text.text = "Neptune큦 View";
                break;
        }
    }
   
}
