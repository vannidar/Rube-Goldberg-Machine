using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    [SerializeField]
    private bool Activated = false;
    [SerializeField]
    private GameObject StopperObj;
    [SerializeField]
    private GameObject Indicator;
    private Renderer LightGlass;
    private Light LightSource;

    void Start()
    {
        LightGlass = Indicator.GetComponent<Renderer>();
        LightSource = Indicator.GetComponent<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Lever" && !Activated)
        {
            Activated = true;
            LightGlass.material.SetColor("_Color", Color.red);
            LightSource.color = Color.red;
            Destroy(StopperObj);
            Destroy(this);
        }
    }
}