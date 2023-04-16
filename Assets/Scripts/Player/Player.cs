using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Controls the balloons rise rate
Controls the defenders position.
*/
public class Player : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Transform balloonPosition;

    [SerializeField] float balloonSpeed;
    [SerializeField] float balloonSpeedIncreaseAmount;
    public float speedMultiplier = 1;

    bool start;

    void Update()
    {
        //Set defenders position.
        if (start)
        {
            transform.position = cam.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0.75f, 10);
            balloonPosition.position = new Vector3(0, balloonPosition.position.y + balloonSpeed * Time.deltaTime * speedMultiplier, 0);
        }

        //Increases balloons rise speed.
        balloonSpeed += balloonSpeedIncreaseAmount;
    }

    public void StartGame()
    {
        start = true;
        balloonSpeed = 1;
    }

    public void EndGame()
    {
        start = false;
        balloonSpeed = 0;
    }
}
