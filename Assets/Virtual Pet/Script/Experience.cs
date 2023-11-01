using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
#if UNITY_EDITOR
[CustomEditor(typeof(Experience))]
public class LevelUpEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Experience levelUpManager = (Experience)target;
        if (GUILayout.Button("Add Experience"))
        {
            levelUpManager.AddExperience(50);
        }

        DrawDefaultInspector();
    }
}
#endif
public class Experience : MonoBehaviour
{
    [Header("Experience Progress")]
    public int currentLevel;
    public float progressValue;
    public float experience;
    public float experienceLimit;

    [Header("Text Contents")]
    public TextMeshProUGUI experienceText;
    public TextMeshProUGUI currentLevelText;

    public void AddExperience(int addAmount)
    {
        experience += addAmount;
        progressValue = experience / experienceLimit;
        if (experience >= experienceLimit)
        {
            StartCoroutine(DisplayLevelUpPopUp());
        }
    }
    IEnumerator DisplayLevelUpPopUp()
    {
        currentLevel++;
        experience = 0;
        experienceLimit += 50;
        yield return new WaitForSeconds(1);
    }
    // Update is called once per frame
    void Update()
    {
        experienceText.text = experience + "/" + experienceLimit.ToString();
        currentLevelText.text = "Level : " + currentLevel.ToString();

    }
}
