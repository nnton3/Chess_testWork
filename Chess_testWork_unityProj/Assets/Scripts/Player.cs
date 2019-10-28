using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Unit selectedUnit;
    private ListOfTheLiving listOfTheLiving;
    private Board board;

    public UnityEvent playersSwapped;

    [SerializeField] private Players currentPlayer = Players.White;
    public Players CurrentPlayer => currentPlayer;

    public enum Players
    {
        White,
        Black
    }

    private void Start()
    {
        listOfTheLiving = GetComponent<ListOfTheLiving>();
        board = GameObject.FindObjectOfType<Tilemap>().GetComponent<Board>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            board.UpdateSelectedPosition();

            if (!UnitWasSelected() && selectedUnit != null)
            {
                selectedUnit.TryToMove();
            }
        }
    }

    private bool UnitWasSelected()
    {
        Unit unit = listOfTheLiving.GetUnitOnPosition(board.SelectedPosition);
        if (unit != null)
        {
            if (unit.IsWhite && currentPlayer == Players.White)
            {
                UpdateSelectedUnit(unit);
                return true;
            }
            if (!unit.IsWhite && currentPlayer == Players.Black)
            {
                UpdateSelectedUnit(unit);
                return true;
            }
        }
        return false;
    }

    private void UpdateSelectedUnit(Unit unit)
    {
        if (selectedUnit != null) selectedUnit.DisableSelectAnimation();
        if (unit != null) unit.EnableSelectAnimation();
        selectedUnit = unit;
    }

    private void ResetSelectUnit()
    {
        if (selectedUnit != null) selectedUnit.DisableSelectAnimation();
        selectedUnit = null;
    }

    public void SwapPlayer()
    {
        ResetSelectUnit();
        if (currentPlayer == Players.Black)
        {
            currentPlayer = Players.White;
            playersSwapped.Invoke();
            return;
        }
        if (currentPlayer == Players.White)
        {
            currentPlayer = Players.Black;
            playersSwapped.Invoke();
            return;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    private void OnDisable()
    {
        playersSwapped.RemoveAllListeners();
    }
}
