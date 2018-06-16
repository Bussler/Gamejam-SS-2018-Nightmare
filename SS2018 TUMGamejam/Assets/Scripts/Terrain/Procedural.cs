using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour{


	public int width = 1024;
	public int height = 1024;
	public int depth = 200;

	private float offsetX = 100f;
	private float offsetY = 100f;
	
	
	public float scale = 2f;
	private TerrainData data;
	void Start() {
		offsetX = Random.RandomRange(0f, 999f);
		offsetY = Random.RandomRange(0f, 999f);
		Terrain terrain = this.GetComponent<Terrain>();
		data = terrain.terrainData;
		terrain.terrainData = GenerateTerrain(terrain.terrainData);
	}

	TerrainData GenerateTerrain(TerrainData terrainData) {
		
		//terrainData.heightmapResolution = data.heightmapWidth + 1;
		terrainData.size = (new Vector3(width, depth, height));
		terrainData.SetHeights(0, 0, GenerateHeights());
		return terrainData;
	}

	float[,] GenerateHeights() {
		float[,] heights = new float[height, width];
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				heights[i, j] = CalculateHeight(i, j);
			}
		}

		return heights;
	}

	float CalculateHeight(float x, float y) {
		float xCoord = x / height * scale + offsetX;
		float yCoord = y / width * scale + offsetY;

		return Mathf.PerlinNoise(xCoord, yCoord);
	}
	
}
