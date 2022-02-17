using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ResourceManager : MonoBehaviour {

	public static Dictionary<string, GameObject> platforms { get; } = new Dictionary<string, GameObject>();

	private void Start() {
		LoadDefaultResources();
	}

	private async void LoadDefaultResources() {
		var loadHandle = Addressables.LoadAssetsAsync<GameObject>("platforms",
		                                                          addressable => {
			                                                          platforms.Add(addressable.name, addressable);
			                                                          Debug.Log(addressable);
		                                                          });
		
		await loadHandle.Task;
		Actions.OnLoadCopmlete();
	}

}
