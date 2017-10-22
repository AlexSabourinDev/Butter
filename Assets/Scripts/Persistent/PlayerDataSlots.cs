using System.Collections.Generic;

public class PlayerData {

	public string m_CharacterName = "Dummy";
	public CombatInputConverter m_InputConverter = null;
}

public delegate void OnPlayerDataAddedDelegate(PlayerData playerData);
public delegate void OnPlayerDataRemovedDelegate(PlayerData playerData);

public static class PlayerDataSlots {

	// -Data-

	static public OnPlayerDataAddedDelegate OnPlayerDataAdded { get; set; }
	static public OnPlayerDataRemovedDelegate OnPlayerDataRemoved { get; set; }

	static private List<PlayerData> s_PlayerSlots = new List<PlayerData>();

	// -Public API-

	static public int Count { get { return s_PlayerSlots.Count; } }

	static public PlayerData AddPlayer() {

		PlayerData newPlayer = new PlayerData();
		s_PlayerSlots.Add(newPlayer);

		if (OnPlayerDataAdded != null) {
			OnPlayerDataAdded(newPlayer);
		}
		return newPlayer;
	}

	static public void RemovePlayer(int index) {
		UnityEngine.Debug.Assert(index > 0 && index < s_PlayerSlots.Count);

		PlayerData removedPlayer = s_PlayerSlots[index];
		s_PlayerSlots.RemoveAt(index);

		if (OnPlayerDataRemoved != null) {
			OnPlayerDataRemoved(removedPlayer);
		}
	}

	static public PlayerData GetPlayer(int index) {
		UnityEngine.Debug.Assert(index >= 0 && index < s_PlayerSlots.Count);
		return s_PlayerSlots[index];
	}
}