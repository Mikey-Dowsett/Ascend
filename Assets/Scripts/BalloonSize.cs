using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSize : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] ParticleSystem partSystem;
    [SerializeField] SpriteRenderer sr;

    [SerializeField] AudioClip[] sizeSounds;

    void Start(){
        if(FindObjectOfType<Settings>().sound == false)
            audioSource.enabled = false;
    }

    //Checks for when the coin hits the balloon
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Balloon") || col.CompareTag("Player"))
        {
            //Plays random coin sound
            audioSource.clip = sizeSounds[Random.Range(0, sizeSounds.Length - 1)];
            audioSource.pitch = 1 + Random.Range(-0.1f, 0.1f);
            if (audioSource.enabled) audioSource.Play();
            partSystem.Play();
            GameObject.FindObjectOfType<Score>().AddCoin();
            GetComponent<CircleCollider2D>().enabled = false;
            FindObjectOfType<Player>().StartCoroutine("SizeUpgrade");
            StartCoroutine("DeathCounter");
        }
    }

    //Makes the coin invisable and destorys it after 1 second.
    private IEnumerator DeathCounter()
    {
        sr.color = new Color32(255, 255, 255, 0);
        yield return new WaitForSeconds(1f);
        GameObject.Destroy(gameObject);
    }
}
