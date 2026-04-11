using UnityEngine;
using System.Collections.Generic;

public class CSVLoader : MonoBehaviour
{
    public Dictionary<int, NPCData> npcDict = new Dictionary<int, NPCData>();

    void Awake()
    {
        LoadCSV();
    }

    void LoadCSV()
    {
        TextAsset csvFile = Resources.Load<TextAsset>("HH_npc_data");

        if (csvFile == null)
        {
            Debug.LogError("CSV 파일 못 찾음");
            return;
        }

        string[] lines = csvFile.text.Split(new[] { "\r\n", "\n" }, System.StringSplitOptions.None);

        //Debug.Log("총 줄 수: " + lines.Length);

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;

            //Debug.Log("원본 줄: " + lines[i]);

            string[] data = lines[i].Split(','); 

            //Debug.Log("분리 개수: " + data.Length);

            for (int j = 0; j < data.Length; j++)
                data[j] = data[j].Trim();

            if (data.Length < 8)
            {
                Debug.LogWarning("데이터 부족: " + lines[i]);
                continue;
            }

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

            npcDict[npc.id] = npc;
        }

        //Debug.Log("NPC 로드 완료: " + npcDict.Count);
    }
    public NPCData GetNPC(int id)
    {
        if (npcDict.TryGetValue(id, out NPCData npc))
            return npc;

        Debug.LogWarning("NPC 없음: " + id);
        return null;
    }
}