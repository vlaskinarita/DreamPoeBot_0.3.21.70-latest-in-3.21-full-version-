using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using DreamPoeBot.Auth;
using DreamPoeBot.Auth.SR;
using DreamPoeBot.Hooks;
using DreamPoeBot.Loki;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Structures.ns3;
using log4net;
using Newtonsoft.Json;

namespace DreamPoeBot.Structures.ns13;

internal class Class104
{
	[Serializable]
	private sealed class Class105
	{
		public static readonly Class105 Class9 = new Class105();

		public static Func<Class41, r0> Method9__1_0;

		public static Func<IPAddress, bool> Method9__8_0;

		public static EventHandler Method9__9_0;

		public static EventHandler Method9__9_1;

		public static Func<Class41, bool> Method9__12_1;

		public static ThreadStart Method9__12_0;

		internal r0 method_0(Class41 class41_0)
		{
			return class41_0.method_6();
		}

		internal bool method_1(IPAddress ipaddress_0)
		{
			return ipaddress_0.AddressFamily == AddressFamily.InterNetwork;
		}

		internal void method_2(object sender, EventArgs e)
		{
			Hooking.Deinitialize();
			Thread.Sleep(100);
			smethod_2();
			smethod_0();
			smethod_1();
			Environment.Exit(1);
		}

		internal void method_3(object sender, EventArgs e)
		{
			Hooking.Deinitialize();
			Thread.Sleep(100);
			smethod_2();
			smethod_0();
			smethod_1();
			Environment.Exit(1);
		}

		internal void method_4()
		{
			Random random = new Random();
			try
			{
				while (true)
				{
					if (!string.IsNullOrEmpty(Class41.clientIdent))
					{
						while (true)
						{
							try
							{
								Thread.Sleep(random.Next(25, 30) * 1000);
								if (!Class46.smethod_2(Class9.method_5))
								{
									Class41.smethod_3();
									break;
								}
							}
							catch (Exception ex)
							{
								ilog_0.ErrorFormat("Authentication thread exception: {0}", (object)ex.ToString());
							}
						}
					}
					else
					{
						ilog_0.InfoFormat("Waiting for SID...", Array.Empty<object>());
						Thread.Sleep(1000);
					}
				}
			}
			catch (ThreadAbortException ex2)
			{
				ilog_0.ErrorFormat("Authentication thread abort exception: {0}", (object)ex2.ToString());
			}
			object object_ = object_0;
			lock (object_)
			{
				thread_0 = null;
			}
		}

		internal bool method_5(Class41 class41_0)
		{
			string text = smethod_3(class41_0);
			r0 r = class41_0.method_10();
			if (!(r.Body == "Server Exception") && !r.Body.ToLower().Contains("underlying provider") && !r.Body.ToLower().Contains("fehler beim zugrunde"))
			{
				if (!r.Success)
				{
					ilog_0.ErrorFormat("Authentication Server Response: {0}", (object)r.Body);
					ilog_0.ErrorFormat("Connection: {0}", (object)text);
					ilog_0.ErrorFormat("SID: {0}", (object)class41_0.ClientIdent);
					class41_0.ClientIdent = null;
					return false;
				}
				if (!string.IsNullOrEmpty(r.Body) && r.Body[0] == 'T')
				{
					ilog_0.ErrorFormat("Thank you for your DPB trial.", Array.Empty<object>());
					class41_0.ClientIdent = null;
					return false;
				}
				return true;
			}
			return true;
		}
	}

	private sealed class Class106
	{
		public string StringCdKey;

		internal bool method_0(Class41 class41_0)
		{
			try
			{
				class41_0.method_6();
				string text = smethod_3(class41_0);
				ilog_0.InfoFormat("[Pre-Login] {0}", (object)text);
				long num = DateTime.UtcNow.ToBinary();
				d0 d = class41_0.method_5(StringCdKey, 10, num);
				string_0 = d.Body;
				if (!d.Success)
				{
					ilog_0.ErrorFormat("Error while logging into auth: {0}", (object)d.Body);
					return false;
				}
				ilog_0.InfoFormat("Region: {0}", (object)d.Info);
				ilog_0.InfoFormat("T: {0} {1}", (object)num, (object)d.Body);
				return true;
			}
			catch (Exception ex)
			{
				ilog_0.Error((object)"Error", ex);
				string_0 = ex.ToString();
				class41_0.method_6();
				return false;
			}
		}
	}

	private sealed class Class107
	{
		public string string_0;

		public string Body;

		public string ProductId;

		internal byte[] method_0(Class41 class41_0)
		{
			d0 d = class41_0.method_7(string_0, Assembly.GetEntryAssembly().GetName().Version.ToString());
			if (d.Success)
			{
				return d.Data;
			}
			Body = d.Body;
			return null;
		}

		internal byte[] method_1(Class41 class41_0)
		{
			d0 prodList = class41_0.GetProdList();
			Body = prodList.Body;
			if (prodList.Success)
			{
				return prodList.Data;
			}
			return null;
		}

