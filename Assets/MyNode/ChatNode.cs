﻿using System;
using NodeEditorFramework;
using UnityEngine;
using UnityEngine.Serialization;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
/// <summary>
/// basic dialog node class, all other dialog nodes are derived from this
/// </summary>
[Node(false, "Chat/ChatNode")]
public class ChatNode : Node
{
	public enum TapType
	{
		None,
		Continus,
		UnContinus,
		Fear,
		Last,
	}
	public const string ID = "ChatNode";
	public override string GetID { get { return ID; } }

	public override string Title { get { return "NPC对话框"; } }
	public override Vector2 DefaultSize { get { return new Vector2 (200, 225); } }

	[ValueConnectionKnob("Input", Direction.In, "System.String")]
	public ValueConnectionKnob inputKnob;
	[ValueConnectionKnob("Output", Direction.Out, "System.String")]
	public ValueConnectionKnob outputKnob;
	private Vector2 scroll;
	[FormerlySerializedAs("WhatTheCharacterSays")]
	public string DialogLine;
	[FormerlySerializedAs("TapType")]
	public TapType tapType;
	public override void NodeGUI () 
	{
		GUILayout.Label ("打字类型");
		tapType = (TapType)EditorGUILayout.EnumPopup (tapType);
		// Display Float connections
		GUILayout.BeginHorizontal ();
		inputKnob.DisplayLayout ();
		outputKnob.DisplayLayout ();
		GUILayout.EndHorizontal ();
		GUILayout.BeginVertical();

		scroll = EditorGUILayout.BeginScrollView(scroll, GUILayout.Height(80));
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
	public override Node GetLast ()
	{
		return inputKnob.connections [0].body;
	}
	public override Node GetNext ()
	{
		if (outputKnob.connections.Count == 0)
			return null;
		return outputKnob.connections [0].body;
	}
}
