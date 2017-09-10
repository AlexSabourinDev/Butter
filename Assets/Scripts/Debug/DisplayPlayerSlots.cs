using UnityEngine;


namespace ButtDebug {

	public class DisplayPlayerSlots : ButtBehaviour {

		private void OnGUI() {

			GUILayout.Label(PlayerDataSlots.Length.ToString());
		}
	}
}
