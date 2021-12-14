using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsPanel: MonoBehaviour {

  public Platform[] platforms;
  public Platform   currentPlatform;

  public void OnSelectPlatform(int index) {
    currentPlatform = platforms[index];
  }

}
