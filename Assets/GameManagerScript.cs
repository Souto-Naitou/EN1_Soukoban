using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
	int[] map;

	void PrintArray()
	{
		string debugText = "";
		for (int i = 0; i < map.Length; i++)
		{
			debugText += map[i].ToString() + ", ";
		}
		Debug.Log(debugText);
	}
	int GetPlayerIndex()
	{
		// 要素数はmap.Lengthで取得
		for (int i = 0; i < map.Length; i++)
		{
			if (map[i] == 1)
			{
				return i;
			}
		}
        return -1;
	}
	/// <summary>
	/// 数を移動させる。
	/// </summary>
	/// <param name="_number">探す名前</param>
	/// <param name="_moveFrom">動く前のインデックス</param>
	/// <param name="_moveTo">動く先のインデックス</param>
	/// <returns></returns>
	bool MoveNumber(int _number, int _moveFrom, int _moveTo)
	{
		if (_moveTo < 0 || _moveTo >= map.Length) { return false; }
		// 移動先に２(箱)がいたら
		if (map[_moveTo] == 2)
		{
			// どの方向へ移動するかを算出
			int velocity = _moveTo - _moveFrom;
			// プレイヤーの移動先から、更に先へ2(箱)を移動させる。
			// 箱の移動処理。MoveNumberメソッドないでMoveNumberメソッドを
			// 呼び、処理が再帰している。移動可不可をboolで記録
			bool success = MoveNumber(2, _moveTo, _moveTo + velocity);
			// もし箱が移動失敗したら、プレイヤーの移動も失敗
			if (!success) { return false; }
		}
		// 箱いなかったら実行
		map[_moveTo] = _number;
		map[_moveFrom] = 0;
		return true;
	}

	// Start is called before the first frame update
	void Start()
	{
		// 配列の実態の作成と初期化
		map = new int[] { 0, 0, 0, 1, 0, 2, 0, 0, 0};
		PrintArray();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			int playerIndex = GetPlayerIndex();

			/*
			 * playerIndex+1のインデックスのものと交換するので
			 * playerIndex-1よりさらに小さいインデックスのときのみ
			 * 交換を行う
			*/

			// 移動処理
			MoveNumber(1, playerIndex, playerIndex + 1);
            // 出力
            PrintArray();

		}

		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			int playerIndex = GetPlayerIndex();

			// 移動処理
			MoveNumber(1, playerIndex, playerIndex - 1);
            // 出力
            PrintArray();
		}
	}
}
