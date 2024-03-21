using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class GameController: MonoBehaviour {

  public Level            _levelPrefab;
  public PlayerController _playerPrefab;
  public GameCamera       _cameraPrefab;

  Level _level;
  PlayerController _player;
  GameCamera _camera;

  private void Start() {
    Actions.OnLoadCopmlete += OnLoadCopmlete;
    _level = Instantiate(_levelPrefab, new Vector3(0, 0, 0), Quaternion.identity) as Level;
    _player = Instantiate(_playerPrefab, Level.CenterOfGridPos(new Vector2Int(0, 0)), Quaternion.identity) as PlayerController;
    _camera = Instantiate(_cameraPrefab);
    _camera.SetTarget(_player.transform);
  }

  void OnLoadCopmlete() {
    var fileName = PlayerPrefs.GetString("Editor.LevelFileName", "level");
    Debug.Log(fileName);
    LevelSerialize.DeSerialize(_level, JSON.Parse(File.ReadAllText(fileName)) as JSONObject);
  }

}
