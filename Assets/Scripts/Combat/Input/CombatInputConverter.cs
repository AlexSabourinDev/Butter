

public class CombatInputConverter {

	// -Data-

	private IInputDevice m_InputDevice;
	private ICombatController m_Controller;

	private CombatConverterMap m_Converter;


	// -Public API-

	public void BindDevice(IInputDevice device) {
		UnityEngine.Debug.Assert(device != null);
		UnityEngine.Debug.Assert(m_InputDevice == null, "Attempting to bind a device to an already bound converter!");
		m_InputDevice = device;

		// Register to the devices disconnect in order to assure that we handle it gracefully when a device disconnects
		m_InputDevice.OnInputReceived += OnInputReceived;
		m_InputDevice.OnDeviceDisconnect += OnDeviceDisconnect;
	}

	public void BindController(ICombatController controller) {
		UnityEngine.Debug.Assert(controller != null);
		UnityEngine.Debug.Assert(m_Controller == null, "Attempting to bind a combat controller to an already bound device!");
		m_Controller = controller;
	}

	public void SetConverterMap(CombatConverterMap converter) {
		UnityEngine.Debug.Assert(converter != null);
		m_Converter = converter;
	}


	// -Private API-

	private void OnDeviceDisconnect() {
		// If this asserts, did we bind to more than one event? If so, investigate.
		UnityEngine.Debug.Assert(m_InputDevice != null, "OnDeviceDisconnect was invoked while no device connected.");

		m_InputDevice.OnInputReceived -= OnInputReceived;
		m_InputDevice.OnDeviceDisconnect -= OnDeviceDisconnect;
		m_InputDevice = null;
	}

	private void OnInputReceived(InputEventType eventType) {
		if (m_Controller == null) return;
		if (m_Converter == null) {
			UnityEngine.Debug.LogWarning("No converter map bound to the CombatInputConverter!");
			return;
		}

		CombatCommand command = m_Converter.Map(eventType);
		m_Controller.ReceiveCommand(command);
	}
}
