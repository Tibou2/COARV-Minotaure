using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameColor : MonoBehaviour
{
    public Material MaterialSolution; // Ajouter le materiel qui r�sout l'�nigme

    private Material Defaultmaterial;
    [SerializeField]
    private bool goal;  //R�ussite de l'�nigme
    public bool getGoal() { return goal; }

    // Start is called before the first frame update
    void Start()
    {
        Defaultmaterial = transform.GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Defaultmaterial == MaterialSolution)
        {
            goal = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Sphere")
        {
            other.gameObject.transform.parent = transform;
            Defaultmaterial = other.gameObject.transform.GetComponent<Material>();
        }
    }
}
