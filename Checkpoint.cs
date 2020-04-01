using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public HealthManager HealthM;
    public Renderer materialRenderer;

    public Material CPOff;
    public Material CPOn;

    

	// Use this for initialization
	void Start () {
        HealthM = FindObjectOfType<HealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void checkpointOn()
    {
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();

        foreach(Checkpoint cp in checkpoints)
        {
            cp.checkpointOff();
        }

        materialRenderer.material = CPOn;
    }

    public void checkpointOff()
    {
        materialRenderer.material = CPOff;
    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.tag.Equals("Player"))
        {
            HealthM.setSpawnPoint(transform.position);
            checkpointOn();
        }
    }
}
 