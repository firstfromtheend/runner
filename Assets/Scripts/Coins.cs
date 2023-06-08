using UnityEngine;

public class Coins : MonoBehaviour {
    [SerializeField] private Animator _coinAnimator;
    string currentAnimaton;

    const string _spinAnim = "spin coin animation";
    const string _collectedAnim = "coin collected";

    private void OnEnable() {
        ChangeAnimationState(_spinAnim);
    }

    private void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        _coinAnimator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }
}