using System;
using UnityEngine;

public class PControls : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1f;

    private PlayerController _playerController;
    private Rigidbody2D _rb;

    /// <summary>
    /// test zone
    /// </summary>
    [SerializeField] private int _poolCount = 4;
    [SerializeField] private TestForPool _prefabMy;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private Transform _papPool;

    private CoinPool<TestForPool> _pool;

    private void Awake()
    {
        _playerController = new PlayerController();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerController.Main.Enable();
        _playerController.Main.Jump.performed += _ => Jump();
        _playerController.Main.Skill1.performed += _ => CreateNewObj();
    }

    private void OnDisable()
    {
        _playerController.Main.Disable();
        _playerController.Main.Skill1.performed -= _ => CreateNewObj();
    }

    private void CreateNewObj()
    {
        var trian = this._pool.GetFreeElement();
        trian.transform.position = new Vector3(1, 1, 1);
    }

    private void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }


    // Start is called before the first frame update
    void Start()
    {
        this._pool = new CoinPool<TestForPool>(_prefabMy, _poolCount, _papPool);
        this._pool.autoExpand = _autoExpand;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
