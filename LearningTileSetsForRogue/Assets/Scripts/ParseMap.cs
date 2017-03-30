using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;

public class ParseMap : MonoBehaviour {

    private void Start()
    {
        LoadMap();
    }

    string tilesheetName;
    Sprite[] mapSprites;

    void LoadMap()
    {
        //ClearLevel()

        //Wait for end of frame

        //load xml document
        XmlDocument xmlDoc = new XmlDocument();

        //load level info into doc
        xmlDoc.LoadXml((Resources.Load(@"Levels/theMazrofMazes") as TextAsset).text);
        //Debug.Log(xmlDoc.Name);

        XmlNodeList RoyceOgreNodes = xmlDoc.GetElementsByTagName("layer");

        //Debug.Log(RoyceOgreNodes[0].Attributes[0].InnerText);

        XmlNode tilesetNode = xmlDoc.SelectSingleNode("map").SelectSingleNode("tileset");
        tilesheetName = tilesetNode.SelectSingleNode("image").Attributes["source"].InnerText;
        mapSprites = Resources.LoadAll<Sprite>(tilesheetName);
        //Debug.Log(mapSprites.Length);
        //tile width and height
        float tileWidth = float.Parse(tilesetNode.Attributes["tilewidth"].Value);
        float tileHeight = float.Parse(tilesetNode.Attributes["tileheight"].Value);

        foreach(XmlNode Royce in RoyceOgreNodes)
        {
            int layerRow = int.Parse(Royce.Attributes["width"].Value);
            int layerCol = int.Parse(Royce.Attributes["height"].Value);

            //get the layer GID's
            XmlNode dataNode = Royce.SelectSingleNode("data");

            int rowIndex = 0, colIndex = 0;
            int depth = 0;

            string[] tileGIDs = dataNode.InnerText.Split(',');

            for(int tileCol = 0; tileCol < layerCol; tileCol++)
            {
                for(int tileRow = 0; tileRow < layerRow; tileRow++)
                {
                    GameObject tempSprite = new GameObject("New GO");
                    SpriteRenderer spriteRend = tempSprite.AddComponent<SpriteRenderer>();
                    spriteRend.sprite = mapSprites[0];
                    tempSprite.transform.position = new Vector3((tileWidth * tileRow), (tileHeight * tileCol));
                }
            }
        }

        //get a tile
        

        //Debug.Log(tileHeight);
        //load sprites into array
    }
}
