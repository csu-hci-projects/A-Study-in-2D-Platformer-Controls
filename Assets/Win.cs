using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
	public bool gameStart;
	public bool win;
	public GameObject player;
	public MoveCharacter r;
	public Text t;
	public float time;
    // Start is called before the first frame update
    void Start()
    {
		gameStart = false;
        win = false;
		player = GameObject.FindWithTag("Player");
		t = GameObject.Find("WinText").GetComponent<Text>();
		r = player.GetComponent<MoveCharacter>();
		time = 0f;
		t.text = "The Experiment Begins!\n" +
				 "Use A to move left, D to move right, and J to jump!\n" +
				 "Get to the gold box at the top of the tower " +
				 "as fast as possible.\n" +
				 "Press R when you're ready to begin!";
    }

    // Update is called once per frame
    void Update()
    {
        time = GameObject.Find("Timer").GetComponent<Timer>().time;
		if (Input.GetKey("r") && !gameStart) {
			t.text = "";
			gameStart = true;
			r.input = true;
		}
		else if (Input.GetKey("r") && win) {
			t.text = "";
			r.input = true;
			win = false;
		}
    }
	
	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.tag == "Player") {
			while (!r.doneWinning);
			t.text = "Congratulations! You Win!\n"
			+ "Final Time: " + time.ToString("#.##");
			if (r.secondCycle) {
				t.text += "\nPress R for Round 2!";
			}
			else {
				t.text += "\nThe Experiment is done!";
			}
			//Thread.sleep(5000);
			player.transform.SetPositionAndRotation(
			new Vector3(-0.04f,-3.5f,-1.5f),new Quaternion(0,0,0,0));
			if (r.secondCycle) win = true;
		}
	}
}
