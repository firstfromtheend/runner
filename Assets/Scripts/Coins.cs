using System.Collections;
using UnityEngine;

public class Coins : MonoBehaviour {
    [SerializeField] private float _moveSpeed = 3f;

    [SerializeField] private Animator _coinAnimator;
    string currentAnimaton;

    const string _spinAnim = "coinSpin";
    const string _collectedAnim = "coinCollected";

    private void Awake()
    {
        _coinAnimator = GetComponent<Animator>();
    }

    private void OnEnable() {
        ChangeAnimationState(_spinAnim);
    }

    private void OnDisable()
    {
        StopCoroutine("CoinCollected");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //StartCoroutine("CoinCollected");
            gameObject.SetActive(false);
        }
    }

    private void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        _coinAnimator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }

    IEnumerator CoinCollected()
    {
        ChangeAnimationState(_collectedAnim);
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _moveSpeed);
    }
}