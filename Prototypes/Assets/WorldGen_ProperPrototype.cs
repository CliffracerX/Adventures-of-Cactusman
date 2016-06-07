using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Room_Prototype
{
	public int ID;
	public float chance;
	public List<int> acceptableLinksNorth;
	public List<int> acceptableLinksEast;
	public List<int> acceptableLinksSouth;
	public List<int> acceptableLinksWest;
	public GameObject prefab;
	public string name;
}

public class WorldGen_ProperPrototype : MonoBehaviour
{
	public Room_Prototype[] roomTypes;
	public int mapSizeX,mapSizeY,roomSize,startingRoom;
	public float extendChance;
	public int[,] rooms;
	public bool placedSpawnRoom = false;

	void Start()
	{
		rooms = new int[mapSizeX*2,mapSizeY*2];
		for(int x = 0; x<mapSizeX*2; x++)
		{
			for(int y = 0; y<mapSizeY*2; y++)
			{
				rooms[x,y]=-2;
			}
		}
		//rooms[0,0]=roomTypes[startingRoom].ID;
		//Instantiate(roomTypes[startingRoom].prefab, new Vector3((-mapSizeX)*roomSize, 0, (-mapSizeY)*roomSize), Quaternion.identity);
		//GenerateMap();
		PlaceRoom(Random.Range(-mapSizeX, mapSizeX), Random.Range(-mapSizeY, mapSizeY), startingRoom);
		CleanLooseRooms();
		for(int x = -mapSizeX; x<mapSizeX; x++)
		{
			for(int y = -mapSizeY; y<mapSizeY; y++)
			{

			}
		}
	}

	void CleanLooseRooms()
	{

	}

