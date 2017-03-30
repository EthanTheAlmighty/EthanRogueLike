using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class LoadLevel : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        XmlDocument xmlDoc = new XmlDocument();
        TextAsset levelinfo;
        levelinfo = Resources.Load("Levels/testLevel") as TextAsset;

        xmlDoc.LoadXml(levelinfo.text);

        string nameOfImage = xmlDoc.DocumentElement.ChildNodes[0].ChildNodes[0].Attributes["source"].InnerText;

        Debug.Log(nameOfImage);

        Sprite[] levelSprites = Resources.LoadAll<Sprite>(nameOfImage);

        XmlNodeList layerNames = xmlDoc.DocumentElement.GetElementsByTagName("layer");

        //get tile width and height\
        float tileWidth = float.Parse(xmlDoc.DocumentElement.ChildNodes[0].Attributes["tileWidth"].InnerText);
        float tileHeight = float.Parse(xmlDoc.DocumentElement.ChildNodes[0].Attributes["tileHeight"].InnerText);

        //go through first layer (background Floor layer)
        float layerWidth = float.Parse(layerNames[0].Attributes["width"].InnerText);
        float layerHeight = float.Parse(layerNames[0].Attributes["width"].InnerText);

        //select data node
        XmlNode dataNode = layerNames[0].SelectSingleNode("data");

        //first (rows[0] and last (rows.Length-1) are empty
        string[] rows = dataNode.InnerText.Split('\n');

        for(int row = 1; row < layerHeight + 1; row++)
        {
            string[] values = rows[row].Split(',');
            for(int col = 0; col < layerWidth; col++)
            {

            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
