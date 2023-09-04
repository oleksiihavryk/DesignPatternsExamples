using ChainOfResponsibilityPattern;
using Sys = ChainOfResponsibilityPattern.System;

//Chain of responsibility - is a pattern that is well-suited for processing
//requests to outer systems.
var client = new Client();
var sys = new Sys(strings: new[]
{
    "",
    "sas",
    "paras",
    "panas",
    "keeeeeeeeeeeeeeeeesss",
    "1101",
    "110001101",
    "0010110000110",
    "110112",
});

//Chain of responsibility which contains one handling element.
var binaryStrings = new BinaryStringsRequest(sys);

Console.WriteLine("All binary strings in system: ");
Console.WriteLine(client.GetData(binaryStrings));

//Also chain of responsibility which contains one handling element.
var moreThan10SymbolsStrings = new MoreThan10SymbolsRequest(sys);

Console.WriteLine("All strings which length more than 10 symbols");
Console.WriteLine(client.GetData(moreThan10SymbolsStrings));

//Chain of responsibility which contains two handling elements.
var combinedChain = binaryStrings.SetNext(moreThan10SymbolsStrings);

Console.WriteLine("All binary strings which length more than 10 symbols");
Console.WriteLine(client.GetData(combinedChain));

/*
 * This example is have only two handling elements in chain of responsibility,
 * but in reality chain can contain endless of elements.
*/