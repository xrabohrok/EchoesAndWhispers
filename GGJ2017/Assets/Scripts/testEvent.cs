using UnityEngine;

public class testEvent : MonoBehaviour, InvestigationYields {

	// Use this for initialization
	void Start () {
		
	}

    public void DisplayAction()
    {
        Debug.Log(string.Format("You found {0}!!!", name));
    }

    public void ModifyLead(Lead target)
    {
        Debug.Log(string.Format("This event has modified target {0}", target.gameObject.name));
    }

    public int ModifyTimeLeft()
    {
        var randNum = Mathf.FloorToInt( Random.value);
        Debug.Log(string.Format("I just changed the agent's time {0} amount!", randNum));
        return randNum;
    }

    public int ModifyPips()
    {
        var randNum = Mathf.FloorToInt(Random.value);
        Debug.Log(string.Format("I just changed the agents {0} amount!", randNum));
        return randNum;
    }
}
