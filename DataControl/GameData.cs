using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using PixelCrushers.DialogueSystem;

[Serializable] // 직렬화

//Save 할 데이터 리스트
public class GameData
{ 
    //player 데이터
    public int player_Max_Hp;
    public int player_Hp;
    public int player_Mp;
    public int attackPoint;
    public int player_Lv;
    public double player_Exp;
    public double require_LevelUp;
    public int skillPoint;

    //Npc 데이터
    public bool luna;
    public bool npc;
    public string npcName;

    //스킬 데이터
    public string[] magic = new string[3];
    public int[] magicLevel = new int[3];
    public int passive1Level;  // 0이면 비활성화.
    public int passive2Level;  // 0이면 비활성화.
    public int passive3Level;  // 0이면 비활성화.

    //시나리오 데이터
    public System.Single scenario_main_number;
    public System.Single scenario_sub_number;

    public System.Single tower_Level_enable; //허용 가능 타워 레벨
    public System.Single current_tower_Level; // 클리어 한 맥스 타워 레벨

    //시간 데이터
    public string time;

    //스킬들은 Obj로 관리가 되지만 Instance Id로 Save를 하게 되면 매번 변할 가능성이 있기 때문에
    //List로 분할 관리해 게임이 실행 될 때 초기화 작업을 하면서 List데이터를 통해 Obj에서 찾아오는 방식.
    public List<string> kakutokuAbleObj = new List<string> ();
    public List<int> kakutokuAbleCost = new List<int> ();

    public List<string> useAbleObj = new List<string>();
    public List<int> useAbleLevel = new List<int>();


    //위치 데이터
    public String sceneName; // 대부분 위치 여기서 구별
    public int playerPos; // 필드에서 여관 구별

    //언어 데이터(영어,한국어 존재)
    public string languege = "Korean";

    
    
    
}