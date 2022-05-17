using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private static Player _instance;
	public static Player Instance
    {
        get { return _instance; }
    }

	public float MoveSpeed = 4f;
	public float JumpPower = 300f;
	private Rigidbody2D Rigidbody2D;

	private bool isDead = false;
	public bool IsDead
    {
        get { return isDead; }
        set { isDead = value;
			if(isDead == true)
            {
				//死亡后做的事
				Debug.Log("已死亡");
            }
		}
    }

	void Start () {
		Rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		//若死亡直接返回
		if (IsDead) return;

		//掉下悬崖死亡
		if(transform.localPosition.y<-530)
        {
			IsDead = true;
        }

		//左右移动代码
		float h = Input.GetAxis("Horizontal");
		if(Mathf.Abs(h)>0.01f)
        {
			//水平移动，垂直不动
			Rigidbody2D.velocity = new Vector2(h * MoveSpeed * Time.deltaTime * 60, Rigidbody2D.velocity.y);
        }
        else
        {
			//水平不动
			Rigidbody2D.velocity = new Vector2(0f, Rigidbody2D.velocity.y);
        }

		//跳跃代码
		if(Rigidbody2D.velocity.y == 0)//解决二连跳问题
        {
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Rigidbody2D.AddForce(Vector2.up * JumpPower);
			}
		}
	}
}
