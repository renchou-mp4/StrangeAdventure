using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionCondition : MonoBehaviour {

	public bool isDie = false;//碰撞后是否死亡
	public bool NeedHead = false;//是否需要头部碰撞
	public bool NeedFall = false;//下落时是否触发
	public UnityEvent OnConllisionHander;

	

	//碰撞器代码
	void OnCollisionEnter2D(Collision2D collision)
    {
		//需要头部碰撞，但是碰撞的物体不是Head，则返回
		if(NeedHead&&collision.collider.name != "Head")
        {
			return;
		}
		OnConllisionHander.Invoke();
		if (isDie == true)
		{
			Debug.Log("游戏结束");
		}
	}

	//触发器代码
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Collider2D>().name == "Head")
		{
			return;
		}
		//有下落触发属性，且处于下落状态，则返回；有下落属性，且处于上升状态，不返回
		if (NeedFall && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
			return;
		}
		
		OnConllisionHander.Invoke();
		if (isDie == true)
		{
			Debug.Log("游戏结束");
		}
	}

}
