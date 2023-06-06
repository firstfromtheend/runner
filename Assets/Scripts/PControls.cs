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
        _playerController.Main.Jump.performed -= _ => Jump();
    }

    private void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //    private void FixedUpdate()
    //    {
    //        Jump();
    //    }
}
