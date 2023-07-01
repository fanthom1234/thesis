using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thesis;
using System.Linq;

public class DisplayMethod : Method
{
    public override IEnumerator Action(BaseClass baseClass)
    {
        baseClass.gameObject.transform.GetChild(0).gameObject.SetActive(false);

        if (variable.GetType().Name != "VariableGraphic")
            yield return null;

        VariableGraphic vg = (VariableGraphic)variable;
        GameObject.Instantiate(vg.graphics[vg.currGraphicIndex], baseClass.gameObject.transform);
        // // add variable to base class
        // baseClass.variables.Add(this);
        // // update base_class's variable panel 
        // baseClass.UpdatePanel()
        // this.gameObject.SetActive(false);

        yield return null;
    }
}
