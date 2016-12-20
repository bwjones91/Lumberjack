using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerProperties : MonoBehaviour
{

    private int myInventory;
    public GameObject Fire;
    private FireProperties myFireProperties;

    public Text InventoryText;

    // Use this for initialization
    void Start()
    {
        myInventory = 0;
        myFireProperties = Fire.GetComponent<FireProperties>();
        SetInventoryText();
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
            SetInventoryText();
        }
    }

    public void addLog()
    {
        myInventory++;
        SetInventoryText();
    }

    void SetInventoryText()
    {
        InventoryText.text = myInventory.ToString();
    }

}
