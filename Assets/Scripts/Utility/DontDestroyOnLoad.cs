using UnityEngine;

public class DontDestroyOnLoad : ButtBehaviour {

	protected override void Awake() {

		DontDestroyOnLoad(this.gameObject);
	}
}
