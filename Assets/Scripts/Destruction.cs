using System.Collections.Generic;
using UnityEngine;


public class Destruction : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(List<Unit> units)
    {
        units
            .ForEach(rigidbody => rigidbody
            .AddExplosion(_explosionForce, transform.position, _explosionRadius));
    }
}
