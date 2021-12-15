using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Level))]
public class LevelEditorAPI: MonoBehaviour {

  Level _level;

  Platform _currentPlatform;

  void Start() {
    _level = GetComponent<Level>();

    Actions.OnSetPlatform += OnSetPlatform;
    Actions.OnChangeCurrentPlatform += OnChangeCurrentPlatform;
  }

  void OnChangeCurrentPlatform(Platform platform) {
    _currentPlatform = platform;
    Debug.Log(platform);
  }

  void OnSetPlatform(Vector2Int gridPos) {
    Debug.Log(gridPos);
    LevelCell cell = _level.GetCell(gridPos);
    if (cell == null) {
      cell = Level.CreateCell();
      _level.SetCell(gridPos, cell);
    }
    cell.SetPlatform(_currentPlatform);
  }

}
