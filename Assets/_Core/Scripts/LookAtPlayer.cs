using DG.Tweening;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private void Update() {
        if (Player.playerTF != null)
            gameObject.transform.DOLookAt(Player.playerTF.position, 1f);
    }
}
