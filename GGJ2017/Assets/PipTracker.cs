using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipTracker : MonoBehaviour
{
    public GameObject PipTemplate;
    private List<GameObject> pips;

    public int pipsPerDay;

    private int workingPipsRemaining;
    public float pipSpacing;

    public int pipsRemaining
    {
        get { return workingPipsRemaining; }
    }

    public void newTurnStarts()
    {
        workingPipsRemaining = pipsPerDay;
    }

	// Use this for initialization
	void Start ()
	{
        if(pips == null)
            pips = new List<GameObject>();

	    int i = 0;
	    while (i < pipsPerDay)
	    {
	        var thisPip = Instantiate(PipTemplate, new Vector3(this.transform.position.x + i * pipSpacing, this.transform.position.y), Quaternion.identity);
            pips.Add(thisPip);
	        thisPip.transform.parent = this.transform;
	        i++;
	    }
		
        newTurnStarts();
	}

    public bool attempPipChange(int pipsRemoved)
    {
        if (pipsRemoved > workingPipsRemaining)
            return false;

        workingPipsRemaining -= pipsRemoved;
        reEvalPips();
        return true;
    }

    private void reEvalPips()
    {
        int i = 0;
        foreach (var pip in pips)
        {
            if (i > workingPipsRemaining)
            {
                //this will do more later
                pip.SetActive(false);
            }
            i++;
        }
    }

    public void decrement()
    {
        attempPipChange(1);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        int i = 0;
        while (i < pipsPerDay && PipTemplate != null)
        {
//            Gizmos.DrawCube( transform.TransformPoint(new Vector3(i * pipSpacing, 0)), Vector3.one * 20);
            Gizmos.DrawGUITexture(new Rect(transform.TransformPoint(new Vector3(i * pipSpacing, 0)), 20 * PipTemplate.transform.localScale), PipTemplate.GetComponent<Image>().sprite.texture );
            i++;
        }
    } 

}
