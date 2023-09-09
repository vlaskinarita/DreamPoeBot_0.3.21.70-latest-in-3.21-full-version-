using System;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatQuestStateWrapper
{
	public int Index { get; private set; }

	public DatQuestWrapper Quest { get; private set; }

	public string QuestStateText { get; private set; }

	public string QuestProgressText { get; private set; }

	public int Id { get; private set; }

	public int TextOffset { get; private set; }

	public byte MapPinsAnId { get; private set; }

	public int _14 { get; private set; }

	public IntPtr _18 { get; private set; }

	public int _25 { get; private set; }

	public int _2D { get; private set; }

	public int _31 { get; private set; }

	public int _39 { get; private set; }

	public IntPtr _3D { get; private set; }

	public int _41 { get; private set; }

	public IntPtr _45 { get; private set; }

	public IntPtr _49 { get; private set; }

	public byte _4D { get; private set; }

	public IntPtr _52 { get; private set; }

	public IntPtr _56 { get; private set; }

	public IntPtr _5A { get; private set; }

	public DatQuestStateWrapper(string id, string questStateText, string questProgresText, int textOffset, int stateId)
	{
		Quest = new DatQuestWrapper(id);
		QuestStateText = questStateText;
		QuestProgressText = questProgresText;
		TextOffset = textOffset;
		Id = stateId;
		Index = Quest.Index;
	}
}
