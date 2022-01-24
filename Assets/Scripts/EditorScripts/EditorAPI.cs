using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorAPI: MonoBehaviour {

  public enum ToolsType {
    Hand,
    Platform,
    Objects
  }

  public ToolsType  currentType = ToolsType.Hand;
  public LevelCell  currentCell;
  public Platform   currentPlatform;

  void Start() {
    Actions.OnChangeCurrentPlatform += OnChangeCurrentPlatform;
  }

  public void OnHandToolSelect() {
    currentType = ToolsType.Hand;
    currentCell = null;
  }

  public void OnPlatformsToolSelect() {
    currentType = ToolsType.Platform;
  }

  public void OnObjectsToolSelect() {
    currentType = ToolsType.Objects;
  }

  void OnChangeCurrentPlatform(Platform platform) {
    currentPlatform = platform;
  }

}
