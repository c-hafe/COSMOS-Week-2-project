using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TowerPlace : MonoBehaviour
{
    public GameObject wall;
    public GameObject turret;

    public GameObject buildTowerPanel;
    public Button buildWallButton;
    public Button buildTurretButton;
    public Button buildTurret1;

    public static int money;

    public UnityAction buildWall;
    public UnityAction buildTurret;

    public GameObject canvas;
    RectTransform canvasRect;
    RectTransform panelRect;

    // Start is called before the first frame update
    void Start()
    {
        buildWall += placeWall;
        buildWallButton = buildWallButton.GetComponent<Button>();
        buildWallButton.onClick.AddListener(buildWall);

        buildTurret += placeTurret;
        buildTurretButton = buildTurretButton.GetComponent<Button>();
        buildTurretButton.onClick.AddListener(buildTurret);

        money = 15;
        canvas = GameObject.Find("Canvas");
        canvasRect = canvas.GetComponent<RectTransform>();
        panelRect = buildTowerPanel.GetComponent<RectTransform>();
    }

    private void placeWall()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            GameObject.Instantiate(wall, hit.point, Quaternion.identity);
        }
            
            

        
        buildTowerPanel.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (buildTowerPanel.activeSelf != true)
            {

                buildTowerPanel.SetActive(true);
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    if (hit.collider.gameObject.tag == "Ground")
                    {

                        buildTowerPanel.SetActive(true);

                        //Calculate the position of the UI element. 0,0 for the canvas is at the center of the screen,
                        //whereas WorldToViewPortPoint treats the lower left corner as 0,0. Because of this, you need
                        //to subtract the height / width of the canvas * 0.5 to get the correct position.

                        Vector2 panelPosition = Camera.main.WorldToViewportPoint(hit.point);

                        Vector2 worldObjectScreenPosition = new Vector2(
                            ((panelPosition.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f)),
                            ((panelPosition.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f))
                            );

                        panelRect.anchoredPosition = worldObjectScreenPosition;

                    }

                }

            }
        }

        
    }
    void placeTurret()
    {
        RaycastHit hit;

        //Check to see if raycast from camera at the current mouse position hits the terrain
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            Vector3 newPos = hit.point += transform.up * 4;
            GameObject.Instantiate(turret, hit.point, Quaternion.identity);

            //hit.point is where the raycast hit the terrain, move to that location

        }
        buildTowerPanel.SetActive(false);

    }
}




