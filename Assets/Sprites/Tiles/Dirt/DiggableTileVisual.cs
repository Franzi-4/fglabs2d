public class DiggableTileVisual : MonoBehaviour
{
    public Sprite[] holeStages; // Assigned in Inspector: 1 to 7 holes
    private int digCount = 0;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        UpdateVisual();
    }

    public void Dig()
    {
        if (digCount < holeStages.Length - 1)
        {
            digCount++;
            UpdateVisual();
        }
        else
        {
            Debug.Log("Tile fully dug. Ready for planting (later).");
        }
    }

    void UpdateVisual()
    {
        sr.sprite = holeStages[digCount];
    }
}