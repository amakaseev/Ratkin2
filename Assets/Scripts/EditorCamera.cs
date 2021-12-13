using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorCamera: MonoBehaviour {

  public Transform  vertical;
  public float      moveSpeed;
  public float      lookSpeed;

  Vector2 _moveDirection = Vector3.zero;
  Vector2 _lookDirection = Vector3.zero;
  bool    _lookActive;

  public void OnMove(InputValue input) {
    _moveDirection = input.Get<Vector2>();
    Debug.Log("OnMove");
  }

  public void OnLookActive(InputValue input) {
    _lookActive = (input.Get<float>() == 0f)? false : true;
    Debug.Log("lookActive: " + _lookActive);
  }

  public void OnLookDelta(InputValue input) {
    _lookDirection = input.Get<Vector2>();
    Debug.Log("OnLook: " + _lookDirection);
  }

  public void Update() {
    if (_moveDirection != Vector2.zero) {
      var dt = Time.deltaTime;
      var position = transform.position;
      position.x += _moveDirection.x * moveSpeed * dt;
      position.z += _moveDirection.y * moveSpeed * dt;
      transform.position = position;
    }
    if (_lookActive) {
      var dt = Time.deltaTime;
      transform.Rotate(_lookDirection.y * lookSpeed * dt, 0.0f, 0.0f);
    }
  }

}
