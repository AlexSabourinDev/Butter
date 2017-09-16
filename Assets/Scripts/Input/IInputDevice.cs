
public enum InputEventType {

	Left,
	Right,
	Down,
	Up,
	Start,
}

public delegate void OnInputReceivedDelegate(InputEventType eventType);
public delegate void OnDeviceDisconnectDelegate();

// The input device will invoke events whenever input is received, allowing other classes to handle
// the functionality
public interface IInputDevice {

	OnInputReceivedDelegate OnInputReceived { get; set; }
	OnDeviceDisconnectDelegate OnDeviceDisconnect { get; set; }
}
