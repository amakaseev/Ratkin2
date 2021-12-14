using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level: MonoBehaviour {

  public List<LevelCell> _cells = new List<LevelCell>();

  public LevelCell GetCell(Vector2Int pos) {
    foreach (var cell in _cells) {
      if (cell.gridPos == pos) {
        return cell;
      }
    }

    return null;
  }

  public static LevelCell CreateCell(Vector2Int pos) {
    GameObject cellObject = new GameObject("LevelCell");
    LevelCell cell = cellObject.AddComponent<LevelCell>();
    cell.gridPos = pos;
    return cell;
  }

  public void SetCell(Vector2Int pos, LevelCell cell) {
    var prevCell = GetCell(pos);
    if (prevCell) {
      RemoveCell(prevCell);
    }
    _cells.Add(cell);
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

  public void SetPlatformOnCell(Vector2Int pos, Platform platform) {

  }

}
