using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] private Camera sceneCamera;
    [SerializeField] private LayerMask gridPlacementMask;
    private Vector3 lastPosition;

    public Vector3 GetSelectedGridPosition()
    {

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = sceneCamera.nearClipPlane;
        Ray ray = sceneCamera.ScreenPointToRay(mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, gridPlacementMask))
        {
            lastPosition = hit.point;
        }

        return lastPosition;

    }

}
