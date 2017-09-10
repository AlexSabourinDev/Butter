using System.Collections.Generic;

public struct PlayerData {

	public CombatInputConverter m_InputConverter;
}

public static class PlayerDataSlots {

	// -Data-

	static private List<PlayerData> s_PlayerSlots = new List<PlayerData>();

	// -Public API-

	static public int Length { get { return s_PlayerSlots.Count; } }

	static public PlayerData AddPlayer() {
		s_PlayerSlots.Add(new PlayerData());
		return s_PlayerSlots[s_PlayerSlots.Count - 1];
	}

	static public void RemovePlayer(int index) {
		UnityEngine.Debug.Assert(index > 0 && index < s_PlayerSlots.Count);
		s_PlayerSlots.RemoveAt(index);
	}

	static public PlayerData GetPlayer(int index) {
		UnityEngine.Debug.Assert(index > 0 && index < s_PlayerSlots.Count);
		return s_PlayerSlots[index];
	}
}