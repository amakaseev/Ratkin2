using UnityEditor;
using UnityEngine;

public class LevelCell : MonoBehaviour {

  public Platform platform;

  private Vector2Int _gridPos;
  private bool       _selected;

  public Vector2Int gridPos {
    get => _gridPos;
    set {
      _gridPos           = value;
      transform.position = Level.CenterOfGridPos(_gridPos);
    }
  }

  public Vector3 position => transform.position;

  public bool isEmpty {
    get {
      if (platform != null) return false;
      return true;
    }
  }

  public void SetSelected(bool selected) {
    _selected = selected;
    if (_selected && gameObject.GetComponentInChildren<Outline>() == null) {
      var outline = gameObject.AddComponent<Outline>();
      outline.OutlineMode  = Outline.Mode.OutlineAll;
      outline.OutlineColor = Color.yellow;
      outline.OutlineWidth = 5f;
    } else if (!_selected) {
      Destroy(GetComponent<Outline>());
    }
  }

  public void SetPlatform(GameObject plat) {
    if (platform != null) {
      Destroy(platform.gameObject);
    }

    platform = Instantiate(plat).GetComponent<Platform>();

    var transform1 = platform.transform;
    transform1.parent        = transform;
    transform1.localPosition = Vector3.zero;
    transform1.localRotation = Quaternion.identity;
    transform1.localScale    = Vector3.one;
  }

  public void RemovePlatform() {
    if (platform != null) {
      Destroy(platform.gameObject);
      platform = null;
    }

    if (isEmpty) {
      Actions.OnCellIsEmpty(this);
    }
  }
}
