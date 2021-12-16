using System;
using UnityEngine;

public static class Actions {

  public static Action<Platform>    OnChangeCurrentPlatform;
  public static Action<Vector2Int>  OnSetPlatform;
  public static Action<Vector2Int>  OnRemovePlatform;
  public static Action<LevelCell>   OnCellIsEmpty;

}
