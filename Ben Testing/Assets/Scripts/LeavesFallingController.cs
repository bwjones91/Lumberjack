using UnityEngine;
using System.Collections;

public class LeavesFallingController : MonoBehaviour {

    GameObject parentTree;
    TreeProperties parentTreeProperties;
    ParticleSystem system;
    ParticleSystem.EmissionModule emissionModule;
    

	// Use this for initialization
	void Start () {
        parentTree = transform.parent.gameObject;
        parentTreeProperties = parentTree.GetComponent<TreeProperties>();
        system = GetComponent<ParticleSystem>();
        emissionModule = system.emission;
	}
	
	// Update is called once per frame
	void Update () {
        if(parentTreeProperties.TreeIsChopping)
        {
            print("working");
            emissionModule.rate = 10.0F;
        }
        else
        {
            emissionModule.rate = .3F;
        }
	}
}
