using UnityEditor;
using UnityEngine;

public class WatchWindow : EditorWindow {


	[MenuItem("Window/Butter/Debug/Watch Window %W")]
	static private void InitializeWindow() {
		// Get existing open window or if none, make a new one:
		WatchWindow window = (WatchWindow)EditorWindow.GetWindow(typeof(WatchWindow));
		window.Show();
	}

	// -Data-
	private Vector2 m_ScrollPosition = Vector2.zero;

	// -Editor Window API-

	private void OnGUI() {

		EditorGUILayout.LabelField("Watch Values");
		// Draw a straight line
		GUILayout.Box("", new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.Height(1) });

		m_ScrollPosition = EditorGUILayout.BeginScrollView(m_ScrollPosition);

		foreach (IWatchValue watchValue in WatchData.WatchValues) {
			watchValue.Draw();
		}

		EditorGUILayout.EndScrollView();

		Repaint();
	}
}
