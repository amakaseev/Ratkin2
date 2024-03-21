using System;
using UnityEngine;

public static class Actions {

  public static Action             OnLoadCopmlete;
  public static Action<GameObject> OnChangeCurrentPlatform;
  public static Action<Vector2Int> OnSetToCell;
  public static Action<Vector2Int> OnRemoveFromCell;
  public static Action<LevelCell>  OnCellIsEmpty;

}
