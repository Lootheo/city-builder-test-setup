using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDragMoveBuilding : MonoBehaviour
{
    private Building lastSelectedBuilding = null;
    public void OnEnable()
    {
        FindObjectOfType<OnClickSelectBuilding>().BuildingClicked += DragBuilding;
    }

    private void DragBuilding(Building selectedBuilding)
    {
        if (lastSelectedBuilding != null)
        {
            Destroy(lastSelectedBuilding.GetComponent<DragBuilding>());
        }

        selectedBuilding.gameObject.AddComponent<DragBuilding>().GetOffset();
        lastSelectedBuilding = selectedBuilding;
    }

    private void OnDisable()
    {
        OnClickSelectBuilding onClickSelectBuilding = FindObjectOfType<OnClickSelectBuilding>();
        if (onClickSelectBuilding != null)
        {
            onClickSelectBuilding.BuildingClicked -= DragBuilding;
        }

    }
}
