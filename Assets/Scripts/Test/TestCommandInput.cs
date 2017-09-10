 
using System;

public class TestCommandInput : IProducer<CombatCommand> {

	private ConsumerDelegate<CombatCommand> m_Consumers;

	public ConsumerDelegate<CombatCommand> Consumers { get { return m_Consumers; } }

	public void BindConsumer(ConsumerDelegate<CombatCommand> consumer) {
		m_Consumers += consumer;
	}

	public void UnbindConsumer(ConsumerDelegate<CombatCommand> consumer) {
		m_Consumers -= consumer;
	}

	public void GenerateInput(CombatCommand command) {
		m_Consumers(command);
	}
}
