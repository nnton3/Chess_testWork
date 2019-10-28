using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class ListOfTheLiving : MonoBehaviour
{
    private List<Unit> livingUnits = new List<Unit>();
    private Board board;

    private void Start()
    {
        board = GameObject.FindObjectOfType<Tilemap>().GetComponent<Board>();

        foreach(GameObject unit in GameObject.FindGameObjectsWithTag("Unit"))
        {
            livingUnits.Add(unit.GetComponent<Unit>());
        }
    }

    public Unit GetUnitOnPosition(Vector3 currentPositionForCheck)
    {
        foreach(Unit unit in livingUnits)
        {
            if (unit.transform.position == currentPositionForCheck) return unit;
        }
        return null;
    }

    public void RemoveUnitFromList(Unit deadUnit)
    {
        livingUnits.Remove(deadUnit);
    }
}
