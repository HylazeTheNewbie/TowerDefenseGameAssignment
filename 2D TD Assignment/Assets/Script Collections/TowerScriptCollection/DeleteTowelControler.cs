using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTowelControler : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            newPosition.z = 0; // make sure z asix = 0
            transform.position = newPosition;

            if (IsInTrashArea(newPosition))
            {
                ShowTrashCan(true);
            }
            else
            {
                ShowTrashCan(false);
            }
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        ShowTrashCan(false);

        if (IsInTrashArea(transform.position))
        {
            DeleteTower();
        }
    }

    private bool IsInTrashArea(Vector3 position)
    {
        return position.x < -4 && position.y > 4; // change base on the scene
    }

    private void ShowTrashCan(bool show)
    {
        GameObject trashCan = GameObject.Find("TrashCan");
        if (trashCan == null)
        {
            Debug.LogError("TrashCan not found!");
        }
        trashCan.SetActive(show);
    }

    private void DeleteTower()
    {
        Destroy(gameObject);
    }
}
