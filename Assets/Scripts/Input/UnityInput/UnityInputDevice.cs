
using System;
using UnityEngine;

public class UnityInputDevice : IInputDevice {

	private OnInputReceivedDelegate m_OnInputReceived;
	public OnInputReceivedDelegate OnInputReceived {
		get {
			return m_OnInputReceived;
		}

		set {
			m_OnInputReceived = value;
		}
	}

	private OnDeviceDisconnectDelegate m_OnDeviceDisconnect;
	public OnDeviceDisconnectDelegate OnDeviceDisconnect {
		get {
			return m_OnDeviceDisconnect;
		}

		set {
			m_OnDeviceDisconnect = value;
		}
	}

	public void QueryInputs() {

		if(Input.GetKeyDown(KeyCode.Return)) {
			m_OnInputReceived(InputEventType.Start, null);
		}
	}
}
