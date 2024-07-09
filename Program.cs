namespace CSharp15._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the file path:");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("The file does not exist.");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            string fileContent = File.ReadAllText(filePath);

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Search for a word");
                Console.WriteLine("2. Count occurrences of a word");
                Console.WriteLine("3. Search for a word in reverse order");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SearchWord(lines);
                        break;

                    case "2":
                        CountOccurrences(fileContent);
                        break;

                    case "3":
                        SearchWordInReverse(fileContent);
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void SearchWord(string[] lines)
        {
            Console.WriteLine("Enter the word to search:");
            string word = Console.ReadLine();
            bool found = false;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(word))
                {
                    Console.WriteLine($"Word found in line {i + 1}: {lines[i]}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Word not found.");
            }
        }

        static void CountOccurrences(string content)
        {
            Console.WriteLine("Enter the word to count:");
            string word = Console.ReadLine();
            int count = content.Split(new[] { word }, StringSplitOptions.None).Length - 1;
            Console.WriteLine($"The word '{word}' occurs {count} times.");
        }

        static void SearchWordInReverse(string content)
        {
            Console.WriteLine("Enter the word to search in reverse:");
            string word = Console.ReadLine();
            string reversedWord = new string(word.Reverse().ToArray());
            int count = content.Split(new[] { reversedWord }, StringSplitOptions.None).Length - 1;
            Console.WriteLine($"The reversed word '{reversedWord}' occurs {count} times.");
        }
    }
}
