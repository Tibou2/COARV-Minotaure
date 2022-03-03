using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertEye : MonoBehaviour
{

    public GameObject Eye;
    public GameObject OtherEye;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == Eye)
        {
            float x = OtherEye.transform.position.x;
            float y = OtherEye.transform.position.y;
            float z = OtherEye.transform.position.z;
            Eye.transform.position = new Vector3(-x, y, z);
            Debug.Log(Eye.transform.position);
            Eye.transform.rotation = OtherEye.transform.rotation;
            Eye.transform.localScale = OtherEye.transform.localScale;
            //Eye.transform.RotateAround(Relique.transform.position, Vector3.up, 180);
            Eye.transform.SetParent(this.transform); // il retrouve son père d'origine
            col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            col.gameObject.tag = "placed";
        }
    }
}
