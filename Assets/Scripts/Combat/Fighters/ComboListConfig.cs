using System.Collections.Generic;
using System;

[Serializable]
public class ComboSequenceConfig {
	public string[] m_ComboSequence;
	public string m_ComboName;
}

[Serializable]
public class ComboListConfig {
	public ComboSequenceConfig[] m_Sequences;


	public ComboList ToComboList() {
		ComboList list = new ComboList();

		List<ComboSequence> sequences = new List<ComboSequence>();
		foreach (ComboSequenceConfig sequenceConfig in m_Sequences) {
			ComboSequence sequence = new ComboSequence();
			sequence.m_ComboName = sequenceConfig.m_ComboName;

			List<CombatCommand> combatSequence = new List<CombatCommand>();
			foreach (string command in sequenceConfig.m_ComboSequence) {
				combatSequence.Add((CombatCommand)Enum.Parse(typeof(CombatCommand), command));
			}
			sequence.m_Combo = combatSequence.ToArray();

			sequences.Add(sequence);
		}

		list.m_Sequences = sequences.ToArray();
		return list;
	}
}
