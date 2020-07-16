using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    List<GameObject> birds;

    void Awake()
    {
        for (int i = 0; i < this.gameobject.transform.GetChildCount(); i++)
            birds.Insert(this.gameobject.transform.GetChild(i));
    }

    void Update()
    {
        // UPDATE EACH BIRDS NEIGHBORS  
    }
}
