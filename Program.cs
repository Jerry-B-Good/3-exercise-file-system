using System.IO;
using System.Collections.Generic;

var salesFiles = FindFiles("stores");

foreach (var file in salesFiles)
{
    Console.WriteLine(file);
}

IEnumerable<string> FindFiles(string folderName)
{
    // Array of strings to hold the file paths of the sales files. Start with an empty array.
    string[] salesFiles = new string[0];

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        // The file name will contain the full path, so only check the end of it
        if (file.EndsWith("sales.json"))
        {
            Array.Resize(ref salesFiles, salesFiles.Length + 1);
            salesFiles[salesFiles.Length - 1] = file;
        }
    }

    return salesFiles;
}

// Compare outputs with the original repo forked from