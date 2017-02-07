using UnityEngine;
using System.Collections;

public class Player_control : MonoBehaviour {
	
		// Use this for initialization
		
	
	public int player_Num;
	public Rigidbody2D rig;
	public float punchPower;
	public float superPunch;
	public float boost_delay;
	private float waitFor;
	private bool playerFell;
	public float scaleDownDelay;
	public Light light;
	private float maxRange;
	
	
	
	void Start () {
		
		waitFor = 0;
		rig = GetComponent<Rigidbody2D>();
		scaleDownDelay = Time.time + scaleDownDelay;
		light = light.GetComponent<Light>();
		maxRange = light.range;
		
	}
		
	void Update() {
		if(!playerFell)
		{
			bool hor = Input.GetAxis("J" + player_Num + "_Hor") > .1 || Input.GetAxis("J" + player_Num + "_Hor") < -.1;
			bool vert = Input.GetAxis("J" + player_Num + "_Ver") > .1 || Input.GetAxis("J" + player_Num + "_Ver") < -.1;
			Move_Player(hor,vert);
			
			//print(Input.GetAxis("J" + player_Num + "_Hor"));
			
			bool boost = Input.GetButton("J" + player_Num + "_Boost");
			Boost_Player(boost);
			
			if(light.range < maxRange)
			{
				light.range += .1f;
			}
		}
	}
		
	void FixedUpdate () {
		if(playerFell)
		{
			playerFelling();
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		
		playerFell = true;
		//print("fell");
		
	}
	
	void Move_Player (bool X, bool Y)
	{
		
		if(X)
		{
			rig.AddForce(transform.right * punchPower * Input.GetAxis("J" + player_Num + "_Hor") * Time.deltaTime);
		}
		
		if(Y)
		{
			rig.AddForce(transform.up * punchPower * Input.GetAxis("J" + player_Num + "_Ver") * Time.deltaTime);
		}
		
	}
	
	void Boost_Player (bool boost){
		
		
		
		if(boost && Time.time > waitFor)
		{
			
			rig.AddForce(transform.right * superPunch * Input.GetAxis("J" + player_Num + "_Hor") * Time.deltaTime);
			rig.AddForce(transform.up * superPunch * Input.GetAxis("J" + player_Num + "_Ver") * Time.deltaTime);
			light.range = maxRange - 5;
			print("BOOST");
			waitFor = Time.time + boost_delay;
		}
		
	}
	
	void playerFelling()
	{
		
		if(transform.localScale.x >= 0)
		{
			transform.localScale += new Vector3(-.05F, -.05F, 0);
			scaleDownDelay = Time.time + scaleDownDelay;
		}else
		{
			Destroy (gameObject);
		}
		//print("felling");
		
	}
	
	
}
