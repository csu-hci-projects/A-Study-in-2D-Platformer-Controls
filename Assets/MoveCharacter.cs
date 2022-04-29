using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public float walkSpeed;
	public float airSpeed;
	public float jumpSpeed;
	public bool onGround;
	public bool midairC;
	public bool input;
	public bool doneWinning;
	public bool secondCycle;
	public Vector2 jump;
	public Vector2 leftJump;
	public Vector2 rightJump;
	public Rigidbody2D rb2D;
	
	void Start() {
		walkSpeed = 5f;
		airSpeed = 6.5f;
		jumpSpeed = 300f;
		jump = new Vector2(0,1);
		leftJump = new Vector2(-1,1);
		rightJump = new Vector2(1,1);
		rb2D = GetComponent<Rigidbody2D>();
		onGround = true;
		midairC = true;
		input = false;
		doneWinning = false;
		secondCycle = false;
	}
	
    // Update is called once per frame
    void Update()
    {
		Vector2 pos = transform.position;
		if (rb2D.velocity.y != 0f) onGround = false;
		if (input) {
		if (midairC) {
			if (Input.GetKeyDown("j") && onGround) {
				rb2D.AddForce(jump * jumpSpeed);
				onGround = false;
			}
			if (Input.GetKey("a") && !onGround) {
				pos.x -= airSpeed * Time.deltaTime;
			}
			else if (Input.GetKey("a")) {
				pos.x -= walkSpeed * Time.deltaTime;
			}
			if (Input.GetKey("d") && !onGround) {
				pos.x += airSpeed * Time.deltaTime;
			}
			else if (Input.GetKey("d")) {
				pos.x += walkSpeed * Time.deltaTime;
			}
		}
		else {
			if (Input.GetKey("a") && Input.GetKeyDown("j") &&
			onGround) {
				rb2D.AddForce(leftJump * jumpSpeed);
				onGround = false;
			}
			else if (Input.GetKey("d") && Input.GetKeyDown("j") &&
			onGround) {
				rb2D.AddForce(rightJump * jumpSpeed);
				pos.x += walkSpeed * Time.deltaTime;
				onGround = false;
			}
			else if (Input.GetKeyDown("j") && onGround) {
				rb2D.AddForce(jump * jumpSpeed);
				onGround = false;
			}
			if (Input.GetKey("a") && onGround) {
				pos.x -= walkSpeed * Time.deltaTime;
			}
			if (Input.GetKey("d") && onGround) {
				pos.x += walkSpeed * Time.deltaTime;
			}
		}
		}
		
		transform.position = pos;
    }
	
	void OnCollisionEnter2D(Collision2D c) {
		float vert = rb2D.velocity.y;
		if (c.gameObject.tag == "Ground" && vert == 0f) {
			onGround = true;
			rb2D.velocity = new Vector2(0,0);
		}
		if (c.gameObject.name == "Goal") {
			input = false;
			midairC = false;
			if (!secondCycle) { 
				secondCycle = true;
			}
			else {
				secondCycle = false;
			}
			doneWinning = true;
		}
	}
}
