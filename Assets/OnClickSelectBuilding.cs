using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickSelectBuilding : MonoBehaviour
{
    public Action<Building> BuildingClicked;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Transform hitTransformParent = hit.collider.transform.parent;
                
                if (hitTransformParent != null && hitTransformParent.GetComponent<Building>() !=null)
                {
                    BuildingClicked?.Invoke(hitTransformParent.GetComponent<Building>());
                }
            }
        }
    }
}
