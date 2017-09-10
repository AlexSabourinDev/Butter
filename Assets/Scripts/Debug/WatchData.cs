using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

public interface IWatchValue {

	void Draw();
}

public class LabelWatchValue : IWatchValue {

	public delegate string GetLabelDelegate();

	private GetLabelDelegate m_GetLabel;


	public LabelWatchValue(GetLabelDelegate getLabel) {
		UnityEngine.Debug.Assert(getLabel != null);
		m_GetLabel = getLabel;
	}

	public void Draw() {
#if UNITY_EDITOR
		EditorGUILayout.LabelField(m_GetLabel());
#endif
	}
}

public static class WatchData {

	// -Static Data-

	static private List<IWatchValue> s_WatchValues = new List<IWatchValue>();
	static public List<IWatchValue> WatchValues { get { return s_WatchValues; } }

	// -Static API-

	static public IWatchValue AddWatchValue(IWatchValue watchValue) {

		s_WatchValues.Add(watchValue);
		return watchValue;
	}

	static public void RemoveWatchValue(IWatchValue watchValue) {
		s_WatchValues.Remove(watchValue);
	}
}


