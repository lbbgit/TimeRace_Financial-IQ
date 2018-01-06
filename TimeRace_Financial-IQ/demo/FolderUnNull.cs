using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Data;
using System.Collections.Generic;

public class FolderUnNull
{
    public static string NuNull(string folderpath, bool create_KeepFile = true, string keepFileName = ".gitignore")
    {
        if (!System.IO.Directory.Exists(folderpath))
            return null;
        if (string.IsNullOrWhiteSpace(keepFileName))
            keepFileName = ".gitignore";

        string[] folders = System.IO.Directory.GetDirectories(folderpath, "*", SearchOption.AllDirectories);
        List<string> folderNull = new List<string>();
        foreach (string folder in folders)
        {
            if (System.IO.Directory.GetFiles(folder, "*", SearchOption.TopDirectoryOnly).Length == 0)
                folderNull.Add(folder);
        }

        StringBuilder sb = new StringBuilder();
        foreach (string path in folderNull)
        {
            sb.Append(path).Append(',');
            if (create_KeepFile)
                System.IO.File.Create(Path.Combine(path, keepFileName), 0);
        }

        return sb.ToString(); 
    }
}