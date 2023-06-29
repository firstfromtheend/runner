using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instanceGM;
    //[SerializeField] private float _spawnSpeed = Mathf.Clamp(0.5f, 0f, 10f);
    [SerializeField] private float _spawnSpeed = 0.5f;
    public float MovementSpeed { get { return _spawnSpeed; }}
    [SerializeField] private bool playerAlive = true;
    public bool PlayerAlive{ get { return playerAlive; } }

    private void Awake()
    {
        if (instanceGM != null) Destroy(gameObject);
        else instanceGM = this;
        DontDestroyOnLoad(gameObject);
    }
}
