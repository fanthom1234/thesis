using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Transform playerTF;

    private void Update() {
        playerTF = gameObject.transform;
    }
}
