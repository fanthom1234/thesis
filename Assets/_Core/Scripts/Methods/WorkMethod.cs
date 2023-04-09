using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Thesis;

public class WorkMethod : Method
{
    public override float actingDuration => 4f;
    
    public Transform targetTFassign;
    public override Transform targetTF => targetTFassign;

    public VariableType variableType = VariableType.Wealthiness;
    public override VariableType variableNeeded => variableType;

    public GameObject newVisual;

    public override void Action(GameObject from)
    {
        from.transform.DOMove(targetTF.position, 6f).SetEase(Ease.OutCubic);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.TryGetComponent(out BaseClass baseClass))
        {
            Transform parent = other.transform;
            Destroy(parent.GetChild(0).gameObject);

            GameObject newVisualBro = GameObject.Instantiate(newVisual, parent);
            // this.gameObject.SetActive(false);
        }
    }
}
