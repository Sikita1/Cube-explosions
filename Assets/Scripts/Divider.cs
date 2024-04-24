using UnityEngine;

public class Divider : MonoBehaviour
{
    [SerializeField] private Unit _prefab;
    [SerializeField] private UnitFactory _factoryUnit;

    private int _minRandomCount = 2;
    private int _maxRandomCount = 6;

    private void OnEnable()
    {
        _prefab.Clicked += OnCliked;
    }

    private void OnDisable()
    {
        _prefab.Clicked -= OnCliked;
    }

    private void OnCliked()
    {
        int randomCount = Random.Range(_minRandomCount, _maxRandomCount);

        if (_prefab.CanSplit())
        {
            for (int i = 0; i < randomCount; i++)
                _factoryUnit.Create(_prefab.transform.position);

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
