using DG.Tweening;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private void Update() {
        gameObject.transform.DOLookAt(Player.playerTF.position, 1f);
    }
}
