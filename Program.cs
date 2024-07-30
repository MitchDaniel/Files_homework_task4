using System.Text;

namespace Task4
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            string sourceParth = @"C:\Users\Brill\Desktop\Source.txt";
            string[] newTempName = sourceParth.Split('\\');
            StringBuilder sbForName = new StringBuilder();
            for (int i = 0; i < newTempName.Length - 1; i++)
            { 
                sbForName.Append(newTempName[i] + '\\'); 
            }
            sbForName.Append("new " + newTempName[^1]);
            string newFileParth = sbForName.ToString();
            if (!File.Exists(sourceParth))
            {
                throw new FileNotFoundException();
            }
            string[] linesFromFile = File.ReadAllLines(sourceParth);
            StringBuilder newLines = new StringBuilder();
            for (int i = 0; i < linesFromFile.Length; i++)
            {
                string[] words = linesFromFile[i].Split(" ");
                for (int j = 0; j < words.Length; j++)
                {
                    words[j] = new string(words[j].Reverse().ToArray());
                    newLines.Append(words[j] + " ");
                }
                linesFromFile[i] = newLines.ToString();
                newLines.Clear();
            }
            File.WriteAllLines(newFileParth, linesFromFile);
        }
    }
}

//Задание 4:
//Пользователь вводит путь к файлу. Приложение должно перевернуть содержимое файл и образовать новый файл.