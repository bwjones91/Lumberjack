using UnityEngine;
using System.Collections;

public class SeedlingProperties : MonoBehaviour {

    float seedlingNum = Random.Range(1, 10);
    public GameObject myTree;

	// Use this for initialization
	void Start () {
        //var seedlingNum = Random.Range(10, 30);

	}
	
	// Update is called once per frame
	void Update () {
        Invoke("seedlingGrow", seedlingNum);
	}

    void seedlingGrow()
    {
        Destroy(gameObject);
        Instantiate(myTree, new Vector3(transform.position.x, transform.position.y + .207f, 0), Quaternion.identity);
    }
}
