using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hangman.Web.Models
{
    public class GameModel
    {
        public int Guesses { get; set; }

        public char[] FullWord { get; set; }

        public char[] PartialWord { get; set; }

        public char[] UsedLetters { get; set; }

        public List<PlayersModel> UserList { get; set; }
    }
}