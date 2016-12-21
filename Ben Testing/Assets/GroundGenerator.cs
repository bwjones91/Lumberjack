using UnityEngine;
using System.Collections;

public class GroundGenerator : MonoBehaviour
{

    public GameObject theGroundSection;
    public GameObject generationPointRight;
    public GameObject geneartionPointLeft;

   
    private float groundWidth;
    private 


    // Use this for initialization
    void Start()
    {
        groundWidth = theGroundSection.GetComponent<Collider2D>().bounds.size.x;
        print(groundWidth);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > generationPointRight.transform.position.x)
        {
            Instantiate(theGroundSection, generationPointRight.transform.position, generationPointRight.transform.rotation);
            generationPointRight.transform.position = new Vector3(generationPointRight.transform.position.x + groundWidth, generationPointRight.transform.position.y, generationPointRight.transform.position.z);
            
        }

    }
}
