using UnityEngine;
using System.IO;

public static class ExternalJson {
	public static Json LoadJSON<Json>(string jsonPath) {
		string file = File.ReadAllText(string.Format("{0}/External/{1}.json", Application.dataPath, jsonPath));
		Json item = JsonUtility.FromJson<Json>(file);
		return item;
	}
}
