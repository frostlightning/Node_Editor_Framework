using UnityEngine;
using System.Collections.Generic;
using NodeEditorFramework.Utilities;
using UnityEditor;
namespace NodeEditorFramework.Standard
{
	[Node(false, "Chat/Option Node")]
	public class ChatOptionNode : Node
	{
		public const string ID = "ChatOptionNode";
		public override string GetID { get { return ID; } }

		public override string Title { get { return "玩家选择框"; } }
		public override Vector2 MinSize { get { return new Vector2(260, 10); } }
		public override bool AutoLayout { get { return true; } } // IMPORTANT -> Automatically resize to fit list

		public List<string> labels = new List<string>();
		[ValueConnectionKnob("Input", Direction.In, "System.String")]
		public ValueConnectionKnob inputKnob;
		private ValueConnectionKnobAttribute dynaCreationAttribute = new ValueConnectionKnobAttribute("Output", Direction.Out, "System.String");

		public override void NodeGUI()
		{
			if (dynamicConnectionPorts.Count != labels.Count)
			{ // Make sure labels and ports are synchronised
				while (dynamicConnectionPorts.Count > labels.Count)
					DeleteConnectionPort(dynamicConnectionPorts.Count - 1);
				while (dynamicConnectionPorts.Count < labels.Count)
					CreateValueConnectionKnob(dynaCreationAttribute);
			}
				

			// Display text field and add button
			GUILayout.BeginHorizontal();
			inputKnob.DisplayLayout ();
			if (GUILayout.Button("Add", GUILayout.ExpandWidth(false)))
			{
				labels.Add("聊天选项");
				CreateValueConnectionKnob(dynaCreationAttribute);
			}
			GUILayout.EndHorizontal();

			for (int i = 0; i < labels.Count; i++)
			{ // Display label and delete button
				GUILayout.BeginHorizontal();
				labels[i] = EditorGUILayout.TextField(labels[i]);
				((ValueConnectionKnob)dynamicConnectionPorts[i]).SetPosition();
				if(GUILayout.Button("x", GUILayout.ExpandWidth(false)))
				{ // Remove current label
					labels.RemoveAt (i);
					DeleteConnectionPort(i);
					i--;
				}
				GUILayout.EndHorizontal();
			}
		}
		public override Node GetLast ()
		{
			return inputKnob.connections [0].body;
		}
		public override Node GetNext ()
		{
			return dynamicConnectionPorts[GetOptionID()].body;
		}
		int GetOptionID()
		{
			return 0;
		}
	}
}