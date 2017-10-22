using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public static class SceneController {

	// <SceneID, SceneTransition>
	private static Dictionary<string, ISceneTransition> s_SceneTransitions = new Dictionary<string, ISceneTransition>();

	// -Public API-
	public static void SetSceneTransition(string sceneID, ISceneTransition sceneTransition) {
		Debug.Assert(s_SceneTransitions.ContainsKey(sceneID) == false);
		s_SceneTransitions.Add(sceneID, sceneTransition);
	}

	public static void TransitionToScene(string sceneID, params object[] transferData) {

		if (s_SceneTransitions.ContainsKey(sceneID)) {

			ISceneTransition transition = s_SceneTransitions[sceneID];
			bool transitionResults = transition.TransitionTo(sceneID, transferData);

			if (transitionResults == false) {
				Debug.LogWarning(string.Format("{0} failed to transition to {1}. Falling back on default transition!", transition.GetType().Name, sceneID));
				DefaultTransition(sceneID);
			}
		}
		else {

			DefaultTransition(sceneID);
		}
	}

	// -Private API-
	private static void DefaultTransition(string sceneID) {
		SceneManager.LoadScene(sceneID);
	}
}
