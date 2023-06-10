using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CoinMover _coinsPrefab;
    [SerializeField] private Obstacle _obstaclePrefab;
    [SerializeField] private int _poolCount = 4;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private Transform _papPool;
    [SerializeField] private GameManager _gameManager;


    private MainPooler<CoinMover> _coinsPool;
    private MainPooler<Obstacle> _obstaclesPool;

    private void Awake()
    {
        _coinsPool = new MainPooler<CoinMover>(_coinsPrefab, _poolCount, _papPool);
        _coinsPool.autoExpand = _autoExpand;
        _obstaclesPool = new MainPooler<Obstacle>(_obstaclePrefab, _poolCount, _papPool);
        _obstaclesPool.autoExpand = _autoExpand;
    }

    private void OnEnable()
    {
        StartCoroutine("SpawnerCoroutine");
    }

    private void CreateNewObj()
    {

        var rCOunter = Random.Range(0f, 1f);
        if (rCOunter > 0.9f)
        {
            var trian = _obstaclesPool.GetFreeElement();
            var rY = Random.Range(-4f, 4f);
            trian.transform.position = new Vector3(_papPool.position.x, rY, _papPool.position.z);
        }
        else
        {
            var trianC = _coinsPool.GetFreeElement();
            var rcY = Random.Range(-4f, 4f);
            trianC.transform.position = new Vector3(_papPool.position.x, rcY, _papPool.position.z);
        }
    }

    private IEnumerator SpawnerCoroutine()
    {
        while (_gameManager.PlayerAlive)
        {
            yield return new WaitForSeconds(_gameManager.MovementSpeed);
            CreateNewObj();
        }
    }
}
