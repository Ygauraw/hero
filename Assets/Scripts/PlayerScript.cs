using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public float maxSpeed = 10f;
	bool facingRight = true;
	Animator anim;
	JetPack jetpack;
	OxygenScript oxygen;
	HealthScript health;
	public bool grounded = false;
	public bool isFlying = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	void Start(){
		anim = GetComponent<Animator> ();
		jetpack = GetComponent<JetPack>();
		health = GetComponent<HealthScript>();
		oxygen = GetComponent<OxygenScript>();
	}

	void Update(){
		if (grounded && Input.GetKeyDown (KeyCode.Space)) { //Input.GetButton ("Jump")
			anim.SetBool ("Ground", false);
			rigidbody2D.AddForce (new Vector2 (0, jumpForce));
		}

		if (!oxygen.hasTime) {
			health.Damage(1);
		}
	}

	void FixedUpdate(){

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		float move = Input.GetAxis("Horizontal");
		float fly = Input.GetAxis ("Vertical");
		anim.SetFloat ("Speed", Mathf.Abs(move));



		if (fly > 0 && jetpack.gas != 0) {
			isFlying = true;
			rigidbody2D.velocity = new Vector2 (move * maxSpeed, fly * maxSpeed);
		} else {
			isFlying = false;
			rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
			/*if(jetpack.gas == 0){
				health.Damage(1);
			}*/
		}

		if(move > 0 && !facingRight)
			Flip();
		else if (move < 0 && facingRight)
			Flip();
	}

	void Flip(){
		facingRight = ! facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
