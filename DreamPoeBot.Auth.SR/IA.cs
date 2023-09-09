using System.CodeDom.Compiler;
using System.ServiceModel;
using DreamPoeBot.Auth.Objects;

namespace DreamPoeBot.Auth.SR;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(ConfigurationName = "SR.IA")]
internal interface IA
{
	[ServiceKnownType(typeof(WoWFragment))]
	[ServiceKnownType(typeof(r0))]
	[ServiceKnownType(typeof(string[]))]
	[ServiceKnownType(typeof(UsageInfo))]
	[ServiceKnownType(typeof(d0))]
	[ServiceKnownType(typeof(WoWMailbox[]))]
	[ServiceKnownType(typeof(WoWNpc[]))]
	[OperationContract(Action = "http://tempuri.org/IA/Do", ReplyAction = "http://tempuri.org/IA/DoResponse")]
	[ServiceKnownType(typeof(WoWMailboxEx[]))]
	[ServiceKnownType(typeof(object[]))]
	d0 Do(byte b, object[] args);
}
