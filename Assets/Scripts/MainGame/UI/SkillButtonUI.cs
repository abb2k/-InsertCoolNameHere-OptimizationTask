using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonUI : MonoBehaviour
{   
    [SerializeField] private Image skillIcon;
    public Image SkillIcon => skillIcon;
    [SerializeField] private TMP_Text skillNameText;
    public TMP_Text SkillNameText => skillNameText;
}