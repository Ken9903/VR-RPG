using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using PixelCrushers.DialogueSystem;

[Serializable] // ����ȭ

//Save �� ������ ����Ʈ
public class GameData
{ 
    //player ������
    public int player_Max_Hp;
    public int player_Hp;
    public int player_Mp;
    public int attackPoint;
    public int player_Lv;
    public double player_Exp;
    public double require_LevelUp;
    public int skillPoint;

    //Npc ������
    public bool luna;
    public bool npc;
    public string npcName;

    //��ų ������
    public string[] magic = new string[3];
    public int[] magicLevel = new int[3];
    public int passive1Level;  // 0�̸� ��Ȱ��ȭ.
    public int passive2Level;  // 0�̸� ��Ȱ��ȭ.
    public int passive3Level;  // 0�̸� ��Ȱ��ȭ.

    //�ó����� ������
    public System.Single scenario_main_number;
    public System.Single scenario_sub_number;

    public System.Single tower_Level_enable; //��� ���� Ÿ�� ����
    public System.Single current_tower_Level; // Ŭ���� �� �ƽ� Ÿ�� ����

    //�ð� ������
    public string time;

    //��ų���� Obj�� ������ ������ Instance Id�� Save�� �ϰ� �Ǹ� �Ź� ���� ���ɼ��� �ֱ� ������
    //List�� ���� ������ ������ ���� �� �� �ʱ�ȭ �۾��� �ϸ鼭 List�����͸� ���� Obj���� ã�ƿ��� ���.
    public List<string> kakutokuAbleObj = new List<string> ();
    public List<int> kakutokuAbleCost = new List<int> ();

    public List<string> useAbleObj = new List<string>();
    public List<int> useAbleLevel = new List<int>();


    //��ġ ������
    public String sceneName; // ��κ� ��ġ ���⼭ ����
    public int playerPos; // �ʵ忡�� ���� ����

    //��� ������(����,�ѱ��� ����)
    public string languege = "Korean";

    
    
    
}