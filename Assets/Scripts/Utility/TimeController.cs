using UnityEngine;

public enum TimeCategory {
	Gameplay = 0,
	Max
}

public static class TimeController {

	private static EnumArray<TimeCategory, float> s_TimeScales = new EnumArray<TimeCategory, float>(1.0f);

	public static void SetTimeScale(TimeCategory category, float timescale) {
		s_TimeScales[category] = timescale;
	}

	public static float GetTimeScale(TimeCategory category) {
		return s_TimeScales[category];
	}

	public static float GetDeltaTime(TimeCategory category) {
		return Time.deltaTime * s_TimeScales[category];
	}
}
