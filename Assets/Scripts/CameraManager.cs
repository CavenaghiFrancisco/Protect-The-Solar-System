using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]GameObject[] cameras;
    [SerializeField] int currentCamera;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        currentCamera = 0;
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
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentCamera++;
            if (currentCamera > cameras.Length-1)
            {
                currentCamera = 0;
            }
            ActiveCamera();
        }
    }

    void ActiveCamera()
    {
        foreach (GameObject camera in cameras)
        {
            camera.SetActive(false);
            cameras[currentCamera].SetActive(true);
            if(currentCamera != 0)
            {
                player.SetActive(false);
            }
            else
            {
                player.SetActive(true);
            }
        }
    }
}
