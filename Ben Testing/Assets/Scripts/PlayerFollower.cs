using UnityEngine;
using System.Collections;

public class PlayerFollower : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;


    void Start()
    {
        offset = transform.position - player.transform.position;
     
    }


    void LateUpdate ()
    {
        transform.position = player.transform.position;
       

    }
    
}
