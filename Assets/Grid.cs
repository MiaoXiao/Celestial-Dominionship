﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Vector2 Dimensions = Vector2.one;

    public Dictionary<Vector2, GridSlot> SlotList = new Dictionary<Vector2, GridSlot>();

    private Player Owner;

    [SerializeField]
    List<CelestialBody> ListToPopulate;

    [SerializeField]
    public bool Locked;

    [SerializeField]
    private GameObject Example;

    private MeshRenderer MeshRenderer = null;

    [SerializeField]
    private ObjectPooler LinePooler = null;

    [SerializeField]
    private ObjectPooler GridPooler = null;

    private float IntervalX = 0;
    private float IntervalY = 0;

    private void Awake()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
        MeshRenderer.enabled = false;

        Min = MeshRenderer.bounds.min;
        Max = MeshRenderer.bounds.max;
        ReInitGrid(Dimensions);
        for(int x = 0; x < ListToPopulate.Count; x++)
        {
            Debug.Log(Dimensions.x);
            Debug.Log(x % Dimensions.x);
            PopulateGrid(ListToPopulate[x], new Vector2(x % Dimensions.x, (int)(x / Dimensions.x)));
        }
    }

    private void Start()
    {
        //SetObj(new Vector2(5, 5), Example);
    }

    private Vector3 Min;
    private Vector3 Max;


    /// <summary>
    /// Create grid layout
    /// </summary>
    public void ReInitGrid(Vector2 dimensions)
    {
        SlotList.Clear();
        Dimensions = dimensions;

        //IntervalX = MeshRenderer.bounds.size.x / dimensions.x;
        IntervalX = 6.25f;
        float current_interval_x = 0f;
        for (int i = 0; i < dimensions.y + 1; ++i)
        {
            GameObject line_obj = LinePooler.RetrieveCopy();

            Vector3[] line = new Vector3[2];
            line[0] = new Vector3(Min.x, 0, Min.z + current_interval_x);
            line[1] = new Vector3(Min.x + IntervalX * dimensions.x, 0, Min.z + current_interval_x);
            line_obj.GetComponent<LineRenderer>().SetPositions(line);
            current_interval_x += IntervalX;
        }

        //IntervalY = MeshRenderer.bounds.size.z / dimensions.y;
        IntervalY = 6.25f;
        float current_interval_y = 0f;
        for (int i = 0; i < dimensions.x + 1; ++i)
        {
            GameObject line_obj = LinePooler.RetrieveCopy();

            Vector3[] line = new Vector3[2];
            line[0] = new Vector3(Min.x + current_interval_y, 0, Min.z);
            line[1] = new Vector3(Min.x + current_interval_y, 0, Min.z + dimensions.y * IntervalY);
            line_obj.GetComponent<LineRenderer>().SetPositions(line);
            current_interval_y += IntervalY;
        }

        int total_slots = (int)(Dimensions.x * Dimensions.y);
        for (int i = 0; i < Dimensions.x; ++i)
        {
            for (int j = 0; j < Dimensions.y; ++j)
            {
                GameObject slot = GridPooler.RetrieveCopy();
                slot.GetComponent<GridSlot>().Position = new Vector2(i, j);
                slot.transform.position = new Vector3((i * IntervalX) + Min.x + IntervalX / 2, 0, j * IntervalY + Min.z + IntervalY / 2);
                slot.transform.localScale = new Vector3(IntervalX, 0.5f, IntervalY);
                //SetMeshSize(IntervalX, 0, IntervalY);
                SlotList.Add(slot.GetComponent<GridSlot>().Position, slot.GetComponent<GridSlot>());
            }
        }
    }

    public void SetObj(Vector2 position, GameObject model)
    {
        if (position.x > Dimensions.x || position.x < 0 || position.y > Dimensions.y || position.y < 0)
            throw new System.Exception("Specified position: " + position + " not set to a valid position within Dimensions.");
        else if (model == null)
            throw new System.Exception("Model is null");
        model.transform.position = new Vector3(position.x * IntervalX + MeshRenderer.bounds.min.x, 
            this.transform.position.y, 
            position.y * IntervalY + MeshRenderer.bounds.min.y);

        print(position.x + " * " + IntervalX + " + " + MeshRenderer.bounds.min.x);
    }

    private void SetMeshSize(float ScaleX, float ScaleY, float ScaleZ)
    {
        Vector3[] _baseVertices = null;
        var mesh = GetComponent<MeshFilter>().mesh;
        if (_baseVertices == null)
            _baseVertices = mesh.vertices;
        var vertices = new Vector3[_baseVertices.Length];
        for (var i = 0; i < vertices.Length; i++)
        {
            var vertex = _baseVertices[i];
            vertex.x = vertex.x * ScaleX;
            vertex.y = vertex.y * ScaleY;
            vertex.z = vertex.z * ScaleZ;
            vertices[i] = vertex;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }

    /// <summary>
    /// Enable or Disable depending on who the active player is
    /// </summary>
    public void SetVisible()
    {
        if(GameManager.Instance.CurrentPlayer == Owner)
        {
            foreach(KeyValuePair<Vector2, GridSlot> x in SlotList)
            {
                x.Value.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (KeyValuePair<Vector2, GridSlot> x in SlotList)
            {
                x.Value.gameObject.SetActive(false);
            }
        }

    }

    public void PopulateGrid(CelestialBody body, Vector2 Loc)
    {
        body = Instantiate<CelestialBody>(body);
        DragUtility.Instance.EndDrag(body.gameObject,SlotList[Loc].gameObject);
    }
    public void PopulateGrid(CelestialBody body)
    {
        CelestialBody bodyHolder = body;
        int copies = 1;
        if(body.owner == null)
        {
            copies = body.GetCelest().numOfCopies;
        }
        for (int i = 0; i < copies; i++)
        {
            Vector2 Loc = new Vector2();
            for (int x = 0; x < SlotList.Count; x++)
            {
                Vector2 temp = new Vector2(x % Dimensions.x, (int)(x / Dimensions.x));
                if (SlotList[temp].Body == null)
                {
                    Loc = temp;
                    break;
                }
            }
            //Activate to remove them from shop
            Debug.Log("Move to disxard");
            if (i + 1 < copies)
            {
                body = Instantiate<CelestialBody>(bodyHolder);
                DragUtility.Instance.EndDrag(body.gameObject, SlotList[Loc].gameObject);
            }
            else
            {
                DragUtility.Instance.EndDrag(bodyHolder.gameObject, SlotList[Loc].gameObject);
            }
        }
    }
}
