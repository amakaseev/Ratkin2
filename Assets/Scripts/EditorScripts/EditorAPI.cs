using System.IO;
using System.Text;
using SimpleJSON;
using UnityEngine;
using UnityEditor;

public class EditorAPI: MonoBehaviour {

  public enum ToolsType {
    General,
    Hand,
    Platform,
    Objects
  }

  private Level     _level;

  public ToolsType      currentType = ToolsType.Hand;
  public PlatformsPanel platformsPanel;
  public GameObject     currentPlatform;

  private void Awake() {
    Actions.OnLoadCopmlete += OnLoadCopmlete;
  }

  private void Start() {
    _level = GameObject.FindObjectOfType<Level>();

    Actions.OnChangeCurrentPlatform += OnChangeCurrentPlatform;
  }

  public void OnGeneralToolSelect() {
    currentType = ToolsType.General;
  }

  public void OnNewLevelButton() {
    _level.Clear();
  }

  public void OnOpenLevelButton() {
    var fileName = PlayerPrefs.GetString("Editor.LevelFileName", "level");
    // fileName = EditorUtility.OpenFilePanel("Export scene",
    //                                        (fileName.Length > 0) ? Path.GetDirectoryName(fileName) : Application.persistentDataPath,
    //                                        "json");

    if (!string.IsNullOrEmpty(fileName)) {
      LevelSerialize.DeSerialize(_level, JSON.Parse(File.ReadAllText(fileName)) as JSONObject);
    }
  }

  public void OnSaveLevelButton() {
    var fileName = PlayerPrefs.GetString("Editor.LevelFileName", "level");
    // fileName = EditorUtility.SaveFilePanel("Export scene",
    //                                        (fileName.Length > 0) ? Path.GetDirectoryName(fileName) : Application.persistentDataPath,
    //                                        (fileName.Length > 0) ? Path.GetFileName(fileName) : "level", "json");
    if (!string.IsNullOrEmpty(fileName)) {
      PlayerPrefs.SetString("Editor.LevelFileName", fileName);
      var json  = LevelSerialize.Serialize(_level);
      var bytes = new UTF8Encoding().GetBytes(json.ToString(2));
      var fs    = new FileStream(fileName, FileMode.Create, FileAccess.Write);
      fs.Write(bytes, 0, bytes.Length);
      fs.Close();
    }
  }

  public void OnHandToolSelect() {
    currentType = ToolsType.Hand;
  }

  public void OnPlatformsToolSelect() {
    currentType = ToolsType.Platform;
  }

  public void OnObjectsToolSelect() {
    currentType = ToolsType.Objects;
  }

  private void OnLoadCopmlete() {
    platformsPanel.Initialize();
  }

  private void OnChangeCurrentPlatform(GameObject platform) {
    currentPlatform = platform;
  }

}
