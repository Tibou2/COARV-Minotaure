﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchInteraction : MonoBehaviour
{

    public bool resolved = false;
    public bool getGoal(){return resolved;}

    private List<GameObject> torches;
    private List<int> order; // ordre d'allumage des torches
    private List<GameObject> lights;

    // get the child by its name and its parent gameobject
    static public GameObject getChildGameObject(GameObject go, string withName)
    {
        Transform[] ts = go.GetComponentsInChildren<Transform>();
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        torches = new List<GameObject>();
        lights = new List<GameObject>();
        order = new List<int>();
        //GameObject torchesEnigme = GameObject.Find("TorchesEnigme");
        for (int i=0; i<transform.childCount; i++){
            torches.Add(transform.GetChild(i).gameObject);
            lights.Add(torches[i].transform.GetChild(0).gameObject);
            lights[i].SetActive(false);
        }
    }

    private void checkLight(int i){
        //on vérifie la lumière numero i
        if (RayTracing.GetObject("Point light"+(i+1).ToString())){
            Debug.Log("torche "+i.ToString());
            if (!lights[i].activeSelf){
                //si la torche est éteinte, alors on l'allume.
                lights[i].SetActive(true);
                order.Add(i);
            }
        }
    }

    private void checkEnigma(){
        if (order.Count < lights.Count){
            resolved = false;
            
        } else {
            List<int> expectation = new List<int>{0,1,2,3};
            if (equal(order,expectation))
            {
                //on regarde si l'ordre de l'allumage est égale à la solution
                resolved = true;
               
            } else {
                // les 4 torches sont allumées dans le mauvais ordre.
                // on réinitialise donc l'énigme
                resolved = false;
                reset();
            }
        }
    }

    private void reset(){
        // on repart à 0
        order = new List<int>();
        //on éteint les lumières
        for (int i=0; i<lights.Count; i++){
            lights[i].SetActive(false);
        }
    }

    //Renvoie false dès qu'il y a un élément qui n'est pas dans l'ordre, renvoir true si tout est dans l'ordre
    private bool equal(List<int> ordre, List<int> expectation)
    {
        int i = 0;
        while (ordre[i] == expectation[i] && i<ordre.Count)
        {
            i++;
            Debug.Log(i);
        }
        return (i == order.Count);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetJoystickNames());
        /*if (Input.GetJoystickNames() && !resolved)//Remplacer le Input.GetMouseButtonDown(0)
        {
            Debug.Log("Joystick marche");
            for (int i=0; i<lights.Count; i++){
                checkLight(i);
            }
            checkEnigma();
        }*/
    }
}
