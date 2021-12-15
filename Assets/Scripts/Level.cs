using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level: MonoBehaviour {

  public List<LevelCell> _cells = new List<LevelCell>();

  public static LevelCell CreateCell() {
    GameObject cellObject = new GameObject("LevelCell");
    LevelCell cell = cellObject.AddComponent<LevelCell>();
    return cell;
  }

  public static Vector3 CenterOfGridPos(Vector2Int pos) {
    return new Vector3(
      pos.x + ((pos.x < 0)? -0.5f : 0.5f),
      0,
      pos.y + ((pos.y < 0)? -0.5f : 0.5f)
    );
  }

  public LevelCell GetCell(Vector2Int pos) {
    foreach (var cell in _cells) {
      if (cell.gridPos == pos) {
        return cell;
      }
    }

    return null;
  }

  public void SetCell(Vector2Int pos, LevelCell cell) {
    var prevCell = GetCell(pos);
    if (prevCell) {
      RemoveCell(prevCell);
    }
    _cells.Add(cell);
    cell.gridPos = pos;
    cell.transform.parent = transform;
  }

  public void RemoveCell(LevelCell cellToRemove) {
    foreach (var cell in _cells) {
      if (cell.gridPos == cellToRemove.gridPos) {
        _cells.Remove(cell);
        Destroy(cell.gameObject);
        return;
      }
    }
  }

  public static Vector2Int GetGridPos(Vector3 point) {
    return new Vector2Int(
      (int)point.x,
      (int)point.z
    );
  }

}
