using UnityEngine;
using System.Collections;

public class LogProperties : MonoBehaviour {

    private BoxCollider2D myBoxcollider2D;
    private PlayerProperties myPlayerProperties;
    private GameObject lumberjack;

    // Use this for initialization
    void Start () {
        myBoxcollider2D = GetComponent<BoxCollider2D>();
        lumberjack = GameObject.FindGameObjectWithTag("Player");
        myPlayerProperties = lumberjack.GetComponent<PlayerProperties>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            myPlayerProperties.addLog();
            Destroy(gameObject);
        }
    }
}
