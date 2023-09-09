using System;
using System.Runtime.Serialization;

namespace DreamPoeBot.Auth.Objects;

[DataContract(Name = "UsageInfo", Namespace = "Buddy.Auth.Objects")]
[KnownType(typeof(TimeSpan))]
internal class UsageInfo
{
	[DataMember]
	public string OsVersion { get; private set; }

	[DataMember]
	public string BotBase { get; set; }

	[DataMember]
	public string Routine { get; set; }

	[DataMember]
	public string Profile { get; set; }

	[DataMember]
	public TimeSpan RunTime { get; set; }

	public UsageInfo(TimeSpan runTime, string botBase = "", string routine = "", string profile = "")
	{
		RunTime = runTime;
		BotBase = botBase;
		Routine = routine;
		Profile = profile;
		OsVersion = Environment.OSVersion.VersionString;
	}
}
