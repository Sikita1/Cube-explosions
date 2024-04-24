using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Unit : MonoBehaviour
{
    [SerializeField] private Destruction _destruction;

    private float _minChanceSplit = 0f;
    private float _maxChanceSplit = 100f;
    private float _oddsDivider = 2f;

    private Renderer _renderer;

    public event Action Clicked;

    public float CurrentChance { get; private set; } = 100f;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnMouseUpAsButton()
    {
        _destruction.Explode();
        Clicked?.Invoke();
    }

    public void SetChance(float parentChance)
    {
        CurrentChance = parentChance / _oddsDivider;
    }

    public bool CanSplit()
    {
        float chance = UnityEngine.Random.Range(_minChanceSplit, _maxChanceSplit);

        return chance <= CurrentChance;
    }

    internal void SetColor(Color color) =>
        _renderer.material.color = color;
}
