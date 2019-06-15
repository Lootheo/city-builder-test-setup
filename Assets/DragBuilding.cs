using UnityEngine;

public class DragBuilding : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 lastPosition;
    void OnMouseDown()
    {
        GetOffset();
    }

    public void GetOffset()
    {
        lastPosition = transform.position;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position -
                 Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z); // hardcode the y and z for your use

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = new Vector3(curPosition.x-curPosition.x%GameGrid.Instance.TileSize.x, transform.position.y, curPosition.z-curPosition.z % GameGrid.Instance.TileSize.y); 
    }

    void OnMouseUp()
    {
        if (!GameGrid.Instance.CanPlaceBuilding(GetComponent<Building>(), transform.position))
        {
            transform.position = lastPosition;
        }
    }
}