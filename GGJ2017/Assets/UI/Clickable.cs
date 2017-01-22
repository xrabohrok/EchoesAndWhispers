using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Clickable : MonoBehaviour
{
    public string clickMasterTag = "clickMaster";

    private Collider2D collider;
    private ClickScript clickMaster;

    // Use this for initialization
    void Start ()
	{
	    collider = GetComponent<Collider2D>();
	    clickMaster = GameObject.FindGameObjectWithTag(clickMasterTag).GetComponent<ClickScript>();
	}
	
	// Update is called once per frame
	void Update () {

        if(Cursor.visible && collider.OverlapPoint(Camera.main.ScreenToWorldPoint( Input.mousePosition)))
	    {
            clickMaster.ReportHover(this);
        }

    }
}
