using UnityEngine;

public class GoToScene : ButtBehaviour {

	[SerializeField]
	private string m_SceneName;

	protected override void Awake() {
		base.Awake();

		SceneController.TransitionToScene(m_SceneName);
	}
}