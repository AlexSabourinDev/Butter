using UnityEngine;

public class FighterMovement : ButtBehaviour {

	[SerializeField]
	private float m_MovementSpeed = 1.0f;

	public void Move(float movementAmount, float deltaTime) {
		float horizontalVelocity = movementAmount * m_MovementSpeed;
		transform.position += Vector3.right * horizontalVelocity * deltaTime;
	}
}
