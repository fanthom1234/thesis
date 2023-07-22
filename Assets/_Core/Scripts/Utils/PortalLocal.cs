using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLocal : MonoBehaviour
{
    public Transform targetTF;
    public Transform objToBeMove;

    public void DoTransport()
    {
        objToBeMove.position = targetTF.position;
    }
}
