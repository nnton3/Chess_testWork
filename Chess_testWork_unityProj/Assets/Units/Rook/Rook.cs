using UnityEngine;

public class Rook : Unit
{
    private HorizontalOrVerticalMove horizontalOrVerticalMove;

    protected override void Start()
    {
        base.Start();

        horizontalOrVerticalMove = GetComponent<HorizontalOrVerticalMove>();
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
        return horizontalOrVerticalMove.CanHorizontalOrVecticalMove(selectedPosition);
    }
}
