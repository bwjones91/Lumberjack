using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour
{

    private int myInventory;
    public GameObject Fire;
    private FireProperties myFireProperties;



    // Use this for initialization
    void Start()
    {
        myInventory = 0;
        myFireProperties = Fire.GetComponent<FireProperties>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void dropLog()
    {
        if (myInventory > 0)
        {
            myInventory--;
            myFireProperties.addFireHealth();
        }
    }

    public void addLog()
    {
        myInventory++;
    }

}
