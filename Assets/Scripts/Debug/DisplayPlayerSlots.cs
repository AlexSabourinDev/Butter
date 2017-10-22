namespace ButtDebug {

	public class DisplayPlayerSlots : ButtBehaviour {

		private IWatchValue m_WatchValue = null;

		protected override void Awake() {
			base.Awake();
			m_WatchValue = WatchData.AddWatchValue(new LabelWatchValue(() => { return "Player Slots: " + PlayerDataSlots.Count.ToString(); }));
		}

		protected override void OnDestroy() {
			base.OnDestroy();
			WatchData.RemoveWatchValue(m_WatchValue);
		}
	}
}
