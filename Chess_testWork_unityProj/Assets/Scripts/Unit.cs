using UnityEngine.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    protected Board board;
    protected ListOfTheLiving listOfTheLiving;
    protected Player player;
    private Animator anim;

    [SerializeField] protected bool isWhite = true;
    private InfoUI infoUI;

    public bool IsWhite => isWhite;

    protected virtual void Start()
    {
        player = FindObjectOfType<Player>();
        anim = GetComponent<Animator>();
        listOfTheLiving = FindObjectOfType<ListOfTheLiving>();
        board = FindObjectOfType<Tilemap>().GetComponent<Board>();
        infoUI = FindObjectOfType<InfoUI>();
    }

    protected bool ValueIsValid(Vector3 value)
    {
        if (value.x < 0 || value.x >= 7) return false;
        if (value.y < 0 || value.y >= 7) return false;
        else return true;
    }

    public virtual void TryToMove() { }

    public void IsDead()
    {
        listOfTheLiving.RemoveUnitFromList(this);
        if (this is King) infoUI.GameOver((isWhite) ? "White" : "Black");
        Destroy(gameObject);
    }

    protected void SwapPosition()
    {
        player.SwapPlayer();
        transform.position = board.SelectedPosition;
    }

    protected bool KillEnemieUnit()
    {
        Unit attackedUnit = listOfTheLiving.GetUnitOnPosition(board.SelectedPosition);
        if (attackedUnit != null)
        {
            attackedUnit.IsDead();
            return true;
        }
        return false;
    }

    public void EnableSelectAnimation()
    {
        anim.SetTrigger("select");
    }

    public void DisableSelectAnimation()
    {
        anim.SetTrigger("unselect");
    }
}
