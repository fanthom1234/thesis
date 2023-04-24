using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Thesis
{
    public class MoveMethod : Method
    {
        public Transform destination;

        public override void Action(BaseClass baseClass)
        {
            Transform baseClassTF = baseClass.gameObject.transform;

            if (Vector3.Distance(baseClassTF.position, destination.position) <= 0.1)
            {
                Jump(baseClassTF);
                return;
            }

            baseClassTF
                .DOMove(destination.position, 2.5f)
                .SetEase(Ease.OutCubic)
                .OnComplete(() => {
                    baseClassTF.DOLookAt(Player.playerTF.position, 1.5f);
                    Jump(baseClassTF);
                });
        }

        private void Jump(Transform go)
        {
            go.DOJump(go.transform.position, 1, 2, 2f);
        }
    }
}
