using UnityEngine;

public class Spawner : ObjectsPool
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private GameObject _objectPrefab;
    [SerializeField] private float _secondsBetweenSpawn;

    private Transform[] _points;
    private float _elapsedTime;
    private int _currentPoint = 0;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];
        Initialize(_objectPrefab, _spawnPoints.childCount);

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _spawnPoints.GetChild(i);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;

                SetObject(enemy, _points[_currentPoint].position);

                _currentPoint += 1;
            }
        }
    }

    private void SetObject(GameObject obj, Vector2 spawnPoint)
    {
        obj.SetActive(true);
        obj.transform.position = spawnPoint;
    }
}
