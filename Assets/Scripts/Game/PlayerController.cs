using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour {

  int _direction; // 0 - forvard, 1 - right, 2 - back, 3 - left

  public void Turn(int side) {
    _direction += side;
    if (_direction < 0) {
      _direction = 3;
    }
    if (_direction > 3) {
      _direction = 0;
    }
  }

  public void MoveForward() {

  }

}
