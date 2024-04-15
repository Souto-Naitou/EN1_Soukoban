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
		// �v�f����map.Length�Ŏ擾
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
	/// �����ړ�������B
	/// </summary>
	/// <param name="_number">�T�����O</param>
	/// <param name="_moveFrom">�����O�̃C���f�b�N�X</param>
	/// <param name="_moveTo">������̃C���f�b�N�X</param>
	/// <returns></returns>
	bool MoveNumber(int _number, int _moveFrom, int _moveTo)
	{
		if (_moveTo < 0 || _moveTo >= map.Length) { return false; }
		// �ړ���ɂQ(��)��������
		if (map[_moveTo] == 2)
		{
			// �ǂ̕����ֈړ����邩���Z�o
			int velocity = _moveTo - _moveFrom;
			// �v���C���[�̈ړ��悩��A�X�ɐ��2(��)���ړ�������B
			// ���̈ړ������BMoveNumber���\�b�h�Ȃ���MoveNumber���\�b�h��
			// �ĂсA�������ċA���Ă���B�ړ��s��bool�ŋL�^
			bool success = MoveNumber(2, _moveTo, _moveTo + velocity);
			// ���������ړ����s������A�v���C���[�̈ړ������s
			if (!success) { return false; }
		}
		// �����Ȃ���������s
		map[_moveTo] = _number;
		map[_moveFrom] = 0;
		return true;
	}

	// Start is called before the first frame update
	void Start()
	{
		// �z��̎��Ԃ̍쐬�Ə�����
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
			 * playerIndex+1�̃C���f�b�N�X�̂��̂ƌ�������̂�
			 * playerIndex-1��肳��ɏ������C���f�b�N�X�̂Ƃ��̂�
			 * �������s��
			*/

			// �ړ�����
			MoveNumber(1, playerIndex, playerIndex + 1);
            // �o��
            PrintArray();

		}

		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			int playerIndex = GetPlayerIndex();

			// �ړ�����
			MoveNumber(1, playerIndex, playerIndex - 1);
            // �o��
            PrintArray();
		}
	}
}
