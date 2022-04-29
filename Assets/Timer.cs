using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public float time;
	public Text t;
	public Win w;
	
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
		t = GetComponent<Text>();
		t.text = "Time: 0";
		w = GameObject.Find("Goal").GetComponent<Win>();
    }

    // Update is called once per frame
    void Update()
    {
		if (!w.win && w.gameStart) {
			time += 1f * Time.deltaTime;
			t.text = "Time: " + (int)time;
		}
		else {
			time = 0f;
		}
    }
}
