using System.Collections.Generic;
using UnityEngine;
// based of code by chris tutorials

public class DetectionZones : MonoBehaviour
{
    public List<Collider2D> collidersInZone = new List<Collider2D>();
    Collider2D detectCol;
    public int colliderCount;
    // zones to detectect ofther coliders 

    
    void Start()
    {
        detectCol = GetComponent<Collider2D>();
    }

    // on detection adds colider to array so that other parts can work
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.LogError(name + " collider count " + colliderCount);
        collidersInZone.Add(collider);
        colliderCount = collidersInZone.Count;
        Debug.LogError(name + " collider count "+ colliderCount);
        Debug.LogError(name + " collider count " + collider.enabled);


    }
    // on leaving removes collider so that it updates other scripts
    private void OnTriggerExit2D(Collider2D collider)
    {
        collidersInZone.Remove(collider);
        colliderCount = collidersInZone.Count;
    }
}
