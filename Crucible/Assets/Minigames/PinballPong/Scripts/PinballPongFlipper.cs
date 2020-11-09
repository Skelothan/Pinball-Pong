using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballPongFlipper : MonoBehaviour
{
    private float flipTime = 0.2f;

    private static int flipSteps = 10;

    public float flipAngle = 45f;
    public static Vector2 offset = new Vector2 (0f, 0.25f);

    private Rigidbody2D rb;

    private static Vector3 zAxis = new Vector3(0f, 0f, 1f);

    private bool isFlipping;
    private bool isUnflipping;
    private bool isFlipped;

    public Coroutine mostRecentFlip;

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
        StartCoroutine(DoFlip(mostRecentFlip));
    }

    public void UnFlip()
    {
        StartCoroutine(DoUnFlip(mostRecentFlip));
    }

    private IEnumerator DoFlip(Coroutine mostRecentFlip)
    {
        while (isUnflipping)
            yield return new WaitForSeconds(0.1f);

        if (isFlipped)
            yield break;

        isFlipping = true;
        for (int i = 0; i < flipSteps; i++)
        {
            rb.MoveRotation(rb.rotation + flipAngle / flipSteps);
            rb.MovePosition(rb.position + offset / flipSteps);
            yield return new WaitForSeconds(flipTime / flipSteps);
        }
        isFlipped = true;
        isFlipping = false;
    }

    private IEnumerator DoUnFlip(Coroutine mostRecentFlip)
    {
        while (isFlipping)
            yield return new WaitForSeconds(0.1f);

        if (!isFlipped)
            yield break;

        isUnflipping = true;
        for (int i = 0; i < flipSteps; i++)
        {
            rb.MoveRotation(rb.rotation - flipAngle / flipSteps);
            rb.MovePosition(rb.position - offset / flipSteps);
            yield return new WaitForSeconds(flipTime / flipSteps);
        }
        isFlipped = false;
        isUnflipping = false;
    }
}
