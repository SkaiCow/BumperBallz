using UnityEngine;
using System.Collections;

public class FallowCamera : MonoBehaviour {
	
	public float minScale;
	private int numOfPlayers;
	private bool acounted1;
	private bool acounted2;
	private bool acounted3;
	private bool acounted4;
	private float X;
	private float Y;
	public float camraSpeed;
	private float setX;
	private float setY;

	// Use this for initialization
	void Start () {
		
		numOfPlayers = 4;
	
	}
	
	
	void Update()
	{
		
		if(GameObject.Find("Player1") == null & !acounted1)
		{
			numOfPlayers--;
			acounted1 = true;
		}
		if(GameObject.Find("Player2") == null & !acounted2)
		{
			numOfPlayers--;
			acounted2 = true;
		}
		if(GameObject.Find("Player3") == null & !acounted3)
		{
			numOfPlayers--;
			acounted3 = true;
		}
		if(GameObject.Find("Player4") == null & !acounted4)
		{
			numOfPlayers--;
			acounted4 = true;
		}
		
		//print(numOfPlayers);
		
	}
	
	void FixedUpdate ()
	{
		
		if(!acounted1)
		{
			X = GameObject.Find("Player1").transform.position.x;
			Y = GameObject.Find("Player1").transform.position.y;
		}
		
		if(!acounted2)
		{
			
			X = (X + GameObject.Find("Player2").transform.position.x) / 2;
			Y = (Y + GameObject.Find("Player2").transform.position.y) / 2;
			
		}
		if(!acounted3)
		{
			
			X = (X + GameObject.Find("Player3").transform.position.x) / 2;
			Y = (Y + GameObject.Find("Player3").transform.position.y) / 2;
			
		}
		if(!acounted4)
		{
			
			X = (X + GameObject.Find("Player4").transform.position.x) / 2;
			Y = (Y + GameObject.Find("Player4").transform.position.y) / 2;
			
		}
		
		
		transform.position = new Vector3(X , Y , -47.704f);
		//print(transform.position);
	
	}
}
