using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private Material mat;
    [SerializeField]private bool appeared;
    [SerializeField] private bool shipSpawned;

    private void Start()
    {
        mat = gameObject.GetComponent<MeshRenderer>().material;
        mat.SetFloat("Dissolve", 2);
        appeared = false;
        shipSpawned = false;
    }

    private void Update()
    {

        if (mat.GetFloat("Dissolve") >= -0.3 && !appeared)
        {
            mat.SetFloat("Dissolve", mat.GetFloat("Dissolve") - Time.deltaTime * 0.2f);
        }
        else if ((mat.GetFloat("Dissolve") <= -0.3 || appeared) && mat.GetFloat("Dissolve") <= 1)
        {
            appeared = true;
            if (!shipSpawned)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            shipSpawned = true;
            mat.SetFloat("Dissolve", mat.GetFloat("Dissolve") + Time.deltaTime * 0.2f);
        }
    }


}
