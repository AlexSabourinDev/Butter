using System;

[Serializable]
public class ComboSequence {
	public CombatCommand[] m_Combo;
	public string m_ComboName;
}

[Serializable]
public class ComboList {
	public ComboSequence[] m_Sequences;
}
