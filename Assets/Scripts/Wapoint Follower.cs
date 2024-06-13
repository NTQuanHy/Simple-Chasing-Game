using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WapointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;
    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 1f)
        {
            currentWaypointIndex++;
            Flip();
            if (currentWaypointIndex == waypoints.Length) { currentWaypointIndex = 0; }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    } 
    private void Flip()
    {
        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
