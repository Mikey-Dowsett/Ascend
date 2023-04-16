using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Reloads the scene when the balloon is hit.
*/
public class Balloon : MonoBehaviour
{
    [SerializeField] Transform backgroundPos;
    [SerializeField] float bgSpeed;
    [SerializeField] ParticleSystem popParticle;
    [SerializeField] SpriteRenderer balloonSprite;
    public GameObject balloonShield;

    Vector3 newBGPos;

    void Start()
    {
        newBGPos = backgroundPos.localPosition;
    }

    void Update()
    {
        if (Vector3.Distance(backgroundPos.localPosition, newBGPos) > 0.01)
        {
            backgroundPos.localPosition = Vector3.MoveTowards(backgroundPos.localPosition, newBGPos, bgSpeed * Time.deltaTime);
        }
        else
        {
            newBGPos = new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-1f, 1f), 10);// + backgroundPos.localPosition;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Enemy"))
        {
            if (PlayerPrefs.GetString("HAPTIC") == "True") Handheld.Vibrate();
            FindObjectOfType<StartGame>().DeathScreen();
            FindObjectOfType<Player>().EndGame();

            GetComponent<CircleCollider2D>().enabled = false;
            balloonSprite.color = new Color(255, 255, 255, 0);
            popParticle.Play();
        }
    }

    public void Respawn()
    {
        GetComponent<CircleCollider2D>().enabled = true;
        balloonSprite.color = new Color(255, 255, 255, 255);
        FindObjectOfType<Player>().StartGame();
    }

    public IEnumerator ActivateShield(){
        balloonShield.SetActive(true);
        yield return new WaitForSeconds(10);
        for(int i = 0; i < 10; i++){
            print(i);
            balloonShield.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.25f - i / 5);
            balloonShield.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.25f - i / 5);
        }
        balloonShield.SetActive(false);
        StopCoroutine("ActivateShield");
    }
}
