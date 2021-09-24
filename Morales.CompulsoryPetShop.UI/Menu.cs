using System;
using System.Collections.Generic;
using System.Linq;
using Morales.CompulsoryPetShop.Core.IServices;
using Morales.CompulsoryPetShop.Core.Models;
using Morales.CompulsoryPetShop.Domain.IRepositories;

namespace Morales.CompulsoryPetShop.UI
{
    public class Menu
    {
        private IPetService _petService;
        private IPetTypeRepository _petTypeRepository;
        private IOwnerService _ownerService;

        public Menu(IPetService service, IPetTypeRepository typeRepo)
        {
            _petService = service;
            _petTypeRepository = typeRepo;
            
        }

        public void Start()
        {
            ShowWelcomeGreeting();
            ShowMainMenu();
            StartLoop();
        }

        private void StartLoop()
        {
            int choice;
            while ((choice = GetMainMenuSelection()) != 0)
            {
                switch (choice)
                {
                    //Show pets
                    case 1:
                        ReadAllPets();
                        ShowMainMenu();
                        break;
                    //Search pets
                    case 2:
                        SearchByType();
                        ShowMainMenu();
                        break;
                    //Create pets
                    case 3:
                        CreatePet();
                        ShowMainMenu();
                        break;
                    //Delete pets
                    case 4:
                        DeletePet();
                        ShowMainMenu();
                        break;
                    //Update pets
                    case 5:
                        UpdatePet();
                        break;
                    //ShowByPrice pets
                    case 6:
                        SortByPrice();
                        break;
                    //ShowCheapest pet
                    case 7:
                        ShowCheapestPet();
                        break;
                    //Show Owner
                    case 8:
                        ReadAllOwner();
                        break;
                    //Create Owner
                    case 9:
                        CreateOwner();
                        break;
                    //Update Owner
                    case 10:
                        UpdateOwner();
                        break;
                    //Exit petshop
                    case 0:
                        break;
                    //Error message
                    case -1:
                        Print(StringConstans.ErrorMessage);
                        break;
                    default:
                        break;
                }
            }
        }

        private void UpdateOwner()
        {
            ReadAllOwner();
            Print(StringConstans.SelectOwnerToUpdate);
            var owner = _ownerService.ReadByOwnerId(GetMainMenuSelection());
            Print($"Old name: {owner.Name} - enter new name:");
            var name = Console.ReadLine();
            
            _ownerService.UpdateOwner(new Owner()
            {
                Id = owner.Id,
                Name = name,
            });
        }

        private void CreateOwner()
        {
            Print(StringConstans.CreateOwnerText);
            Print(StringConstans.CreateOwnerName);
            var name = Console.ReadLine();
            
            _ownerService.CreateOwner(new Owner()
            {
                Name = name,
            });
        }


        private void ReadAllOwner()
        {
           Print("Here are All Owner");
           var owners = _ownerService.ReadAllOwner();
           foreach (var owner in owners)
           {
               Print($"{owner.Id} - {owner.Name}");
           }
        }

        private void CreatePet()
        {
            Print(StringConstans.CreatePetText);
            Print(StringConstans.Lines);
            Print(StringConstans.CreatePetName);
            var name = Console.ReadLine();
            Print(StringConstans.CreatePetColor);
            var color = Console.ReadLine();
            var birthDate = DateTime.Now;
            var soldDate = DateTime.Now;
            double price = GetPetPrice();
            int type = GetPetType();

            _petService.CreatePet(new Pet()
            {
                Birthdate = birthDate,
                Color = color,
                Name = name,
                Price = price,
                SoldDate = soldDate,
                Type = _petTypeRepository.ReadByPetId(type)
            });
        }

