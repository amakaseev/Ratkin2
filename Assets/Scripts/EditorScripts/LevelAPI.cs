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
    if ((cell == null) && (editorAPI.currentType == EditorAPI.ToolsType.Platform)) {
      cell = Level.CreateCell();
      cell.SetPlatform(editorAPI.currentPlatform);
      _level.SetCell(gridPos, cell);
    } else if (editorAPI.currentType == EditorAPI.ToolsType.Hand) {
      cell.SetSelected(true);
    }
  }

  void OnRemoveFromCell(Vector2Int gridPos) {
    LevelCell cell = _level.GetCell(gridPos);
    if (cell != null) {
      if (editorAPI.currentType == EditorAPI.ToolsType.Hand) {
        cell.SetSelected(false);
        // _level.RemoveCell(cell);
      } else if (editorAPI.currentType == EditorAPI.ToolsType.Platform) {
        cell.RemovePlatform();
      }
    }
  }

  void OnCellIsEmpty(LevelCell cell) {
    _level.RemoveCell(cell);
  }

}
