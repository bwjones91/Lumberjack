using UnityEngine;
using System.Collections;

public class SeedlingProperties : MonoBehaviour {

    float seedlingNum; // = Random.Range(1, 10);
    public GameObject myTree;

	// Use this for initialization
	void Start () {
        seedlingNum = Random.Range(30, 60);
        Invoke("seedlingGrow", seedlingNum);
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    void seedlingGrow()
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
            Instantiate(myTree, new Vector3(transform.position.x, transform.position.y + .207f, 0), Quaternion.identity);
        }
    }
}
