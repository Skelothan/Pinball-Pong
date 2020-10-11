using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballPongPaddle : MonoBehaviour
{

    private Rigidbody2D rigidbody;

    private float MAX_VELOCITY = 4;

    public int playerNumber;

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

        if (MinigameInputHelper.IsButton1Held(playerNumber))
        {
            // Flip left
        }
        if (MinigameInputHelper.IsButton2Held(playerNumber))
        {
            // Flip right
        }
    }
}
