using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCUI : MonoBehaviour
{
    public CSVLoader csvLoader;

    public TMP_Text nameText;
    public TMP_Text ageText;
    public TMP_Text jobText;
    public TMP_Text deathText;
    public TMP_Text criminalText;
    public TMP_Text historyText;
    public TMP_Text noteText;
    public Image portraitImage;

    private int currentIndex = 0;
    private List<int> npcIdList = new List<int>();


    public RectTransform portraitTransform;

    public float moveDistance = 500f;
    public float moveDuration = 0.5f;

    private Vector2 originalPos;


    void Start()
    {
        npcIdList = new List<int>(csvLoader.npcDict.Keys);

        originalPos = portraitTransform.anchoredPosition;

        ShowNPC(npcIdList[currentIndex]);
    }
    public void ShowNPC(int id)
    {
        NPCData npc = csvLoader.GetNPC(id);

        if (npc == null) return;

        nameText.text = npc.name;
        ageText.text = npc.age + "세";
        jobText.text = npc.job;
        deathText.text = npc.cause_of_death;
        criminalText.text = string.Join(", ", npc.criminal_history);
        historyText.text = string.Join(", ", npc.preceding_history);
        noteText.text = npc.note;
        portraitImage.sprite = npc.portrait;
    }
    public void ShowRandomNPC()
    {
        if (npcIdList.Count == 0) return;

        currentIndex = Random.Range(0, npcIdList.Count);
        ShowNPC(npcIdList[currentIndex]);
    }
    public void OnHeavenButton()
    {
        StartCoroutine(MoveAndNext(Vector2.up));
    }

    public void OnHellButton()
    {
        StartCoroutine(MoveAndNext(Vector2.down));
    }

    System.Collections.IEnumerator MoveAndNext(Vector2 direction)
    {
        Vector2 startPos = portraitTransform.anchoredPosition;
        Vector2 targetPos = startPos + direction * moveDistance;

        float time = 0f;

        // 이동 애니메이션
        while (time < moveDuration)
        {
            time += Time.deltaTime;
            float t = time / moveDuration;

            portraitTransform.anchoredPosition = Vector2.Lerp(startPos, targetPos, t);
            yield return null;
        }

        ShowRandomNPC();

        // 위치 초기화
        portraitTransform.anchoredPosition = originalPos;
    }
}