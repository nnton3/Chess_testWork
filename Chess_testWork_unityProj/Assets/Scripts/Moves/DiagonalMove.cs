using UnityEngine;
using System.Collections;

public class DiagonalMove : MonoBehaviour
{
    protected ListOfTheLiving listOfTheLiving;

    private void Start()
    {
        listOfTheLiving = FindObjectOfType<ListOfTheLiving>();
    }

    public bool CanDiagonalMove(Vector3Int selectedPosition)
    {
        Vector3 differencePosition = selectedPosition - transform.position;
        bool isItNotDiagonalMove = Mathf.Abs(differencePosition.x) != Mathf.Abs(differencePosition.y);

        if (isItNotDiagonalMove) return false;
        if (HaveUnitOnTheWay(selectedPosition, differencePosition)) return false;
        return true;
    }

    private bool HaveUnitOnTheWay(Vector3Int selectedPosition, Vector3 differencePosition)
    {
        Vector3 checkStep = new Vector3(Mathf.Sign(differencePosition.x), Mathf.Sign(differencePosition.y), 0);
        for (int i = 1; i < Mathf.Abs(differencePosition.x); ++i)
        {
            Vector3 currentPositionForCheck = transform.position + i * checkStep; 
            if (listOfTheLiving.GetUnitOnPosition(currentPositionForCheck) != null) return true;
        }
        return false;
    }
}
