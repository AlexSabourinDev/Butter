using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;

public class UnityEditorClass {

	[PostProcessBuild]
	public static void BuildGame(BuildTarget target, string pathToBuiltProject) {

		string filename = Path.GetFileNameWithoutExtension(pathToBuiltProject);

		string source = Application.dataPath + "/External/";
		string destination = string.Format("{0}/{1}_Data/{2}/", Path.GetDirectoryName(pathToBuiltProject), filename, "External");

		//Now Create all of the directories
		foreach (string dirPath in Directory.GetDirectories(source, "*", SearchOption.AllDirectories)) {
			Directory.CreateDirectory(dirPath.Replace(source, destination));
		}

		//Copy all the files & Replaces any files with the same name
		foreach (string newPath in Directory.GetFiles(source, "*.json", SearchOption.AllDirectories)) {
			File.Copy(newPath, newPath.Replace(source, destination), true);
		}
	}
}
