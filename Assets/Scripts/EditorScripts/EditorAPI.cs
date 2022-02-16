using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorAPI: MonoBehaviour {

  public enum ToolsType {
    General,
    Hand,
    Platform,
    Objects
  }

  public ToolsType  currentType = ToolsType.Hand;
  public Platform   currentPlatform;

  void Start() {
    Actions.OnChangeCurrentPlatform += OnChangeCurrentPlatform;
  }

  public void OnGeneralToolSelect() {
    currentType = ToolsType.General;
  }
  
  public void OnHandToolSelect() {
    currentType = ToolsType.Hand;
  }

  public void OnPlatformsToolSelect() {
    currentType = ToolsType.Platform;
  }

  public void OnObjectsToolSelect() {
    currentType = ToolsType.Objects;
  }

  private void OnChangeCurrentPlatform(Platform platform) {
    currentPlatform = platform;
  }

}
