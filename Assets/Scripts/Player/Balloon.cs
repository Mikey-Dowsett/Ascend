using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Reloads the scene when the balloon is hit.
*/
public class Balloon : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
