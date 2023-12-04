using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResponsiveGridCellSize : MonoBehaviour
{
    public RectTransform canvasRectTransform;
    public GridLayoutGroup gridLayoutGroup;
    public float widthOffset = 68;
    public float heightOffset = 476;
    // Start is called before the first frame update
    void Start()
    {
        float width = canvasRectTransform.rect.width;
        float height = canvasRectTransform.rect.height;
        gridLayoutGroup.cellSize = new Vector2(width - widthOffset, height - heightOffset);
    }
}
