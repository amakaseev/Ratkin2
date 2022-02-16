using UnityEngine;
using System.Collections.Generic;

public class GridMesh : MonoBehaviour {
  [Space]
  public int xSegments = 8;
  public int ySegments = 8;
  [Space]
  public float xStep = 1.0f;
  public float yStep = 1.0f;
  [Space]
  public Color    color;
  public Material material;
  [Space]
  public bool isCentered = true;
  public bool generateOnStart = true;

  private float _xOffset;
  private float _zOffset;

  private readonly List<Vector3> _verticies = new List<Vector3>();
  private readonly List<int> _indicies = new List<int>();

  private MeshFilter _meshFilter;
  private Mesh _mesh;
  private MeshRenderer _meshRenderer;

  private void Start() {
    _mesh = new Mesh();
    _meshFilter = gameObject.AddComponent<MeshFilter>();
    _meshRenderer = gameObject.AddComponent<MeshRenderer>();
    if (generateOnStart) {
      Generate();
    }
  }

  void Generate() {

    if (isCentered)  {
      _xOffset = xSegments * xStep / 2;
      _zOffset = ySegments * yStep / 2;
    }

    GenerateVerts();
    GenerateIndicies();
    GenerateMesh();
  }

  private void GenerateVerts() {
    _verticies.Clear();
    for (int z = 0; z <= ySegments; z++) {
      for (int x = 0; x <= xSegments; x++) {
        _verticies.Add(new Vector3(x * xStep - _xOffset, 0, z * yStep - _zOffset));
      }
    }
  }

  private void GenerateIndicies() {
    _indicies.Clear();
    for (int vert = 0, y = 0; y < ySegments; y++) {
      for (int x = 0; x < xSegments; x++) {
        _indicies.Add(vert + 0);
        _indicies.Add(vert + 1 + xSegments);

        _indicies.Add(vert + 1 + xSegments);
        _indicies.Add(vert + 2 + xSegments);

        _indicies.Add(vert + 2 + xSegments);
        _indicies.Add(vert + 1);

        _indicies.Add(vert + 1);
        _indicies.Add(vert + 0);

        vert++;
      }
      vert++;
    }
  }

  private void GenerateMesh() {
    _mesh.Clear();
    _mesh.name = "Grid Mesh";
    _mesh.vertices = _verticies.ToArray();
    _mesh.SetIndices(_indicies, MeshTopology.Lines, 0);
    _meshFilter.mesh = _mesh;
    _meshRenderer.material = (material != null)? material : new Material(Shader.Find("Sprites/Default")) { color = color };
  }

}