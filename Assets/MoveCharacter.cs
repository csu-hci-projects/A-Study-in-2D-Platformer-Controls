using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public float walkSpeed;
	public float airSpeed;
	public float jumpSpeed;
	public bool onGround;
	public Vector2 jump;
	public Rigidbody2D rb2D;
	
	void Start() {
		walkSpeed = 5f;
		airSpeed = 6.5f;
		jumpSpeed = 300f;
		jump = new Vector2(0,1);
		rb2D = GetComponent<Rigidbody2D>();
		onGround = true;
	}
	
    // Update is called once per frame
    void Update()
    {
		Vector2 pos = transform.position;
		
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
		
		transform.position = pos;
    }
	
	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.tag == "Ground") {
			onGround = true;
		}
	}
}
