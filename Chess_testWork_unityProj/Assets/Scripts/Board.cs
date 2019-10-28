using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    private Tilemap tilemap;
    private Camera camera;

    [SerializeField] private Vector3Int selectedPosition = new Vector3Int(-100, -100, -100);
    public Vector3Int SelectedPosition => selectedPosition;

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    public void UpdateSelectedPosition()
    {
        Vector3 clickPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = tilemap.WorldToCell(clickPosition);

        selectedPosition = cellPosition;
    }
}
