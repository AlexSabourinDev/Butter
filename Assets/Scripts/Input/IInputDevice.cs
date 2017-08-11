
public enum InputState {
	
	Down,
	Held,
	Up,
	None
}

public interface IInputDevice {

	float QueryAxis(InputKey key);
	InputState QueryState(InputKey key);
}
