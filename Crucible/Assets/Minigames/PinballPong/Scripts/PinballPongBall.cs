using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballPongBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DeathBarrier")
        {
            Debug.Log("A ball was dropped!");
            other.gameObject.GetComponent<PinballPongDeathBarrier>().BallDrop();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 9) // Walls
            PinballPongSoundManager.S.PlayWallBounceSound();

        if (other.gameObject.layer == 8) // Paddles
            PinballPongSoundManager.S.PlayPaddleBounceSound();
    }
}
