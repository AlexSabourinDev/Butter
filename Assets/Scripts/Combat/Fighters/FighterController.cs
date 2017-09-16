using UnityEngine;

public class FighterController : ButtBehaviour, ICombatController {

	[SerializeField]
	private FighterMovement m_Movement;

	// Next frame data
	private float m_MovementAmount = 0.0f;

	public void ReceiveCommand(CombatCommand command) {

		switch(command) {
			case CombatCommand.Right: 
				m_MovementAmount = 1.0f;
				break;
			case CombatCommand.Left:
				m_MovementAmount = -1.0f;
				break;
		}
	}

	protected override void Update() {
		base.Update();

		m_Movement.Move(m_MovementAmount, TimeController.GetDeltaTime(TimeCategory.Gameplay));
	}
}
