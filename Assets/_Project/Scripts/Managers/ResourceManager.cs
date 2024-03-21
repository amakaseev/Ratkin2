using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

// TODO: make as singleton
public class ResourceManager : MonoBehaviour {

  public static Dictionary<string, GameObject> platforms { get; } = new Dictionary<string, GameObject>();

  private void Start() {
    LoadDefaultResources();
  }

  private static async void LoadDefaultResources() {
    var loadHandle = Addressables.LoadAssetsAsync<GameObject>("platforms",
                                                              addressable => {
                                                                platforms.Add(addressable.name, addressable);
                                                                Debug.Log("Loaded: " + addressable);
                                                              });
    await loadHandle.Task;
    Actions.OnLoadCopmlete();
  }

}
