using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    public Transform target;
    public Transform myTransform;
    public float followSpeed;
    public Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = target.position - transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(target);
        transform.Translate(Vector3.forward * followSpeed * Time.deltaTime);

    }

    private void LateUpdate()
    {
        transform.position = target.position - offset;
    }
}
