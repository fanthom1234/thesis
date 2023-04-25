using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Thesis
{
    public class MoveMethod : Method
    {
        public List<Transform> destinations;

        public override IEnumerator Action(BaseClass baseClass)
        {
            Transform baseClassTF = baseClass.gameObject.transform;

            foreach (Transform destination in destinations)
            {
                if (Vector3.Distance(baseClassTF.position, destination.position) <= 0.1)
                {
                    Jump(baseClassTF);
                }

                baseClassTF
                    .DOMove(destination.position, 2.5f)
                    .SetEase(Ease.OutCubic)
                    .OnComplete(() => {
                        baseClassTF.DOLookAt(Player.playerTF.position, 1.5f);
                        Jump(baseClassTF);
                    });
            }
            
            yield return null;
        }

        private void Jump(Transform go)
        {
            go.DOJump(go.transform.position, 1, 2, 2f);
        }
    }
}
