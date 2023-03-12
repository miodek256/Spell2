using UnityEngine;
using System.Collections;

public class MoveModified : MonoBehaviour
{

	private float move = 20;
	private bool stop = false;
	private float blend;
	private float delay = 0;
	public float AddRunSpeed = 1;
	public float AddWalkSpeed = 1;
	private bool hasAniComp = false;
	// Use this for initialization
	void Start()
	{

		if (null != GetComponent<Animation>())
		{
			hasAniComp = true;
		}

	}
	
	void Move()
	{
		float speed = 0.0f;
		float add = 0.0f;

		if (hasAniComp == true)
		{
			if (Input.GetKey(KeyCode.UpArrow))
			{
				GetComponent<Animation>().Play("move_forward");
				add = 5 * AddWalkSpeed;
				speed = Time.deltaTime * add;
				transform.Translate(0, 0, speed);
			}

			if (Input.GetKeyUp(KeyCode.UpArrow))
			{
				if (GetComponent<Animation>().IsPlaying("move_forward"))
				{
					GetComponent<Animation>().CrossFade("idle_normal", 0.3f);
				}
			}
		}
		else
		{
			if (Input.GetKey(KeyCode.UpArrow))
			{
				add = 5 * AddWalkSpeed;
				speed = Time.deltaTime * add;
				transform.Translate(0, 0, speed);
			}
			
		}
			
	}



	bool CheckAniClip(string clipname)
	{
		if (this.GetComponent<Animation>().GetClip(clipname) == null)
			return false;
		else if (this.GetComponent<Animation>().GetClip(clipname) != null)
			return true;

		return false;
	}
	
	

	// Update is called once per frame
	void Update()
	{

		transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

		Move();

		if (hasAniComp == true)
		{
			if (Input.GetKey(KeyCode.V))
			{
				if (CheckAniClip("dead") == false) return;

				GetComponent<Animation>().CrossFade("dead", 0.2f);
				//					animation.CrossFadeQueued("idle_normal");
			}



			if (Input.GetKey(KeyCode.Q))
			{
				if (CheckAniClip("attack_short_001") == false) return;

				GetComponent<Animation>().CrossFade("attack_short_001", 0.0f);
				GetComponent<Animation>().CrossFadeQueued("idle_combat");
			}



			if (Input.GetKey(KeyCode.Z))
			{
				if (CheckAniClip("damage_001") == false) return;

				GetComponent<Animation>().CrossFade("damage_001", 0.0f);
				GetComponent<Animation>().CrossFadeQueued("idle_combat");
			}



			if (Input.GetKey(KeyCode.D))
			{
				if (CheckAniClip("idle_normal") == false) return;

				GetComponent<Animation>().CrossFade("idle_normal", 0.0f);
				GetComponent<Animation>().CrossFadeQueued("idle_normal");
			}

			if (Input.GetKey(KeyCode.F))
			{
				if (CheckAniClip("idle_combat") == false) return;

				GetComponent<Animation>().CrossFade("idle_combat", 0.0f);
				GetComponent<Animation>().CrossFadeQueued("idle_normal");
			}
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(0, Time.deltaTime * -100, 0);
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(0, Time.deltaTime * 100, 0);
		}

	}
}
