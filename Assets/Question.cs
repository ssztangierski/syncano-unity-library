using UnityEngine;
using System.Collections;
using Syncano;

[System.Serializable]
public class Question : SyncanoObject<Question> {

	public string text;

	public string[] answers;

	public bool isModerated;

}
