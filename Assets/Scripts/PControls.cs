using UnityEngine;

public class PControls : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1f;

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
}
