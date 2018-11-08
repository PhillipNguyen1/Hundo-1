﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingBuildable : MonoBehaviour {
    
    // Change to private with getters
    public bool canBuild = true;
    public bool isBlocked = false;   
    public bool canRemove = false;
    public Collider2D blockingObject;

    // Update Function
    public void Update() {      

        if (!isBlocked) {
            canBuild = true;
            canRemove = false;
        }        

        if (canBuild) {
            // Display hologram
        }
    }

    // Function to detect when object is not buildable
    private void OnTriggerStay2D(Collider2D collision) {        
        if (collision.GetType() == typeof(BoxCollider2D)) {     // Checks if collider is a box collider. Need b/c turret has circle collider
            canBuild = false;
            isBlocked = true;
        }

        if (collision.tag.Equals("Buildable") && collision.GetType() != typeof(CircleCollider2D)) {                  
            if (isBlocked && collision.GetComponent<Buildable>().status == Damageable.Status.ACTIVE) {  // Checks if object in front of player is removable
                canRemove = true;                
            }

            blockingObject = collision;      // Reference to blocking object. Turret / wall, etc.             
        }
    }

    // Function to detect when object is buildable
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.GetType() == typeof(BoxCollider2D)) {
            canBuild = true;
            isBlocked = false;
        } 
    } 
    
}
