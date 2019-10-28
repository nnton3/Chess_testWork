using System;
using UnityEngine;

public class Pawn : Unit
{
    [SerializeField]
    [Header("Set 1 if in White team and - 1 if in Black team")]
    private float direction = 1f;

    DiagonalMove diagonalMove;
    HorizontalOrVerticalMove horizontalOrVerticalMove;

    protected override void Start()
    {
        base.Start();

        diagonalMove = GetComponent<DiagonalMove>();
        horizontalOrVerticalMove = GetComponent<HorizontalOrVerticalMove>();
    }

    public override void TryToMove()
    {
        base.TryToMove();

        if (PositionIsValidForPawn())
        {
            if (PositionForDiagonalMoveIsValid(board.SelectedPosition))
            {
                KillEnemieUnit();
                SwapPosition();
                return;
            }
            if (PositionForHorizontalOrVerticalMoveIsValid(board.SelectedPosition))
            {
                SwapPosition();
                return;
            }
        }
    }

    private bool PositionForDiagonalMoveIsValid(Vector3Int selectedPosition)
    {
        if (listOfTheLiving.GetUnitOnPosition(selectedPosition))
            return diagonalMove.CanDiagonalMove(selectedPosition);
        return false;
    }

    private bool PositionForHorizontalOrVerticalMoveIsValid(Vector3Int selectedPosition)
    {
        if (listOfTheLiving.GetUnitOnPosition(selectedPosition)) return false;
        return horizontalOrVerticalMove.CanHorizontalOrVecticalMove(selectedPosition);
    }

    private bool PositionIsValidForPawn()
    {
        if (WayDistance() != 1f) return false;

        Vector3 positionDifference = board.SelectedPosition - transform.position;

        if (Mathf.Sign(positionDifference.y) != direction) return false;
        if (positionDifference.y == 0f) return false;

        return true;
    }

    private float WayDistance()
    {
        Vector3 differencePosition = board.SelectedPosition - transform.position;
        return (differencePosition.magnitude <= Mathf.Sqrt(2)) ? 1f : 0f;
    }
}
