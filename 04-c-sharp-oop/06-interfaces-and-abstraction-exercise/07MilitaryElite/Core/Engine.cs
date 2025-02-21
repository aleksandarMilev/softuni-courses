using MilitaryElite.Core.Interfaces;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private Dictionary<int, ISoldier> soldiers;


        public Engine()
        {
            soldiers = new();
        }


        public void Run()
        {
            string command;
            try
            {
                while ((command = Console.ReadLine()) != "End")
                {
                    string[] arguments = command
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    ISoldier soldier = null;

                    string soldierType = arguments[0];
                    int id = int.Parse(arguments[1]);
                    string firstName = arguments[2];
                    string lastName = arguments[3];
                    decimal salary = 0;

                    if (soldierType != "Spy")
                    {
                        salary = decimal.Parse(arguments[4]);
                    }

                    bool isValidCorps;
                    Corps corps;

                    switch (soldierType)
                    {
                        case "Private":
                            soldier = GetPrivate(id, firstName, lastName, salary);
                            break;
                        case "LieutenantGeneral":
                            soldier = GetLieutenantGeneral(arguments, id, firstName, lastName, salary);
                            break;
                        case "Engineer":
                            soldier = GetEngineer(arguments, out soldier, id, firstName, lastName, salary, out isValidCorps, out corps);
                            break;
                        case "Commando":
                            soldier = GetCommando(arguments, out soldier, id, firstName, lastName, salary, out isValidCorps, out corps);
                            break;
                        case "Spy":
                            soldier = GetSpy(arguments, id, firstName, lastName);
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine(soldier);
                    soldiers.Add(id, soldier);
                }
            }
            catch (Exception ex) { }
        }

        private static ISoldier GetSpy(string[] arguments, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            int codeNumber = int.Parse(arguments[4]);
            soldier = new Spy(id, firstName, lastName, codeNumber);
            return soldier;
        }

        private static ISoldier GetCommando(string[] arguments, out ISoldier soldier, int id, string firstName, string lastName, decimal salary, out bool isValidCorps, out Corps corps)
        {
            ValidateCorps(arguments, out isValidCorps, out corps);
            if (!isValidCorps)
            {
                throw new Exception();
            }

            List<IMission> missions = new();
            for (int i = 6; i < arguments.Length; i += 2)
            {
                string missionName = arguments[i];
                string missionState = arguments[i + 1];

                bool isMissionStateValid = Enum.TryParse<State>(missionState, out State state);
                if (!isMissionStateValid)
                {
                    continue;
                }

                IMission mission = new Mission(missionName, state);
                missions.Add(mission);
            }

            soldier = new Commando(id, firstName, lastName, salary, corps, missions);
            return soldier;
        }

        private static ISoldier GetEngineer(string[] arguments, out ISoldier soldier, int id, string firstName, string lastName, decimal salary, out bool isValidCorps, out Corps corps)
        {
            ValidateCorps(arguments, out isValidCorps, out corps);
            if (!isValidCorps)
            {
                throw new Exception();
            }

            List<IRepair> repairs = new();
            for (int i = 6; i < arguments.Length; i += 2)
            {
                string partName = arguments[i];
                int hoursWorked = int.Parse(arguments[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);
                repairs.Add(repair);
            }

            soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
            return soldier;
        }

        private ISoldier GetLieutenantGeneral(string[] arguments, int id, string firstName, string lastName, decimal salary)
        {
            ISoldier soldier;
            List<IPrivate> privates = new();
            for (int i = 5; i < arguments.Length; i++)
            {
                int privateId = int.Parse(arguments[i]);
                IPrivate currentPrivate = soldiers[privateId] as IPrivate;
                privates.Add(currentPrivate);
            }

            soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
            return soldier;
        }

        private static ISoldier GetPrivate(int id, string firstName, string lastName, decimal salary)
            => new Private(id, firstName, lastName, salary);

        private static void ValidateCorps(string[] arguments, out bool isValidCorps, out Corps corps)
            => isValidCorps = Enum.TryParse<Corps>(arguments[5], out corps);
    }
}