        private void UpdatePet()
        {
            ReadAllPets();
            Print(StringConstans.SelectPetToUpate);
            var pet = _petService.ReadByPetId(GetMainMenuSelection());
            Print($"Old name: {pet.Name} - enter new name:");
            var name = Console.ReadLine();
            Print($"Old color: {pet.Color} - enter new name:");
            var color = Console.ReadLine();
            var birthDate = DateTime.Now;
            var soldDate = DateTime.Now;
            double price = GetPetPrice();
            int type = GetPetType();

            _petService.UpdatePet(new Pet()
            {
                Birthdate = birthDate,
                Color = color,
                Id = pet.Id,
                Name = name,
                Price = price,
                SoldDate = soldDate,
                Type = _petTypeRepository.ReadByPetId(type)
            });
        }

        private void ShowCheapestPet()
        {
            var cheap = _petService.ReadAllPets().OrderBy(p => p.Price).ToList();
            for (int i = 0; i < cheap.Capacity; i++)
            {
                if (i == 5)
                {
                    break;
                }

                Print(cheap[i].ToString());
            }
        }

        private void SortByPrice()
        {
            List<Pet> petByPrice = _petService.ReadAllPets().OrderBy(p => p.Price).ToList();
            foreach (var pet in petByPrice)
            {
                Print($"{pet.Name} - {pet.Type} - {pet.Color} - {pet.Price} - {pet.Birthdate}");
            }
        }

        private void ShowWelcomeGreeting()
        {
            Console.WriteLine(StringConstans.WelcomeGreeting);
        }

        private void ReadAllPets()
        {
            Print("Here are all pets:");
            Print(StringConstans.Lines);
            var pets = _petService.ReadAllPets();
            foreach (var pet in pets)
            {
                Print($"{pet.Id} - {pet.Name} - {pet.Price} - {pet.Color} - {pet.Type.Name}");
            }
        }

        private void Print(string value)
        {
            Console.WriteLine(value);
        }

        private int GetMainMenuSelection()
        {
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }

            return -1;
        }

        private void DeletePet()
        {
            Print(StringConstans.DeletePetText);
            Pet pet = _petService.RemovePet((GetMainMenuSelection()));
            Print($"The pet {pet.Name} was deleted!");
        }

        private void SearchByType()
        {
            Print(StringConstans.SearchByPriceMenuText);
            PrintPetTypes();
            int typeId = GetMainMenuSelection();
            Print(StringConstans.Lines);
            Print($"Showing all the pets of type{ _petTypeRepository.ReadByPetId(typeId).Name}");
            foreach (var pet in _petService.ReadAllPets())
            {
                if (pet.Type.Id == typeId)
                {
                    Print($"{pet.Name} - {pet.Color} - {pet.Price} - {pet.Birthdate}");
                }
            }
        }

        private void ShowMainMenu()
        {
            PrintNewLine();
            Print(StringConstans.Lines);
            Print(StringConstans.ShowPetsMenuMessage);
            Print(StringConstans.SearchPetsByTypeMenuMessage);
            Print(StringConstans.CreatePetMenuMessage);
            Print(StringConstans.DeletePetMenuMessage);
            Print(StringConstans.UpdatePetMenuMessage);
            Print(StringConstans.SortPetsByPriceMessage);
            Print(StringConstans.ShowCheapestPetsMenuMessage);
            Print(StringConstans.ShowOwnerMenuMessage);
            Print(StringConstans.CreateOwnerMenuMessage);
        }

        private void PrintNewLine()
        {
            Console.WriteLine("");
        }

        private int GetPetType()
        {
            PrintPetTypes();
            Print(StringConstans.CreatePetType);
            return GetMainMenuSelection();
        }

        private void PrintPetTypes()
        {
            foreach (var petType in _petTypeRepository.ReadAllPetTypes())
            {
                Print($" Id: {petType.Id} - {petType.Name}");
            }
        }

        private double GetPetPrice()
        {
            while (true)
            {
                Console.WriteLine(StringConstans.CreatePetPrice);
                var priceString = Console.ReadLine();
                double price;
                if (double.TryParse(priceString,out price))
                {
                    return price;
                }
                Console.WriteLine("You must enter a number!");
            }
        }
    }
}