using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;

public class BasicParsing : MonoBehaviour {

	// Use this for initialization
	void Start () {
        TextAsset xmlFile = Resources.Load("BookList") as TextAsset; // load the xml file into a text asset
        XmlDocument xmlDoc = new XmlDocument(); // use the xml library to create a new xml document

        xmlDoc.LoadXml(xmlFile.text);   //load the file stored in xmlFile as an XML document

        //create vars to store data
        string tempArtist = "";
        string tempTitle = "";
        string tempGenre = "";
        double tempPrice = 0;
        string tempYear = "";
        string tempMonth = "";
        int books = 0;

        ////documentelelement = first node in the file
        //XmlNodeList CDs = xmlDoc.DocumentElement.ChildNodes;

        //XmlNode firstCD = CDs[0];

        //XmlNode firstCDTitle = firstCD.ChildNodes[0];

        //Debug.Log(firstCDTitle.InnerText);

        //Debug.Log(CDs.Count);

        foreach(XmlNode Book in xmlDoc.DocumentElement.ChildNodes)
        {
            //shows we're in each book
            //Debug.Log(Book.Attributes["id"].Value);
            //somehow get the book's id
            if (Book.Attributes["id"].Value == "bk109")
                continue;

            foreach (XmlNode book in Book.ChildNodes)
            {
                //shows each of the categories
                //Debug.Log(book.InnerText);
                switch(book.Name)
                {
                    case "author":
                        //gets each author
                        //Debug.Log(book.InnerText);
                        tempArtist = book.InnerText;
                        break;
                    case "title":
                        tempTitle = book.InnerText;
                        break;
                    case "genre":
                        tempGenre = book.InnerText;
                        break;
                    case "price":
                        tempPrice = Convert.ToDouble(book.InnerText);
                        break;
                    case "publish_date":
                        tempYear = book.InnerText.Substring(0, 4);
                        tempMonth = book.InnerText.Substring(5, 2);
                        //Debug.Log(tempMonth);
                        //slicing publish date to just get year and a month
                        //Debug.Log(tempYear);
                        break;   
                }

                

                #region "cd stuff"
                ////inside each CD
                //switch(book.Name)
                //{
                //    case "author":
                //        break;
                //    case "title":
                //        break;
                //    case "COUNTRY":
                //        break;
                //    case "COMPANY":
                //        break;
                //    case "PRICE":
                //        break;
                //    case "YEAR":
                //        break;
                //}
                #endregion
            }

            if (tempYear == 2000.ToString())
            {
                if (tempMonth != "04")
                {
                    Debug.Log(string.Format("Author: {0} Title: {1}", tempArtist, tempTitle));

                }
            }
            else if (tempYear == 2001.ToString())
            {
                if (tempMonth != "04")
                {
                    Debug.Log(string.Format("Author: {0} Title: {1}\nGenre: {2} Price: {3}", tempArtist, tempTitle, tempGenre, tempPrice.ToString()));

                }
            }
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
