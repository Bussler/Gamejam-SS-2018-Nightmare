using UnityEngine;
using System.IO;

public class MTerrainGen : MonoBehaviour {

    public int width=256;
    public int height=256;
    public int depth=20;

    private float offX;
    private float offY;

    public float scale=20;

	// Use this for initialization
	void Start () {
        offX = Random.Range(0f, 999f);
        offY = Random.Range(0f,999f);

        Terrain terrain = GetComponent<Terrain>();//getting the terrain
        //terrain.terrainData = generateTerrain(terrain.terrainData);

        Blending blender = new Blending();//init blender
        Texture2D grass = Resources.Load("greenLawn") as Texture2D;//1
        Texture2D wood = Resources.Load("Holz-34") as Texture2D;//2
        Texture2D mud = Resources.Load("mud02") as Texture2D;//3
        Texture2D stone = Resources.Load("rock8") as Texture2D;//4

        Color[,] colorArray= blender.generateBlend(grass,wood,mud,stone, terrain.terrainData,width,height);
        
        //use this colorArray to calculate a texture and apply it to the terrain
        Texture2D image = new Texture2D(width, height);
        for (int y=0;y<height;y++)
        {
            for (int x=0;x<width;x++)
            {
                image.SetPixel(x, y, colorArray[x, y]);
            }
        }

        //save pic
        var Bytes = image.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath+"/Resources/TerrainColorMap.png",Bytes);
        
    }
	
	TerrainData generateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width,depth,height);
        terrainData.SetHeights(0,0,generateHeightValues());
        return terrainData;
    }

    float[,] generateHeightValues()//generate heightValues for the array
    {
        float[,] vals = new float[width, height];
        for (int y=0;y<height;y++)
        {
            for (int x=0;x<width;x++)
            {
                vals[x, y] = calculateHeightNoise(x, y);
            }

        }

        return vals;
    }

    float calculateHeightNoise(int x, int y)
    {
        float xCoord = (float)x / width * scale+offX;
        float yCoord = (float)y / height * scale+offY;

        return Mathf.PerlinNoise(xCoord,yCoord);
    }
}
