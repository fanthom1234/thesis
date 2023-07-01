using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Thesis
{
    public class VariableGraphic : Variable
    {
        public List<GameObject> graphics; 
        public int currGraphicIndex;
        public string currentGraphicName;
        private GameObject baseClassGO;

        public override bool IsReachMax() => false;

        public override bool IsReachMin() => false;

        public override void ChangeVariableValue()
        {
            IncreaseVariableValue();
        }

        public override void IncreaseVariableValue()
        {
            if (currGraphicIndex < graphics.Count - 1)
            {
                currGraphicIndex++;
            }
            else
            {
                currGraphicIndex = 0;
            }
        }

        public override void DecreaseVariableValue()
        {
            if (currGraphicIndex > 0)
            {
                currGraphicIndex--;
            }
            else
            {
                currGraphicIndex = graphics.Count - 1;
            }
        }

        public override string GetVariableValue()
        {
            return graphics[currGraphicIndex].name;
        }

        // private void OnCollisionEnter(Collision other) {
        //     if (other.gameObject.TryGetComponent(out BaseClass baseClass))
        //     {
        //         variableName = currentGraphicName;

        //         if (baseClass.variables.Any(var => var.variableName == this.variableName))
        //         {
        //             this.gameObject.SetActive(false);
        //             return;
        //         }

        //         baseClass.gameObject.transform.GetChild(0).gameObject.SetActive(false);

        //         GameObject.Instantiate(graphics[currGraphicIndex], baseClass.gameObject.transform);

        //         // add variable to base class
        //         baseClass.variables.Add(this);

        //         // update base_class's variable panel 
        //         baseClass.UpdatePanel();

        //         this.gameObject.SetActive(false);
        //     }
        // }
    }
}
