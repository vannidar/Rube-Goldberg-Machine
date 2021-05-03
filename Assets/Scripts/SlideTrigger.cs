using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject Slide;  
    [SerializeField]
    private bool isTriggered = false;
    private Vector3 EndScale = new Vector3(1, 1, 1);
    private Vector3 StartScale = new Vector3(0, 0, 0);
    private float CurrentLerp = 0;

    void Start()
    {
        Slide.transform.localScale = StartScale;
    }

    private IEnumerator StartLerp()
    {
        while(CurrentLerp < 1)
        {
            CurrentLerp += Time.deltaTime * 1.1f;
            Slide.transform.localScale = Vector3.Lerp(StartScale, EndScale, CurrentLerp);
            yield return null;
        }
    } 

    private void OnTriggerEnter(Collider other)
    {
        if(!isTriggered)
        {
            StartCoroutine(StartLerp());
        }
    }
}
