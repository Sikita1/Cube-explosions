using System.Collections.Generic;
using UnityEngine;

public class Divider : MonoBehaviour
{
    [SerializeField] private Unit _prefab;
    [SerializeField] private UnitFactory _factoryUnit;
    [SerializeField] private Destruction _destruction;

    [SerializeField] private float _radiusSphere;

    private int _minRandomCount = 2;
    private int _maxRandomCount = 6;
    private float _maximumTurn = 360f;

    private void OnEnable()
    {
        _prefab.Splitting += OnSpliting;
    }

    private void OnDisable()
    {
        _prefab.Splitting -= OnSpliting;
    }

    private void OnSpliting()
    {
        List<Unit> units = new List<Unit>();

        int randomCount = Random.Range(_minRandomCount, _maxRandomCount);

        for (int i = 0; i < randomCount; i++)
        {
            var position = CalculateRandomPosition(_prefab.transform.position, _radiusSphere);
            units.Add(_factoryUnit.Create(position));
        }

        _destruction.Explode(units);
    }

    private Vector3 CalculateRandomPosition(Vector3 position, float radius) =>
        CalculateRandomRotation() * Vector3.forward * radius + position;

    private Quaternion CalculateRandomRotation() =>
        Quaternion.Euler(0, Random.Range(0, _maximumTurn), 0);
}
