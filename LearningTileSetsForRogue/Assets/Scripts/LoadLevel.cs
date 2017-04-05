﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class LoadLevel : MonoBehaviour {
    const string BACKGROUND_FLOOR = "Background Floor";
    const string BACKGROUND = "Background";
    const string BACKGROUND_DETAIL = "Background Detail";
    const string OBSTACLE = "Obstacle";
    const string INTERACTIBLE = "Interactible";
    const string PLAYER = "Player";
    const string FOREGROUND = "Foreground";
    const string FOREGROUND_DETAIL = "Foreground Detail";

    public TextAsset levelInfo;

    // Use this for initialization
    void Start()
    {
        XmlDocument xmlDoc = new XmlDocument();
        //TextAsset levelinfo;
        //levelinfo = Resources.Load("Levels/testLevel") as TextAsset;

        GameObject emptyObject = new GameObject();

        xmlDoc.LoadXml(levelinfo.text);

        string nameOfImage = xmlDoc.DocumentElement.ChildNodes[0].ChildNodes[0].Attributes["source"].InnerText;

        //Debug.Log(nameOfImage);

        Sprite[] levelSprites = Resources.LoadAll<Sprite>(nameOfImage);

        XmlNodeList layerNames = xmlDoc.DocumentElement.GetElementsByTagName("layer");

        //get tile width and height\
        float tileWidth = float.Parse(xmlDoc.DocumentElement.ChildNodes[0].Attributes["tilewidth"].InnerText);
        float tileHeight = float.Parse(xmlDoc.DocumentElement.ChildNodes[0].Attributes["tileheight"].InnerText);

        //doing all of this for each layer
        for (int layerNum = 0; layerNum < layerNames.Count; layerNum++)
        {
            //create object for layer 1
            GameObject parentObject = new GameObject();
            parentObject.name = layerNames[layerNum].Attributes["name"].InnerText;

            //go through first layer (background Floor layer)
            float layerWidth = float.Parse(layerNames[layerNum].Attributes["width"].InnerText);
            float layerHeight = float.Parse(layerNames[layerNum].Attributes["width"].InnerText);

            //select data node
            XmlNode dataNode = layerNames[layerNum].SelectSingleNode("data");

            //first (rows[0] and last (rows.Length-1) are empty
            string[] rows = dataNode.InnerText.Split('\n'); //these are the rows, ex 275, 270, ...

            for (int row = 1; row < layerHeight + 1; row++) //for each column
            {
                //getting the row based on the sprite
                string[] values = rows[row].Split(','); // pull an entire row into individual values
                for (int col = 0; col < layerWidth; col++)
                {
                    //
                    int theIndexofSprite = int.Parse(values[col]);

                    if (theIndexofSprite == 0)
                        continue;

                    GameObject tempSprite = Instantiate(emptyObject);
                    tempSprite.transform.SetParent(parentObject.transform); // set the current object as a kid of the parent so it's collapsable in heirarchy
                    tempSprite.transform.position = new Vector3(col, row, 0);
                    SpriteRenderer tempRenderer = tempSprite.AddComponent<SpriteRenderer>();
                    tempRenderer.sortingLayerName = parentObject.name;
                    tempRenderer.sprite = levelSprites[theIndexofSprite - 1];

                    //apply conponents based on layer
                    if(parentObject.name == "Obstacle")
                    {
                        Rigidbody2D tempRB = tempSprite.AddComponent<Rigidbody2D>();
                        tempRB.gravityScale = 0;
                        tempRB.simulated = false;
                        tempSprite.AddComponent<BoxCollider2D>();
                    }
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
