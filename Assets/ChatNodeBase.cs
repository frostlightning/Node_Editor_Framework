using System;
using NodeEditorFramework;
using UnityEngine;
using UnityEngine.Serialization;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
/// <summary>
/// basic dialog node class, all other dialog nodes are derived from this
/// </summary>
[Node(false, "Chat/ChatNodeBase")]
public class ChatNodeBase : Node
{
	public const string ID = "ChatNodeBase";
	public override string GetID { get { return ID; } }

	public override string Title { get { return "Chat Node Base"; } }
	public override Vector2 DefaultSize { get { return new Vector2 (200, 180); } }

	[ValueConnectionKnob("Input", Direction.In, "System.String")]
	public ValueConnectionKnob inputKnob;
	[ValueConnectionKnob("Output", Direction.Out, "System.String")]
	public ValueConnectionKnob outputKnob;
	private Vector2 scroll;
	[FormerlySerializedAs("WhatTheCharacterSays")]
	public string DialogLine;
	public override void NodeGUI () 
	{
		// Display Float connections
		GUILayout.BeginHorizontal ();
		inputKnob.DisplayLayout ();
		outputKnob.DisplayLayout ();
		GUILayout.EndHorizontal ();
		GUILayout.BeginVertical();

		scroll = EditorGUILayout.BeginScrollView(scroll, GUILayout.Height(100));
		EditorStyles.textField.wordWrap = false;
		DialogLine = EditorGUILayout.TextArea(DialogLine, GUILayout.ExpandHeight(true));
		EditorStyles.textField.wordWrap = false;
		EditorGUILayout.EndScrollView();
		GUILayout.EndVertical();
		/*
		// Get adjacent flow elements
		Node flowSource = flowIn.connected ()? flowIn.connections[0].body : null;
		List<Node> flowTargets = flowOut.connections.Select ((ConnectionKnob input) => input.body).ToList ();

		// Display adjacent flow elements
		GUILayout.Label ("Flow Source: " + (flowSource != null? flowSource.name : "null"));
		GUILayout.Label ("Flow Targets:");
		foreach (Node flowTarget in flowTargets)
			GUILayout.Label ("-> " + flowTarget.name);
		*/
	}
		
	public class ChatConnection : ConnectionKnobStyle
	{
		public override string Identifier { get { return "ChatBase"; } }
		public override Color Color { get { return Color.red; } }
	}
}
