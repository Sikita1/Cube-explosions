using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Unit : MonoBehaviour
{
    private float _minChanceSplit = 0f;
    private float _maxChanceSplit = 100f;
    private float _oddsDivider = 2f;

    private float _sizeReduction = 2f;
    private float _radiusIncrease = 2f;
    private float _forceIncrease = 2f;

    private Renderer _renderer;
    private Rigidbody _rigidbody;

    public event Action Splitting;
    public event Action Obliterating;

    public float CurrentChance { get; private set; } = 100f;
    public float CurrentRadiusDestruction { get; private set; } = 20f;
    public float CurrentForceDestruction { get; private set; } = 300f;
    private bool CanSplit { get; set; } = true;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Clicked()
    {
        if (CanSplit)
            Splitting?.Invoke();
        else
            Obliterating?.Invoke();

        Destroy(gameObject);
    }

    public void AddExplosion(float force, Vector3 position, float radius) =>
        _rigidbody.AddExplosionForce(force, position, radius);

    public void Initialize(float parentChance, Vector3 parentScale, float parentForce, float parentRadius)
    {
        SetChance(parentChance);
        SetColor(CreateRandomColor());
        SetSize(parentScale);
        SetForceExtention(parentForce);
        SetRadiusExtension(parentRadius);

        CanSplit = UnityEngine.Random.Range(_minChanceSplit, _maxChanceSplit) < CurrentChance;
    }

    private void SetRadiusExtension(float parentRadius) =>
        CurrentRadiusDestruction = parentRadius * _radiusIncrease;

    private void SetForceExtention(float parentForce) =>
        CurrentForceDestruction = parentForce * _forceIncrease;

    private void SetSize(Vector3 parentScale) =>
        transform.localScale = parentScale / _sizeReduction;

    private void SetChance(float parentChance) =>
        CurrentChance = parentChance / _oddsDivider;


    private Color CreateRandomColor() =>
        new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);

    private Color SetColor(Color color) =>
        _renderer.material.color = color;
}
