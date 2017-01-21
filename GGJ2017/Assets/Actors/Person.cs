using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Person : MonoBehaviour
{

    public string name;
    private List<Link> connections;
    public bool alive { get; set; }

    public List<GameObject> peopleConnections; 

	// Use this for initialization
	void Start ()
	{
	    name = (Random.value*100).ToString();
        if(connections == null)
            connections = new List<Link>();
    }

    public void recieveLink(Link link)
    {
        if (connections == null)
            connections = new List<Link>();
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

    public void breakLinkWith(Person person)
    {

    }

    public void breakLink(Link link)
    {

    }

    public void createLinkWith(Person person)
    {
        if (connections == null)
            connections = new List<Link>();

    }

    public void die()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
