using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Light))]
public class PlayerProperties : MonoBehaviour
{
    private int beardHealth;
    private int myInventory;
    public GameObject Fire;
    private FireProperties myFireProperties;

    public Text BeardText;
    public Text InventoryText;

    private float minIntensity = .5f;
    private float maxIntensity = 1.5f;

    public Light fireLight;

    float random;

    Animator anim;

    private bool isTriggered = false;

    // Use this for initialization
    void Start()
    {
        myInventory = 0;
        myFireProperties = Fire.GetComponent<FireProperties>();
        beardHealth = 0;
        InvokeRepeating("beardHealthDrop", 0f, 1f);
        SetBeardText();
        SetInventoryText();
        random = Random.Range(0.0f, 65535.0f);
        GetComponent<Light>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(beardHealth > 0)
        {
            minIntensity = .5f;
            maxIntensity = 1.5f;
        }
        else
        {
            minIntensity = 0f;
            maxIntensity = 0f;
        }
        float noise = Mathf.PerlinNoise(random, Time.time);
        fireLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
        print(beardHealth);
        anim.SetInteger("beardHealth", beardHealth);
        if(isTriggered)
        {
            addBeardHealth();
        }
        SetBeardText();
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

    void SetBeardText()
    {
        BeardText.text = beardHealth.ToString();
    }

    void SetInventoryText()
    {
        InventoryText.text = myInventory.ToString();
    }

    void beardHealthDrop()
    {
        if (beardHealth > 0)
        {
            beardHealth--;
        }
    }

    public void addBeardHealth()
    {
        beardHealth = 50;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Fire")
        {
            addBeardHealth();
            //isTriggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Fire")
        {
            //isTriggered = false;
        }
    }
    
}
