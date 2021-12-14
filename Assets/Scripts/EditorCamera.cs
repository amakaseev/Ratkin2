using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorCamera: MonoBehaviour {

  public Transform  vertical;
  public float      moveSpeed;
  public float      lookSpeed;

  Vector2 _moveDirection = Vector3.zero;
  bool    _lookActive;

  void Start() {
    Application.targetFrameRate = 60;
    QualitySettings.vSyncCount = 1;
  }

  public void OnMove(InputValue input) {
    _moveDirection = input.Get<Vector2>();
  }

  public void OnLookActive(InputValue input) {
    _lookActive = (input.Get<float>() == 0f)? false : true;
  }

  public void OnLookDelta(InputValue input) {
    Vector2 lookDirection = input.Get<Vector2>();
    if (_lookActive) {
      vertical.transform.Rotate(lookDirection.y * lookSpeed, 0.0f, 0.0f);
      transform.Rotate(0.0f, lookDirection.x * lookSpeed, 0.0f);
    }
  }

  public void Update() {
    if (_moveDirection != Vector2.zero) {
      var dt = Time.deltaTime;
      var right = new Vector3(1, 0, 0) * _moveDirection.x * moveSpeed * dt;
      var forward = new Vector3(0, 0, 1) * _moveDirection.y * moveSpeed * dt;

      transform.Translate(forward);
      transform.Translate(right);
    }
  }

}
