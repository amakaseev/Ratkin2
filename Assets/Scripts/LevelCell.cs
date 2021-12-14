using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCell : MonoBehaviour {

  public Platform  platform;

  Vector2Int _gridPos;

  public Vector2Int gridPos {
    get {
      return _gridPos;
    }
    set {
      _gridPos = value;
      transform.position = new Vector3(_gridPos.x, 0, _gridPos.y);
    }
  }

  public bool IsEmpty {
    get {
      if (platform != null) return false;
      return true;
    }
  }

}
