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

  Vector2 _cursorPosition;
  Vector2 _cursorDelta;
  Vector2 _moveDirection = Vector3.zero;
  bool    _leftButton;
  bool    _lookActive;
  Vector2 _zoom;

  void Start() {
    Application.targetFrameRate = 60;
    QualitySettings.vSyncCount = 1;
  }

  public void OnCursorPosition(InputValue input) {
    _cursorPosition = input.Get<Vector2>();
  }

  public void OnCursorDelta(InputValue input) {
    _cursorDelta = input.Get<Vector2>();
    if (_lookActive && _leftButton) {
      yaw.transform.Rotate(0f, _cursorDelta.x * lookSpeed, 0f);
      pitch.transform.Rotate(_cursorDelta.y * lookSpeed, 0f, 0f);
    }
  }

  public void OnLeftButton(InputValue input) {
    _leftButton = (input.Get<float>() == 0f)? false : true;
    if (!_lookActive && _leftButton) {
      float distance;
      Ray ray = Camera.main.ScreenPointToRay(_cursorPosition);
      Plane plane = new Plane(Vector3.up, Vector3.zero);
      if (plane.Raycast(ray, out distance)) {
        Vector3 point = ray.GetPoint(distance);

        Debug.DrawLine(Camera.main.transform.position, point, Color.red );

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = point;
      }
    }
  }

  public void OnMove(InputValue input) {
    _moveDirection = input.Get<Vector2>();
  }

  public void OnLookActive(InputValue input) {
    _lookActive = (input.Get<float>() == 0f)? false : true;
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
