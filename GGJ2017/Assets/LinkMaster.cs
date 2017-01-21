using UnityEngine;

public class LinkMaster : MonoBehaviour
{

    public GameObject LinkPrefab;

	// Use this for initialization
	void Start ()
	{

	    var everyone = GameObject.FindGameObjectsWithTag("person");

        //this allows people to be linked directly in the editor
        //I don't need people shooting themselves, not now.
	    foreach (var dude in everyone)
	    {
	        var currentPerson = dude.GetComponent<Person>();
	        var peopleConnections = currentPerson.showStarterLinks();

	        foreach (var person in peopleConnections)
	        {
	            var personComp = person.GetComponent<Person>();
	            if (personComp != null)
	            {
                    //check existing links real quick
                    if (!personComp.isLinkedTo(currentPerson))
	                {
	                    var temp = Instantiate(LinkPrefab);
	                    var tempLink = temp.GetComponent<Link>();
	                    tempLink.recieveTargets(currentPerson, personComp);
                        personComp.recieveLink(tempLink);
                        currentPerson.recieveLink(tempLink);
	                }
	            }
	        }
	    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
