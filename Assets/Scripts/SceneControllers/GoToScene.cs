using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : ButtBehaviour {

	[SerializeField]
	private string m_SceneName;

	protected override void Awake() {
		base.Awake();

		SceneManager.LoadScene(m_SceneName);
	}
}