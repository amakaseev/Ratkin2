using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid: MonoBehaviour {

  GridMesh gridMesh;

  void Start() {
    gridMesh = GetComponent<GridMesh>();
  }

  void Update() {
  }
}
