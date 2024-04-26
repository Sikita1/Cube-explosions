using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    [SerializeField] private Unit _prefab;

    public Unit Create(Vector3 position)
    {
        Unit unit = Instantiate(_prefab, position, Quaternion.identity);
        unit.Initialize(_prefab.CurrentChance, _prefab.transform.localScale);

        return unit;
    }
}
