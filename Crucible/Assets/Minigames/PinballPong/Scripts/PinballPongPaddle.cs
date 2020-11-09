using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballPongPaddle : MonoBehaviour
{

    private Rigidbody2D rigidbody;

    private float MAX_VELOCITY = 4;

    public int playerNumber;

    public GameObject leftFlipper;
    public GameObject rightFlipper;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Set velocity
        float joystick = MinigameInputHelper.GetHorizontalAxis(playerNumber);
        Debug.Log(joystick);
        Vector2 v = new Vector2(joystick * MAX_VELOCITY, 0);
        rigidbody.velocity = v;

        if (MinigameInputHelper.IsButton1Down(playerNumber))
        {
            // Flip left
            leftFlipper.GetComponent<PinballPongFlipper>().Flip();
        }
        if (MinigameInputHelper.IsButton1Up(playerNumber))
        {
            // Flip left
            leftFlipper.GetComponent<PinballPongFlipper>().UnFlip();
        }
        if (MinigameInputHelper.IsButton2Down(playerNumber))
        {
            rightFlipper.GetComponent<PinballPongFlipper>().Flip();
        }
        if (MinigameInputHelper.IsButton2Up(playerNumber))
        {
            rightFlipper.GetComponent<PinballPongFlipper>().UnFlip();
        }
    }
}
