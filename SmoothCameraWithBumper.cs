﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SmoothCameraWithBumper : MonoBehaviour
{
     private Transform target = null;
     private float distance = 3.0f;
    private float height = 1.0f;
     private float damping = 5.0f;
     private bool smoothRotation = true;
    private float rotationDamping = 10.0f;

     private Vector3 targetLookAtOffset; // allows offsetting of camera lookAt, very useful for low bumper heights
     private float bumperDistanceCheck = 5f; // length of bumper ray
     private float bumperCameraHeight = 1.0f; // adjust camera height while bumping
     private Vector3 bumperRayOffset; // allows offset of the bumper ray from target origin
                                                      /// 
                                                      /// If the target moves, the camera should child the target to allow for smoother movement. DR
                                                      /// 
    private void Awake()
    {
        GetComponent<Camera>().transform.parent = target;
    }
    private void FixedUpdate()
    {
        Vector3 wantedPosition = target.TransformPoint(0, height, -distance);
        // check to see if there is anything behind the target
        RaycastHit hit;
        Vector3 back = target.transform.TransformDirection(-1 * Vector3.forward);
        // cast the bumper ray out from rear and check to see if there is anything behind
        if (Physics.Raycast(target.TransformPoint(bumperRayOffset), back, out hit, bumperDistanceCheck)
            && hit.transform != target) // ignore ray-casts that hit the user. DR
        {
            // clamp wanted position to hit position
            wantedPosition.x = hit.point.x;
            wantedPosition.z = hit.point.z;
            wantedPosition.y = Mathf.Lerp(hit.point.y + bumperCameraHeight, wantedPosition.y, Time.deltaTime * damping);
        }
        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);
        Vector3 lookPosition = target.TransformPoint(targetLookAtOffset);
        if (smoothRotation)
        {
            Quaternion wantedRotation = Quaternion.LookRotation(lookPosition - transform.position, target.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
        }
        else
            transform.rotation = Quaternion.LookRotation(lookPosition - target.position, target.up);
    }
}