namespace MyLibrary;

using System.IO;

public class Subject : ISubject
{
    private readonly StreamWriter _writer;

    public Subject(StreamWriter writer)
    {
        _writer = writer;
    }

    public void DoNothing()
    {
        _writer.WriteLine("Nothing is done");
    }
}
