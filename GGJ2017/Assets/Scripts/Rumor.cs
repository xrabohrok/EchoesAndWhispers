using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rumor: MonoBehaviour {

    public List<Person> infectedPersons;
    public Link target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.propagate();
	}

    public void infect(Person person)
    {
        if (!this.infectedPersons.Contains(person))
        {
            this.infectedPersons.Add(person);
            person.infect(this);
        }
    }

    public void startRumorAbout(Link target, Person start)
    {
        this.target = target;
        if (this.infectedPersons == null)
        {
            this.infectedPersons = new List<Person>();
            this.infect(start);
        }
    }

    public void propagate()
    {
        this.infectedPersons.ForEach((Person infected) =>
        {
            infected.getConnections().ForEach((Link connection) => {
                Person otherPerson = infected.getOtherPersonFromLink(connection);
                if (!otherPerson.isInfectedByRumor(this))
                {
                    // TODO: Miss chance
                    this.infect(otherPerson);
                }
            });
        });
    }

    public void breakLink()
    {
        target.personA.breakLinkWith(target.personB);
        target.personB.breakLinkWith(target.personA);
        this.destroySelf();
    }

    public void destroySelf()
    {
        this.infectedPersons.ForEach((Person person) =>
        {
            person.rumors.Remove(this);
        });

        this.infectedPersons = new List<Person>();
        this.target = null;
    }
}
