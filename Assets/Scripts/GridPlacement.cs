using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridPlacement : MonoBehaviour
{

    [SerializeField] GameObject mouseIndicator;
    [SerializeField] GameObject cellIndicator;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Grid grid;


    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = inputManager.GetSelectedGridPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
        mouseIndicator.transform.position = mousePosition;
        cellIndicator.gameObject.SetActive(true);
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
    }
}
