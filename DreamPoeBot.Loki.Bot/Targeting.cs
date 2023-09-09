using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.Objects;
using log4net;

namespace DreamPoeBot.Loki.Bot;

public class Targeting
{
	public class Entry
	{
		public int Id;

		public float Weight;

		public Entry(int id, float weight = 0f)
		{
			Id = id;
			Weight = weight;
		}
	}

	public delegate bool InclusionCalculator(NetworkObject entity);

	public delegate void WeightCalcuator(NetworkObject entity, ref float weight);

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private readonly List<Entry> _list0 = new List<Entry>();

	private InclusionCalculator _inclusionCalculator0;

	private WeightCalcuator _weightCalcuator0;

	public event InclusionCalculator InclusionCalcuation
	{
		add
		{
			InclusionCalculator inclusionCalculator = _inclusionCalculator0;
			InclusionCalculator inclusionCalculator2;
			do
			{
				inclusionCalculator2 = inclusionCalculator;
				InclusionCalculator value2 = (InclusionCalculator)Delegate.Combine(inclusionCalculator2, value);
				inclusionCalculator = Interlocked.CompareExchange(ref _inclusionCalculator0, value2, inclusionCalculator2);
			}
			while (inclusionCalculator != inclusionCalculator2);
		}
		remove
		{
			InclusionCalculator inclusionCalculator = _inclusionCalculator0;
			InclusionCalculator inclusionCalculator2;
			do
			{
				inclusionCalculator2 = inclusionCalculator;
				InclusionCalculator value2 = (InclusionCalculator)Delegate.Remove(inclusionCalculator2, value);
				inclusionCalculator = Interlocked.CompareExchange(ref _inclusionCalculator0, value2, inclusionCalculator2);
			}
			while (inclusionCalculator != inclusionCalculator2);
		}
	}

	public event WeightCalcuator WeightCalculation
	{
		add
		{
			WeightCalcuator weightCalcuator = _weightCalcuator0;
			WeightCalcuator weightCalcuator2;
			do
			{
				weightCalcuator2 = weightCalcuator;
				WeightCalcuator value2 = (WeightCalcuator)Delegate.Combine(weightCalcuator2, value);
				weightCalcuator = Interlocked.CompareExchange(ref _weightCalcuator0, value2, weightCalcuator2);
			}
			while (weightCalcuator != weightCalcuator2);
		}
		remove
		{
			WeightCalcuator weightCalcuator = _weightCalcuator0;
			WeightCalcuator weightCalcuator2;
			do
			{
				weightCalcuator2 = weightCalcuator;
				WeightCalcuator value2 = (WeightCalcuator)Delegate.Remove(weightCalcuator2, value);
				weightCalcuator = Interlocked.CompareExchange(ref _weightCalcuator0, value2, weightCalcuator2);
			}
			while (weightCalcuator != weightCalcuator2);
		}
	}

	public void ResetInclusionCalcuation()
	{
		_inclusionCalculator0 = null;
	}

	public void ResetWeightCalculation()
	{
		_weightCalcuator0 = null;
	}

	public IEnumerable<T> Targets<T>() where T : class
	{
		IOrderedEnumerable<Entry> source = from entry0 in _list0
			where entry0.Weight.CompareTo(float.MinValue) != 0
			orderby entry0.Weight descending
			select entry0;
		List<Entry> list = source.ToList();
		List<T> list2 = new List<T>();
		List<NetworkObject> objects = LokiPoe.ObjectManager.Objects;
		foreach (Entry entry in list)
		{
			if (objects.FirstOrDefault((NetworkObject x) => x.Id == entry.Id) is T item)
			{
				list2.Add(item);
			}
		}
		return list2;
	}

	public IEnumerable<NetworkObject> Targets()
	{
		return Targets<NetworkObject>();
	}

	public void Update()
	{
		_list0.Clear();
		if (!LokiPoe.IsInGame || _inclusionCalculator0 == null)
		{
			return;
		}
		List<NetworkObject> objects = LokiPoe.ObjectManager.Objects;
		foreach (NetworkObject item in objects)
		{
			try
			{
				Delegate[] invocationList = _inclusionCalculator0.GetInvocationList();
				IEnumerable<InclusionCalculator> enumerable = invocationList.Cast<InclusionCalculator>();
				foreach (InclusionCalculator item2 in enumerable)
				{
					if (item2(item))
					{
						Entry entry = new Entry(item.Id);
						if (_weightCalcuator0 != null)
						{
							_weightCalcuator0(item, ref entry.Weight);
						}
						_list0.Add(entry);
					}
				}
			}
			catch (Exception ex)
			{
				ilog_0.Error((object)"[Targeting] Exception during targeting inclusion invocation processing.", ex);
			}
		}
	}
}
