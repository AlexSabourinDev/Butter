using UnityEngine;
using System.Collections.Generic;

internal class InputDeviceListener {

	public delegate void OnInputReceivedDelegate(IInputDevice inputDevice, InputEventType type);
	public delegate void OnDeviceDisconnectDelegate(InputDeviceListener listener);

	private IInputDevice m_RegisteredDevice;
	private OnInputReceivedDelegate m_OnInputReceived;
	private OnDeviceDisconnectDelegate m_OnInputDisconnect;


	public InputDeviceListener(IInputDevice device, OnInputReceivedDelegate onInputReceived, OnDeviceDisconnectDelegate onDeviceDisconnect) {
		Debug.Assert(device != null);
		Debug.Assert(onInputReceived != null);
		Debug.Assert(onDeviceDisconnect != null);

		m_RegisteredDevice = device;
		m_OnInputReceived = onInputReceived;
		m_OnInputDisconnect = onDeviceDisconnect;

		device.OnInputReceived += OnInputReceived;
		device.OnDeviceDisconnect += OnInputDisconnect;
	}

	public void ReleaseData() {
		m_RegisteredDevice.OnInputReceived -= OnInputReceived;
		m_RegisteredDevice.OnDeviceDisconnect -= OnInputDisconnect;

		m_OnInputReceived = null;
		m_OnInputDisconnect = null;
		m_RegisteredDevice = null;
	}

	public bool IsListeningTo(IInputDevice device) {
		return m_RegisteredDevice == device;
	}


	private void OnInputReceived(InputEventType inputEvent) {
		m_OnInputReceived(m_RegisteredDevice, inputEvent);
	}

	private void OnInputDisconnect() {
		m_OnInputDisconnect(this);
	}
}

// The player input listener listens for any input events of interest in order to connect them to a player slot
public class PlayerInputListener : ButtBehaviour {

	// -Data-

	List<InputDeviceListener> m_Listeners = new List<InputDeviceListener>();

	// -ButtBehaviour API-

	protected override void Awake() {
		base.Awake();

		// We look through all the registered devices as there might have already been some devices available
		// and we register them to our listener
		InputDeviceCollection devices = InputSystem.Instance.Devices;
		devices.OnDeviceAdded += OnDeviceAdded;

		foreach (IInputDevice device in devices) {
			m_Listeners.Add(new InputDeviceListener(device, OnInputReceived, RemoveListener));
		}
	}


	// -Private API-

	private void OnDeviceAdded(IInputDevice device) {
		m_Listeners.Add(new InputDeviceListener(device, OnInputReceived, RemoveListener));
	}

	private void OnInputReceived(IInputDevice device, InputEventType eventType) {

		if (eventType == InputEventType.Start) {

			PlayerData playerData = PlayerDataSlots.AddPlayer();
			playerData.m_InputConverter = new CombatInputConverter();
			playerData.m_InputConverter.BindDevice(device);

			// We remove the listener here because we don't want to listen for this device anymore, we just added him to a player slot
			InputDeviceListener listener = m_Listeners.Find((InputDeviceListener l) => { return l.IsListeningTo(device); });
			RemoveListener(listener);
		}
	}

	private void RemoveListener(InputDeviceListener listener) {

		listener.ReleaseData();
		m_Listeners.Remove(listener);
	}
}
