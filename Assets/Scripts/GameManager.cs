using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField] private float _spawnSpeed = Mathf.Clamp(0.5f, 0f, 10f);
    public float MovementSpeed { get { return _spawnSpeed; }}
    [SerializeField] private bool playerAlive = true;
    public bool PlayerAlive{ get { return playerAlive; } }

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

}
