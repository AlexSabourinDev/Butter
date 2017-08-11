
using System;
using System.Collections;
using System.Linq;

[Serializable]
public class EnumArray<KeyType, Type> : IEnumTypeProvider, IArray where KeyType : struct, IConvertible {

	private Type[] m_Array = new Type[System.Enum.GetValues(typeof(KeyType)).Cast<int>().Max()];

	public int Length {
		get {
			return m_Array.Length;
		}
	}

	public Type[] ToArray() {
		return m_Array;
	}

	public System.Type EnumType {
		get {
			return typeof(KeyType);
		}
	}

	public Type this[int index] {
		get {
			return m_Array[index];
		}
		set {
			m_Array[index] = value;
		}
	}

	public Type this[KeyType index] {
		get {
			return m_Array[index.ToInt32(null)];
		}
		set {
			m_Array[index.ToInt32(null)] = value;
		}
	}

	public System.Object GetElement(int index) {

		return this[index];
	}
}
