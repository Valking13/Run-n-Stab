using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public TMPro.TextMeshProUGUI hpBarText;
    public Slider hpBarSlider;
    DamageableObject playerDmgComponent;
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) { Debug.Log("no player found"); }

        playerDmgComponent = player.GetComponent<DamageableObject>();
    }

    void Start()
    {
        Debug.Log(playerDmgComponent.HP+" "+ playerDmgComponent.MaxHP);
        hpBarSlider.value = CalculateSliderPercentage(playerDmgComponent.HP, playerDmgComponent.MaxHP);
        hpBarText.text = "HP: " + playerDmgComponent.HP + "/" + playerDmgComponent.MaxHP;
    }

    private float CalculateSliderPercentage(float hp, float maxHP)
    {
        return (hp / maxHP)*100;
    }
    // Update is called once per frame
    private void OnEnable()
    {
        playerDmgComponent.hpChange.AddListener(OnPlayerHealthChanged);
    }
    private void OnDisable()
    {
        playerDmgComponent.hpChange.RemoveListener(OnPlayerHealthChanged);
    }

    private void OnPlayerHealthChanged(int newHp, int maxHp)
    {
        hpBarSlider.value = CalculateSliderPercentage(newHp, maxHp);
        hpBarText.text = "HP: " + newHp+ "/" +maxHp;
    }
}
