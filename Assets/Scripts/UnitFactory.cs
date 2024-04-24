using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    [SerializeField] private Unit _prefab;

    private float _sizeReduction = 2f;

    public Unit Create(Vector3 position)
    {
        Unit unit = Instantiate(_prefab, position, Quaternion.identity);
        unit.transform.localScale /= _sizeReduction;
        unit.SetChance(_prefab.CurrentChance);
        unit.SetColor(CreateRandomColor());

        return unit;
    }

    private Color CreateRandomColor() =>
        new Color(Random.value, Random.value, Random.value);
}
