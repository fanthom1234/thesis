using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thesis;

namespace Thesis
{
    public class MethodAction : Method
    {
        public Method currentMethod;

        protected override void OnCollisionEnter(Collision other) {
        if (other.gameObject.TryGetComponent(out BaseClass baseClass))
        {
            if (currentMethod is GrowMethod)
            {
                GrowMethod gm = (GrowMethod)currentMethod;
                gm.targetScale = baseClass.gameObject.transform;
                // (GrowMethod)currentMethod.targetScale = baseClass.transform;
                currentMethod = gm;
            }
        }

        base.OnCollisionEnter(other);
    } 

        public override IEnumerator Action(BaseClass baseClass)
        {
            currentMethod.variable = this.variable;
            StartCoroutine(currentMethod.Action(baseClass));

            yield return null;
        }
    }
}
