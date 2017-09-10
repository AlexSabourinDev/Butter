using System.Collections.Generic;
using System.Collections;
using UnityEngine;

// Keeps track of all the input devices added to it and notifies others when a device is added
public class InputDeviceCollection {

	public delegate void OnDeviceDelegate(IInputDevice device);


	private List<IInputDevice> m_InputDevices = new List<IInputDevice>();


	private OnDeviceDelegate m_OnDeviceAdded;

	public OnDeviceDelegate OnDeviceAdded { get { return m_OnDeviceAdded; } set { m_OnDeviceAdded = value; } }


	private OnDeviceDelegate m_OnDeviceRemoved;

	public OnDeviceDelegate OnDeviceRemoved { get { return m_OnDeviceRemoved; } set { m_OnDeviceRemoved = value; } }


	public int Count { get { return m_InputDevices.Count; } }

	public IInputDevice this[int index] { get { return m_InputDevices[index]; } }


	public void Add(IInputDevice device) {

		Debug.Assert(m_InputDevices.Contains(device) == false);
		m_InputDevices.Add(device);

		if(OnDeviceAdded != null) OnDeviceAdded(device);
	}

	public void Remove(IInputDevice device) {

		Debug.Assert(m_InputDevices.Contains(device));
		m_InputDevices.Remove(device);

		if(OnDeviceRemoved != null) OnDeviceRemoved(device);
	}

	public bool Contains(IInputDevice device) {

		return m_InputDevices.Contains(device);
	}

	public List<IInputDevice>.Enumerator GetEnumerator() {

		return m_InputDevices.GetEnumerator();
	}
}
