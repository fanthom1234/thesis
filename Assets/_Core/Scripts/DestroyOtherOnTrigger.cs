using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thesis;

public class DestroyOtherOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out BaseClass baseClass))
            Destroy(other.gameObject);
    }
}
