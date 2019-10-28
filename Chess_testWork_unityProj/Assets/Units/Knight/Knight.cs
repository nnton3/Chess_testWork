using UnityEngine;

public class Knight : Unit
{
    public override void TryToMove()
    {
        base.TryToMove();

        if (PositionToMoveIsValid(board.SelectedPosition)) SwapPosition();
    }

    private bool PositionToMoveIsValid(Vector3Int selectedPosition)
    {
        Vector3 differencePosition = selectedPosition - transform.position;
        if (differencePosition.magnitude != Mathf.Sqrt(5)) return false;

        KillEnemieUnit();

        return true;
    }
}
