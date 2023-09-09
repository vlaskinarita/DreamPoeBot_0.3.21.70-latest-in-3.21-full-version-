using System;
using System.Collections.Generic;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Elements;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using log4net;

namespace DreamPoeBot.Loki.Controllers;

public class GameStateController : RemoteMemoryObject
{
	private class GameStateHashNode : RemoteMemoryObject
	{
		public GameStateEnum Key => (GameStateEnum)base.M.ReadByte(base.Address + 11L);

		public GameState Value1 => ReadObject<GameState>(base.Address + 24L);
	}

	private static readonly ILog Log = Logger.GetLoggerInstanceForType();

	public static long PreGameStatePtr = -1L;

	public static long LoginStatePtr = -1L;

	public static long SelectCharacterStatePtr = -1L;

	private static long WaitingStatePtr = -1L;

	public static long EscapeStatePtr = -1L;

	private static long InGameStatePtr = -1L;

	private static long CreateCharacterStatePtr = -1L;

	public static long LoadingStatePtr = -1L;

	private static GameStateController Instance;

	public readonly Dictionary<GameStateEnum, GameState> AllGameStates;

	public static AreaLoadingState AreaLoadingState { get; private set; }

	public static LoginStateClass LoginState { get; private set; }

	public static SelectCharacterStateClass SelectCharacterState { get; private set; }

	public static EscapeStateClass EscapeState { get; private set; }

	public static CreateCharacterStateClass CreateCharacterState { get; private set; }

	public static IngameState IngameState { get; private set; }

	public static List<GameState> CurrentGameStates => Instance.M.ReadDoublePtrVectorClasses<GameState>(Instance.Address + 8L);

	public static List<GameState> ActiveGameStates => Instance.M.ReadDoublePtrVectorClasses<GameState>(Instance.Address + 32L, noNullPointers: true);

	public List<GameState> _CurrentGameStates => CurrentGameStates;

	public List<GameState> _ActiveGameStates => ActiveGameStates;

	public static bool IsPreGame => GameStateActive(PreGameStatePtr);

	public static bool IsLoginState => GameStateActive(LoginStatePtr);

	public static bool IsSelectCharacterState => GameStateActive(SelectCharacterStatePtr);

	public static bool IsCreateCharacterStateActive => GameStateActive(CreateCharacterStatePtr);

	public static bool IsWaitingState
	{
		get
		{
			if (WaitingStatePtr != 0L)
			{
				return GameStateActive(WaitingStatePtr);
			}
			return false;
		}
	}

	public static bool IsInGameState => GameStateActive(InGameStatePtr);

	public static bool IsAreaLoading => AreaLoadingState.IsLoading;

	public static bool IsLoading => GameStateActive(LoadingStatePtr);

	public static bool IsEscapeState => EscapeState.IsEscapeStateActive;

	public LoginPannelElement LogInPannel => GetObject<LoginPannelElement>(base.M.ReadLong(LoginStatePtr + 208L));

	public ClassSelectionElement CaracterCreationPannel => GetObject<ClassSelectionElement>(base.M.ReadLong(CreateCharacterStatePtr));

	public long createstartptr => CreateCharacterStatePtr;

	public GameStateController()
	{
		Instance = this;
		base.Address = base.M.ReadLong(base.Offsets.GameStateOffset + base.M.AddressOfProcess);
		AllGameStates = ReadGameState(base.Address + 72L);
		PreGameStatePtr = AllGameStates[GameStateEnum.PreGameState].Address;
		LoginStatePtr = AllGameStates[GameStateEnum.LoginState].Address;
		LoginState = AllGameStates[GameStateEnum.LoginState].AsObject<LoginStateClass>();
		SelectCharacterStatePtr = AllGameStates[GameStateEnum.SelectCharacterState].Address;
		SelectCharacterState = AllGameStates[GameStateEnum.SelectCharacterState].AsObject<SelectCharacterStateClass>();
		CreateCharacterState = AllGameStates[GameStateEnum.CreateCharacterState].AsObject<CreateCharacterStateClass>();
		CreateCharacterStatePtr = AllGameStates[GameStateEnum.CreateCharacterState].Address;
		WaitingStatePtr = ((AllGameStates[GameStateEnum.WaitingState] == null) ? 0L : AllGameStates[GameStateEnum.WaitingState].Address);
		InGameStatePtr = AllGameStates[GameStateEnum.InGameState].Address;
		EscapeState = AllGameStates[GameStateEnum.EscapeState].AsObject<EscapeStateClass>();
		AreaLoadingState = AllGameStates[GameStateEnum.AreaLoadingState].AsObject<AreaLoadingState>();
		LoadingStatePtr = AllGameStates[GameStateEnum.LoadingState].Address;
		IngameState = AllGameStates[GameStateEnum.InGameState].AsObject<IngameState>();
	}

	private static bool GameStateActive(long stateAddress)
	{
		Memory memory = GameController.Instance.Memory;
		long num = memory.ReadLong(Instance.Address + 32L);
		long num2 = memory.ReadLong(Instance.Address + 48L);
		int num3 = (int)(num2 - num);
		byte[] value = memory.ReadBytes(num, num3);
		int num4 = 0;
		while (true)
		{
			if (num4 < num3)
			{
				long num5 = BitConverter.ToInt64(value, num4);
				if (stateAddress == num5)
				{
					break;
				}
				num4 += 16;
				continue;
			}
			return false;
		}
		return true;
	}

	private Dictionary<GameStateEnum, GameState> ReadGameState(long pointer)
	{
		Dictionary<GameStateEnum, GameState> dictionary = new Dictionary<GameStateEnum, GameState>();
		new Stack<GameStateHashNode>();
		for (int i = 0; i < 12; i++)
		{
			if (base.M.ReadLong(pointer + i * 16) == 0L)
			{
				dictionary.Add((GameStateEnum)i, null);
			}
			else
			{
				dictionary.Add((GameStateEnum)i, ReadObject<GameState>(pointer + i * 16));
			}
		}
		return dictionary;
	}
}
