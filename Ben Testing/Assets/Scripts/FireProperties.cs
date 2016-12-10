using UnityEngine;
using System.Collections;

public class FireProperties : MonoBehaviour {

    private static int fireHealth;

    private bool changeFire = false;

    private BoxCollider2D myBoxCollider2D;
    
    public enum FireState
    {
        FireSmall = 0,
        FireMedium = 1,
        FireLarge = 2
    }

    public FireState myFireState { get; private set; }

	// Use this for initialization
	void Start () {
        changeFire = false;
        fireHealth = 100;
        print(fireHealth);
        InvokeRepeating("fireHealthDrop", 0f, 1f);
        myFireState = FireState.FireSmall;
        myBoxCollider2D = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        print(fireHealth);

        if (fireHealth < 101)
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

        SetFireState();
        
	}

    void fireHealthDrop()
    {
        fireHealth--;
    }

    public void addFireHealth()
    {
        fireHealth += 10;
        print(fireHealth);
    }

    public void GrowFireState()
    {
        if ((int)myFireState < 2)
        {
            myFireState++;
            changeFire = true;
        }
    }

    public void ShrinkFireState()
    {
        if ((int)myFireState > 1)
        {
            myFireState--;
            changeFire = true;
        }
    }

    void SetFireState()
    {
        switch (myFireState)
        {
            case FireState.FireSmall:
                myBoxCollider2D.size = new Vector2(myBoxCollider2D.size.x, myBoxCollider2D.size.y);
                break;
            case FireState.FireMedium:
                myBoxCollider2D.size = new Vector2(myBoxCollider2D.size.x + .1F, myBoxCollider2D.size.y + .1F);
                break;
            case FireState.FireLarge:
                myBoxCollider2D.size = new Vector2(myBoxCollider2D.size.x + .2F, myBoxCollider2D.size.y + .2F);
                break;
        }
        }

}
