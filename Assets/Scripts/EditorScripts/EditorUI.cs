using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorUI: MonoBehaviour {

  public Platform currentPlatform;

  void Start() {
    Actions.OnChangeCurrentPlatform += OnChangeCurrentPlatform;
  }

  void OnChangeCurrentPlatform(Platform platform) {
    currentPlatform = platform;
  }

}
