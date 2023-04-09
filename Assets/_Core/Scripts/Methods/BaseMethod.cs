using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using Thesis;
using Polyperfect.Animals;

public class BaseMethod : Method
{   
    [SerializeField] private bool isAgentAI = false;

    public override float actingDuration => 2f;
    
    public Transform targetTFassign;
    public override Transform targetTF => targetTFassign;

    public VariableType variableType = VariableType.Tiredness;
    public override VariableType variableNeeded => variableType;

    public override void Action(GameObject from)
    {
        if (from) {
            if (from.GetComponentInChildren<Animal_WanderScript>())
            {
                from.GetComponentInChildren<Animal_WanderScript>().enabled = false;
                from.GetComponentInChildren<NavMeshAgent>().enabled = false;
            }
        }

        if (isAgentAI)
        {
            from.GetComponent<NavMeshAgent>().SetDestination(targetTF.position);
        }
        else
            from.transform.DOMove(targetTF.position, 2f).SetEase(Ease.OutCubic)
                    .OnComplete(() => from.transform.DOJump(from.transform.position, 1, 4, 5f));
    }
}
