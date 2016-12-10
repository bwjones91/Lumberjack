using UnityEngine;
using System.Collections;

public class TreeProperties : MonoBehaviour {

    private float treeHealth = 10;
    private BoxCollider2D myBoxcollider2D;
    private PlayerController myPlayerController;
    private float chopDamage = 1;
    private GameObject lumberjack;

    public GameObject myLogs;

	// Use this for initialization
	void Start () {
        myBoxcollider2D = GetComponent<BoxCollider2D>();
        lumberjack = GameObject.FindGameObjectWithTag("Player");
        myPlayerController = lumberjack.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(treeHealth< 0)
        {
            Destroy(gameObject);
            Instantiate(myLogs, new Vector3(transform.position.x, transform.position.y + 0.25f, 0), Quaternion.identity);
        }
	    
	}


    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (myPlayerController.chopInput)
            {
                gettingChopped();
            }
        }
    }

    void gettingChopped()
    {
        treeHealth -= chopDamage * Time.deltaTime;
        
    }

}
