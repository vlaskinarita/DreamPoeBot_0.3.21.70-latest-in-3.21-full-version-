using System.Collections.Generic;

namespace DreamPoeBot.XAMLMarkupExtensions.Base;

internal interface INestedMarkupExtension
{
	List<TargetPath> GetTargetPropertyPaths();

	object UpdateNewValue(TargetPath targetPath);

	object FormatOutput(TargetInfo endpoint, TargetInfo info);

	bool IsConnected(TargetInfo info);
}
