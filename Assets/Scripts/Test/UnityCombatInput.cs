using System;
using UnityEngine;

public class UnityCombatInput : ButtBehaviour, IProducer<CombatCommand> {

	private ConsumerDelegate<CombatCommand> m_Consumers;

	public ConsumerDelegate<CombatCommand> Consumers {
		get {
			return m_Consumers;
		}
	}

	public void BindConsumer(ConsumerDelegate<CombatCommand> consumer) {

		m_Consumers += consumer;
	}

	public void UnbindConsumer(ConsumerDelegate<CombatCommand> consumer) {

		m_Consumers -= consumer;
	}

	protected override void Update() {
		
		if(Input.GetKeyDown(KeyCode.D)) {

			m_Consumers(CombatCommand.Right);
		}
		else if(Input.GetKeyDown(KeyCode.A)) {

			m_Consumers(CombatCommand.Left);
		}
	}
}
