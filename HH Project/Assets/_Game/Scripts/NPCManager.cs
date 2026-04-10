using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.U2D;

public class NPCManager : MonoBehaviour
{
    public TMP_Text nameText;
    public Image portraitImage;

    Dictionary<int, NPCData> npcDict = new Dictionary<int, NPCData>();

    void Start()
    {
        LoadCSV();
        ShowNPC(1); // id 1 테스트
    }

    void LoadCSV()
    {
        TextAsset csvFile = Resources.Load<TextAsset>("HH_npc_data");
        string[] lines = csvFile.text.Split('\n');

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;

            string[] data = lines[i].Split(',');

            NPCData npc = new NPCData()
            {
                name = data[0],
                id = int.Parse(data[1]),
                job = data[2],
                cause_of_death = data[3],
                criminal_history = data[4].Split('|'),
                preceding_history = data[5].Split('|'),
                note = data[6],
                portrait = Resources.Load<Sprite>("Images/" + data[7])

            };
            Sprite sprite = Resources.Load<Sprite>("Images/" + data[7]);

            if (sprite == null)
                Debug.LogError("이미지 못 찾음: " + data[7]);
            npcDict.Add(npc.id, npc);
        }
    }

    void ShowNPC(int id)
    {
        if (npcDict.TryGetValue(id, out NPCData npc))
        {
            nameText.text = npc.name;
            portraitImage.sprite = npc.portrait;
        }
        else
        {
            Debug.Log("NPC 없음");
        }
    }
}