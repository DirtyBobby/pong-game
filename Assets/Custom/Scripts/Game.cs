﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Контроллирует очки игроков, сложность уровня
/// </summary>
public class Game : Singleton<Game>
	{
	public int PlayerCount=1;
	public int BotCount;
	BasePlayer[] players;
	RectTransform[] scores;
	// Use this for initialization
	void Awake ()
		{
		DontDestroyOnLoad(gameObject);
		}

	public void StartGameScene ()
		{
		scores = GameObject.Find("Canvas").GetComponentsInChildren<RectTransform>();
		players = LevelFabric.SingletonObj.CreateLevel(PlayerCount, BotCount);
		foreach ( var item in players )
			{
			item.track.Goal += OnGoal;
			}
		}

	/// <summary>
	/// Срабатывает, когда кому-то забивают гол
	/// </summary>
	/// <param name="id"></param>
	/// <param name="score"></param>
	private void OnGoal (int id)
		{
		BasePlayer t = FindByID(id);
		t.Score -= 1;
		return;
		}

	BasePlayer FindByID(int id)
		{
		foreach ( var item in players )
			{
			if ( item.identificator == id )
				return item;
			}
		return null;
		}

	// Update is called once per frame
	void Update ()
		{

		}
	}
