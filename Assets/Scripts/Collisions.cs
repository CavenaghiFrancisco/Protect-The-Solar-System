using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        if(collision.gameObject.tag == "Bullet")
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            Collider col = gameObject.GetComponent<Collider>();
            audio.enabled = !audio.enabled;
            col.enabled = !col.enabled;
        }
        StartCoroutine(DestroyAfterTime());
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
