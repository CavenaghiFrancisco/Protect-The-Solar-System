using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollsions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Bullet")
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            AudioSource audio = gameObject.transform.GetChild(1).gameObject.GetComponent<AudioSource>();
            Collider col = gameObject.GetComponent<Collider>();
            col.enabled = !col.enabled;
            StartCoroutine(DestroyAfterTime());
        }
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
