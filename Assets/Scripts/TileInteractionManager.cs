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
            Debug.Log("Mouse click detected");

            Vector3 worldClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cell = tilemap.WorldToCell(worldClick);
            Vector3 center = tilemap.GetCellCenterWorld(cell);

            Debug.Log("Grid cell: " + cell + " | World pos: " + center);

            Collider2D hit = Physics2D.OverlapPoint(worldClick);
            if (hit != null)
            {
                Debug.Log("Collider hit: " + hit.name);
            }
            else
            {
                Debug.Log("No collider hit, instantiating dug tile.");
                GameObject dug = Instantiate(dugTilePrefab, center, Quaternion.identity);
            }
        }
    }
}
