using UnityEngine;

public class MouseRaycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _layerMask;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == false)
            return;

        if (TryGetUnit(out Unit unit) == false)
            return;

        unit.Clicked();
    }

    private bool TryGetUnit(out Unit model)
    {
        model = null;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, _layerMask.value) == false)
            return false;

        if (raycastHit.collider.TryGetComponent<Unit>(out Unit unit) == false)
            return false;

        model = unit;

        return true;
    }
}
