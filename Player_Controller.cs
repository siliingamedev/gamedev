using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {
	[SerializeField]private float speed = 6.0F;
	[SerializeField]private float runSpeed = 10.0F;
	[SerializeField]private float jumpSpeed = 8.0F;
	[SerializeField]private float gravity = 20.0F;
	[SerializeField]private float horizontalSpeed = 2.0F;
	private Vector3 moveDirection = Vector3.zero;
	private Animator anim;

	void Start() {
		anim = GetComponent<Animator> ();
	}
	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;

			if (Input.GetButton ("Jump")) {
				moveDirection.y = jumpSpeed;
				anim.Play ("jump");
			}

		}
		if (moveDirection == Vector3.zero) {
			anim.SetBool ("IsWalking", false);
		}
			else{ anim.SetBool("IsWalking", true);
			}
		if (Input.GetMouseButtonDown(0)){
			anim.Play ("atack");
		}
		if (Input.GetMouseButtonDown (1)) {
			anim.Play ("spin_attack");
		}
		if (Input.GetMouseButtonDown (1) & Input.GetMouseButtonDown (1)) {
			anim.Play ("double atack");
		}
		if (Input.GetButton ("Run")) {
			moveDirection *= runSpeed;
			anim.Play ("run");
		}

		float h = horizontalSpeed * Input.GetAxis("Mouse X");
		transform.Rotate(0, h, 0);
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}