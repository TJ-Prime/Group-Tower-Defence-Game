using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                if (GameObject.Find("Selection") != null)
                {
                    Destroy(GameObject.Find("Selection"));
                }
                Vector3 p = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                p = new Vector3(Mathf.Round(p.x),
                                Mathf.Round(p.y),
                                -0.5f);

                GameObject newPoint = Instantiate(Resources.Load("Selection")) as GameObject;
                newPoint.transform.position = p;
                newPoint.name = "Selection";
            }
        }
    }
}
