using SimpleJSON;
using UnityEngine;

public static class LevelSerialize {

	public static JSONObject Serialize(Level level) {
		var cells = level.GetCells();
		var cellsArray = new JSONArray();
		
		foreach (var cell in cells) {
			cellsArray.Add(Serialize(cell));
		}

		return new JSONObject {
			["cells"] = cellsArray
		};
	}

	public static void DeSerialize(Level level, JSONObject json) {
		level.Clear();

		var cellsArray = json["cells"] as JSONArray;
		if (cellsArray != null) {
			foreach (var cell in cellsArray) {
				DeSerializeCell(level, cell.Value as JSONObject);
				Debug.Log(cell.Value);
			}
		}

		Debug.Log(json);
	}

	private static JSONObject Serialize(LevelCell cell) {
		var cellObject = new JSONObject();
		cellObject["pos"]      = cell.gridPos.ToString();
		cellObject["platform"] = cell.platform.id;
		return cellObject;
	}

	private static void DeSerializeCell(Level level, JSONObject cellObject) {
		var cell = Level.CreateCell();
		level.SetCell(new Vector2Int().FromString(cellObject["pos"]), cell);
	}

}
