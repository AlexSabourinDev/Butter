using UnityEngine;

class PlayerSpawn : ButtBehaviour {

	[SerializeField]
	private int m_PlayerSlotToSpawn = 0;

	[SerializeField]
	private string m_DefaultCharacter = "Dummy";

	// -ButtBehaviour API-

	protected override void Awake() {
		base.Awake();

		string characterName = m_DefaultCharacter;

		if (m_PlayerSlotToSpawn < PlayerDataSlots.Count) {
			PlayerData playerData = PlayerDataSlots.GetPlayer(m_PlayerSlotToSpawn);
			characterName = playerData.m_CharacterName;
		}

		CharacterConfig config = ExternalJson.LoadJSON<CharacterConfig>("Characters/" + characterName);
		SpawnCharacter(config);
	}


	// -Private API-

	private void SpawnCharacter(CharacterConfig config) {
		GameObject templateCharacter = Resources.Load<GameObject>("Characters/Templates/" + config.m_CharacterTemplate);
		GameObject spawnedCharacter = Instantiate(templateCharacter);

		spawnedCharacter.transform.position = transform.position;
		spawnedCharacter.transform.rotation = transform.rotation;

		FighterController fighterController = spawnedCharacter.GetComponent<FighterController>();
		fighterController.SetCombos(config.m_ComboList.ToComboList());

		if (m_PlayerSlotToSpawn < PlayerDataSlots.Count) {
			PlayerData playerData = PlayerDataSlots.GetPlayer(m_PlayerSlotToSpawn);
			playerData.m_InputConverter.BindController(fighterController);
		}
	}

}
