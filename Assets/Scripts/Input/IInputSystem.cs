
// The input system manages the input devices,
// The concept behind it is to abstract away the actual input system,
// thus, allowing the internal input system to vary
public interface IInputSystem {

	InputDeviceCollection Devices { get; }
}

public static class InputSystem {

	private static IInputSystem s_Instance;

	public static IInputSystem Instance {
		get {
			return s_Instance;
		}

		set {
			UnityEngine.Debug.Assert(s_Instance == null, "There is already an active input system!");
			s_Instance = value;
		}
	}
}