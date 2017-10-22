
public delegate void OnAnimationCompleteDelegate();

public interface IAnimation {
	void StartAnimation(OnAnimationCompleteDelegate onAnimationComplete);
	void StopAnimation();
}
