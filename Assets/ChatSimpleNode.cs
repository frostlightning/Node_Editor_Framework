using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatSimpleNode : ScriptableObject {
	public int id;
	public ChatSimpleNode firstNode;
	public ChatSimpleNode lastNode;
	public ChatSimpleNode parentNode;
	public List<ChatSimpleNode> childNodes;
	public int optionID = -1;

	public T GetNode<T>() where T:ChatSimpleNode
	{
		return this as T;
	}
}
