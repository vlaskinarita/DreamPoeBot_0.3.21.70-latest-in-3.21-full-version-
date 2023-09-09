namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class SkillGemWrapper : RemoteMemoryObject
{
	public string Name => base.M.ReadStringU(base.M.ReadLong(base.Address));

	public ActiveSkillWrapper ActiveSkill => ReadObject<ActiveSkillWrapper>(base.Address + 115L);
}
