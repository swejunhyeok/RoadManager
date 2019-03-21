using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderManager : MonoBehaviour {
    public GameObject roadManager;
    public RoadManager s_roadManger;

    public bool Render_Control = true;

    int Length;
    // Use this for initialization
    void Start () {
        s_roadManger = roadManager.GetComponent<RoadManager>();
        Length = s_roadManger.Road_Size * 27;
        float this_Length = Mathf.Sqrt((Length/2) * (Length/2) + (Length / 2) * (Length / 2));
        this.transform.localScale = new Vector3(this_Length, 100, this_Length);
        this.transform.position = new Vector3(0, 0, Length / 4);
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider other)
    {
        if (Render_Control)
        {
            Renderer[] rend = other.gameObject.GetComponentsInChildren<Renderer>();
            for (int i = 0; i < rend.Length; i++)
            {
                if (rend[i] != null)
                    rend[i].enabled = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (Render_Control)
        {
            Renderer[] rend = other.gameObject.GetComponentsInChildren<Renderer>();
            for (int i = 0; i < rend.Length; i++)
            {
                if (rend[i] != null)
                    rend[i].enabled = false;
            }
        }
    }
}
