using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.U2D;
using UnityEditor.ShaderGraph.Drawing.Slots;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

	public int resolution = 256;
	private MeshFilter filter;
	
	// Use this for initialization
	void Start () {
		Random.seed = 1;
		filter = GetComponent<MeshFilter>();
		filter.mesh = terrainGen();
	}



	Mesh terrainGen() {
		Mesh terrain = new Mesh();
		List<Vector3> vertices = new List<Vector3>();
		List<Vector3> normals = new List<Vector3>();
		List<Vector2> uv = new List<Vector2>();

		for (int i = 0; i < resolution + 1; i++) {
			for (int j = 0; j < resolution + 1; j++) {
				vertices.Add(new Vector3(i * resolution - (resolution/2.0f), 0, j - (resolution / 2.0f)));
				normals.Add(Vector3.up);
				uv.Add(new Vector2(i / (float)resolution, j / (float) resolution));
			}
		}
		List<int> triangles = new List<int>();
		int vertCount = resolution - 1;



		for (int i = 0; i < vertCount * vertCount; i++) {
			if ((i + 1) % vertCount == 0) {
				continue;
				
			}
			triangles.AddRange(new List<int>(){i+1+vertCount, i+vertCount, i, 
												i, i+1, i+vertCount+1});
				
			
		}

		terrain.SetVertices(vertices);
		terrain.SetNormals(normals);
		terrain.SetUVs(0, uv);
		terrain.SetTriangles(triangles, 0);
		return terrain;
	}
	

	float randomGen() {
		return Random.value;
	}
	
}
