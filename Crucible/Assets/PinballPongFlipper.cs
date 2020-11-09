using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballPongFlipper : MonoBehaviour
{

    public bool isRightFlipper;

    private float flipTime = 0.02f;

    private int flipSteps = 30;

    public float flipAngle = 45f;
    public static Vector2 offset = new Vector2 (0f, 0.25f);

    private Rigidbody2D rb;

    private static Vector3 zAxis = new Vector3(0f, 0f, 1f);

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Don't collide with other flipper
        Physics.IgnoreLayerCollision(8, 8, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Flip()
    {
        StartCoroutine(DoFlip());
    }

    public void UnFlip()
    {
        StartCoroutine(DoUnFlip());
    }

    private IEnumerator DoFlip()
    {
        for (int i = 0; i < flipSteps; i++)
        {
            rb.MoveRotation(rb.rotation + flipAngle / flipSteps);
            rb.MovePosition(rb.position + offset / flipSteps);
            yield return new WaitForSeconds(flipTime / flipSteps);
        }
    }

    private IEnumerator DoUnFlip()
    {
        for (int i = 0; i < flipSteps; i++)
        {
            rb.MoveRotation(rb.rotation - flipAngle / flipSteps);
            rb.MovePosition(rb.position - offset / flipSteps);
            yield return new WaitForSeconds(flipTime / flipSteps);
        }
    }
}
