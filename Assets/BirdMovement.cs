using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    float angle = 0;
    List<BirdMovement> neighbors;
    void Update()
    {
        dt1 = Seperation();
        dt2 = Alignment();
        dt3 = Cohesion();
    }
}
