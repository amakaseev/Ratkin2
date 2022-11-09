using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class GameController: MonoBehaviour {

  private Level _level;

  private void Awake() {
    Actions.OnLoadCopmlete += OnLoadCopmlete;
    _level = GameObject.FindObjectOfType<Level>();
  }

  void OnLoadCopmlete() {
    var fileName = PlayerPrefs.GetString("Editor.LevelFileName", "level");
    Debug.Log(fileName);
    LevelSerialize.DeSerialize(_level, JSON.Parse(File.ReadAllText(fileName)) as JSONObject);
  }

}
