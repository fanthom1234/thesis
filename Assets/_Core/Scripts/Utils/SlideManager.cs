using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlideManager : MonoBehaviour
{
    public List<GameObject> images;
    private int currIndex;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "next_button")
                {
                    Ascend();
                }

                if (hit.collider.gameObject.name == "prev_button")
                {
                    Descend();
                }
            }
        }
    }

    public void Ascend()
    {
        if (images.Count <= 0)
                        return;

        images[currIndex].SetActive(false);

        currIndex++;

        if (currIndex >= images.Count)
            currIndex = 0;

        images[currIndex].SetActive(true);
    }

    public void Descend()
    {
        if (images.Count <= 0)
            return;

        images[currIndex].SetActive(false);
                    
        currIndex--;

        if (currIndex < 0)
             currIndex = images.Count - 1;

        images[currIndex].SetActive(true);
    }
}
