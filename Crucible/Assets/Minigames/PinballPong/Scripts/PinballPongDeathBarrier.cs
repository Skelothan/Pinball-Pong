﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballPongDeathBarrier : MonoBehaviour
{
    public int playerNumber;
    public GameObject ballPrefab;

    public MinigameController minigameController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void BallDrop()
    {
        StartCoroutine(GivePointAndReset());
    }

    private IEnumerator GivePointAndReset()
    {
        minigameController.TimerPaused = true;
        minigameController.AddScore(playerNumber, 1);
        yield return new WaitForSeconds(3f);

        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position = new Vector2(3.5f * (playerNumber * 2 - 3) * -1, 1f);
        minigameController.TimerPaused = false;
    }
}
