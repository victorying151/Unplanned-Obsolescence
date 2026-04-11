using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceTower : MonoBehaviour
{
    public Vector3 mousePosition;
    public Vector3 worldPosition;
    public float offset;
    Plane plane = new Plane(Vector3.down, 0);
    public GameObject tower;
    public int overlap = 0;
    public GameObject invalid;
    public GameObject valid;
    public LogicManager logicManager;
    public int cost;

    void Start()
    {
        plane = new Plane(Vector3.down, offset);
        logicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManager>();
    }
    void Update()
    {
        mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        if (plane.Raycast(ray, out float distance))
        {
            worldPosition = ray.GetPoint(distance);
        }
        transform.position = worldPosition;

        if(Input.GetKeyDown(KeyCode.Mouse0) == true && !EventSystem.current.IsPointerOverGameObject() && overlap == 0)
        {
            if(logicManager.money >= cost)
            {
                logicManager.selectedTower = Instantiate(tower, new Vector3(transform.position.x, offset, transform.position.z), Quaternion.identity);
                logicManager.money -= cost;
            }
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) == true)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer == 7 || collider.gameObject.layer == 9)
        {
            overlap += 1;
            valid.SetActive(false);
            invalid.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.layer == 7 || collider.gameObject.layer == 9)
        {
            overlap -= 1;
            if (overlap == 0)
            {
                valid.SetActive(true);
                invalid.SetActive(false);
            }
        }
    }
}
