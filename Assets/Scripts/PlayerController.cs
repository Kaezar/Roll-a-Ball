using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private int count;

	public Text countText;
	public Text winText;
	public float speed;

	void Start() {
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rb.AddForce (movement * speed);
    }

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			count++;
			SetCountText ();
			other.gameObject.SetActive (false);
		}
	}
	void SetCountText () {
		countText.text = "Count: " + count.ToString ();
		if (count >= 13) {
			winText.text = "You win!";
		}
	}
}
