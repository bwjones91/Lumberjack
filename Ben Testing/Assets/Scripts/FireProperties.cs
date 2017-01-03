using UnityEngine;
using UnityEngine.UI;
using System.Collections;


[RequireComponent(typeof(Light))]
public class FireProperties : MonoBehaviour {

    private int fireHealth;

    private bool changeFire = false;

    private BoxCollider2D myBoxCollider2D;

    Animator anim;

    ArduinoCommunication myArduinoCommunication;

    public enum FireState
    {
        FireSmall = 0,
        FireMedium = 1,
        FireLarge = 2
    }

    public FireState myFireState { get; private set; }

    private float minIntensity;
    private float maxIntensity;

    public Light fireLight;

    float random;

    public Text HealthText;
        

    // Use this for initialization
    void Start () {
        changeFire = false;
        fireHealth = 10;
        InvokeRepeating("fireHealthDrop", 0f, 1f);
        myFireState = FireState.FireSmall;
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        random = Random.Range(0.0f, 65535.0f);
        GetComponent<Light>();
        SetHealthText();
        myArduinoCommunication = GetComponent<ArduinoCommunication>();
    }
	
	// Update is called once per frame
	void Update () {
        // print("Fire Health: " + fireHealth);
       // print(Screen.width);
       // print(Screen.height);
       // print("test");

        if (fireHealth < 101 && fireHealth > 0)
        {
            myFireState = FireState.FireSmall;
        }
        else if (fireHealth > 100 && fireHealth < 201)
        {
            myFireState = FireState.FireMedium;
        }
        else if (fireHealth > 200)
        {
            myFireState = FireState.FireLarge;
        }
        else if (fireHealth < 1)
        {
            Destroy(gameObject);
            print("You Lose!!!!");
            myArduinoCommunication.ledOff();
            
        }

            SetFireState();
        anim.SetInteger("FireState", (int)myFireState);

        if (myFireState == FireState.FireSmall)
        {
            minIntensity = .5f;
            maxIntensity = 1f;
        }
        if (myFireState == FireState.FireMedium)
        {
            minIntensity = 1f;
            maxIntensity = 1.5f;
        }
        if (myFireState == FireState.FireLarge)
        {
            minIntensity = 1.5f;
            maxIntensity = 2.5f;
        }
        float noise = Mathf.PerlinNoise(random, Time.time);
        fireLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);

    }

    void fireHealthDrop()
    {
        fireHealth--;
        SetHealthText();
    }

    public void addFireHealth()
    {
        fireHealth += 10;
        SetHealthText();
       // print(fireHealth);
    }


    void SetFireState()
    {
        changeFire = false;
        switch (myFireState)
        {
            case FireState.FireSmall:
                myBoxCollider2D.size = new Vector2(myBoxCollider2D.size.x, myBoxCollider2D.size.y);
                break;
            case FireState.FireMedium:
                myBoxCollider2D.size = new Vector2(.5F, .5F);
                break;
            case FireState.FireLarge:
                myBoxCollider2D.size = new Vector2(1F, 1F);
                break;
        }
     }

    void SetHealthText()
    {
        HealthText.text = fireHealth.ToString();
    }

}
