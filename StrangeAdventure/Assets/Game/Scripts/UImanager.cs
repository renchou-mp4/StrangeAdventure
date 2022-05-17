using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{

	//单例模式
	private static UImanager _instance;
	public static UImanager Instance
	{
		get { return _instance; }
	}

	//存放现有面板的栈
	private Stack<UIbase> UIStack = new Stack<UIbase>();

	//保存当前面板的字典
	private Dictionary<string, UIbase> currentUIDict = new Dictionary<string, UIbase>();

	//保存面板prefab的字典
	private Dictionary<string, GameObject> UIobjectDict = new Dictionary<string, GameObject>();

	public string ResourceDir = "UI";

	void Awake()
    {
		_instance = this;
		AddUIbase("UIStart");
		AddUIbase("UIOption");
		AddUIbase("TMX_1_1");
	}

	//加载UIbase
	public void AddUIbase(string UIname)
    {
		string path = ResourceDir + "/" + UIname;
		GameObject UIobject = Resources.Load<GameObject>(path);
		if (UIobject)
			UIobjectDict.Add(UIname, UIobject);
	}


	//入栈
	public void PushUIpanel(string UIname)
    {
		//若栈中有元素，则先获取栈顶元素，将其暂停
		if (UIStack.Count > 0 )
        {
			UIbase old_topUI = UIStack.Peek();
			old_topUI.DoOnPausing();
        }

		//得到将要入栈面板的UIbase，开始面板，入栈
		UIbase new_topUI = GetUIbase(UIname);
		new_topUI.DoOnEntering();
		UIStack.Push(new_topUI);

    }

	//获取UIbase
	private UIbase GetUIbase(string UIname)
    {
		//先看之前是否存在这个面板，若存在则返回这个面板的UIbase
        foreach (var name in currentUIDict.Keys)
        {
			if (name == UIname)
				return currentUIDict[UIname];
        }
		//若之前不存在，则先得到面板的prefab，在得到UIbase并返回
		GameObject UIobject = Instantiate<GameObject>(UIobjectDict[UIname]);
		UIobject.name = UIname;
		UIbase uibase = UIobject.GetComponent<UIbase>();
		currentUIDict.Add(UIname, uibase);
		return uibase;
    }

	//出栈
	public void PopUIpanel()
    {
		//若栈中没有元素，直接返回
		if (UIStack.Count == 0)
			return;
		//若栈中有元素，则将栈顶元素弹出，并退出
		UIbase old_topUI = UIStack.Pop();
		old_topUI.DoOnExiting();
		//若出栈后栈中还有元素，则将栈顶元素恢复
		if(UIStack.Count>0)
        {
			UIbase new_topUI = UIStack.Peek();
			new_topUI.DoOnResuming();
        }
    }
}