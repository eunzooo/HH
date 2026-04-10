using UnityEngine;
using System.Collections.Generic;

public class CSVLoader : MonoBehaviour
{
    public List<NPCData> npcList = new List<NPCData>();

    void Start()
    {
        LoadCSV();
    }

    void LoadCSV()
    {
        TextAsset csvFile = Resources.Load<TextAsset>("npc");
        string[] lines = csvFile.text.Split('\n');

        for (int i = 1; i < lines.Length; i++) // 첫 줄은 헤더
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

            npcList.Add(npc);
        }
    }
}