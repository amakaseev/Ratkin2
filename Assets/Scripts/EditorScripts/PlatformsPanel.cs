using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlatformsPanel: MonoBehaviour {

  public  Toggle   platformButton;
  
  public void Initialize() {
    var group           = GetComponent<ToggleGroup>();
    var platformsAssets = ResourceManager.platforms;

    foreach (var platformName in platformsAssets.Keys) {
      var button = Instantiate(platformButton, transform);
      button.onValueChanged.AddListener( (isSelected) => {
        if (isSelected) {
          Actions.OnChangeCurrentPlatform(platformsAssets[platformName]);
        }
      });
      button.isOn  = false;
      button.group = group;
    }
  }

}
