using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rumor: MonoBehaviour {

    public List<Person> infectedPersons;
    public Person target;
    public List<Person> allPersons;

	// Use this for initialization
	void Start () {	}
	
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

    public void recursivelyFillPersonList(Person person)
    {
        person.getConnections().ForEach((Link link) => {
            var otherPerson = person.getOtherPersonFromLink(link);
            if (!this.allPersons.Contains(otherPerson) && otherPerson != this.target)
            {
                this.allPersons.Add(otherPerson);
                this.recursivelyFillPersonList(otherPerson);
            }
        });
    }

    public void startRumorAbout(Person target, Person start)
    {
        this.target = target;

        this.allPersons = new List<Person>();
        this.recursivelyFillPersonList(start);

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
                if (connection.contains(this.target))
                {
                    //TODO: Miss chance.
                    this.breakLink(infected);
                }
                else
                {
                    Person otherPerson = infected.getOtherPersonFromLink(connection);
                    if (!otherPerson.isInfectedByRumor(this))
                    {
                        // TODO: Miss chance
                        this.infect(otherPerson);
                    }
                }
            });
        });
        
        if(this.infectedPersons == this.allPersons)
        { this.destroySelf(); }
    }

    public void breakLink(Person person)
    {
        person.breakLinkWith(this.target);
        this.target.breakLinkWith(person);
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
