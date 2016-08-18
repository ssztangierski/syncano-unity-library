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
		Questions q = new Questions();
		q.text = "new text";
		q.answers = new string[] {"a", "b", "c", "d"};
		Syncano.Instance.Please().Save(q, res);
		*/

		// MODIFY TEXT

		Questions q = new Questions();
		q.id = 178;
		q.text = "modified text";
		q.answers = new string[] {"d", "e", "f", "g"};
		Syncano.Instance.Please().Save(q, onSuccess, onFailure);


		// DELETE OBJECT
		/*
		Questions q = new Questions();
		q.id = 163;
		Syncano.Instance.Please().Delete(q, res);
		*/

		// GET ONE QUESTION
		yield return s.Please().Get(179, onSuccess);

	//	yield return s.Please().CallScriptEndpoint<Questions> ("d019a1036c7ec1348713de2770385b728f050ed1", "get_questions", null);


		yield return null;
	}

	/*

	private void resList (GetResponseList<Questions> res)
	{
		//Debug.Log(res.Data.Count);
	}
*/


	private void onSuccess (Response<Questions> res)
	{
		Debug.Log(res.Data.text);
	}

	private void onFailure (SyncanoError res)
	{
		Debug.Log(res.Data.text);
	}


}
