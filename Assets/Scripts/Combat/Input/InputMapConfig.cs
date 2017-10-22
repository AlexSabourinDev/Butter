using System;
using System.Collections.Generic;

[Serializable]
public struct InputPairConfig {
	public string m_InputKey;
	public string m_CombatCommand;
}

[Serializable]
public class InputMapConfig {
	public InputPairConfig[] m_InputMap;

	public CombatConverterMap ToConverterMap() {
		CombatConverterMap converter = new CombatConverterMap();

		Dictionary<InputEventType, CombatCommand> converterMap = new Dictionary<InputEventType, CombatCommand>();
		foreach(InputPairConfig config in m_InputMap) {
			InputEventType inputEvent = (InputEventType)Enum.Parse(typeof(InputEventType), config.m_InputKey);
			CombatCommand combatCommand = (CombatCommand)Enum.Parse(typeof(CombatCommand), config.m_CombatCommand);

			converterMap.Add(inputEvent, combatCommand);
		}
		converter.SetCombatMap(converterMap);

		return converter;
	}
}