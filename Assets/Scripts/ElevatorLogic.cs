using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject Target;
    private Vector3 StartPosition;
    private Vector3 EndPosition;
    private float CurrentLerp;
    private bool FloorState = false;

    void Start()
    {
        StartPosition = transform.position;
        EndPosition = Target.transform.position;
    }

    private IEnumerator GoUp(GameObject passenger)
    {
        passenger.GetComponent<Rigidbody>().isKinematic = true;
      //  passenger.transform.SetParent(transform);
        CurrentLerp = 0;
        while(CurrentLerp < 1)
        {
            CurrentLerp += Time.deltaTime;
            transform.position = Vector3.Lerp(StartPosition, EndPosition, CurrentLerp);
            passenger.transform.position = transform.position + new Vector3(0, 0.5f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        passenger.GetComponent<Rigidbody>().isKinematic = false;
     //   passenger.transform.parent = null;
    }

 /*   private IEnumerator GoDown(GameObject passenger)
    {
        passenger.GetComponent<Rigidbody>().isKinematic = true;
        passenger.transform.SetParent(transform);
        CurrentLerp = 0;
        while(CurrentLerp < 1)
        {
            CurrentLerp += Time.deltaTime;
            transform.position = Vector3.Lerp(EndPosition, StartPosition, CurrentLerp);
            yield return new WaitForSeconds(0.01f);
        }
        passenger.GetComponent<Rigidbody>().isKinematic = false;
        passenger.transform.parent = null;
    } */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(!FloorState)
            {
                FloorState = true;
                StartCoroutine(GoUp(other.gameObject));
            }
            else
            {
             /*   FloorState = false;
                StartCoroutine(GoDown(other.gameObject)); */
            }
        }
    }

}
