using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class GameCamera: MonoBehaviour {

  public float      moveSpeed = 10;
  public float      lookSpeed = 25;
  public float      lookDamping = 10;

  Transform _target;
  Vector3   _sphCoord = new Vector3(); // The spherical coordinates
  Vector3   _sphCoordTarget = new Vector3();

  bool    _isPointerOverGameObject;
  Vector2 _cursorPosition;
  Vector2 _cursorDelta;
  bool    _leftButton;
  bool    _rightButton;
  bool    _lookActive;

  void Start() {
    Application.targetFrameRate = 60;
    QualitySettings.vSyncCount = 1;
  }

  public void SetTarget(Transform target) {
    _target = target;

    transform.position = _target.position - _target.forward * 3 + new Vector3(0, 4, 0);
    transform.LookAt(_target);

    _sphCoord = getSphericalCoordinates(transform.position);
    _sphCoordTarget = _sphCoord;
  }

  public void OnCursorPosition(InputValue input) {
    _cursorPosition = input.Get<Vector2>();
  }

  public void OnCursorDelta(InputValue input) {
    _cursorDelta = input.Get<Vector2>();
    if (_lookActive && _leftButton) {
      float dx = _cursorDelta.x * lookSpeed * 0.001f;
      float dy = _cursorDelta.y * lookSpeed * 0.001f;

      _sphCoordTarget.y -= dx;
      _sphCoordTarget.z = Mathf.Clamp(_sphCoordTarget.z - dy, 0.2f, 1f);
    }
  }

  public void OnLeftButton(InputValue input) {
    _leftButton = (input.Get<float>() != 0f);
  }

  public void OnRightButton(InputValue input) {
    _rightButton = (input.Get<float>() != 0f);
  }

  public void OnLookActive(InputValue input) {
    _lookActive = (input.Get<float>() != 0f);
  }

  public void OnZoom(InputValue input) {
    var zoom = input.Get<Vector2>();
    float dz = zoom.y * lookSpeed * 0.0005f;
    _sphCoordTarget.x = Mathf.Clamp(_sphCoordTarget.x + dz, 3f, 10f);
  }

  Vector3 getSphericalCoordinates(Vector3 cartesian) {
      float r = Mathf.Sqrt(
          Mathf.Pow(cartesian.x, 2) +
          Mathf.Pow(cartesian.y, 2) +
          Mathf.Pow(cartesian.z, 2)
      );

      float phi = Mathf.Atan2(cartesian.z / cartesian.x, cartesian.x);
      float theta = Mathf.Acos(cartesian.y / r);

      if (cartesian.x < 0) {
          phi += Mathf.PI;
      }

      return new Vector3 (r, phi, theta);
  }

  Vector3 getCartesianCoordinates(Vector3 spherical) {
      Vector3 ret = new Vector3();

      ret.x = spherical.x * Mathf.Cos(spherical.z) * Mathf.Cos(spherical.y);
      ret.y = spherical.x * Mathf.Sin(spherical.z);
      ret.z = spherical.x * Mathf.Cos(spherical.z) * Mathf.Sin(spherical.y);

      return ret;
  }

  public void Update() {
    var dt = Time.deltaTime;

    _isPointerOverGameObject = EventSystem.current.IsPointerOverGameObject();

    _sphCoord = Vector3.Lerp(_sphCoord, _sphCoordTarget, lookDamping * Time.deltaTime);

    transform.position = getCartesianCoordinates(_sphCoord) + _target.position;
    transform.LookAt(_target.position);
  }

}
