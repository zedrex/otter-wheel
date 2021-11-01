using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField]
    private Text resultText;

    [SerializeField]
    private Rotate rotate;

    [SerializeField]
    private GameObject wheel;

    [SerializeField]
    private float angleDistance;

    [SerializeField]
    private Camera mainCamera;


    [SerializeField]
    private string[] colorStrings;

    [SerializeField]
    private Color[] colorsHex;

    private string colorString;
    private Color colorHex;
    private bool isFinished;


    // Start is called before the first frame update
    void Start()
    {
        isFinished = false;
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotate.isRotating && !isFinished)
        {
            isFinished = true;
            GetResult();
        }
        else if (rotate.isRotating && isFinished)
        {
            isFinished = false;
            Reset();
        }

    }

    void GetResult()
    {

        float angle = wheel.transform.rotation.eulerAngles.z;
        for (int i = 0; i < colorStrings.Length; i++)
        {
            if ((angle >= i * angleDistance) && (angle < (i + 1) * angleDistance))
            {
                colorString = colorStrings[i];
                colorHex = colorsHex[i];
                break;
            }
        }

        mainCamera.backgroundColor = colorHex;
        resultText.text = colorString;
    }

    void Reset()
    {
        resultText.text = "";
        colorString = "";
    }

}
