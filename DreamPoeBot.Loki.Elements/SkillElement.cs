namespace DreamPoeBot.Loki.Elements;

public class SkillElement : Element
{
	public bool isValid => (ulong)unknown1 > 0uL;

	public bool IsAssignedKeyOrIsActive => base.M.ReadInt(unknown1 + 8L) > 3;

	public string SkillIconPath => base.M.ReadStringU(base.M.ReadLong(unknown1 + 16L), 100).TrimEnd('0');

	public int totalUses => base.M.ReadInt(unknown3 + 80L);

	public bool isUsing => base.M.ReadByte(unknown3 + 8L) > 2;

	private long unknown1 => base.M.ReadLong(base.Address + 580L);

	private long unknown3 => base.M.ReadLong(base.Address + 812L);
}
