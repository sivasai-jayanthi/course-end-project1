using System;
using System.Collections.Generic;

namespace course_end_project1
{
	class Player
	{
		public int PlayerId { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
	}

	interface ITeam
	{
		void Add(Player player);
		void Remove(int playerId);
		Player GetPlayerById(int playerId);
		Player GetPlayerByName(string playerName);
		List<Player> GetAllPlayers();
	}

	class Team : ITeam
	{
		private List<Player> players = new List<Player>();

		public void Add(Player player)
		{
			if (players.Count < 11)
			{
				players.Add(player);
				Console.WriteLine($"Player {player.Name} added to the team.");
			}
			else
			{
				Console.WriteLine("Cannot add more than 11 players to the team.");
			}
		}

		public void Remove(int playerId)
		{
			Player playerToRemove = players.Find(p => p.PlayerId == playerId);
			if (playerToRemove != null)
			{
				players.Remove(playerToRemove);
				Console.WriteLine($"Player with ID {playerId} removed from the team.");
			}
			else
			{
				Console.WriteLine($"Player with ID {playerId} not found in the team.");
			}
		}

		public Player GetPlayerById(int playerId)
		{
			return players.Find(p => p.PlayerId == playerId);
		}

		public Player GetPlayerByName(string playerName)
		{
			return players.Find(p => p.Name == playerName);
		}

		public List<Player> GetAllPlayers()
		{
			return players;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Team cricketTeam = new Team();

			while (true)
			{
				Console.Write("Choose an option:");
				Console.Write("1. Add Player ");
				Console.Write("2. Remove Player ");
				Console.Write("3. Get Player by ID ");
				Console.Write("4. Get Player by Name ");
				Console.Write("5. Get All Players ");
				Console.Write("6. Exit ");

				int choice = int.Parse(Console.ReadLine());

				switch (choice)
				{
					case 1:
						Console.Write("Enter Player ID: ");
						int playerId = int.Parse(Console.ReadLine());
						Console.Write("Enter Player Name: ");
						string name = Console.ReadLine();
						Console.Write("Enter Player Age: ");
						int age = int.Parse(Console.ReadLine());

						Player newPlayer = new Player
						{
							PlayerId = playerId,
							Name = name,
							Age = age
						};

						cricketTeam.Add(newPlayer);
						break;

					case 2:
						Console.Write("Enter Player ID to remove: ");
						int removeId = int.Parse(Console.ReadLine());

						cricketTeam.Remove(removeId);
						break;

					case 3:
						Console.Write("Enter Player ID to get details: ");
						int getId = int.Parse(Console.ReadLine());

						Player playerById = cricketTeam.GetPlayerById(getId);
						if (playerById != null)
						{
							Console.WriteLine($"Player ID: {playerById.PlayerId}, Name: {playerById.Name}, Age: {playerById.Age}");
						}
						else
						{
							Console.WriteLine("Player not found.");
						}
						break;

					case 4:
						Console.Write("Enter Player Name to get details: ");
						string getName = Console.ReadLine();

						Player playerByName = cricketTeam.GetPlayerByName(getName);
						if (playerByName != null)
						{
							Console.WriteLine($"Player ID: {playerByName.PlayerId}, Name: {playerByName.Name}, Age: {playerByName.Age}");
						}
						else
						{
							Console.WriteLine("Player not found.");
						}
						break;

					case 5:
						List<Player> allPlayers = cricketTeam.GetAllPlayers();
						foreach (Player player in allPlayers)
						{
							Console.WriteLine($"Player ID: {player.PlayerId}, Name: {player.Name}, Age: {player.Age}");
						}
						break;

					case 6:
						Environment.Exit(0);
						break;

					default:
						Console.WriteLine("Invalid choice. Please try again.");
						break;
				}

				Console.Write("Do you want to continue (y/n)? ");
				if (Console.ReadLine().ToLower() != "y")
				{
					break;
				}
				Console.ReadLine();
			}
		}
	}
}
