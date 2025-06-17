using UnityEngine;
using UnityEngine.Tilemaps;

public class TileInteractionManager : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject dugTilePrefab;
    public GameObject plantPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cell = tilemap.WorldToCell(worldClick);
            Vector3 center = tilemap.GetCellCenterWorld(cell);

            Collider2D hit = Physics2D.OverlapPoint(worldClick);

            if (hit != null && hit.GetComponent<DiggableTileVisual>() != null)
            {
                // ✔️ Already a dug tile → dig deeper
                hit.GetComponent<DiggableTileVisual>().Dig();
            }
            else
            {
                // ✔️ First time digging → instantiate and dig once
                GameObject dug = Instantiate(dugTilePrefab, center, Quaternion.identity);
                DiggableTileVisual digScript = dug.GetComponent<DiggableTileVisual>();
                if (digScript != null)
                {
                    digScript.Dig();
                }
            }
        }
    }
}