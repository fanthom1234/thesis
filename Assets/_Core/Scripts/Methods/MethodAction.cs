using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thesis;

namespace Thesis
{
    public class MethodAction : Method
    {
        public Method currentMethod;
        public GameObject vfxPrefab;

        protected override void OnTriggerEnter(Collider other) {
            base.OnTriggerEnter(other);
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

            GameObject vfxObject = GameObject.Instantiate(vfxPrefab, transform.position, Quaternion.identity);
            vfxObject.SetActive(true);
            Destroy(vfxObject, 3f);
        } 

        public override IEnumerator Action(BaseClass baseClass)
        {
            currentMethod.variable = this.variable;
            StartCoroutine(currentMethod.Action(baseClass));

            yield return null;
        }
    }
}
