using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Person : MonoBehaviour
{

    public string name;
    private List<Links> connections;

    public List<GameObject> peopleConnections; 

	// Use this for initialization
	void Start ()
	{
	    name = (Random.value*100).ToString();
        if(connections == null)
            connections = new List<Links>();
    }

    public void recieveLink(Links link)
    {
        if (connections == null)
            connections = new List<Links>();
        connections.Add(link);
    }

    public bool isLinkedTo(Person person)
    {
        if (connections == null)
            return false;
        return connections.Exists(p => p.personA == person || p.personB == person);
    }

    public List<GameObject> showStarterLinks()
    {
        return peopleConnections;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
