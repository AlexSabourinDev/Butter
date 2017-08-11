using System;
using UnityEngine;

public class AsInterfaceAttribute : PropertyAttribute {

	private System.Type m_InterfaceType;
	public Type InterfaceType {
		get {
			return m_InterfaceType;
		}
	}

	public AsInterfaceAttribute(System.Type type) {
		m_InterfaceType = type;
	}
}
