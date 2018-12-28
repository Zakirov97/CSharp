using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGG8.FileSystem
{
    public class File
    {
        #region Private fields
        private string _fileName;
        private readonly int _fileSize;
        private string _fullPathToFile;
        private string _parentFolder;
        private DateTime _lastModified;
        private string _extension;
        #endregion

        #region Properties
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; _lastModified = DateTime.Today; }
        }

        public int FileSize
        {
            get { return _fileSize; }
        }

        public string GetFullPathToFile
        {
            get { return _parentFolder + @"\" + _fileName; }
        }

        public string ParentFolder
        {
            get { return _parentFolder; }
            set { _parentFolder = value; _fullPathToFile = value + @"\" + _fileName; _lastModified = DateTime.Today; }
        }

        public DateTime LastModified
        {
            get { return _lastModified; }
        }

        public string Extension
        {
            get { return _extension; }
            set { _extension = value.Split('.').Last(); _lastModified = DateTime.Today; }
        }

        #endregion

        #region Methods
        public void MoveToFolder(string folder)
        {
            _parentFolder = folder;
            _lastModified = DateTime.Today;
        }
        #endregion

        #region Constructor
        public File(string _fileName, int _fileSize)
        {
            this._fileName = _fileName;
            this._fileSize = _fileSize;
            _lastModified = DateTime.Today;
        }
        public File()
        {
            _lastModified = DateTime.Today;
        }
        #endregion
    }
}
