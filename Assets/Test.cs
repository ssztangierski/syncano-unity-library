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
		/*
		Questions q = new Questions();
		q.id = 163;
		q.text = "modified text";
		q.answers = new string[] {"d", "e", "f", "g"};
		Syncano.Instance.Please().Save(q, res);
		*/

		/*
		// GET ONE QUESTION
		yield return s.Please().Get<Questions>(161, res);
		*/

		yield return null;
	}



	private void res (Response<Questions> res)
	{
		Debug.Log(res.Data.text);
	}

	private void test (Questions callback)
	{
		
	}

	private void testList(List<Questions> questions)
	{
		Debug.Log(questions);
	}


}
