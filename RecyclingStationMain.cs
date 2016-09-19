using System;
using RecyclingStation.Models;
using RecyclingStation.Models.GarbageDisposalStrategies;
using RecyclingStation.Models.Wastes;
using RecyclingStation.WasteDisposal;
using RecyclingStation.WasteDisposal.Attributes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation
{
    public class RecyclingStationMain
    {
        private static void Main(string[] args)
        {
            double energy = 0;
            double capital = 0;

            ManagementRequirement managementRequierement = null;

            var input = Console.ReadLine();
            while (input != "TimeToRecycle")
            {
                if (input == "Status")
                {
                    Console.WriteLine("Energy: {0:0.00} Capital: {1:0.00}", energy, capital);
                }
                else
                {
                    var commandArgs = input?.Split(' ', '|');

                    if (commandArgs?[0] == "ProcessGarbage")
                    {
                        var strategyHolder = new StrategyHolder();
                        strategyHolder.AddStrategy(typeof(RecyclableAttribute), new RecyclableGarbageDsiposalStrategy());
                        strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableGarbageDisposalStrategy());
                        strategyHolder.AddStrategy(typeof(StorableAttribute), new StorableGarbageDisposalStrategy());

                        var garbageProcessor = new GarbageProcessor(strategyHolder);

                        var name = commandArgs[1];
                        var weight = Convert.ToDouble(commandArgs[2]);
                        var volumePerKg = Convert.ToDouble(commandArgs[3]);
                        var type = commandArgs[4];

                        IWaste garbage = null;
                        switch (type)
                        {
                            case "Recyclable":
                                garbage = new RecyclableGarbage(name, volumePerKg, weight);
                                break;
                            case "Burnable":
                                garbage = new BurnableGarbage(name, volumePerKg, weight);
                                break;
                            case "Storable":
                                garbage = new StorableGarbage(name, volumePerKg, weight);
                                break;
                            default:
                                throw new ArgumentException();
                        }

                        if (managementRequierement != null &&
                            (managementRequierement.CapitalBalance > capital ||
                             managementRequierement.EnergyBalance > energy))
                        {
                            Type attrType = Type.GetType("RecyclingStation.WasteDisposal.Attributes." + managementRequierement.GarbageType + "Attribute");
                            strategyHolder.RemoveStrategy(attrType);
                        }
                        
                        var data = garbageProcessor.ProcessWaste(garbage);
                        if (data != null)
                        {
                            energy += data.EnergyBalance;
                            capital += data.CapitalBalance;

                            Console.WriteLine("{0:0.00} kg of {1} successfully processed!", weight, name);
                        }
                        else
                        {
                            Console.WriteLine("Processing Denied!");
                        }
                    }
                    else if (commandArgs?[0] == "ChangeManagementRequirement")
                    {
                        var energyBalance = Convert.ToDouble(commandArgs[1]);
                        var capitalBalance = Convert.ToDouble(commandArgs[2]);
                        var garbageType = commandArgs[3];

                        managementRequierement = new ManagementRequirement(energyBalance, capitalBalance, garbageType);

                        Console.WriteLine("Management requirement changed!");
                    }
                }

                input = Console.ReadLine();
            }

        }
    }
}