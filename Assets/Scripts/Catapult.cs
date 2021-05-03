using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField]
    private GameObject control;
    private HingeJoint joint;

    void Start()
    {
        joint = control.GetComponent<HingeJoint>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!joint.useMotor && other.gameObject.tag == "Player")
        {
            StartCoroutine(launch());
        }   
    }

    private IEnumerator launch()
    {
        yield return new WaitForSeconds(1f);
        joint.useMotor = true;
        yield return new WaitForSeconds(1f);
        joint.useMotor = false;
    }
}