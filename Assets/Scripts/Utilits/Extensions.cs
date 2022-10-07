using UnityEngine;

public static class VectorExtensionMethods  {

  public static Vector2Int FromString(this Vector2Int vec, string str) {
    var temp   = str.Substring(1,str.Length-2).Split(',');
    vec.x = int.Parse(temp[0]);
    vec.y = int.Parse(temp[1]);
    return vec;
  }

}
