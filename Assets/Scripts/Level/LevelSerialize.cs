using SimpleJSON;
using UnityEngine;

public class LevelSerialize {

	public static void Serialize(Level level) {
		var       cells      = level.GetCells();
		JSONArray cellsArray = new JSONArray();
		
		foreach (var cell in cells) {
			cellsArray.Add(Serialize(cell));
		}

		//Application.persistentDataPath;
		//EditorUtility.SaveFilePanel
	}

	public static void DeSerialize(Level level, JSONObject json) {
		//return new Level();
	}

	private static JSONObject Serialize(LevelCell cell) {
		JSONObject cellObject = new JSONObject();
		cellObject["pos"]      = cell.gridPos.ToString();
		cellObject["platform"] = cell.platform.type;
		return cellObject;
	}

}
