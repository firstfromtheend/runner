using System.Collections;
using System.Drawing.Text;
using Unity.VisualScripting;
using UnityEngine;

public class PControls : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1f;
    [SerializeField] private int _playerHealths = 2;


    private PlayerController _playerController;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _playerController = new PlayerController();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerController.Main.Enable();
        _playerController.Main.Jump.performed += _ => Jump();
    }

    private void OnDisable()
    {
        _playerController.Main.Disable();
    }


    private void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private IEnumerator DeathFlag()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1f);
        LevelController.instanceLC.LoadMainMenu();
    }

    private void HealthDecreaser()
    {
        _playerHealths--;
        if (_playerHealths <= 0)
            StartCoroutine("DeathFlag");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle")) HealthDecreaser();
    }
}
