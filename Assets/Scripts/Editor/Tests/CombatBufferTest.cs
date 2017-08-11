using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class CombatBufferTest {

	[Test]
	public void TestCombatBuffer() {

		CombatBuffer buffer = new CombatBuffer(10);

		for (int iter = 0; iter < 1; iter++) {
			for (int i = 0; i < 3; i++) {
				buffer.Write(CombatCommand.Down);
			}
			Debug.Assert(buffer.Count == 3);

			for (int i = 0; i < 20; i++) {
				buffer.Write(CombatCommand.Down);
			}
			Debug.Assert(buffer.Count == 10);

			buffer.Write(CombatCommand.Right);
			Debug.Assert(buffer.Newest() == CombatCommand.Right);
			Debug.Assert(buffer.Oldest() == CombatCommand.Down);

			Debug.Assert(buffer.Match(new CombatCommand[] { CombatCommand.Down }) == false);
			Debug.Assert(buffer.Match(new CombatCommand[] { CombatCommand.Right, CombatCommand.Down }));
			Debug.Assert(buffer.Match(new CombatCommand[] { CombatCommand.Down, CombatCommand.Down }) == false);

			buffer.Write(CombatCommand.Up);
			Debug.Assert(buffer.Match(new CombatCommand[] { CombatCommand.Up, CombatCommand.Right }));

			buffer.ClearCommands();
			Debug.Assert(buffer.Count == 0);
		}
	}
}
