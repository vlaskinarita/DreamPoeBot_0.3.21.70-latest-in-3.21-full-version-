using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Threading;
using DreamPoeBot.Auth;
using DreamPoeBot.Auth.Objects;
using DreamPoeBot.Auth.SR;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Structures.ns1;
using log4net;

namespace DreamPoeBot.Structures.ns3;

internal class Class41
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Delegate)]
	private sealed class Attribute0 : Attribute
	{
	}

	private static readonly ILog ilog_0;

	public static string clientIdent;

	[CompilerGenerated]
	private static string string_1;

	private static EndpointAddress endpointAddress_0;

	[CompilerGenerated]
	private static EventHandler eventHandler_0;

	[CompilerGenerated]
	private static EventHandler eventHandler_1;

	[CompilerGenerated]
	private static EventHandler eventHandler_2;

	[CompilerGenerated]
	private static string string_2;

	[CompilerGenerated]
	private static Region region_0;

	internal readonly AClient aclient_0;

	private static byte[] byte_0;

	private static Stopwatch stopwatch_0;

	private const string string_3 = "<RSAKeyValue><Modulus>t0aG8IaxqGaPj0mJN8HwD0BDm57mUdEnuiq+ANRH5A+rLoLrHbCfgDaslUckBzzlUqXHncDGARD8tYbVRjFWjbH4oWPLvKfjx/ZmIIvzVxOj5Uo9r95qJdS+DNh7oVP8pFavEtSOurXYrw0uRbj08r1zrrIsrssfXVBw2PI/pCy+gX3WeydXQknczl97bKIOBAFobMpLUBsQcM8Bs8gJC+f81cGw1ndhAwqZYRpR/KlDdEw0vWACpOMBIdeLAK0akx2deWvquAGRmLJBaJInOGpYRa6kVqcXRIG1vB2Zh3x9GhYeoeAQMVcogTvIxgNfiGNNc6CgsyRWoikLYS+1UQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

	public static string ReturnInfo { get; private set; }

	public static string String_1 { get; private set; }

	public static Region Region_0 { get; private set; }

	public string ClientIdent
	{
		get
		{
			return clientIdent;
		}
		set
		{
			clientIdent = value;
		}
	}

	public CommunicationState CommunicationState_0 => aclient_0.State;

	public static event EventHandler Event_0
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
	}

	public static event EventHandler Event_1
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
	}

	public static event EventHandler Event_2
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_2;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_2;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
	}

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern uint GetModuleFileName([In] IntPtr intptr_0, [Out] StringBuilder stringBuilder_0, [In][MarshalAs(UnmanagedType.U4)] int int_0);

	static Class41()
	{
		ilog_0 = Logger.GetLoggerInstanceForType();
		smethod_0(Region.BestLatency);
	}

	public static void smethod_0(Region region_1)
	{
		Region_0 = region_1;
		string arg;
		if (region_1 == Region.BestLatency)
		{
			String_1 = null;
			arg = "51.75.249.226";
		}
		else
		{
			String_1 = smethod_1(region_1);
			arg = string.Format("51.75.249.226", String_1);
		}
		endpointAddress_0 = new EndpointAddress($"net.tcp://{arg}:8090/Service");
	}

	private static string smethod_1(Region region_1)
	{
		return region_1 switch
		{
			Region.Europe => "eu", 
			Region.NorthAmerica => "na", 
			Region.China => "cn", 
			Region.SoutheastAsia => "sea", 
			_ => throw new ArgumentOutOfRangeException("region"), 
		};
	}

	private static Region smethod_2(string string_4)
	{
		return string_4.ToLowerInvariant() switch
		{
			"eu" => Region.Europe, 
			"sea" => Region.SoutheastAsia, 
			"cn" => Region.China, 
			"na" => Region.NorthAmerica, 
			_ => throw new ArgumentOutOfRangeException("regionAbbrev"), 
		};
	}

	public static void smethod_3()
	{
		eventHandler_2?.Invoke(null, null);
	}

	public Class41()
	{
		NetTcpBinding binding = new NetTcpBinding(SecurityMode.None)
		{
			PortSharingEnabled = true,
			MaxReceivedMessageSize = 2147483647L,
			ReaderQuotas = 
			{
				MaxArrayLength = int.MaxValue
			},
			SendTimeout = new TimeSpan(0, 10, 0)
		};
		aclient_0 = new AClient(binding, endpointAddress_0);
	}

	[Obsolete("Does nothing")]
	public void method_0()
	{
	}

	public void method_1()
	{
		aclient_0.Abort();
	}

	public void method_2()
	{
		aclient_0.Close();
	}

	private d0 method_3(Enum1 enum1_0, params object[] object_0)
	{
		return aclient_0.Do((byte)enum1_0, object_0);
	}

	private bool method_4()
	{
		return !string.IsNullOrEmpty(ClientIdent);
	}

	public d0 GetProd(string id)
	{
		string authKey = GlobalSettings.Instance.AuthKey;
		d0 d = method_3(Enum1.StoreGetProducts, authKey, id, ClientIdent);
		if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		if (d.Success)
		{
			if (d.Data != null && d.Data.Length != 0)
			{
				byte[] bytes = Encoding.ASCII.GetBytes(ClientIdent);
				byte[] bytes2 = Encoding.ASCII.GetBytes(ClientIdent);
				Array.Reverse(bytes2);
				d.Data = Class42.smethod_5(d.Data, bytes, bytes2);
			}
			ReturnInfo = d.Info;
		}
		return d;
	}

	public d0 GetProdList()
	{
		string authKey = GlobalSettings.Instance.AuthKey;
		d0 d = method_3(Enum1.StoreGetProductList, authKey, ClientIdent);
		if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		if (d.Success)
		{
			if (d.Data != null && d.Data.Length != 0)
			{
				byte[] bytes = Encoding.ASCII.GetBytes(ClientIdent);
				byte[] bytes2 = Encoding.ASCII.GetBytes(ClientIdent);
				Array.Reverse(bytes2);
				d.Data = Class42.smethod_5(d.Data, bytes, bytes2);
			}
			ReturnInfo = d.Info;
		}
		return d;
	}

	public d0 GetTimeLeft()
	{
		string authKey = GlobalSettings.Instance.AuthKey;
		d0 d = method_3(Enum1.UsageInfo, authKey);
		if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		_ = d.Success;
		return d;
	}

	public d0 method_5(string string_4, byte byte_1, long long_0)
	{
		string text = Class42.smethod_2("AUTH_KEY");
		d0 d = method_3(Enum1.Login, string_4, text, byte_1, long_0);
		if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		if (d.Success)
		{
			ClientIdent = Encoding.ASCII.GetString(d.Data);
			smethod_0(smethod_2(d.Info));
		}
		return d;
	}

	public r0 method_6()
	{
		if (!method_4())
		{
			return new r0
			{
				Success = false,
				Body = "Invalid Session"
			};
		}
		d0 d = method_3(Enum1.Logout, ClientIdent);
		if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		return d;
	}

	public d0 method_7(string string_4, string string_5, bool bool_0 = false)
	{
		if (!method_4())
		{
			return new d0
			{
				Success = false,
				Body = "Invalid Session"
			};
		}
		d0 d = method_3(Enum1.Offsets, ClientIdent, string_4, string_5, bool_0);
		if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		if (d.Data != null && d.Data.Length != 0)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(ClientIdent);
			byte[] bytes2 = Encoding.ASCII.GetBytes(ClientIdent);
			Array.Reverse(bytes2);
			d.Data = Class42.smethod_5(d.Data, bytes, bytes2);
		}
		ReturnInfo = d.Info;
		return d;
	}

	private void method_8()
	{
		Thread.Sleep(500);
		Process.GetCurrentProcess().Kill();
	}

	private ulong method_9()
	{
		ulong num = 14695981039346656037uL;
		uint id = (uint)Process.GetCurrentProcess().Id;
		byte[] array = new byte[4]
		{
			(byte)id,
			(byte)(id >> 8),
			(byte)(id >> 16),
			(byte)(id >> 24)
		};
		foreach (byte b in array)
		{
			num *= 1099511628211L;
			num ^= b;
		}
		StringBuilder stringBuilder = new StringBuilder(512);
		uint moduleFileName = GetModuleFileName(IntPtr.Zero, stringBuilder, 512);
		for (int j = 0; j < moduleFileName; j++)
		{
			num ^= (byte)stringBuilder[j];
			num *= 1099511628211L;
		}
		return num;
	}

	public unsafe r0 method_10(params object[] object_0)
	{
		if (method_4() && (stopwatch_0 == null || stopwatch_0.Elapsed.TotalMinutes <= 5.0))
		{
			long timestamp = Stopwatch.GetTimestamp();
			ulong num = method_9();
			long num2 = 0L;
			if (byte_0 != null)
			{
				if (byte_0.Length != 272)
				{
					ilog_0.InfoFormat($"DPB will now be closed due to an auth issue. there is been a problem recieving data from the server. [Length = {byte_0.Length}]", Array.Empty<object>());
					method_8();
				}
				byte[] array;
				byte* ptr2;
				if ((array = byte_0) != null && array.Length != 0)
				{
					fixed (byte* ptr = &array[0])
					{
						ptr2 = ptr;
					}
				}
				else
				{
					ptr2 = null;
				}
				num2 = *(long*)ptr2;
				ptr2 = null;
				byte[] rgbHash;
				using (SHA256Managed sHA256Managed = new SHA256Managed())
				{
					rgbHash = sHA256Managed.ComputeHash(byte_0, 0, 16);
				}
				using RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
				rSACryptoServiceProvider.PersistKeyInCsp = false;
				rSACryptoServiceProvider.FromXmlString("<RSAKeyValue><Modulus>t0aG8IaxqGaPj0mJN8HwD0BDm57mUdEnuiq+ANRH5A+rLoLrHbCfgDaslUckBzzlUqXHncDGARD8tYbVRjFWjbH4oWPLvKfjx/ZmIIvzVxOj5Uo9r95qJdS+DNh7oVP8pFavEtSOurXYrw0uRbj08r1zrrIsrssfXVBw2PI/pCy+gX3WeydXQknczl97bKIOBAFobMpLUBsQcM8Bs8gJC+f81cGw1ndhAwqZYRpR/KlDdEw0vWACpOMBIdeLAK0akx2deWvquAGRmLJBaJInOGpYRa6kVqcXRIG1vB2Zh3x9GhYeoeAQMVcogTvIxgNfiGNNc6CgsyRWoikLYS+1UQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");
				RSAPKCS1SignatureDeformatter rSAPKCS1SignatureDeformatter = new RSAPKCS1SignatureDeformatter(rSACryptoServiceProvider);
				rSAPKCS1SignatureDeformatter.SetHashAlgorithm("SHA256");
				byte[] array2 = new byte[byte_0.Length - 16];
				for (int i = 0; i < byte_0.Length - 16; i++)
				{
					array2[i] = byte_0[16 + i];
				}
				rSAPKCS1SignatureDeformatter.VerifySignature(rgbHash, array2);
			}
			byte[] array3 = null;
			if (num2 == 0L || (timestamp - num2) / Stopwatch.Frequency > 540L)
			{
				array3 = new byte[16];
				byte[] array4;
				byte* ptr4;
				if ((array4 = array3) != null && array4.Length != 0)
				{
					fixed (byte* ptr3 = &array4[0])
					{
						ptr4 = ptr3;
					}
				}
				else
				{
					ptr4 = null;
				}
				*(long*)ptr4 = timestamp;
				*(ulong*)(ptr4 + 8) = num;
				ptr4 = null;
			}
			List<object> list = object_0.ToList();
			list.Insert(0, ClientIdent);
			if (array3 != null)
			{
				list.Insert(1, array3);
			}
			d0 d;
			using (new Class48(aclient_0, TimeSpan.FromSeconds(30.0)))
			{
				d = method_3(Enum1.Heartbeat, list.ToArray());
			}
			if (array3 != null && d.Data != null && d.Data.Length == 272)
			{
				byte_0 = d.Data;
			}
			if (d.Success || stopwatch_0 == null)
			{
				stopwatch_0 = Stopwatch.StartNew();
			}
			if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
			{
				eventHandler_1?.Invoke(null, null);
			}
			eventHandler_0?.Invoke(null, null);
			return d;
		}
		stopwatch_0 = null;
		return new r0
		{
			Success = false,
			Body = "Invalid Session"
		};
	}

	public d0 method_11(string string_4, byte byte_1 = 2)
	{
		if (!method_4())
		{
			return new d0
			{
				Success = false,
				Body = "Invalid Session"
			};
		}
		d0 d = method_3(Enum1.Mesh, ClientIdent, string_4, byte_1);
		if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		return d;
	}

	public d0 method_12(string string_4, string string_5, byte byte_1 = 2)
	{
		if (!method_4())
		{
			return new d0
			{
				Success = false,
				Body = "Invalid Session"
			};
		}
		d0 d = method_3(Enum1.HB_MESH_FROM_MAP, ClientIdent, string_4, string_5, byte_1);
		if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		return d;
	}

	public d0 method_13(WoWNpc[] woWNpc_0)
	{
		if (!method_4())
		{
			return new d0
			{
				Success = false,
				Body = "Invalid Session"
			};
		}
		d0 d = method_3(Enum1.HBInsertNpc, ClientIdent, woWNpc_0, Assembly.GetEntryAssembly().GetName().Version.Build);
		if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		return d;
	}

	public d0 method_14(WoWMailboxEx[] woWMailboxEx_0)
	{
		if (!method_4())
		{
			return new d0
			{
				Success = false,
				Body = "Invalid Session"
			};
		}
		d0 d = method_3(Enum1.HBInsertMailbox, ClientIdent, woWMailboxEx_0, Assembly.GetEntryAssembly().GetName().Version.Build);
		if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		return d;
	}

	public d0 method_15(WoWFragment woWFragment_0)
	{
		if (!method_4())
		{
			return new d0
			{
				Success = false,
				Body = "Invalid Session"
			};
		}
		d0 d = method_3(Enum1.HBInsertFragment, ClientIdent, woWFragment_0, Assembly.GetEntryAssembly().GetName().Version.Build);
		if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		return d;
	}

	public d0 method_16(string string_4, byte byte_1 = 2)
	{
		if (!method_4())
		{
			return new d0
			{
				Success = false,
				Body = "Invalid Session"
			};
		}
		string_4 += ((byte_1 == 2) ? "_v2" : "");
		d0 d = method_3(Enum1.Tilemap, ClientIdent, string_4, byte_1);
		if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		return d;
	}

	public d0 method_17(string string_4, byte byte_1 = 2)
	{
		if (!method_4())
		{
			return new d0
			{
				Success = false,
				Body = "Invalid Session"
			};
		}
		d0 d = method_3(Enum1.HB_MAPMETADATA, ClientIdent, string_4, byte_1);
		if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		return d;
	}

	public d0 method_18(string string_4, byte[] byte_1, byte byte_2 = 2)
	{
		if (!method_4())
		{
			return new d0
			{
				Success = false,
				Body = "Invalid Session"
			};
		}
		d0 d = method_3(Enum1.HB_GAMEOBJ_MESH_QUERY, ClientIdent, string_4, byte_1, byte_2);
		if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		return d;
	}

	public r0 method_19(UsageInfo usageInfo_0)
	{
		if (!method_4())
		{
			return new d0
			{
				Success = false,
				Body = "Invalid Session"
			};
		}
		r0 r = method_3(Enum1.UsageInfo, ClientIdent, usageInfo_0);
		if (!string.IsNullOrEmpty(r.Body) && r.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		return r;
	}

	public Dictionary<string, string> method_20(byte byte_1)
	{
		Dictionary<string, string> result = new Dictionary<string, string>();
		if (!method_4())
		{
			return result;
		}
		d0 d = method_3(Enum1.StoreGetProductList, ClientIdent, byte_1);
		if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		if (d.Success && d.Data != null && d.Data.Length != 0)
		{
			DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(Dictionary<string, string>));
			using MemoryStream stream = new MemoryStream(d.Data);
			return (Dictionary<string, string>)dataContractSerializer.ReadObject((Stream)stream);
		}
		return result;
	}

	public List<StoreProduct> method_21(byte byte_1, string[] string_4)
	{
		List<StoreProduct> result = new List<StoreProduct>();
		if (!method_4())
		{
			return result;
		}
		d0 d = method_3(Enum1.StoreGetProducts, ClientIdent, byte_1, string_4);
		if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		if (d.Success && d.Data != null && d.Data.Length != 0)
		{
			DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(List<StoreProduct>));
			using MemoryStream stream = new MemoryStream(d.Data);
			return (List<StoreProduct>)dataContractSerializer.ReadObject((Stream)stream);
		}
		return result;
	}

	public r0 method_22(string string_4, string string_5, string string_6, int int_0)
	{
		if (!method_4())
		{
			return new r0
			{
				Success = false,
				Body = "Invalid Session"
			};
		}
		d0 d = method_3(Enum1.BGJoined, ClientIdent, string_4, string_5, string_6, int_0);
		if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		return d;
	}

	public r0 method_23(string string_4, string string_5)
	{
		if (!method_4())
		{
			return new r0
			{
				Success = false,
				Body = "Invalid Session"
			};
		}
		d0 d = method_3(Enum1.BGLeaderChanged, ClientIdent, string_4, string_5);
		if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		return d;
	}

	public r0 method_24(string string_4)
	{
		if (!method_4())
		{
			return new r0
			{
				Success = false,
				Body = "Invalid Session"
			};
		}
		d0 d = method_3(Enum1.BGFinished, ClientIdent, string_4);
		if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		return d;
	}

	public d0 method_25(string string_4)
	{
		if (!method_4())
		{
			return new d0
			{
				Success = false,
				Body = "Invalid Session",
				Data = null
			};
		}
		d0 d = method_3(Enum1.AB_GetScript, ClientIdent, string_4);
		if (!string.IsNullOrEmpty(d.Body) && d.Body == "TRIPWIRE")
		{
			eventHandler_1?.Invoke(null, null);
		}
		return d;
	}
}
