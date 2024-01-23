namespace MyLibrary;

using System.IO;

public class Subject : ISubject
{
    private readonly TextWriter _writer;

    public Subject(TextWriter writer)
    {
        _writer = writer;
    }

    public void DoNothing()
    {
        _writer.WriteLine("Nothing is done");
    }
}
