using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float runSpeed;
    public float move;
    public bool facingRight { get; private set; }

    public bool chopInput { get; private set; }
    public bool dropInput { get; private set; }
    private bool nearFire;
    private PlayerProperties myPlayerProperties;

    Animator anim;


    Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        facingRight = true;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        myPlayerProperties = GetComponent<PlayerProperties>();
	}

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(KeyCode.Mouse0))
        {
            chopInput = true;
        }
        else chopInput = false;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            dropInput = true;
        }
        

    }
    void FixedUpdate()
        {
            anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        anim.SetBool("Chopping", chopInput);
            
            move = Input.GetAxis("Horizontal");
        if (chopInput == false)
        {
            rb2d.velocity = new Vector2(move * runSpeed, rb2d.velocity.y);
        }
            if (move > 0 && !facingRight)
            {
                Flip();
            }
            else if (move < 0 && facingRight)
                Flip();

        if (dropInput == true && nearFire)
        {

        }
        }


    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Fire")
        {
            if (dropInput)
            {
                dropInput = false;
                myPlayerProperties.dropLog();
            }
        }
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
