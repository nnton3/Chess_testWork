using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Unit
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

        if (WayDistance() == 1f)
        {
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
    }

    private float WayDistance()
    {
        Vector3 differencePosition = board.SelectedPosition - transform.position;
        return (differencePosition.magnitude <= Mathf.Sqrt(2)) ? 1f : 0f;
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
