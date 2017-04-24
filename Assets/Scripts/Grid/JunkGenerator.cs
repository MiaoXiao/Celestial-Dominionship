using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkGenerator : MonoBehaviour
{
    [SerializeField]
    private int NumbOfJunk = 30;

    private Grid GridRef = null;

    [SerializeField]
    private ObjectPooler JunkPooler = null;

    private void Awake()
    {
        GridRef = GetComponent<Grid>();
        if (GridRef == null)
            throw new System.Exception("Junk Generator needs to be attached along with a Grid");

        if (JunkPooler == null)
            throw new System.Exception("Attach Junk pooler reference to Junk Generator");
    }

    private void Start()
    {
        GenerateJunk(NumbOfJunk);
    }

    /// <summary>
    /// Generates an x amount of junk objects in the grid reference
    /// Assumes grid is empty!
    /// </summary>
    public void GenerateJunk(int junk)
    {
        if (junk <= 0)
            return;
        else if (junk > GridRef.Dimensions.x * GridRef.Dimensions.y)
            throw new System.Exception("Can't generate " + junk + " junk for this grid, because the Grid dimensions are not large enough.");

        //All possible positions to place junk
        List<Vector2> existing_pos = new List<Vector2>();
        for (int i = 0; i < GridRef.Dimensions.x; ++i)
        {
            for (int j = 0; j < GridRef.Dimensions.y; ++j)
            {
                existing_pos.Add(new Vector2(i, j));
            }
        }

        for (int i = 0; i < junk; ++i)
        {
            int rand_index = Random.Range(0, (int)(GridRef.Dimensions.x * GridRef.Dimensions.y) - i);
            GameObject junk_obj = JunkPooler.RetrieveCopy();
            GridRef.PopulateGrid(junk_obj.GetComponent<CelestialBody>(), existing_pos[rand_index]);
            existing_pos.RemoveAt(rand_index);
        }

    }

}
