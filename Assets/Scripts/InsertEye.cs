using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertEye : MonoBehaviour
{

    public GameObject Eye;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == Eye)
        {
            Eye.transform.position = this.transform.position;
            Eye.transform.rotation = this.transform.rotation;
            //Eye.transform.RotateAround(Relique.transform.position, Vector3.up, 180);
            col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
