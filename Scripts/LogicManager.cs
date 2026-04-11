using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    public Vector3 mousePosition;
    public Ray ray;
    public LayerMask tower;
    public GameObject menu;
    public Button path1Button;
    public Button path2Button;
    public Button removeButton;
    public GameObject selectedTower;
    public int money;
    public Text moneyAmount;
    public Text upgradeCost1;
    public Text upgradeCost2;
    public float time;
    public GameObject currentShadow;
    public GameObject burnEffect;
    public Text towerHealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mousePosition = Input.mousePosition;
            ray = Camera.main.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000f, tower))
            {
                selectedTower = hit.collider.gameObject;
            }

        }
        if (selectedTower)
        {
            removeButton.interactable = true;
            Tower currentTower = selectedTower.GetComponent<Tower>();
            if (currentTower.upgrades.Count == 0)
            {
                path1Button.interactable = false;
                upgradeCost1.text = "X";
                path2Button.interactable = false;
                upgradeCost2.text = "X";
            }
            if (currentTower.upgrades.Count == 1 && currentTower.twozero && currentTower.threezeropossible <= 0)
            {
                path1Button.interactable = false;
                upgradeCost1.text = "Requires Wall 2-0";
                path2Button.interactable = false;
                upgradeCost2.text = "X";
            }
            if (currentTower.upgrades.Count == 1 && currentTower.zerotwo && currentTower.zerothreepossible <= 0)
            {
                path1Button.interactable = false;
                upgradeCost1.text = "Requires Wall 0-2";
                path2Button.interactable = false;
                upgradeCost2.text = "X";
            }
            if (currentTower.upgrades.Count == 1 && ((!currentTower.twozero && !currentTower.zerotwo) || (currentTower.twozero && currentTower.threezeropossible > 0) || (currentTower.zerotwo && currentTower.zerothreepossible > 0)))
            {
                path1Button.interactable = true;
                upgradeCost1.text = "Upgrade:" + currentTower.upgradeCosts[0].ToString();
                path2Button.interactable = false;
                upgradeCost2.text = "X";
            }
            if (currentTower.upgrades.Count == 2)
            {
                path1Button.interactable = true;
                path2Button.interactable = true;
                upgradeCost1.text = "Upgrade:" + currentTower.upgradeCosts[0].ToString();
                upgradeCost2.text = "Upgrade:" + currentTower.upgradeCosts[1].ToString();
            }
            towerHealth.text = "Tower Health: " + currentTower.health;
        }
        else
        {
            removeButton.interactable = false;
            path1Button.interactable = false;
            upgradeCost1.text = "X";
            path2Button.interactable = false;
            upgradeCost2.text = "X";
            towerHealth.text = "";
        }
        moneyAmount.text = "Money:" + money.ToString();

        bool bossAlive = healthBar.boss != null;

        if (healthBar.gameObject.activeSelf != bossAlive)
        {
            healthBar.gameObject.SetActive(bossAlive);
        }


        if (bossAlive)
        {
            if (healthBar.boss.health > healthBar.slider.maxValue)
            {
                healthBar.slider.maxValue = healthBar.boss.health;
            }
            healthBar.slider.value = healthBar.boss.health;
        }
    }

    public void CreateShadow(GameObject towerShadow)
    {
        if(currentShadow != null)
        {
            Destroy(currentShadow);
        }
        currentShadow = Instantiate(towerShadow, new Vector3(0, -10, 0), Quaternion.identity);
        
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
    }

    public void UpgradeTower(int path)
    {
        Tower towerToUpgrade = selectedTower.GetComponent<Tower>();
        if (towerToUpgrade != null)
        {
            if (towerToUpgrade.upgradeCosts[path] <= money)
            {
                money -= towerToUpgrade.upgradeCosts[path];
                GameObject newTower = Instantiate(towerToUpgrade.upgrades[path], selectedTower.transform.position, selectedTower.transform.rotation);
                Destroy(selectedTower);
                selectedTower = newTower;
            }
            
        }
    }

    public void RemoveTower()
    {
        if(selectedTower != null)
        {
            Destroy(selectedTower);
        }
    }
}
