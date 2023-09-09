namespace DreamPoeBot.Loki.Game;

public enum ApplicationExitCodes
{
	None = 0,
	UnsupportedClientVersion = 1,
	OffsetsMissing = 2,
	UpdaterNotFound = 3,
	UpdateException = 4,
	Updating = 5,
	Restarting = 6,
	CompileErrors = 7,
	AuthError = 8,
	LoadErrors = 9,
	Unknown = 998,
	MissingPrerequisites = 999
}
