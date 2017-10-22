using UnityEngine;

public class FighterController : ButtBehaviour, ICombatController {

	const int MAX_COMBO_SIZE = 20;

	[SerializeField]
	private FighterMovement m_Movement = null;

	[SerializeField]
	private ComboList m_Combos = null;

	[SerializeField]
	private float m_ComboTimeout = 0.5f;

	private CombatBuffer m_CombatBuffer = new CombatBuffer(MAX_COMBO_SIZE);

	// Next frame data
	private float m_MovementAmount = 0.0f;

	private float m_ComboLife = 0.0f;

	// -Public API-
	public void SetCombos(ComboList combos) {
		m_Combos = combos;
	}

	
	// -ICombatController-
	public void ReceiveCommand(CombatCommand command) {

		switch (command) {
			case CombatCommand.Right:
				m_MovementAmount = 1.0f;
				break;
			case CombatCommand.Left:
				m_MovementAmount = -1.0f;
				break;

			case CombatCommand.Heavy:
			case CombatCommand.Light:
				m_ComboLife = 0.0f;
				m_CombatBuffer.Write(command);
				break;
		}

		// Check for combos
		string activeCombo = FindActiveCombo();
		DispatchCombo(activeCombo);
	}


	// -ButtBehaviour API-
	protected override void Update() {
		base.Update();

		m_Movement.Move(m_MovementAmount, TimeController.GetDeltaTime(TimeCategory.Gameplay));
		m_ComboLife += TimeController.GetDeltaTime(TimeCategory.Gameplay);

		if(m_ComboLife > m_ComboTimeout) {
			m_CombatBuffer.ClearCommands();
			m_ComboLife = 0.0f;
		}
	}


	// -Private API-
	private string FindActiveCombo() {
		foreach (ComboSequence sequence in m_Combos.m_Sequences) {
			if (m_CombatBuffer.Match(sequence.m_Combo)) {
				return sequence.m_ComboName;
			}
		}
		return string.Empty;
	}

	private void DispatchCombo(string comboName) {
		Debug.Log(comboName);
	}
}
