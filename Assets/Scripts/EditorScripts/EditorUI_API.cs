using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorUI_API: MonoBehaviour {

  public Platform currentPlatform;

  void Start() {
    Actions.OnChangeCurrentPlatform += OnChangeCurrentPlatform;
  }

  public void OnHandToolSelect() {

  }

  public void OnPlatformsToolSelect() {

  }

  public void OnObjectsToolSelect() {

  }

  void OnChangeCurrentPlatform(Platform platform) {
    currentPlatform = platform;
  }

}
