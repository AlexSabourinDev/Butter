using System.Collections.Generic;

// The CombatConverterMap gets loaded and passed to a CombatInputConverter
// The CombatInputConverter then uses this map to transform raw input events to CombatCommands.
public class CombatConverterMap {

	// -Data-
	private Dictionary<InputEventType, CombatCommand> m_CombatMap = new Dictionary<InputEventType, CombatCommand>();

	// -Public API-

	// Map the event type and input data to a CombatCommand
	public CombatCommand Map(InputEventType eventType) {

		CombatCommand command = CombatCommand.None;
		if (m_CombatMap.ContainsKey(eventType)) {
			command = m_CombatMap[eventType];
		}

		return command;
	}
}
