using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelect : MonoBehaviour
{
    int TowerIndex = 0;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Vector3 p = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                p = new Vector3(Mathf.Round(p.x),
                                Mathf.Round(p.y),
                                -0.5f);

                //Detect if position is valid or out of bounds
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                bool hasHit = Physics.Raycast(ray, out hit);

                if (!hasHit)
                {
                    RemoveSelection();
                }
                else if (hasHit)
                {
                    if (hit.collider.gameObject.name == "Grid")
                    {
                        SelectBox(p);
                    }
                    else
                    {
                        RemoveSelection();
                    }
                }
            }
        }
    }

    void RemoveSelection()
    {
        if (GameObject.Find("Selection") != null)
        {
            Destroy(GameObject.Find("Selection"));
            TowerIndex = -1;
        }
    }

    void SelectBox(Vector3 p)
    {
        if (TowerIndex == -1) //No tower has been selected
        {
            if (GameObject.Find("Selection") != null)
            {
                Destroy(GameObject.Find("Selection"));
            }

            GameObject newPoint = Instantiate(Resources.Load("Selection")) as GameObject;
            newPoint.transform.position = p;
            newPoint.name = "Selection";
        }
        else
        {
            string TowerName = transform.GetChild(TowerIndex).name;
            GameObject newTower = Instantiate(Resources.Load("Towers/Test/" + TowerName)) as GameObject;
            newTower.transform.position = p;
            newTower.name = TowerName;
        }
    }

    public void newSelection(int Index)
    {
        TowerIndex = Index;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).Find("SelectBox").gameObject.SetActive(false);
        }
        transform.GetChild(Index).Find("SelectBox").gameObject.SetActive(true);
    }
}
