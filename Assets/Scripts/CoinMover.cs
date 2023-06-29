using System.Collections;
using UnityEngine;

public class CoinMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;
    private ParticleSystem _particleSystem;
    private SpriteRenderer _spriteReneder;
    private AudioSource _audioSource;

    private void OnEnable()
    {
        _spriteReneder.gameObject.SetActive(true);
        _spriteReneder.enabled = true;
    }

    private void Awake()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _spriteReneder = GetComponentInChildren<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _spriteReneder.enabled = false;
            StartCoroutine("CoinCollected");
        }
    }

    private IEnumerator CoinCollected()
    {
        _particleSystem.Play();
        _audioSource.Play();
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }
}