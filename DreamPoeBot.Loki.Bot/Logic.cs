using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.CSharp.RuntimeBinder;

namespace DreamPoeBot.Loki.Bot;

public class Logic
{
	[CompilerGenerated]
	private static class OutputClass
	{
		public static CallSite<Func<CallSite, Type, ILogicProvider, object, string, Tuple<ILogicProvider, object, string>>> Target;
	}

	[CompilerGenerated]
	private static class InputClass
	{
		public static CallSite<Func<CallSite, Type, object, string, Tuple<object, string>>> Target;
	}

	private readonly List<Tuple<object, string>> _inputs;

	private readonly List<Tuple<ILogicProvider, object, string>> _outputs;

	public string Id { get; }

	public IReadOnlyList<Tuple<object, string>> Inputs => _inputs;

	public IReadOnlyList<Tuple<ILogicProvider, object, string>> Outputs => _outputs;

	public object Sender { get; }

	public Logic(string id, object sender = null)
	{
		_inputs = new List<Tuple<object, string>>();
		_outputs = new List<Tuple<ILogicProvider, object, string>>();
		_id = id;
		_sender = sender;
	}

	public Logic(string id, object sender, params dynamic[] input)
	{
		_inputs = new List<Tuple<object, string>>();
		_outputs = new List<Tuple<ILogicProvider, object, string>>();
		_id = id;
		_sender = sender;
		AddInputs(input);
	}

	public void AddInput<T>(T input, string name)
	{
		_inputs.Add(new Tuple<object, string>(input, name));
	}

	public void AddInputs(params dynamic[] input)
	{
		foreach (object arg in input)
		{
			if (InputClass.Target == null)
			{
				CSharpArgumentInfo[] argumentInfo = new CSharpArgumentInfo[3]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
				};
				InputClass.Target = CallSite<Func<CallSite, Type, object, string, Tuple<object, string>>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof(Logic), argumentInfo));
			}
			_inputs.Add(InputClass.Target.Target(InputClass.Target, typeof(Tuple<object, string>), arg, ""));
		}
	}

	public void AddOutput<T>(ILogicProvider handler, T output, string name = "")
	{
		_outputs.Add(new Tuple<ILogicProvider, object, string>(handler, output, name));
	}

	public void AddOutputs(ILogicProvider handler, params dynamic[] output)
	{
		foreach (object arg in output)
		{
			if (OutputClass.Target == null)
			{
				CSharpArgumentInfo[] argumentInfo = new CSharpArgumentInfo[4]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
				};
				OutputClass.Target = CallSite<Func<CallSite, Type, ILogicProvider, object, string, Tuple<ILogicProvider, object, string>>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof(Logic), argumentInfo));
			}
			_outputs.Add(OutputClass.Target.Target(OutputClass.Target, typeof(Tuple<ILogicProvider, object, string>), handler, arg, ""));
		}
	}

	public T GetInput<T>(int index = 0)
	{
		TryGetInput<T>(index, out var input);
		return input;
	}

	public T GetInput<T>(string name)
	{
		TryGetInput<T>(name, out var input);
		return input;
	}

	public T GetOutput<T>(int index = 0)
	{
		TryGetOutput<T>(index, out var input);
		return input;
	}

	public T GetOutput<T>(string name)
	{
		TryGetOutput<T>(name, out var output);
		return output;
	}

	public bool TryGetInput<T>(int index, out T input)
	{
		if (index >= 0 && index < Inputs.Count)
		{
			input = (T)Inputs[index].Item1;
			return true;
		}
		input = default(T);
		return false;
	}

	public bool TryGetInput<T>(string name, out T input)
	{
		foreach (Tuple<object, string> input2 in Inputs)
		{
			if (input2.Item2.Equals(name))
			{
				input = (T)input2.Item1;
				return true;
			}
		}
		input = default(T);
		return false;
	}

	public bool TryGetOutput<T>(int index, out T input)
	{
		if (index >= 0 && index < Outputs.Count)
		{
			input = (T)Outputs[index].Item2;
			return true;
		}
		input = default(T);
		return false;
	}

	public bool TryGetOutput<T>(string name, out T output)
	{
		foreach (Tuple<ILogicProvider, object, string> output2 in Outputs)
		{
			if (output2.Item3.Equals(name))
			{
				output = (T)output2.Item2;
				return true;
			}
		}
		output = default(T);
		return false;
	}
}
