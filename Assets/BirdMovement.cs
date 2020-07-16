using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public int num_neighbors = 0;
    public Vector3 neighbor_avg_pos = Vector3.zero;
    public float neighbor_avg_angle = 0;
    public float angle = 0;
    public Vector3 seperation = Vector3.zero;
    Vector3 velocity = Vector3.zero;

    public float speed = 1f;

    Vector3 Alignment()
    {
        return new Vector3(Mathf.Cos(neighbor_avg_angle), Mathf.Sin(neighbor_avg_angle), 0);
    }

    Vector3 Seperation() 
    {
        return (transform.position - neighbor_avg_pos).normalized;
    }

    Vector3 Cohesion()
    {
        return (neighbor_avg_pos - transform.position) / 100;
    }

    void Update()
    {
        if(num_neighbors == 0)
            return;

        Vector3 dt1 = seperation;
        Vector3 dt2 = Alignment();
        Vector3 dt3 = Cohesion();
        Debug.Log(dt2);
        Debug.Log(dt3);

        Vector3 vel = (dt1 + dt2 + dt3);
        velocity += vel;
        transform.position += Time.deltaTime * speed * velocity;
        angle = Mathf.Atan2(vel.y, vel.x);
        angle += Random.Range(0f, 3.14f);
    }
}
