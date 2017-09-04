using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewEditModeTest
{

	[Test]
	public void TestForExtendUp ()
	{
		int[] sour = new int[9];
		for (int i = 0; i < 9; i++) {
			sour [i] = 1;
		}
		System.Text.StringBuilder sb1 = new System.Text.StringBuilder ();
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				sb1.Append (sour [i + j * 3] + " ");
			}
			sb1.Append ("\n");
		}
		sb1.Append ("\n");
		Debug.Log (sb1);
		
		int[] tmp = new int[sour.Length];
		sour.CopyTo (tmp, 0);
		sour = new int[12];
		int oldId = 0;
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 4; j++) {
				int id = i * 3 + j;
				if (j == 0) {
					sour [id] = 11;
				} else {
					sour [id] = tmp [oldId++];
				}
			}
		}
		System.Text.StringBuilder sb = new System.Text.StringBuilder ();
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 3; j++) {
				sb.Append (sour [i + j * 3] + " ");
			}
			sb.Append ("\n");
		}
		Debug.Log (sb);
	}

	[Test]
	public void TestForExtendLeft ()
	{
		int[] sour = new int[9];
		for (int i = 0; i < 9; i++) {
			sour [i] = 1;
		}
		System.Text.StringBuilder sb1 = new System.Text.StringBuilder ();
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				sb1.Append (sour [i + j * 3] + " ");
			}
			sb1.Append ("\n");
		}
		sb1.Append ("\n");
		Debug.Log (sb1);

		int[] tmp = new int[sour.Length];
		sour.CopyTo (tmp, 0);
		sour = new int[12];
		for (int i = 0; i < 12; i++) {
			if (i < 3) {
				sour [i] = 11;
			} else {
				sour [i] = tmp [i - 3];
			}
		}
		
		System.Text.StringBuilder sb = new System.Text.StringBuilder ();
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 4; j++) {
				sb.Append (sour [i + j * 3] + " ");
			}
			sb.Append ("\n");
		}
		Debug.Log (sb);
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator NewEditModeTestWithEnumeratorPasses ()
	{
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}
