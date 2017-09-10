using System;
using UnityEngine;

public class FighterController : ButtBehaviour, ICombatController {

	public void ReceiveCommand(CombatCommand command) {
		
		if(command == CombatCommand.Right) {
			transform.position += Vector3.right;
		}
		else if(command == CombatCommand.Left) {
			transform.position += Vector3.left;
		}
	}
}
