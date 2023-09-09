namespace DreamPoeBot.Loki.Models;

public class BaseItemType
{
	public string[] Tags;

	public string[] MoreTagsFromPath;

	public long Address { get; set; }

	public string ClassName { get; set; }

	public string Metadata { get; set; }

	public int Width { get; set; }

	public int Height { get; set; }

	public int DropLevel { get; set; }

	public string BaseName { get; set; }
}
