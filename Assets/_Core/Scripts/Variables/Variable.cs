using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thesis
{
    public enum VariableType {
            Hungriness = 0,
            Tiredness = 1,
            Wealthiness = 2,
    }

    public class Variable : MonoBehaviour
    {
        public VariableType variableType;
    }
}
