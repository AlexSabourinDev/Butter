using UnityEngine;
using System.Collections.Generic; 

// The player input listener listens for any input events of interest in order to connect them to a player slot
public class PlayerInputListener : ButtBehaviour {

	// -Data-

	private AnyInputDevice m_AnyInput;
	private List<IInputDevice> m_IgnoredDevices = new List<IInputDevice>();

	// -ButtBehaviour-

	protected override void Awake() {
		base.Awake();

		m_AnyInput = new AnyInputDevice(InputSystem.Instance.Devices);
		m_AnyInput.OnAnyInputReceived += OnInputReceived;
	}

	protected override void OnDestroy() {
		base.OnDestroy();

		m_AnyInput.OnAnyInputReceived -= OnInputReceived;
		m_AnyInput = null;
	}

	// -Private API-

	private void OnInputReceived(IInputDevice device, InputEventType inputEvent) {

		if (inputEvent == InputEventType.Start) {
			 
			if(m_IgnoredDevices.Contains(device)) {
				return;
			}

			PlayerData playerData = PlayerDataSlots.AddPlayer();
			playerData.m_InputConverter = new CombatInputConverter();

			InputMapConfig inputMap = ExternalJson.LoadJSON<InputMapConfig>("Input/ConverterMap");
			playerData.m_InputConverter.SetConverterMap(inputMap.ToConverterMap());

			playerData.m_InputConverter.BindDevice(device);

			m_IgnoredDevices.Add(device);
		}
	}
}
