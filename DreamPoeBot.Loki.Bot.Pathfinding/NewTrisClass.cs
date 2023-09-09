using System.Collections.Generic;
using DreamPoeBot.Common;

namespace DreamPoeBot.Loki.Bot.Pathfinding;

public class NewTrisClass
{
	public List<Vector3> Verts { get; set; }

	public List<int> Indices { get; set; }

	public List<Vector3> VertsJumpable { get; set; }

	public List<int> IndicesJumpable { get; set; }

	public List<RectanglePlus> WalkableRects { get; set; }

	public List<RectanglePlus> JumpableRects { get; set; }

	public NewTrisClass(List<Vector3> verts, List<int> indices, List<Vector3> vertsJumpable, List<int> indicesJumpable, List<RectanglePlus> walkableRects, List<RectanglePlus> jumpableRects)
	{
		Verts = verts;
		Indices = indices;
		VertsJumpable = vertsJumpable;
		IndicesJumpable = indicesJumpable;
		WalkableRects = walkableRects;
		JumpableRects = jumpableRects;
	}
}
