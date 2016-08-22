using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Test : MonoBehaviour {

	IEnumerator Start()
	{
		Syncano s = Syncano.Instance.Init("adfee89ec99b7022de16383185b299c29459e1fa", "unity-quiz-app");

		// CREATE NEW OBJECT
		/*
		Question q = new Question();
		q.text = "new text";
		q.answers = new string[] {"a", "b", "c", "d"};
		Syncano.Instance.Please().Save(q, onSuccess, onFailure);
		*/

		// MODIFY TEXT

		/*
		Question q = new Question();
		q.id = 221;
		q.text = "modified text";
		q.isModerated = true;

		q.answers = new string[] {"d", "e", "f", "g"};
		Syncano.Instance.Please().Save(q, onSuccess);
		*/

		// DELETE OBJECT
		/*
		Question q = new Question();
		q.id = 232;
		Syncano.Instance.Please().Delete(q, onSuccess);
		*/

		// GET ONE QUESTION
		yield return s.Please().Get<Question>(235, onSuccess, onFailure);


		//yield return s.Please().CallScriptEndpoint("6349c3ec1208c0be5ade53b154427d4eb5cb1628", "get_question_to_moderate", onSuccessScriptEndpoint);
		yield return null;
	}

	private void onSuccessScriptEndpoint (ScriptEndpoint res) {

		Question q = JsonUtility.FromJson<Question>(res.result.stdout);// Question.FromJson(res.result.stdout);
	
		Debug.Log(" q to moderate id= " + q.id + " ;length" + q.answers.Length);
	}


	/*

	private void resList (GetResponseList<Questions> res)
	{
		//Debug.Log(res.Data.Count);
	}
*/

	private void onSuccess (Response<Question> res)
	{
		Debug.Log(res.Data.text);
	}

	private void onFailure (Response<Question> res)
	{
		if(res.IsSyncanoError)
			Debug.Log(res.syncanoError);
		else
			Debug.Log(res.webError);
			
	}

}
