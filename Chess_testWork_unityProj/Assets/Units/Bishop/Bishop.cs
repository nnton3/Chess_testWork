using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Unit
{
    private DiagonalMove diagonalMove;

    protected override void Start()
    {
        base.Start();

        diagonalMove = GetComponent<DiagonalMove>();
    }

    public override void TryToMove()
    {
        base.TryToMove();

        if (PositionToMoveIsValid(board.SelectedPosition))
        {
            KillEnemieUnit();
            SwapPosition();
        }
    }

    private bool PositionToMoveIsValid(Vector3Int selectedPosition)
    {
        return diagonalMove.CanDiagonalMove(selectedPosition);
    }
}
