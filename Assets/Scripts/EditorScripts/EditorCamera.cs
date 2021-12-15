using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class EditorCamera: MonoBehaviour {

  public float      moveSpeed;
  public float      lookSpeed;

  bool    _isPointerOverGameObject;
  Vector2 _cursorPosition;
  Vector2 _cursorDelta;
  Vector2 _moveDirection = Vector3.zero;
  bool    _leftButton;
  bool    _rightButton;
  bool    _lookActive;
  bool    _editOnMoveActive;
  Vector2 _zoom;

  void Start() {
    Application.targetFrameRate = 60;
    QualitySettings.vSyncCount = 1;
  }

  public void OnCursorPosition(InputValue input) {
    _cursorPosition = input.Get<Vector2>();

    if (!_isPointerOverGameObject && _editOnMoveActive && _leftButton) {
      Actions.OnSetPlatform(Level.GetGridPos(GetLookPoint(_cursorPosition)));
    }
  }

  public void OnCursorDelta(InputValue input) {
    _cursorDelta = input.Get<Vector2>();
    if (_lookActive) {
      if (_leftButton) {
        Vector3 rotatePoint = GetLookPoint(new Vector2(Screen.width / 2, Screen.height / 2));
        transform.RotateAround(rotatePoint, Vector3.up, _cursorDelta.x * lookSpeed);
        transform.RotateAround(rotatePoint, transform.right, - _cursorDelta.y * lookSpeed);
      } else if (_rightButton) {
        var right = transform.right * _cursorDelta.x * 0.2f;
        var forward = transform.forward * _cursorDelta.y * 0.2f;
        forward.y = 0;
        transform.position = transform.position - forward - right;
      }
    }
  }

  public void OnLeftButton(InputValue input) {
    _leftButton = (input.Get<float>() == 0f)? false : true;

    if (!_isPointerOverGameObject && !_lookActive && _leftButton) {
      _editOnMoveActive = true;
      Actions.OnSetPlatform(Level.GetGridPos(GetLookPoint(_cursorPosition)));
      // var point = GetLookPoint(_cursorPosition);
      // GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
      // point.x = Mathf.Floor(point.x) + 0.5f;
      // point.z = Mathf.Floor(point.z) + 0.5f;
      // sphere.transform.position = point;
    }
  }

  public void OnRightButton(InputValue input) {
    _rightButton = (input.Get<float>() == 0f)? false : true;
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

  public Vector3 GetLookPoint(Vector2 screenPosition) {
    float distance;
    Ray ray = Camera.main.ScreenPointToRay(screenPosition);
    Plane plane = new Plane(Vector3.up, Vector3.zero);
    plane.Raycast(ray, out distance);
    return ray.GetPoint(distance);
  }

  public void Update() {
    var dt = Time.deltaTime;

    _isPointerOverGameObject = EventSystem.current.IsPointerOverGameObject();

    if (_isPointerOverGameObject || _lookActive) {
      _editOnMoveActive = false;
    }

    if (_moveDirection != Vector2.zero) {
      var right = Vector3.right * _moveDirection.x * moveSpeed * dt;
      var forward = transform.forward;
      forward.y = 0;
      forward.Normalize();
      forward = forward * _moveDirection.y * moveSpeed * dt;

      transform.Translate(right);
      transform.position = transform.position + forward;
    }

    if (_zoom != Vector2.zero) {
      transform.Translate(Vector3.forward * _zoom.y * moveSpeed * dt * 0.5f);
    }
  }

}
