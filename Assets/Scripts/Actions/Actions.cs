using System;
using UnityEngine;

public static class Actions {

  public static Action<Platform>    OnChangeCurrentPlatform;
  public static Action<Vector2Int>  OnSetToCell;
  public static Action<Vector2Int>  OnRemoveFromCell;
  public static Action<LevelCell>   OnCellIsEmpty;

}
