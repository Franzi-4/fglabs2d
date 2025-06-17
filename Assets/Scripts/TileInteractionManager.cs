using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class TileInteractionManager : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject dugTilePrefab;
    public GameObject plantPrefab;

    private PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
        controls.Gameplay.Click.performed += ctx => HandleClick();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    void HandleClick()
    {
        Vector3 worldClick = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3Int cell = tilemap.WorldToCell(worldClick);
        Vector3 center = tilemap.GetCellCenterWorld(cell);

        Collider2D hit = Physics2D.OverlapPoint(worldClick);

        if (hit != null && hit.GetComponent<DiggableTileVisual>() != null)
        {
            hit.GetComponent<DiggableTileVisual>().Dig();
        }
        else
        {
            GameObject dug = Instantiate(dugTilePrefab, center, Quaternion.identity);
            dug.GetComponent<DiggableTileVisual>().Dig();
        }
    }
}