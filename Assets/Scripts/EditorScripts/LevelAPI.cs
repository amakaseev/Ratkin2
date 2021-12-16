using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Level))]
public class LevelAPI: MonoBehaviour {

  public EditorAPI editorAPI;

  Level _level;

  void Start() {
    _level = GetComponent<Level>();

    Actions.OnSetToCell += OnSetToCell;
    Actions.OnRemoveFromCell += OnRemoveFromCell;
    Actions.OnCellIsEmpty += OnCellIsEmpty;
  }

  void OnSetToCell(Vector2Int gridPos) {
    LevelCell cell = _level.GetCell(gridPos);
    if (cell == null) {
      cell = Level.CreateCell();
      _level.SetCell(gridPos, cell);
    }

    if (editorAPI.currentType == EditorAPI.ToolsType.Platform) {
      cell.SetPlatform(editorAPI.currentPlatform);
    }
  }

  void OnRemoveFromCell(Vector2Int gridPos) {
    LevelCell cell = _level.GetCell(gridPos);
    if (cell != null) {
      if (editorAPI.currentType == EditorAPI.ToolsType.Platform) {
        cell.RemovePlatform();
      }
    }
  }

  void OnCellIsEmpty(LevelCell cell) {
    _level.RemoveCell(cell);
  }

}
