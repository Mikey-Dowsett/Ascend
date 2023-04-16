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
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        rb.gravityScale = 0.5f;
        if (col.CompareTag("Player"))
        {
            HitPlayer();
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
}
