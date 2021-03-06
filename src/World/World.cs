﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class World : GenericWorld
{
    public GameObject block;

    public int squareSize = 30;
    public int depth = 50;

    private string dataPath;
    private Dictionary<string, GameObject> m_blockMap = new Dictionary<string, GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        initWorld();
    }

    void initWorld()
    {
        for (int x = -squareSize; x < squareSize; x += 2)
        {
            for (int y = -squareSize; y < squareSize; y += 2)
            {
                for (int z = 5; z < depth + 5; z += 2)
                {
                    createBlock(new Vector3(x, y, z), 0);
                }
            }
        }

        Debug.Log("World initialized");
    }


    // Create a block with a certain texture at position
    public void createBlock(Vector3 position, int textureIndex)
    {
        if (m_blockMap.ContainsKey(posToId(position))) return;

        GameObject tmpBlock = (GameObject)Instantiate(block, position, Quaternion.identity);
        tmpBlock.GetComponent<Block>().setTextureIndex(textureIndex);
        tmpBlock.transform.parent = gameObject.transform;
        m_blockMap.Add(posToId(position), tmpBlock);
    }

    public void deleteBlock(Vector3 position)
    {
        string id = posToId(position);

        if (m_blockMap.ContainsKey(id))
        {
            Destroy(m_blockMap[id]);
            m_blockMap.Remove(id);
        }

    }

    public GameObject getBlock(Vector3 position)
    {
        string id = posToId(position);

        if (m_blockMap.ContainsKey(id))
        {
            return m_blockMap[id];
        } else {
            return null;
        }
    }


    private string posToId(Vector3 pos)
    {
        // Take the absolute position and translate it to the relative position
        pos = pos - gameObject.transform.position;
        return $"{pos.x},{pos.y},{pos.z}";
    }

}
