using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorCamera: MonoBehaviour {

  public Transform  yaw;
  public Transform  pitch;

  public float      moveSpeed;
  public float      lookSpeed;

  Vector2 _moveDirection = Vector3.zero;
  bool    _lookActive;
  Vector2 _zoom;

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
      yaw.transform.Rotate(0f, lookDirection.x * lookSpeed, 0f);
      pitch.transform.Rotate(lookDirection.y * lookSpeed, 0f, 0f);
    }
  }

  public void OnZoom(InputValue input) {
    _zoom = input.Get<Vector2>();
  }

  public void Update() {
    var dt = Time.deltaTime;

    if (_moveDirection != Vector2.zero) {
      var right = yaw.right * _moveDirection.x * moveSpeed * dt;
      var forward = yaw.forward * _moveDirection.y * moveSpeed * dt;

      transform.Translate(forward);
      transform.Translate(right);
    }

    if (_zoom != Vector2.zero) {
      transform.Translate(pitch.forward * _zoom.y * moveSpeed * dt);
    }
  }

}
