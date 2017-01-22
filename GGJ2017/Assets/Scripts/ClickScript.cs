using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ClickScript : MonoBehaviour {

    public Vector3 lastGoodPoint { get; set; }
    public Vector3 clickedLocation { get; set; }
    public List<GameObject> clickedObject { get; set;  }

    private bool valid = false;
    public bool validClickable { get { return valid; } }

	// Use this for initialization
    void Start()
    {
        clickedObject = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Cursor.visible)
        {
            valid = clickedObject.Any();
            clickedLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
	}

    public List<GameObject> getAndClearClicked()
    {
        var temp = clickedObject;
        clickedObject = new List<GameObject>();
        return temp;
    }

    public void ReportHover(Clickable victim)
    {
        clickedObject.Add(victim.gameObject);
        lastGoodPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
