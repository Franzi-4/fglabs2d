using UnityEngine;

public class DiggableTileVisual : MonoBehaviour
{
    public Sprite[] holeStages;
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

    void UpdateVisual()
    {
        sr.sprite = holeStages[digCount];
    }
}