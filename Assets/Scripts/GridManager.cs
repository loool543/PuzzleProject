using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;  // 타일 Prefab 연결
    [SerializeField] private int gridSize = 4;       // 그리드 크기
    [SerializeField] private float spacing = 1.1f;   // 타일 간격

    [SerializeField] private Color emptyTileColor = new Color(0.8f, 0.76f, 0.71f); // 베이지
    [SerializeField] private Color boardColor = new Color(0.73f, 0.68f, 0.63f);    // 진한 베이지


    private GameObject[,] tiles;  // 타일 배열

    void Start()
    {
        CreateBoard();
        CreateGrid();
    }

    void CreateBoard()
    {
        // 배경 보드 생성
        GameObject board = GameObject.CreatePrimitive(PrimitiveType.Quad);
        board.name = "Board Background";
        board.transform.SetParent(transform);
        board.transform.localPosition = Vector3.zero;

        float boardSize = gridSize * spacing + 0.5f;
        board.transform.localScale = new Vector3(boardSize, boardSize, 1);

        board.GetComponent<Renderer>().material.color = boardColor;
        Destroy(board.GetComponent<Collider>()); // Collider 제거
    }

    void CreateGrid()
    {
        tiles = new GameObject[gridSize, gridSize];
        float offset = (gridSize - 1) / 2f * spacing;

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 position = new Vector3(
                    x * spacing - offset,
                    y * spacing - offset,
                    -0.1f  // 배경 앞에 오도록
                );

                tiles[x, y] = Instantiate(tilePrefab, position, Quaternion.identity, transform);
                tiles[x, y].name = $"TileSlot ({x}, {y})";

                // 빈 타일 색상 적용
                tiles[x, y].GetComponent<SpriteRenderer>().color = emptyTileColor;
            }
        }
    }


}
