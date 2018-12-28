using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGG8.FileSystem
{
    public class LogicalDisk
    {
        #region Private fields
        private char _diskLabel;
        private int _diskTotalSize;
        private List<Folder> _folders;
        private DateTime _lastModified;
        #endregion

        #region Properties
        public char DiskLabel
        {
            get { return _diskLabel; }
        }
        public int DiskTotalSize
        {
            get { return _diskLabel; }
        }
        public DateTime LastModified
        {
            get { return _lastModified; }
        }
        public int FreeSpace
        {
            get { return 0; }
        }
        #endregion

        #region Methods

        public void AddFolder(Folder folder)
        {
            folder.ParentFolder = null;
            _folders.Add(folder);
        }
        #endregion

        #region Constructors
        public LogicalDisk(char diskLabel, int diskTotalSize)
        {
            _diskLabel = diskLabel;
            _diskTotalSize = diskTotalSize;
        }
        #endregion
    }
}
