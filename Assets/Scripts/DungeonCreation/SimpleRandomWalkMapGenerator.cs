using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class SimpleRandomWalkMapGenerator : MonoBehaviour
{
    [SerializeField]
    protected Vector2Int startPosition = Vector2Int.zero;
    [SerializeField]
    private int iterations = 10;
    public int walkLength = 10;
    public bool startRandomlyEachIteration = true;
    [SerializeField]
    private TilemapVisualier tilemapVisualier;

    void Start(){
        RunProceduralGeneration();
    }

    public void RunProceduralGeneration(){
        HashSet<Vector2Int> floorPositions = RunRandomWalk();
        tilemapVisualier.Clear();
        tilemapVisualier.PaintFloorTiles(floorPositions);
    }

    protected HashSet<Vector2Int> RunRandomWalk(){
        var CurrenPosition = startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < iterations; i++)
        {
            var path = ProceduralGenerationAlgorthim.SimpleRandomWalk(CurrenPosition, walkLength);
            floorPositions.UnionWith(path);
            if (startRandomlyEachIteration){
                CurrenPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
            }
        }
        return floorPositions; 
    }

}
