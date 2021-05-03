using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float Elapsed = 0f;
    private Text TextComp;

    void Start()
    {
        TextComp = GetComponent<Text>();
        TextComp.text = Elapsed + "s";
    }

    void Update()
    {
        Elapsed += Time.deltaTime;
        TextComp.text = (int)Elapsed + "s";
    }
}
