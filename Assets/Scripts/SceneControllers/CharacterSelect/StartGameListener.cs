using UnityEngine;

public class StartGameListener : ButtBehaviour {

	// -Data-

	[SerializeField]
	private int m_PlayersNeededToStart = 2;

	[SerializeField]
	private string m_FightScene = string.Empty;

	[SerializeField, AsInterface(typeof(IAnimation))]
	private ButtBehaviour m_StartAnimation = null;

	[SerializeField, AsInterface(typeof(IAnimation))]
	private ButtBehaviour m_EndAnimation = null;

	private AnyInputDevice m_InputDevice = null;
	private bool m_IsGameReadyToStart = false;

	// -Public API-

	public void AllowGameToStart() {
		m_IsGameReadyToStart = true;
	}

	// -ButtBehaviour API-

	protected override void Awake() {
		base.Awake();

		m_InputDevice = new AnyInputDevice(InputSystem.Instance.Devices);
		m_InputDevice.OnAnyInputReceived += OnInputReceived;
		PlayerDataSlots.OnPlayerDataAdded += OnPlayerAdded;
	}


	protected override void OnDestroy() {
		base.OnDestroy();

		PlayerDataSlots.OnPlayerDataRemoved -= OnPlayerAdded;
		m_InputDevice.OnAnyInputReceived -= OnInputReceived;
		m_InputDevice = null;
	}


	// -Private API-

	private void OnPlayerAdded(PlayerData playerData) {

		if(PlayerDataSlots.Count >= m_PlayersNeededToStart) {
			((IAnimation)m_StartAnimation).StartAnimation(AllowGameToStart);
		}
	}

	private void OnInputReceived(IInputDevice inputDevice, InputEventType inputEvent) {

		if(m_IsGameReadyToStart && inputEvent == InputEventType.Start) {
			((IAnimation)m_EndAnimation).StartAnimation(() => { SceneController.TransitionToScene(m_FightScene); });
		}
	}
}
