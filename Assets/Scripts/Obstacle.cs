using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Sets the obstacles theme and turns on gravity when hit.
*/
public class Obstacle : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject whiteMask;
    [SerializeField] AudioSource audioSource;
    [SerializeField] ParticleSystem deathPart;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = GameObject.FindObjectOfType<IconManager>().color;
        if(FindObjectOfType<Settings>().sound == false)
            audioSource.enabled = false;
    }

    private void Update(){
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        rb.gravityScale = 0.5f;
        if (col.collider.CompareTag("Player"))
        {
            HitPlayer();
        } else if(col.collider.CompareTag("Destroy")){
            StartCoroutine("DeathCounter");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        rb.gravityScale = 0.5f;
        if (col.CompareTag("Player"))
        {
            HitPlayer();
        } else if(col.CompareTag("Destroy")){
            StartCoroutine("DeathCounter");
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        whiteMask.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        whiteMask.SetActive(false);
    }

    private void HitPlayer(){
        whiteMask.SetActive(true);
        audioSource.pitch = 1 + Random.Range(-0.2f, 0.2f);
        if (audioSource.enabled) audioSource.Play();
    }

    private IEnumerator DeathCounter()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        GetComponent<BoxCollider2D>().enabled = false;

        var main = deathPart.main;
        main.startColor = GetComponent<SpriteRenderer>().color;
        deathPart.Play();
        
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
        audioSource.pitch = 1 + Random.Range(-0.2f, 0.2f);
        if (audioSource.enabled) audioSource.Play();
        yield return new WaitForSeconds(1f);
        GameObject.Destroy(gameObject);
    }
}
