using UnityEngine;

[RequireComponent(typeof(Level))]
public class LevelAPI: MonoBehaviour {

  public EditorAPI editorAPI;

  Level _level;

  private void Start() {
    _level = GetComponent<Level>();

    Actions.OnSetToCell += OnSetToCell;
    Actions.OnRemoveFromCell += OnRemoveFromCell;
    Actions.OnCellIsEmpty += OnCellIsEmpty;
  }

  private void OnSetToCell(Vector2Int gridPos) {
    LevelCell cell = _level.GetCell(gridPos);
    if ((editorAPI.currentType == EditorAPI.ToolsType.Platform) && editorAPI.currentPlatform) {
      if (cell == null) {
        cell = Level.CreateCell();
        _level.SetCell(gridPos, cell);
      }
      cell.SetPlatform(editorAPI.currentPlatform);
    } else if ((editorAPI.currentType == EditorAPI.ToolsType.Hand) && (cell != null)) {
      cell.SetSelected(true);
    }
  }

  private void OnRemoveFromCell(Vector2Int gridPos) {
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

  private void OnCellIsEmpty(LevelCell cell) {
    _level.RemoveCell(cell);
  }

}
