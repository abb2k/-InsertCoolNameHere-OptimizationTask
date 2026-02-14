using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    
    [SerializeField] private PlayerCharacterController bobby;
    [SerializeField] private SkillButtonUI[] skillsButtons;
    [SerializeField] private Sprite[] skillIcons;
    
    public void RefreshHPText(int newHP)
    {
        hpText.text = newHP.ToString();
    }

    private void Awake()
    {
        bobby.onTakeDamageEventAction += RefreshHPText;
    }

    private void Start()
    {
        hpText.text = bobby.Hp.ToString();

        int index = 0;
        foreach (var skillBtn in skillsButtons)
        {
            skillBtn.skillIcon.sprite = skillIcons[index];
            skillBtn.skillNameText.text = $"Skill {index + 1}";

            index++;
        }
    }
}
