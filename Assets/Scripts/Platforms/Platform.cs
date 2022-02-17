using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Platform: MonoBehaviour {

	public string id => AssetDatabase.GetAssetPath(PrefabUtility.GetPrefabInstanceHandle(gameObject));

}
