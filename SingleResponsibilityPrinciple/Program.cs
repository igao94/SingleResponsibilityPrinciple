﻿using SingleResponsibilityPrinciple.DataAccess;

var names = new Names();
var path = new NamesFilePathBuilder().BuildFilePath();
var stringsTextualRepository = new StringsTextualRepository();

if (File.Exists(path))
{
    Console.WriteLine("Names file already exists. Loading names.");
    var stringsFromFile = stringsTextualRepository.Read(path);
    names.AddNames(stringsFromFile);
}
else
{
    Console.WriteLine("Names file does not yet exists.");

    names.AddName("John");
    names.AddName("not a valid name");
    names.AddName("Claire");
    names.AddName("123 definitely not a valid name.");

    Console.WriteLine("Saving names to a file.");
    stringsTextualRepository.Write(path, names.All);
}

Console.WriteLine(new NamesFormater().Format(names.All));
Console.ReadKey();
