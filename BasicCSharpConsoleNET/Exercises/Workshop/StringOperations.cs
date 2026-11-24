using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BasicCSharpConsoleNET.Exercises.Workshop
{
    internal class StringOperations
    {
        public void Run()
        {
            const string MyText = "Lorem ipsum dolor sit amet,\r\nconsectetur adipiscing elit.    ";

            //WhiteCharacters space, tab, new line, carriage return, hard space, non-breaking space, etc.
            //split
            int wordsCount = MyText
                .Split(new[] { ' ', '\r', '\n', ',', '.' }, StringSplitOptions.RemoveEmptyEntries)
                .Length;

            //fragment tekstu
            var beforeComma = MyText.Substring(0, MyText.IndexOf(','));

            var afterComma = MyText.Substring(MyText.IndexOf(',') + 1);

            Console.WriteLine($"Liczba słów: {wordsCount}");
            Console.WriteLine($"Tekst przed przecinkiem: {beforeComma}");
            Console.WriteLine($"Tekst po przecinku: {afterComma.TrimStart()}");

            //trzeci wyraz
            var thirdWord = MyText
                .Split(new[] { ' ', '\r', '\n', ',', '.' }, StringSplitOptions.RemoveEmptyEntries)[2];

            //połączyć w jeden string co drugi wyraz
            var words = MyText
                .Split(new[] { ' ', '\r', '\n', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            var everySecondWord = string.Empty;
            for (int i = 0; i < words.Length; i += 2)
            {
                everySecondWord += words[i] + " ";
            }
            

            // e letter in a sentence
            var eLetterCount = MyText.Split('e').Length - 1;
        }
    }
}
