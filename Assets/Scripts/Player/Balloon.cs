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
            SceneManager.LoadScene(0);
        }
    }
}
