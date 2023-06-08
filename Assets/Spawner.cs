using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPointTransform;
    //[SerializeField] private Coins _coinsPrefab;
    [SerializeField] private Obstacle _obstaclePrefab;
    [SerializeField] private int _poolCount = 4;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private Transform _papPool;

    //private MainPooler<Coins> _coinsPool;
    private MainPooler<Obstacle> _obstaclesPool;

    [SerializeField] private PlayerController _player;

    private void Awake()
    {
        //_coinsPool = new MainPooler<Coins>(_coinsPrefab, _poolCount, _papPool);
        _obstaclesPool = new MainPooler<Obstacle>(_obstaclePrefab, _poolCount, _papPool);
        _obstaclesPool.autoExpand = _autoExpand;
        _player = new PlayerController();
    }

    private void OnEnable()
    {
        _player.Main.Enable();
        _player.Main.Skill1.performed += _ => CreateNewObj();
    }

    private void OnDisable()
    {
        
    }

    private void CreateNewObj()
    {
        var trian = _obstaclesPool.GetFreeElement();
        var rY = Random.Range(-4f, 4f);
        trian.transform.position = new Vector3(_papPool.position.x, rY, _papPool.position.z);
    }
}
