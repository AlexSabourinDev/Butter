using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class CombatInputGenerationTest {

	[Test]
	public void TestCombatInputGeneration() {

		CombatBuffer buffer = new CombatBuffer(50);
		TestCommandInput input = new TestCommandInput();

		input.BindConsumer(buffer.Write);

		// Generate input
		input.GenerateInput(CombatCommand.Down);
		input.GenerateInput(CombatCommand.Left);
		input.GenerateInput(CombatCommand.Right);
		input.GenerateInput(CombatCommand.Down);
		input.GenerateInput(CombatCommand.Up);
		input.GenerateInput(CombatCommand.Up);

		CombatCommand[][] commands = new CombatCommand[3][];
		commands[0] = new CombatCommand[] { CombatCommand.Up, CombatCommand.Up };
		commands[1] = new CombatCommand[] { CombatCommand.Left, CombatCommand.Left, CombatCommand.Down };
		commands[2] = new CombatCommand[] { CombatCommand.Up, CombatCommand.Up, CombatCommand.Down };

		Debug.Assert(buffer.Match(commands[0]));
		Debug.Assert(buffer.Match(commands[1]) == false);
		Debug.Assert(buffer.Match(commands[2]));

		// Generate a ton of input
		for(int i = 0; i < 100; i++) {
			input.GenerateInput(CombatCommand.Down);
			input.GenerateInput(CombatCommand.Left);
			input.GenerateInput(CombatCommand.Right);
			input.GenerateInput(CombatCommand.Down);
			input.GenerateInput(CombatCommand.Up);
			input.GenerateInput(CombatCommand.Up);
		}

		input.UnbindConsumer(buffer.Write);
	}
}