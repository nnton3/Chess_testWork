using UnityEngine;

public class HorizontalOrVerticalMove : MonoBehaviour
{
    protected ListOfTheLiving listOfTheLiving;

    private void Start()
    {
        listOfTheLiving = FindObjectOfType<ListOfTheLiving>();
    }

    public bool CanHorizontalOrVecticalMove(Vector3Int selectedPosition)
    {
        Vector3 differencePosition = selectedPosition - transform.position;
        bool isItNotHorizontalOrVerticalMove = differencePosition.x != 0f && differencePosition.y != 0f;

        if (isItNotHorizontalOrVerticalMove) return false;
        if (HaveUnitOnTheWay(selectedPosition, differencePosition)) return false;
        return true;
    }

    private bool HaveUnitOnTheWay(Vector3Int selectedPosition, Vector3 differencePosition)
    {
        if (selectedPosition.x != 0f)
        {
            for (int i = 1; i < Mathf.Abs(differencePosition.x); ++i)
            {
                Vector3 checkStep = new Vector3(Mathf.Sign(differencePosition.x), 0f, 0f);
                Vector3 currentPositionForCheck = selectedPosition - i * checkStep;
                if (listOfTheLiving.GetUnitOnPosition(currentPositionForCheck) != null) return true;
            }
        }
        if (selectedPosition.y != 0f)
        {
            for (int i = 1; i < Mathf.Abs(differencePosition.y); ++i)
            {
                Vector3 currentPositionForCheck = selectedPosition - (new Vector3(0f, i * Mathf.Sign(differencePosition.y), 0f));
                if (listOfTheLiving.GetUnitOnPosition(currentPositionForCheck) != null) return true;
            }
        }
        return false;
    }
}
