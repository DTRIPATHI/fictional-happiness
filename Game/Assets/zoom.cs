﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour
{
    private Camera cam;
    private float zoomin;
    int triggercount = 0;
  
    private void OnTriggerEnter(Collider other)
    {
        triggercount++;
        if (triggercount == 1 || triggercount == 3)
        {
            cam = Camera.main;
            cam.fieldOfView -= 30;
        }
        else
        {

            cam.fieldOfView = 57;
        }
        
    }
         
}