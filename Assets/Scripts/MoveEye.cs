using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEye : MonoBehaviour
{
    public GameObject skull;
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (this.tag == "unplaced")
        {
            if (Input.GetMouseButtonDown(0) && RayTracing.GetObject(gameObject.tag) == gameObject)
            {
                // si le diamant est sélectionné on l'attache a la caméra.
                GetComponent<Rigidbody>().useGravity = false;
                transform.SetParent(Camera.main.transform);
            }
            if (Input.GetMouseButtonUp(0))
            {
                transform.SetParent(skull.transform); // il retrouve son père d'origine
                GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
}
