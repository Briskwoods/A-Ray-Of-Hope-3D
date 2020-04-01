using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeRotate : MonoBehaviour {

    Transform cmpTransform;
    Vector3 rotationVector = new Vector3(0f, 1f, 0f);

	// Use this for initialization
	void Start ()
    {
        cmpTransform = GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        cmpTransform.Rotate(rotationVector);

		
	}
}
