using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NPCData
{
    public string name;
    public int id;
    public int age;
    public string job;
    public string cause_of_death;           // 사인
    public string[] criminal_history;       // 범죄 이력
    public string[] preceding_history;      // 선행 이력
    public string note;                     // 비고
    public Sprite portrait;                 // 초상화

}