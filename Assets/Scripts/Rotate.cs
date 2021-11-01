using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public bool isRotating = false;

    [SerializeField]
    private float initialSpeedRangeStart = 700;

    [SerializeField]
    private float initialSpeedRangeEnd = 1000;

    [SerializeField]
    private float decelerationRangeStart = 0.7f;

    [SerializeField]
    private float decelerationRangeEnd = 0.9f;

    [SerializeField]
    private float stoppingThreshold = 5.0f;

    public float speed;
    private float deceleration;


    // Start is called before the first frame update
    void Start()
    {
        isRotating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(0, 0, speed);
            speed = speed * deceleration;

            if (speed < stoppingThreshold)
            {
                speed = 0;
                isRotating = false;
            }

        }

        if (Input.GetKeyDown(KeyCode.Space) && !isRotating)
        {
            Initialize();
            isRotating = true;
        }

    }

    void Initialize()
    {
        speed = Random.Range(initialSpeedRangeStart, initialSpeedRangeEnd);
        deceleration = Random.Range(decelerationRangeStart, decelerationRangeEnd);
    }
}
