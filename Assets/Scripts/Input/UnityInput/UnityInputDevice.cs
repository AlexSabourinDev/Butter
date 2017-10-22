
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

		if (Input.GetKeyUp(KeyCode.Return)) {
			m_OnInputReceived(InputEventType.Start);
		}

		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			m_OnInputReceived(InputEventType.Right);
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			m_OnInputReceived(InputEventType.Left);
		}

		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			m_OnInputReceived(InputEventType.Up);
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			m_OnInputReceived(InputEventType.Down);
		}

		if (Input.GetKeyDown(KeyCode.K)) {
			m_OnInputReceived(InputEventType.KeyK);
		}
		if(Input.GetKeyDown(KeyCode.J)) {
			m_OnInputReceived(InputEventType.KeyJ);
		}

	}
}
