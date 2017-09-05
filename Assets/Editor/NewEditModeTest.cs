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

	[Test]
	public void TestAngelMode ()
	{
		unsafe {
			float a = -360f + Random.Range (0, 720f);
			Debug.Log (a);
			a = (float)((360.0 / 65536) * ((int)(a * (65536 / 360.0)) & 65535));
			Debug.Log (a);
		}
	}

	[Test]
	public void TestSqrtTime ()
	{
		float tmp = Random.Range (0f, 99f);
		
		double res = 0;
		double res2 = 0;
		double res3 = 0;
		double res4 = 0;
		System.DateTime a = System.DateTime.Now;
		res = System.Math.Sqrt (tmp);
		var s1 = System.DateTime.Now - a;
		
		a = System.DateTime.Now;
		res2 = Sqrt (tmp);
		var s2 = System.DateTime.Now - a;

		a = System.DateTime.Now;
		res3 = Sqrt2 (tmp);
		var s3 = System.DateTime.Now - a;

		a = System.DateTime.Now;
		res4 = Sqrt2 (tmp);
		var s4 = System.DateTime.Now - a;
		
		Debug.Log ("Num:" + tmp);
		Debug.LogFormat ("System res:{0} cost:{1}ms", res, s1.TotalMilliseconds);
		Debug.LogFormat ("System res:{0} cost:{1}ms", res2, s2.TotalMilliseconds);
		Debug.LogFormat ("System res:{0} cost:{1}ms", res3, s3.TotalMilliseconds);
		Debug.LogFormat ("System res:{0} cost:{1}ms", res4, s4.TotalMilliseconds);
	}

	private float Sqrt (float x)
	{
		unsafe {  
			float xhalf = 0.5f * x;  
			int i = *(int*)&x;              // Read bits as integer.  
			i = 0x5f375a86 - (i >> 1);      // Make an initial guess for Newton-Raphson approximation  
			x = *(float*)&i;                // Convert bits back to float  
			x = x * (1.5f - xhalf * x * x); // Perform left single Newton-Raphson step.  
			return 1 / x;  
		} 
	}

	private float Sqrt2 (float number)
	{
		unsafe {
			long i;  
			float x, y;

			x = number * 0.5F;  
			y = number;  
			i = *(long*)&y;  
			i = 0x5f3759df - (i >> 1);  
//			i = 0x5f375a86 - (i >> 1); 
			y = *(float*)&i;  
			y = y * (1.5F - (x * y * y));  
			y = y * (1.5F - (x * y * y));  
			return number * y;  
		} 
	}

	private float Sqrt3 (float number)
	{
		unsafe {
//			long i;  
//			float x, y;

//			x = number * 0.5F;  
//			y = number;  
//			i = *(long*)&y;  
////			i = 0x5f3759df - (i >> 1);  
//			i = 0x5f375a86 - (i >> 1); 
//			y = *(float*)&i;  
//			y = y * (1.5F - (x * y * y));  
//			y = y * (1.5F - (x * y * y));  
//			return number * y;
//			
			
			
			float xHalf = number * 0.5f;
			long i = *(long*)&number;
			i = 0x5f375a86 - (i >> 1);
			float y = *(float*)&i;
			y = y * (1.5F - (xHalf * y * y));
			y = y * (1.5F - (xHalf * y * y));
			return number * y;
		} 
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
