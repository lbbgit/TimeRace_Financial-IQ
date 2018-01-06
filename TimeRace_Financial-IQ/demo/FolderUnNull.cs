using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Data;
using System.Collections.Generic;

public class FolderUnNull
{
    public bool? isNullFolder(string folderpath)
    {
        string[] folders = System.IO.Directory.GetDirectories(folderpath, "*", SearchOption.TopDirectoryOnly);
        if (folders.Length > 0)
            return false;//ListToString(folders);

        string[] files = System.IO.Directory.GetFiles(folderpath, "*", SearchOption.TopDirectoryOnly);
        if (files.Length == 0)
            return true;
        else
            return null;//self is null
    }
    public string ListToString(string[] strs)
    {
        if (strs == null || strs.Length == 0)
            return string.Empty;
        StringBuilder sb = new StringBuilder();
        foreach (string str in strs)
            sb.Append(str).Append(',');
        return sb.ToString();
    }
    public static List<string> NuNull(string folderpath, bool create_KeepFile = true, string keepFileName = ".gitignore",
        bool top=true)
    {
        if (top && !System.IO.Directory.Exists(folderpath)) 
            return null; 

        if (string.IsNullOrWhiteSpace(keepFileName))
            keepFileName = ".gitignore";

        //begin ,if u have son  
        List<string> emptyFolder=new List<string>(); 
        string[] folders = System.IO.Directory.GetDirectories(folderpath, "*", SearchOption.TopDirectoryOnly);
        if (folders.Length > 0)
        {
            foreach (string folder in folders)
            {
                List<string> sout = NuNull(folder, create_KeepFile, keepFileName, false);
                if (sout != null)
                    emptyFolder.AddRange(sout);
            }
        }
        else
        {
            string[] files = System.IO.Directory.GetFiles(folderpath, "*", SearchOption.TopDirectoryOnly);
            if (files.Length == 0 )
            {
                if (create_KeepFile)
                    ClearNull(folderpath, create_KeepFile, keepFileName);
                return new List<string> { folderpath };
            }
            else
                return null;
        }
        return emptyFolder;

        //List<string> folderNull = new List<string>();
        //foreach (string folder in folders)
        //{
        //    if (System.IO.Directory.GetDirectories(folder, "*", SearchOption.TopDirectoryOnly).Length == 0
        //        &&
        //        System.IO.Directory.GetFiles(folder, "*", SearchOption.TopDirectoryOnly).Length == 0)
        //        folderNull.Add(folder);
        //}

        //StringBuilder sb = new StringBuilder();
        //foreach (string path in folderNull)
        //{
        //    sb.Append(path).Append(',');
        //    if (create_KeepFile)
        //        System.IO.File.Create(Path.Combine(path, keepFileName), 0);
        //} 
    }
    public static void ClearNull(string folderpath, bool create_KeepFile = true, string keepFileName = ".gitignore")
    {
        if (create_KeepFile)
            System.IO.File.Create(Path.Combine(folderpath, keepFileName), 0);
    }
    public static string NuNull_old(string folderpath, bool create_KeepFile = true, string keepFileName = ".gitignore")
    {
        if (!System.IO.Directory.Exists(folderpath))
            return null;
        if (string.IsNullOrWhiteSpace(keepFileName))
            keepFileName = ".gitignore";

        string[] folders = System.IO.Directory.GetDirectories(folderpath, "*", SearchOption.AllDirectories);
        List<string> folderNull = new List<string>();
        foreach (string folder in folders)
        {
            if (System.IO.Directory.GetDirectories(folder, "*", SearchOption.TopDirectoryOnly).Length == 0
                &&
                System.IO.Directory.GetFiles(folder, "*", SearchOption.TopDirectoryOnly).Length == 0)
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