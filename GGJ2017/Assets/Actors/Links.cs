using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Links : MonoBehaviour
{
    public GameObject personA;
    public GameObject personB;

    public bool visible;

    public GameObject drawLinkPiece;
    public float LinkWidth = .5f;
    public float LinkSpacing = .02f;

    private int lastnum = 0;

    // Use this for initialization
    void Start()
    {
    }



    // Update is called once per frame
    void Update()
    {
        var placea = personA.transform.position;
        var placeb = personB.transform.position;
        this.transform.position = placea;

        var dist = placeb - placea;
        var num = Mathf.FloorToInt( Mathf.Abs( dist.magnitude/(LinkWidth)));

        if (lastnum != num)        {            List<GameObject> children = new List<GameObject>();
            for (int i = 0; i < this.transform.childCount; i++)
            {
                children.Add(transform.GetChild(i).gameObject);
            }
            children.ForEach(Destroy);

            for (int i = 0; i < num; i++)            {                var temp = GameObject.Instantiate(drawLinkPiece);
                temp.transform.position = transform.position;
                temp.transform.localPosition += new Vector3(LinkWidth + LinkSpacing, 0) * i;                temp.transform.parent = this.gameObject.transform;
            }

        }
        lastnum = num;

        
        dist.Normalize();        float rot_z = Mathf.Atan2(dist.y, dist.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(rot_z, Vector3.forward);

        Debug.Log(personA.transform.position);



    }
}