using UnityEngine;

public class UnityInputSystem : ButtBehaviour, IInputSystem {

	private InputDeviceCollection m_Devices = new InputDeviceCollection();

	public InputDeviceCollection Devices {
		get {
			return m_Devices;
		}
	}

	protected override void Awake() {

		InputSystem.Instance = this;
		m_Devices.Add(new UnityInputDevice());
	}

	protected override void Update() {
		
		foreach(IInputDevice device in m_Devices) {

			UnityInputDevice unityDevice = (UnityInputDevice)device;
			unityDevice.QueryInputs();
		}
	}
}