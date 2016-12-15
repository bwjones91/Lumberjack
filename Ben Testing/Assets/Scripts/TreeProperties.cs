using UnityEngine;
using System.Collections;

public class TreeProperties : MonoBehaviour {

    private float treeHealth = 2;
    public float TreeHealth
    {
        get
        {
            return treeHealth;
        }
        set
        {
            treeHealth = value;
            OnValueChange();
        }
    }
    private bool isDead = false;
    private BoxCollider2D myBoxcollider2D;
    private PlayerController myPlayerController;
    private float chopDamage = 1;
    Animator anim;
    private GameObject lumberjack;

    public GameObject myLogs;

    public GameObject mySeedling;

    bool treeIsChopping;

	// Use this for initialization
	void Start () {
        myBoxcollider2D = GetComponent<BoxCollider2D>();
        lumberjack = GameObject.FindGameObjectWithTag("Player");
        myPlayerController = lumberjack.GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        treeIsChopping = false;
	}
	
	// Update is called once per frame
	void Update () {

        anim.SetBool("Chopping", treeIsChopping);

       

        if (myPlayerController.chopInput == false)
        {
            treeIsChopping = false;
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
        TreeHealth -= chopDamage * Time.deltaTime;
        treeIsChopping = true;
    }

    void OnValueChange()
    {
        if (treeHealth < 0 && !isDead)
        {
            isDead = true;
            print("Destroy");
           
            Instantiate(mySeedling, new Vector3(transform.position.x, transform.position.y - .207f, 0), Quaternion.identity);
            var logNum = Random.Range(1, 1);
            for (var i = 0; i < logNum; i++)
                Instantiate(myLogs, new Vector3(transform.position.x, transform.position.y + 0.25f, 0), Quaternion.identity);
            Destroy(gameObject);

        }
    }


}
