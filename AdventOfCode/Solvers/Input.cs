using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventOfCode.Solvers
{
    public class Input
    {
        private readonly int _day;
        
        public string ResourceName => $"AdventOfCode.day._{_day}.input";
        
        public Input(int day)
        {
            _day = day;
        }

        public int[] AsArrayOfInt()
        {
            var input = AsArrayOfString();

            return input.Select(i => Convert.ToInt32(i)).ToArray();
        }

        public string[] AsArrayOfString()
        {
            return AsText().Split(new[] { "\n" }, StringSplitOptions.None);
        }

        public string AsText()
        {
            string result;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            return result.Trim();
        }
        
    }
}