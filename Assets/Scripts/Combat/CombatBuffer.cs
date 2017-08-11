
using System.Collections.Generic;
using UnityEngine;

public class CombatBuffer {

	private List<CombatCommand> m_Commands;
	private int m_BeginIndex = 0;
	private int m_EndIndex = 0;

	public int Count {
		get {
			if(m_BeginIndex == 0) {
				return m_EndIndex - m_BeginIndex;
			}
			else {
				return m_Commands.Count;
			}
		}
	}

	public CombatBuffer(int bufferSize) {

		UnityEngine.Debug.Assert(bufferSize > 0);
		m_Commands = new List<CombatCommand>(new CombatCommand[bufferSize]);
		CollectionUtilities.SetAll(m_Commands, CombatCommand.None);
	}

	public void Write(CombatCommand command) {

		// If we've reached that maximum size, shift the beginning index
		// If we've already shifted the begin index, shift it nonetheless
		if (m_BeginIndex == 0 && m_EndIndex >= m_Commands.Count || m_BeginIndex != 0) {

			m_BeginIndex = (m_BeginIndex + 1) % m_Commands.Count;

			// We don't need to add again, we've already added
			m_EndIndex = m_EndIndex % m_Commands.Count;
		}

		m_Commands[m_EndIndex] = command;

		m_EndIndex++;
	}

	public CombatCommand Read(int index) {

		Debug.Assert(index < m_Commands.Count);

		int realIndex = (m_BeginIndex + index) % m_Commands.Count;
		return m_Commands[realIndex];
	}

	public CombatCommand Newest() {
		return m_Commands[m_EndIndex - 1];
	}

	public CombatCommand Oldest() {
		return m_Commands[m_BeginIndex];
	}


	public void ClearCommands() {

		CollectionUtilities.SetAll(m_Commands, CombatCommand.None);
		m_BeginIndex = 0;
		m_EndIndex = 0;
	}

	// Match an expression with our most recent commands
	public bool Match(CombatCommand[] commandExpression) {

		UnityEngine.Debug.Assert(commandExpression.Length > 0);
		UnityEngine.Debug.Assert(commandExpression.Length <= m_Commands.Count);

		for (int match = 0; match < commandExpression.Length; match++) {

			if(Read(Count - 1 - match) != commandExpression[match]) {
				return false;
			}
		}
		
		return true;
	}
}

