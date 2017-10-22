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

public delegate void OnAnyInputReceivedDelegate(IInputDevice device, InputEventType eventType);

public class AnyInputDevice {

	// -Data-

	public OnAnyInputReceivedDelegate OnAnyInputReceived { get; set; }

	private List<InputDeviceListener> m_Listeners = new List<InputDeviceListener>();

	// -Public API-

	public AnyInputDevice(InputDeviceCollection devices)
	{
		// We look through all the registered devices as there might have already been some devices available
		// and we register them to our listener
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

		if(OnAnyInputReceived != null) {
			OnAnyInputReceived(device, eventType);
		}
	}

	private void RemoveListener(InputDeviceListener listener) {

		listener.ReleaseData();
		m_Listeners.Remove(listener);
	}

}
