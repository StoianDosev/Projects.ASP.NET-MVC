﻿using Hangman.Data;
using Hangman.Models;
using Hangman.Repository;
using Hangman.Web.Data;
using Hangman.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Hangman.Web.Controllers
{
    [Authorize]
    public class GameController : BaseController
    {
        private static Random rand = new Random();

        private static int guesses;

        private IList<PlayersModel> userList;

        public GameController(IUowData data)
        {
            this.Data = data;
            this.userList = GetAllPlayers();
        }

        [HttpGet]
        public ActionResult StartGame()
        {
           
            SecretWord.UsedLetters = new char[] { 'a', 'b','c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
                'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            guesses = 5;

            var country = this.GenerateRandumCountry();

            SecretWord.FullWord = this.ConvertCountryNameToArray(country);

            GameModel model = new GameModel()
            {
                FullWord = SecretWord.FullWord,
                Guesses = guesses,
                PartialWord = SecretWord.PartialWord,
                UsedLetters = SecretWord.UsedLetters,
            };

            return View(model);
        }

        private Country GenerateRandumCountry()
        {
            var countries = this.Data.Countries.All();
            int countryIndex = rand.Next(1, countries.Count() + 1);
            var country = this.Data.Countries.GetById(countryIndex);

            return country;
        }

        private char[] ConvertCountryNameToArray(Country country)
        {
            string name = country.Name;

            char[] arr = new char[name.Length];

            for (int i = 0; i < name.Length; i++)
            {
                arr[i] = name[i];
            }

            SecretWord.PartialWord = new char[arr.Length];

            return arr;
        }

        [HttpGet]
        public ActionResult GuessTheLetter(string letter)
        {
            GameModel model = new GameModel
            {
                Guesses = guesses,
                FullWord = SecretWord.FullWord,
                UsedLetters = SecretWord.UsedLetters,
                PartialWord = SecretWord.PartialWord,
            };

            if (string.IsNullOrEmpty(letter) && guesses > 0)
            {
                return PartialView("_SecretWord", model);
            }

            SearchForLetter(letter);

            model.Guesses = guesses;

            if (guesses == 0)
            {
                return RedirectToAction("GameOver");
            }
            else if (CheckIfTheWordIsComplete() == true)
            {
                return RedirectToAction("Winner");
            }
            else
            {
                return PartialView("_SecretWord", model);
            }
        }

        private void SearchForLetter(string letter)
        {
            bool isFound = false;

            char[] letterArray = letter.ToCharArray();

            for (int i = 0; i < letterArray.Length; i++)
            {
                for (int k = 0; k < SecretWord.FullWord.Length; k++)
                {
                    if (char.ToLower(SecretWord.FullWord[k]) == char.ToLower(letterArray[i]))
                    {
                        isFound = true;

                        if (k == 0)
                        {
                            SecretWord.PartialWord[k] = char.ToUpper(letterArray[i]);
                        }
                        else
                        {
                            SecretWord.PartialWord[k] = letterArray[i];
                        }
                    }
                }

                for (int j = 0; j < SecretWord.UsedLetters.Length; j++)
                {
                    if (char.ToLower(SecretWord.UsedLetters[j]) == char.ToLower(letterArray[i]))
                    {
                        SecretWord.UsedLetters[j] = ' ';
                    }
                }
            }

            if (isFound == false)
            {
                guesses = guesses - 1;
            }
        }

        private bool CheckIfTheWordIsComplete()
        {

            for (int i = 0; i < SecretWord.PartialWord.Length; i++)
            {
                if (char.IsLetter(SecretWord.PartialWord[i]) == false)
                {
                    return false;
                }
            }
            return true;
        }

        public ActionResult Winner()
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.userManager.FindById(userId);
            user.Score = user.Score + 1;
            this.userManager.Update(user);


            return PartialView("_Winner", SecretWord.PartialWord);
        }

        public ActionResult GameOver()
        {

            return PartialView("_GameOver", SecretWord.FullWord);
        }

        private List<PlayersModel> GetAllPlayers()
        {
            var users = this.userManager.GetAllUsers();

            List<PlayersModel> userList = new List<PlayersModel>();

            foreach (var item in users)
            {
                var adminRole = item.Roles.Where(x => x.Role.Name == "admin").FirstOrDefault();
                if (adminRole == null)
                {
                    userList.Add(new PlayersModel()
                    {
                        Name = item.UserName,
                        Score = item.Score,
                    });
                }
            }
            return userList;
        }

        [HttpGet]
        public ActionResult DisplayTopPlayers()
        {
            var topPlayers = this.userList.OrderByDescending(x => x.Score).Take(5).ToList();

            return PartialView("_DisplayTopPlayers", topPlayers);
        }

        [HttpGet]
        public ActionResult DisplayAllPlayers(int page = 1)
        {
            
            IPagedList<PlayersModel> list = this.userList.OrderByDescending(x => x.Score).ToPagedList(page, 5);

            return PartialView("_AllPlayers", list);

        }
    }
}