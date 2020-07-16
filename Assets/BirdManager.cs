using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    List<BirdMovement> birds = new List<BirdMovement>();
    public float radius = 1f;
    public float radius_sep = 0.1f;

    void Start ()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            birds.Add(child.GetComponent<BirdMovement>());
        }
    }

    void Update()
    {
        // Zero out bird averages 
        foreach(BirdMovement bird in birds)
        {
            bird.neighbor_avg_pos = Vector3.zero;
            bird.neighbor_avg_angle = 0f;
            bird.num_neighbors = 0;
            bird.seperation = Vector3.zero;
        }

        for(int i = 0; i < birds.Count; ++i)
        {
            Vector3 p1 = birds[i].gameObject.transform.position;
            for(int j = i+1; j < birds.Count; ++j)
            {
                Vector3 p2 = birds[j].gameObject.transform.position;
                if((p1 - p2).magnitude <= radius)
                {
                    birds[i].neighbor_avg_pos += p2;
                    birds[j].neighbor_avg_pos += p1;

                    birds[i].neighbor_avg_angle += birds[j].angle;
                    birds[j].neighbor_avg_angle += birds[i].angle;

                    birds[i].num_neighbors += 1;
                    birds[j].num_neighbors += 1;
                }

                if((p1 - p2).magnitude <= radius_sep)
                {
                    birds[i].seperation += p1 - p2;
                    birds[j].seperation += p2 - p1;
                }
            }
        }

        foreach(BirdMovement bird in birds)
        {
            bird.neighbor_avg_pos /= bird.num_neighbors;
            bird.neighbor_avg_angle /= bird.num_neighbors;
        }
    }
}
