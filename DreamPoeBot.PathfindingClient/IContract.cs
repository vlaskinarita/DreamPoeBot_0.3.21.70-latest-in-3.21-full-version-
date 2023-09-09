using System.ServiceModel;

namespace DreamPoeBot.PathfindingClient;

[ServiceContract(Namespace = "Alcor75RD")]
public interface IContract
{
	[OperationContract]
	void Handshake(string name);

	[OperationContract]
	void Disconnect(string name);

	[OperationContract]
	void Ping(string name);

	[OperationContract]
	void AddObstacle(string name, int x, int y, float range);

	[OperationContract]
	void RemoveObstacle(string name, int x, int y);

	[OperationContract]
	void ClearObstacles(string name);

	[OperationContract]
	void UpdateObstacles(string name);

	[OperationContract]
	void DestroyPathfinder(string name);

	[OperationContract]
	void CreateNewPathfinder(string name);

	[OperationContract]
	bool LiesOnPoly(string name, int x, int y);

	[OperationContract]
	bool AreaGenerated(string name);

	[OperationContract]
	void ProcessEntireZone(string name, uint areaHash, byte[] data, int bPR, int cols, int rows, byte value, string areaId, bool bol);

	[OperationContract]
	string FindPath(string name, string data);

	[OperationContract]
	void SaveMapPicture(string name);

	[OperationContract]
	string ExternalGetTris(string name);
}
