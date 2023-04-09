using UnityEngine;
using Thesis;
using DG.Tweening;

public class Drag : MonoBehaviour
{   
    [SerializeField] private bool _canDrag = true;

    private Vector3 _mOffset;
    private float _mZCoord;

    private void OnMouseDown() {
        if (!_canDrag)
            return;

        if (gameObject.TryGetComponent(out BaseClass baseClass))
        {
            baseClass.transform.DOKill();
            baseClass.enabled = false;
        }

        _mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        _mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag() {
        if (!_canDrag)
            return;

        transform.position = GetMouseWorldPos() + _mOffset;
    }
    
    private void OnMouseUp() {
        if (gameObject.TryGetComponent(out BaseClass baseClass))
        {
            baseClass.enabled = true;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = _mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public void SetDrag(bool _bool)
    {
        _canDrag = _bool;
    }
}
