using Sudoku.Models.Board;
using Sudoku.Services.SerializationServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sudoku.Services.ReaderServices
{
    internal static class BoardsReader
    {
        #region Public methods
        public static List<Board> Read(string path)
        {
            List<Board> boards = new List<Board>();
            string extension = @".board";
            var files = new DirectoryInfo(path).GetFiles().Where(file => file.Extension.Equals(extension));
            foreach (var file in files)
            {
                boards.Add(Serializer.DeserializeJsonObject<Board>(file.FullName));
            }
            return boards;
        }
        public static Board ReadRandomBoard(string path)
        {
            Random random = new Random();
            string extension = @".board";
            var files = new DirectoryInfo(path).GetFiles().Where(file => file.Extension.Equals(extension)).ToList();
            return files.Count != 0 ? Serializer.DeserializeJsonObject<Board>(files[random.Next(files.Count)].FullName) : null;
        }
        #endregion
    }
}
