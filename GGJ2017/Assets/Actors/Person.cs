using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class Person : MonoBehaviour
{
    public List<Sprite> boyPics;
    public List<Sprite> girlPics;
    public bool generateId = true;

    public GameObject PortraitTarget;

    public static List<string> boyNames;
    private static List<string> girlNames;

    public string name;
    private List<Link> connections;
    public bool alive { get; set; }

    private bool isBoy;

    public List<ManualConnection> peopleConnections; 

    public bool isMissionTarget = false;

	// Use this for initialization
	void Start ()
	{

	    if (boyNames == null)
	    {
	        var rawBoyNames = Resources.Load<TextAsset>("boy_names");
	        boyNames = rawBoyNames.text.Split('\n').ToList();
            
	    }

        if (girlNames == null)
        {
            var rawGirlNames = Resources.Load<TextAsset>("girl_names");
            girlNames = rawGirlNames.text.Split('\n').ToList();
        }

        if(generateId)
        {
            var portRenderer = PortraitTarget.GetComponent<SpriteRenderer>();

            isBoy = Mathf.FloorToInt(Random.value * 100) > 50;

            if (isBoy)
            {
                name = boyNames[Mathf.FloorToInt((Random.value * boyNames.Count))];
                if (portRenderer != null)
                {
                    portRenderer.sprite = boyPics[Mathf.FloorToInt((Random.value * boyPics.Count))];
                }

            }
            else
            {
                name = girlNames[Mathf.FloorToInt((Random.value * boyNames.Count))];
                if (portRenderer != null)
                {
                    portRenderer.sprite = girlPics[Mathf.FloorToInt((Random.value * girlPics.Count))];
                }
            }
        }

	    alive = true;

        if (connections == null)
            connections = new List<Link>();
    }

    public void recieveLink(Link link)
    {
        if (connections == null)
            connections = new List<Link>();
        Person other = this.getOtherPersonFromLink(link);
        if(!this.isLinkedTo(other))
            connections.Add(link);
    }

    public Person getOtherPersonFromLink(Link link)
    {
        Person otherPerson;
        if (link.personA == this)
            otherPerson = link.personB;
        else
            otherPerson = link.personA;
        return otherPerson;
    }

    public bool isLinkedTo(Person person)
    {
        if (connections == null)
            return false;
        return connections.Exists(p => p.personA == person || p.personB == person);
    }

    public List<ManualConnection> showStarterLinks()
    {
        return peopleConnections;
    }

    public void breakLinkWith(Person person)
    {
        connections.ForEach((Link linkToPerson) => {
            if (linkToPerson.personA == person || linkToPerson.personB == person)
            {
                this.connections.Remove(linkToPerson);
            }
        });
    }

    public void breakLink(Link link)
    {
        connections.Remove(link);
    }

    public void createLinkWith(Person person)
    {
        Link newLink = new Link();
        newLink.recieveTargets(this, person);
        this.recieveLink(newLink);
    }

    public void die()
    {
        this.alive = false;
    }

    public List<Link> getConnections()
    {
        return this.connections;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void move(Vector3 newloc)
    {
        this.transform.position = new Vector3(newloc.x, newloc.y, 0);
    }
}

[Serializable]
public class ManualConnection
{
    public bool visible;
    public GameObject person;
}
