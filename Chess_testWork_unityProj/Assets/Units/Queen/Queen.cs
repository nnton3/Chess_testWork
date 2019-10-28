using System;
using UnityEngine;

public class Queen : Unit
{
    private DiagonalMove diagonalMove;
    private HorizontalOrVerticalMove horizontalOrVerticalMove;

    protected override void Start()
    {
        base.Start();

        diagonalMove = GetComponent<DiagonalMove>();
        horizontalOrVerticalMove = GetComponent<HorizontalOrVerticalMove>();
    }

    public override void TryToMove()
    {
        base.TryToMove();

        if (PositionForDiagonalMoveIsValid(board.SelectedPosition))
        {
            MoveToNewPosition();
            return;
        }
        if (PositionForHorizontalOrVerticalMoveIsValid(board.SelectedPosition))
        {
            MoveToNewPosition();
            return;
        }
    }

    private void MoveToNewPosition()
    {
        KillEnemieUnit();
        SwapPosition();
    }

    private bool PositionForDiagonalMoveIsValid(Vector3Int selectedPosition)
    {
        return diagonalMove.CanDiagonalMove(selectedPosition);
    }

    private bool PositionForHorizontalOrVerticalMoveIsValid(Vector3Int selectedPosition)
    {
        return horizontalOrVerticalMove.CanHorizontalOrVecticalMove(selectedPosition);
    }
}
