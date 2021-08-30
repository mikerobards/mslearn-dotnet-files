﻿using System;
using System.IO;
using System.Collections.Generic;

namespace files_module
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            var storesDirectory = Path.Combine(currentDirectory, "stores");

            var salesFiles = FindFiles(storesDirectory);

            foreach (var file in salesFiles)
            {
                Console.WriteLine(file);
            }

        }
        static IEnumerable<string> FindFiles(string folderName)
        {
            List<string> salesFiles = new List<string>();

            var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

            foreach (var file in foundFiles)
            {
                // The file name will contain the full path, so only check the end of it
                var extension = Path.GetExtension(file);

                if (extension == ".json")
                {
                    salesFiles.Add(file);
                }
            }

            return salesFiles;
        }
    }
}