	void PlaceRoom(int x, int y, int ID)
	{
		int modX = x+mapSizeX;
		int modY = y+mapSizeY;
		int northID = -2; //Up
		int eastID = -2; //Right
		int southID = -2; //Down
		int westID = -2; //Left
		print(x);
		print(y);
		print(modX);
		print(modY);
		if(modY+1<mapSizeY*2)
		{
			northID=rooms[modX,modY+1];
		}
		else
			northID=-3;
		if(modX+1<mapSizeX*2)
		{
			eastID=rooms[modX+1,modY];
		}
		else
			eastID=-3;
		if(modY-1>=0)
		{
			southID=rooms[modX,modY-1];
		}
		else
			southID=-3;
		if(modX-1>=0)
		{
			westID=rooms[modX-1,modY];
		}
		else
			westID=-3;
		print(northID);
		print(southID);
		print(eastID);
		print(westID);
		rooms[modX,modY]=roomTypes[ID].ID;
		bool noSpawn = false;
		if(rooms[x+mapSizeX,y+mapSizeY]==startingRoom)
		{
			if(placedSpawnRoom)
			{
				noSpawn=true;
			}
		}
		if(rooms[x+mapSizeX,y+mapSizeY]>=0 && !noSpawn)
			Instantiate(roomTypes[rooms[x+mapSizeX,y+mapSizeY]].prefab, new Vector3(x*roomSize, 0, y*roomSize), Quaternion.identity);
		if(rooms[x+mapSizeX,y+mapSizeY]==startingRoom)
		{
			placedSpawnRoom=true;
		}
		if(northID==-2 && Random.Range(0.0f, 1.0f)<=extendChance)
		{
			List<Room_Prototype> validRooms = new List<Room_Prototype>(roomTypes);
			int valCount = validRooms.Count;
			foreach(Room_Prototype room in roomTypes)
			{
				if(!roomTypes[ID].acceptableLinksNorth.Contains(room.ID) || Random.Range(0.0f, 1.0f)>=room.chance)
				{
					validRooms.Remove(room);
					valCount-=1;
				}
			}
			if(valCount>=1)
			{
				int rid = validRooms[Random.Range(0, valCount)].ID;
				print("NAME: "+roomTypes[ID].name+", RID: "+rid+", RID NAME: "+this.roomTypes[rid].name);
				PlaceRoom(x, y+1, rid);
			}
			else
				rooms[modX,modY]=-1;
		}
		if(eastID==-2 && Random.Range(0.0f, 1.0f)<=extendChance)
		{
			List<Room_Prototype> validRooms = new List<Room_Prototype>(roomTypes);
			int valCount = validRooms.Count;
			foreach(Room_Prototype room in roomTypes)
			{
				if(!roomTypes[ID].acceptableLinksEast.Contains(room.ID) || Random.Range(0.0f, 1.0f)>=room.chance)
				{
					validRooms.Remove(room);
					valCount-=1;
				}
			}
			if(valCount>=1)
			{
				int rid = validRooms[Random.Range(0, valCount)].ID;
				print("NAME: "+roomTypes[ID].name+", RID: "+rid+", RID NAME: "+this.roomTypes[rid].name);
				PlaceRoom(x+1, y, rid);
			}
			else
				rooms[modX,modY]=-1;
		}
		if(southID==-2 && Random.Range(0.0f, 1.0f)<=extendChance)
		{
			List<Room_Prototype> validRooms = new List<Room_Prototype>(roomTypes);
			int valCount = validRooms.Count;
			foreach(Room_Prototype room in roomTypes)
			{
				if(!roomTypes[ID].acceptableLinksSouth.Contains(room.ID) || Random.Range(0.0f, 1.0f)>=room.chance)
				{
					validRooms.Remove(room);
					valCount-=1;
				}
			}
			if(valCount>=1)
			{
				int rid = validRooms[Random.Range(0, valCount)].ID;
				print("NAME: "+roomTypes[ID].name+", RID: "+rid+", RID NAME: "+this.roomTypes[rid].name);
				PlaceRoom(x, y-1, rid);
			}
			else
				rooms[modX,modY]=-1;
		}
		if(westID==-2 && Random.Range(0.0f, 1.0f)<=extendChance)
		{
			List<Room_Prototype> validRooms = new List<Room_Prototype>(roomTypes);
			int valCount = validRooms.Count;
			foreach(Room_Prototype room in roomTypes)
			{
				if(!roomTypes[ID].acceptableLinksWest.Contains(room.ID) || Random.Range(0.0f, 1.0f)>=room.chance)
				{
					validRooms.Remove(room);
					valCount-=1;
				}
			}
			if(valCount>=1)
			{
				int rid = validRooms[Random.Range(0, valCount)].ID;
				print("NAME: "+roomTypes[ID].name+", RID: "+rid+", RID NAME: "+this.roomTypes[rid].name);
				PlaceRoom(x-1, y, rid);
			}
			else
				rooms[modX,modY]=-1;
		}
	}
	
	void GenerateMap()
	{
		/*for(int x = -mapSizeX+1; x<mapSizeX; x++)
		{
			for(int y = -mapSizeY+1; y<mapSizeY; y++)
			{
				int modX = x+mapSizeX;
				int modY = y+mapSizeY;
				int northID = -1; //Up
				int eastID = -1; //Right
				int southID = -1; //Down
				int westID = -1; //Left
				if(modY+1<mapSizeY*2)
				{
					northID=rooms[modX,modY+1];
				}
				if(modX+1<mapSizeX*2)
				{
					eastID=rooms[modX+1,modY];
				}
				if(modY-1>=0)
				{
					southID=rooms[modX,modY-1];
				}
				if(modX-1>=0)
				{
					westID=rooms[modX-1,modY];
				}
				/*List<Room_Prototype> validRooms = new List<Room_Prototype>(roomTypes);
				foreach(Room_Prototype room in roomTypes)
				{
					if(!room.acceptableLinksNorth.Contains(northID))
						if(!room.acceptableLinksEast.Contains(eastID))
							if(!room.acceptableLinksSouth.Contains(southID))
								if(!room.acceptableLinksWest.Contains(westID))
									{validRooms.Remove(room);}
				}
				Instantiate(validRooms[Random.Range(0, validRooms.Count)].prefab, new Vector3(x*roomSize, 0, y*roomSize), Quaternion.identity);*/
				/*if(rooms[modX,modY]==-2)
				{

				}
			}
		}*/

	}
}