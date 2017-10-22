using System;
using UnityEngine;

class UnityAnimation : ButtBehaviour, IAnimation {

	// -Data-
	[SerializeField]
	private Animation m_AnimationPlayer = null;

	[SerializeField]
	private AnimationClip m_Animation = null;

	private bool m_AnimationWasPlaying = false;
	private OnAnimationCompleteDelegate m_OnAnimationComplete;


	// -Public API-
	public void StartAnimation(OnAnimationCompleteDelegate onAnimationComplete) {
		Debug.Assert(onAnimationComplete != null);
		Debug.Assert(m_AnimationPlayer != null);
		Debug.Assert(m_Animation != null);

		m_AnimationPlayer.Play(m_Animation.name);
		m_AnimationWasPlaying = true;
		m_OnAnimationComplete = onAnimationComplete;
	}

	public void StopAnimation() {
		m_AnimationPlayer.Stop();
	}

	// -Buttbehaviour API-
	protected override void Update() {
		base.Update();

		if(m_AnimationWasPlaying && m_AnimationPlayer.isPlaying == false) {
			m_OnAnimationComplete();
			m_AnimationWasPlaying = false;
		}
	}
}