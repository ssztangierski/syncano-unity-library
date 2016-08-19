using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Test : MonoBehaviour {

	IEnumerator Start()
	{
		Syncano s = Syncano.Instance;
		s.Init("adfee89ec99b7022de16383185b299c29459e1fa", "unity-quiz-app");

		// CREATE NEW OBJECT
		/*
		Question q = new Question();
		q.text = "new text";
		q.answers = new string[] {"a", "b", "c", "d"};
		Syncano.Instance.Please().Save(q, res);
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
		q.id = 163;
		Syncano.Instance.Please().Delete(q, res);
		*/

		// GET ONE QUESTION
	//	yield return s.Please().Get(179, onSuccess);

	//	yield return s.Please().CallScriptEndpoint<Questions> ("d019a1036c7ec1348713de2770385b728f050ed1", "get_questions", null);

		yield return s.Please().CallScriptEndpoint("6349c3ec1208c0be5ade53b154427d4eb5cb1628", "get_question_to_moderate", onSuccessScriptEndpoint);



		yield return null;
	}



	private void onSuccessScriptEndpoint (ScriptEndpoint res) {

		Question q = Question.FromJson(res.result.stdout);
		Debug.Log(res.result.stdout);
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
		
		//Debug.Log(res.Data.text);
	}



}
