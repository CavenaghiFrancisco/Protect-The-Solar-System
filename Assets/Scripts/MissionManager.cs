using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    [SerializeField] private List<LineRenderer> lrs;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject currentPlanetMission;
    [SerializeField] private GameObject[] asteroids;
    [SerializeField] private List<GameObject> planets;
    [SerializeField] private Text text;
    [SerializeField] private GameObject textBox;
    [SerializeField] private Text missionText;
    [SerializeField] private GameObject missionBox;
    [SerializeField] private int aliensDestroyed;
    [SerializeField] private int asteroidsDestroyed;
    [SerializeField] private int objective;
    [SerializeField] private List<GameObject> firstAsteroidsToDestroy;
    [SerializeField] private List<GameObject> secondAsteroidsToDestroy;
    [SerializeField] private List<GameObject> asteroidsToDestroy;
    [SerializeField] private List<GameObject> aliensToDestroy;
    [SerializeField] private int typeOfMission; //0 is asteroid mission, 1 is planet mission
    [SerializeField] private List<AudioSource> audios;
    [SerializeField] private int timeLapse;
    [SerializeField] private GameObject highscore;

    void Start()
    {
        StartCoroutine(StartSimulation());
    }

   

    private void UpdateGuideBeam(Vector3 v1, Vector3 v2)
    {
        lrs[0].SetPosition(0, v1);
        lrs[0].SetPosition(1, v2);
        lrs[1].SetPosition(0, v1);
        lrs[1].SetPosition(1, v2);
        lrs[2].SetPosition(0, v1);
        lrs[2].SetPosition(1, v2);
    }

    private void UpdateGuideBeam(GameObject currentPlanetMission)
    {
        UpdateGuideBeam(Vector3.zero, Vector3.zero);
        lrs[0].SetPosition(0, player.transform.GetChild(0).transform.GetChild(transform.childCount).transform.position);
        lrs[0].SetPosition(1, currentPlanetMission.transform.position);
    }

    private void UpdateGuideBeam(List<GameObject> asteroids)
    {
        UpdateGuideBeam(Vector3.zero, Vector3.zero);
        for (int i = 0; i < asteroids.Count; i++)
        {
            lrs[i].SetPosition(0, player.transform.GetChild(0).transform.GetChild(transform.childCount).transform.position);
            lrs[i].SetPosition(1, asteroids[i].transform.position);
        }
    }

    private IEnumerator StartSimulation()
    {
        float t1 = Time.time;
        yield return new WaitForSeconds(2);
        yield return PlayAudio(0);
        yield return AsteroidMission(0);
        UpdateGuideBeam(Vector3.zero, Vector3.zero);
        yield return PlayAudio(1);
        yield return AliensMission(planets[4],1);
        UpdateGuideBeam(Vector3.zero, Vector3.zero);
        yield return PlayAudio(2);
        yield return AsteroidMission(2);
        UpdateGuideBeam(Vector3.zero, Vector3.zero);
        yield return PlayAudio(3);
        yield return AliensMission(planets[7], 3);
        UpdateGuideBeam(Vector3.zero, Vector3.zero);
        yield return new WaitForSeconds(2f);
        float t2 = Time.time;
        timeLapse = (int)t2 - (int)t1;
        player.SetActive(false);
        textBox.SetActive(false);
        missionBox.SetActive(false);
        highscore.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private IEnumerator AsteroidMission(int numberOfMission)
    {
        textBox.SetActive(false);
        if (numberOfMission == 0)
        {
            missionBox.SetActive(true);
            asteroidsToDestroy = firstAsteroidsToDestroy;
        }
        else
        {
            asteroidsToDestroy = secondAsteroidsToDestroy;
        }
        asteroidsDestroyed = 0;
        while (asteroidsDestroyed < objective)
        {
            UpdateGuideBeam(asteroidsToDestroy);
            foreach (GameObject asteroid in asteroidsToDestroy)
            {
                if (asteroid.activeSelf == false)
                {
                    asteroidsToDestroy.Remove(asteroid);
                    asteroidsDestroyed += 1;
                    break;
                }
            }
            missionBox.GetComponent<Image>().color = Color.red;
            missionText.text = "";
            missionText.text = "Destroy\nthe\nasteroids\n( " + asteroidsDestroyed + " / 3 )";
            UpdateGuideBeam(asteroidsToDestroy);
            yield return null;
        }
        missionBox.GetComponent<Image>().color = Color.green;
        missionText.text = "";
        missionText.text = "Destroy\nthe\nasteroids\n( " + asteroidsDestroyed + " / 3 )";
        UpdateGuideBeam(asteroidsToDestroy);
        yield return null;
    }

    private IEnumerator AliensMission(GameObject planet, int numberOfMission)
    {
        textBox.SetActive(false);
        if (numberOfMission == 1)
        {
            planets[4].transform.GetChild(2).gameObject.SetActive(true);
            planets[4].transform.GetChild(3).gameObject.SetActive(true);
            planets[4].transform.GetChild(4).gameObject.SetActive(true);
            aliensToDestroy.Add(planets[4].transform.GetChild(2).gameObject);
            aliensToDestroy.Add(planets[4].transform.GetChild(3).gameObject);
            aliensToDestroy.Add(planets[4].transform.GetChild(4).gameObject);
        }
        else
        {
            planets[7].transform.GetChild(3).gameObject.SetActive(true);
            planets[7].transform.GetChild(4).gameObject.SetActive(true);
            planets[7].transform.GetChild(5).gameObject.SetActive(true);
            aliensToDestroy.Add(planets[7].transform.GetChild(3).gameObject);
            aliensToDestroy.Add(planets[7].transform.GetChild(4).gameObject);
            aliensToDestroy.Add(planets[7].transform.GetChild(5).gameObject);
        }
        aliensDestroyed = 0;
        while (aliensDestroyed < objective)
        {
            UpdateGuideBeam(planet);
            foreach(GameObject alien in aliensToDestroy)
            {
                if(alien.activeSelf == false)
                {
                    aliensToDestroy.Remove(alien);
                    aliensDestroyed += 1;
                    break;
                }
            }
            missionBox.GetComponent<Image>().color = Color.red;
            missionText.text = "";
            missionText.text = "Destroy\nthe\naliens\n( " + aliensDestroyed + " / 3 )";
            UpdateGuideBeam(planet);
            yield return null;
        }
        missionBox.GetComponent<Image>().color = Color.green;
        missionText.text = "";
        missionText.text = "Destroy\nthe\naliens\n( " + aliensDestroyed + " / 3 )";
        UpdateGuideBeam(planet);
        yield return null;
    }

    private IEnumerator PlayAudio(int numOfMission)
    {
        switch (numOfMission)
        {
            case 0:
                audios[0].Play();
                textBox.SetActive(true);
                text.text = "";
                text.text = "Destroy the asteroids that threaten the planet Neptune";
                break;
            case 1:
                audios[1].Play();
                textBox.SetActive(true);
                text.text = "";
                text.text = "The aliens are attacking the planet Earth. Finish them off";
                break;
            case 2:
                audios[2].Play();
                textBox.SetActive(true);
                text.text = "";
                text.text = "Destroy the asteroids that threaten the planet Earth";
                break;
            case 3:
                audios[3].Play();
                textBox.SetActive(true);
                text.text = "";
                text.text = "The aliens are attacking the planet Saturn. Finish them off";
                break;
        }
        yield return new WaitForSeconds(2f);

    }

    public int GetScore()
    {
        return timeLapse;
    }
}
