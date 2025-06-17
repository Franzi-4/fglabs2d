using UnityEngine;

public class DiggableTileVisual : MonoBehaviour
{
    public Sprite[] holeStages; // 7 sprites, from 1 to 7 holes
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
    }

    private void UpdateVisual()
    {
        sr.sprite = holeStages[digCount];
    }
}