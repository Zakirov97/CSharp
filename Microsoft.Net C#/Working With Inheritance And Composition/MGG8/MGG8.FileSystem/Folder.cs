using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGG8.FileSystem
{
    public class Folder
    {
        #region Private fields
        private string _folderName;
        private List<File> _files;
        private List<Folder> _folders;
        private string _parentFolder;
        private string _fullPathToFolder;
        private List<Object> Basket;
        private DateTime _lastModified;
        #endregion

        #region Properties
        public string FolderName
        {
            get { return _folderName; }
            set { _folderName = value; _lastModified = DateTime.Today; }
        }

        public string ParentFolder
        {
            get { return _parentFolder; }
            set { _parentFolder = value; _fullPathToFolder = _parentFolder + @"\" + _folderName; _lastModified = DateTime.Today; }
        }

        public string GetFullPathToFolder() { return _parentFolder + @"\" + _folderName; }

        public DateTime LastModified
        {
            get { return _lastModified; }
        }

        public int FolderSize
        {
            get { return GetFolderSize(); }
        }
        #endregion

        #region Methods
        public void AddFile(File file)
        {
            if (_files == null)
            {
                _files = new List<File>();
            }
            if (_files.Exists(p => p.FileName == file.FileName))
            {
                Console.WriteLine("This file already exist in this folder.");
                return;
            }
            file.ParentFolder = _parentFolder;
            _files.Add(file);
            _lastModified = DateTime.Today;
        }

        public void DeleteFile(File file)
        {
            Basket.Add(file);
            _files.Remove(file);
        }

        public void AddFolder(Folder folder)
        {
            if (_folders == null)
            {
                _folders = new List<Folder>();
            }
            if (_folders.Exists(p => p._parentFolder == folder._folderName))
            {
                Console.WriteLine("The destination folder in which to place the files is a child of the folder in which they are located.");
                return;
            }
            folder.ParentFolder = _parentFolder;
            _folders.Add(folder);
            _lastModified = DateTime.Today;
        }

        public void DeleteFolder(Folder folder)
        {
            Basket.Add(folder);
            _folders.Remove(folder);
        }

        public void Reestablish()
        {
            foreach (var item in Basket)
            {
                if (item is File)
                    Console.WriteLine("File - {0}", (item as File).FileName);
                else
                    Console.WriteLine("Folder - {0}", (item as Folder).FolderName);
            }
            string s = Console.ReadLine();
            foreach (var item in Basket)
            {
                if (item is File)
                {
                    if ((item as File).FileName == s)
                    {
                        _files.Add(item as File);
                        Basket.Remove(item);
                        return;
                    }
                }
                else
                {
                    if ((item as Folder)._folderName == s)
                    {
                        _folders.Add(item as Folder);
                        Basket.Remove(item);
                        return;
                    }
                }
            }
        }

        private int GetFolderSize()
        {
            int size = 0;
            if (this._folders != null)
            {
                for (int i = 0; i < _folders.Count; i++)
                {
                    size += _folders[i].GetFolderSize();
                }
            }
            if (this._files != null)
            {
                for (int i = 0; i < _files.Count; i++)
                {
                    size += _files[i].FileSize;
                }
            }
            return size;
        }

        public void RemoveFile(string fileName)
        {
            for (int i = 0; i < _files.Count; i++)
            {
                if (_files[i].FileName == fileName)
                {
                    _files.RemoveAt(i);
                    break;
                }
            }
            _lastModified = DateTime.Today;

        }

        public void RemoveFolder(string folderName)
        {
            for (int i = 0; i < _folders.Count; i++)
            {
                if (_folders[i]._folderName == folderName)
                {
                    _folders.RemoveAt(i);
                    break;
                }
            }
            _lastModified = DateTime.Today;
        }

        public void MoveFolder(string folderName)
        {
            _parentFolder = folderName;
            _lastModified = DateTime.Today;
        }


        #endregion

        #region Constructors
        public Folder(string folderName)
        {
            _folderName = folderName;
        }
        public Folder()
        {
        }



        #endregion
    }
}