		internal byte[] method_2(Class41 class41_0)
		{
			d0 prod = class41_0.GetProd(ProductId);
			Body = prod.Body;
			if (prod.Success)
			{
				return prod.Data;
			}
			return null;
		}

		internal byte[] method_3(Class41 class41_0)
		{
			d0 timeLeft = class41_0.GetTimeLeft();
			Body = timeLeft.Body;
			if (timeLeft.Success)
			{
				return timeLeft.Data;
			}
			return null;
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	public static string string_0;

	private const byte byte_0 = 10;

	private static bool bool_0 = false;

	private static bool bool_1 = false;

	private static Thread thread_0;

	private static readonly object object_0 = new object();

	public static void smethod_0()
	{
		try
		{
			Class46.smethod_2(Class105.Class9.method_0);
		}
		catch
		{
		}
	}

	private static bool smethod_1()
	{
		try
		{
			if (GlobalSettings.Instance.TerminatePoeOnAuthIssue && !LokiPoe.bool_6IsEBLoading)
			{
				ilog_0.InfoFormat("The game client will now be closed due to an auth issue. [TerminatePoeOnAuthIssue = true]", Array.Empty<object>());
				Thread.Sleep(500);
				GameController.Instance.Memory.Process.Kill();
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	private static void smethod_2()
	{
		try
		{
			if (GlobalSettings.Instance.LogoutPoeOnAuthIssue && !LokiPoe.bool_6IsEBLoading && LokiPoe.IsInGame && !LokiPoe.ObjectManager.Me.IsInTown && !LokiPoe.ObjectManager.Me.IsInHideout)
			{
				ilog_0.InfoFormat("The bot is now logging out the client due to an auth issue.", Array.Empty<object>());
				LokiPoe.EscapeState.LogoutError logoutError = LokiPoe.EscapeState.LogoutToTitleScreen();
				ilog_0.DebugFormat("LogoutToTitleScreen returned {0}.", (object)logoutError);
			}
		}
		catch
		{
		}
	}

	private static string smethod_3(Class41 class41_0)
	{
		Uri uri = class41_0.aclient_0.Endpoint.Address.Uri;
		try
		{
			if (uri.HostNameType == UriHostNameType.Dns)
			{
				return $"Connecting to {Class41.Region_0} ({Dns.GetHostAddresses(uri.Host).FirstOrDefault(Class105.Class9.method_1)})";
			}
			return $"Connecting to {Class41.Region_0} [{uri.Host}]";
		}
		catch (Exception arg)
		{
			return $"Could not retrieve host name for {uri.Host}. Please check the DNS configuration. Error: {arg}";
		}
	}

	public static bool smethod_4(Region region_0, string string_1)
	{
		Class106 @class = new Class106();
		@class.StringCdKey = string_1;
		string_0 = "";
		Class41.smethod_0(region_0);
		if (!bool_0)
		{
			Class41.Event_1 += Class105.Class9.method_2;
			bool_0 = true;
		}
		if (!bool_1)
		{
			Class41.Event_2 += Class105.Class9.method_3;
			bool_1 = true;
		}
		bool? flag = Class46.smethod_2(@class.method_0);
		if (!flag.HasValue)
		{
			return false;
		}
		return flag.Value;
	}

	public static bool smethod_5()
	{
		object obj = object_0;
		lock (obj)
		{
			if (thread_0 != null)
			{
				return false;
			}
			thread_0 = new Thread(Class105.Class9.method_4)
			{
				IsBackground = true
			};
		}
		thread_0.Start();
		return true;
	}

	public static byte[] smethod_6(string string_1, out string string_2)
	{
		Class107 @class = new Class107();
		@class.string_0 = string_1;
		@class.Body = null;
		byte[] array = Class46.smethod_2(@class.method_0);
		string_2 = @class.Body;
		byte[] array2 = array;
		if (array2 != null && array2.Length != 0)
		{
			return array2;
		}
		return null;
	}

	public static byte[] GetProduct(string id)
	{
		Class107 @class = new Class107();
		@class.string_0 = null;
		@class.Body = null;
		@class.ProductId = id;
		return Class46.smethod_2(@class.method_2);
	}

	public static List<string> GetProducts()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		Class107 @class = new Class107();
		@class.string_0 = null;
		@class.Body = null;
		byte[] bytes = Class46.smethod_2(@class.method_1);
		string @string = Encoding.ASCII.GetString(bytes);
		JsonSerializerSettings val = new JsonSerializerSettings
		{
			TypeNameHandling = (TypeNameHandling)1,
			Formatting = (Formatting)1
		};
		return JsonConvert.DeserializeObject<List<string>>(@string, val);
	}

	public static string GetTimeLeft()
	{
		Class107 @class = new Class107();
		@class.string_0 = null;
		@class.Body = null;
		@class.ProductId = null;
		byte[] bytes = Class46.smethod_2(@class.method_3);
		return Encoding.ASCII.GetString(bytes);
	}
}
