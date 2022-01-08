using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagManager : MonoBehaviour
{
    GameObject[] CollisionEvir = GameObject.FindGameObjectsWithTag("evir");
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "evir")
        {
            
        }
    }

}
