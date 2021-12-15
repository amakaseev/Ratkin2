using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsPanel: MonoBehaviour {

  public Platform[] platforms;

  public void OnSelectPlatform(int index) {
    Actions.OnChangeCurrentPlatform(platforms[index]);
  }

}
