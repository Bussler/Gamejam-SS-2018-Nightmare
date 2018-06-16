/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.U2D;
using UnityEditor.ShaderGraph.Drawing.Slots;
using UnityEngine;
using Random = UnityEngine.Random;

#define IDX

public class TerrainGenerator : MonoBehaviour{

	public int resolution = 256;
	private MeshFilter filter;
	public float roughenss = 0.8f;

	public float sigma = 0.5f;
	// Use this for initialization
	void Start() {
		Random.seed = 1;
		filter = GetComponent<MeshFilter>();
		filter.mesh = terrainGen();
	}
	
	
	
	
	
	
	float nextRandom() {
		float u, v, S;
		do {
			u = 2.0f * Random.value - 1.0f;
			v = 2.0f * Random.value - 1.0f;
			S = u * u + v * v;
		} while (S > roughenss || S < -roughenss);

		float fa = (float)Math.Sqrt(-2.0f * Math.Log(S) / S);
		return u * fa;
	}
	
	/*int norm(float minValue, float maxValue) {
		float mean = (minValue + maxValue) / 2.0f;
		float sigman = (maxValue - mean) / 3.0f;

		Random.Range(-1, 1);
		return nextRandom(mean, sigman);
	}*/




/*	Mesh terrainGen() {
		Mesh terrain = new Mesh();
		List<Vector3> vertices = new List<Vector3>();
		List<Vector3> normals = new List<Vector3>();
		List<Vector2> uv = new List<Vector2>();

		for (int i = 0; i < resolution + 1; i++) {
			for (int j = 0; j < resolution + 1; j++) {
				vertices.Add(new Vector3(i * resolution - (resolution/2.0f), 0f, j - (resolution / 2.0f)));
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
	

	void createHeighTField() {
		List<float> heightmap = new List<float>((resolution+1) * (resolution+1));
		heightmap.Insert(0, nextRandom());
		heightmap.Insert(resolution, nextRandom());
		heightmap.Insert(resolution*resolution, nextRandom());
		heightmap.Insert(resolution*resolution+resolution, nextRandom());
		
		
		int r = resolution+1;
		float i = 1.0f;
		for (int s = r / 2; s >= 1; s /= 2) {
			//Diamond part
			for (int y = s; y < resolution+1; y += 2 * s) {
				for (int x = s; x < resolution+1; x += 2 * s) {
					heightmap.Insert(x + y * (resolution+1), diamond(x, y, s, heightmap, resolution+1));

					heightmap[IDX(x, y, heightOrLength)] += createRandomFloat(randomEngine, 0.f, Math.Pow(sigma, i));
				}
			}
			//Square part
			for (int y = s; y < resolution+1; y += 2 * s) {
				for (int x = s; x < resolution+1; x += 2 * s) {
					heightmap.Insert(x-s + y * (resolution+1), square(x-s, y, s, heightmap, resolution+1));
					heightmap.Insert(x-s + y * (resolution+1), nextRandom());
					
					heightmap.Insert(x + (y-s) * (resolution+1), square(x, y-s, s, heightmap, resolution+1));
					heightmap.Insert(x + (y-s) *(resolution+1), nextRandom());
					
					heightmap.Insert(x+s + y * (resolution+1), square(x+s, y, s, heightmap, resolution+1));
					heightmap.Insert(x+s + (y) * (resolution+1), nextRandom());

					heightmap.Insert(x + (y+s) * (resolution+1), square(x, y+s, s, heightmap, resolution+1));
					heightmap.Insert(x + (y+s) * (resolution+1), nextRandom());

					heightmap[IDX(x, y+s, heightOrLength)] = square(x, y+s, s, heightField, heightOrLength);
					heightmap[IDX(x, y+s, heightOrLength)] += createRandomFloat(randomEngine, 0.f, );
				}
			}
			i++;
		}
		
	}
	
	
}*/
