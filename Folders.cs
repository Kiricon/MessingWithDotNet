using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.IO;

public class Folders
{
    public static IEnumerable<string> FolderNames(string xml, char startingLetter)
    {
        List<string> Folders = new List<string>();
        using (XmlReader reader = XmlReader.Create(new StringReader(xml))) {
            while(reader.Read()) {
                if(reader.NodeType == XmlNodeType.Element) {
                    if(reader.Name == "folder") {
                        if(reader.GetAttribute("name")[0] == startingLetter) {
                            Folders.Add(reader.GetAttribute("name"));
                        }
                    }
                }
            }
        }

        return Folders;
    }

    public static void Main(string[] args)
    {
        string xml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<folder name=\"c\">" +
                "<folder name=\"program files\">" +
                    "<folder name=\"uninstall information\" />" +
                "</folder>" +
                "<folder name=\"users\" />" +
            "</folder>";

        foreach (string name in Folders.FolderNames(xml, 'u'))
            Console.WriteLine(name);
    }
}
