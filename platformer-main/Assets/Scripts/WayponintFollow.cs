using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayponintFollow : MonoBehaviour
{
   [SerializeField] GameObject[] waypoints;
   int currentWaypointIndex = 0;

   //speed of object in between waypoints

   [SerializeField] float speed =1f;

    // position of thing following waypoint changes according to waypoint position
   void Update(){
      
      //which waypoint to head towards 

      if(Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f){

         currentWaypointIndex++;
         if(currentWaypointIndex >= waypoints.Length)
         {
            currentWaypointIndex = 0;
         }
         
      }
      
      transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
   }
}
