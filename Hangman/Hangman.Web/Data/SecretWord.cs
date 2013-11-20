using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hangman.Web.Data
{
    public static class SecretWord
    {
        public static char[] PartialWord { get; set; }

        public static char[] FullWord { get; set; }

        public static char[] UsedLetters { get; set; }
    }
}