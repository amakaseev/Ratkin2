using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Level))]
public class LevelEditorAPI: MonoBehaviour {

  public EditorUI editorUI;

  Level _level;

  void Start() {
    _level = GetComponent<Level>();

    Actions.OnSetPlatform += OnSetPlatform;
    Actions.OnRemovePlatform += OnRemovePlatform;
    Actions.OnCellIsEmpty += OnCellIsEmpty;
  }

  void OnSetPlatform(Vector2Int gridPos) {
    LevelCell cell = _level.GetCell(gridPos);
    if (cell == null) {
      cell = Level.CreateCell();
      _level.SetCell(gridPos, cell);
    }
    cell.SetPlatform(editorUI.currentPlatform);
  }

  void OnRemovePlatform(Vector2Int gridPos) {
    LevelCell cell = _level.GetCell(gridPos);
    if (cell != null) {
      cell.RemovePlatform(editorUI.currentPlatform);
    }
  }

  void OnCellIsEmpty(LevelCell cell) {
    _level.RemoveCell(cell);
  }

}
