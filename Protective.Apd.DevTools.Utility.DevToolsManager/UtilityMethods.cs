using System;
using System.IO;

namespace DevToolsAndReferenceAnalyzer
{
    /// <summary>
    /// Class that provides generic utility methods (such as file/directory operations) to the project.
    /// </summary>
    public static class UtilityMethods
    {
        /// <summary>
        /// Makes the file writable, doesn't check if it is already writable.
        /// </summary>
        /// <param name="path">The path.</param>
        public static void MakeFileWritable(string path)
        {
            string fullPath = Path.GetFullPath(path);

            var fileAttributes = File.GetAttributes(fullPath);
            fileAttributes = fileAttributes & ~FileAttributes.ReadOnly;
            File.SetAttributes(fullPath, fileAttributes);
        }

        /// <summary>
        /// Determines whether the file is read-only.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>
        ///   <c>true</c> if the file is read-only; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFileReadOnly(string path)
        {
            string fullPath = Path.GetFullPath(path);

            FileInfo fileInfo = new FileInfo(fullPath);

            return fileInfo.IsReadOnly;
        }

        /// <summary>
        /// Backs up the file using a specific date/time format.
        /// </summary>
        /// <param name="filePathWithFileName">Name of the file path with file.</param>
        public static void BackupFile(string filePathWithFileName)
        {
            string fullPath = Path.GetFullPath(filePathWithFileName);

            string filePath = Path.GetDirectoryName(fullPath);
            string fileName = Path.GetFileName(fullPath);

            string backupFileName = string.Format(fileName + ".{0}.bak", DateTime.Now.ToString("O").Replace(":", "-"));

            string fullBackupFilePath = Path.Combine(filePath, backupFileName);

            File.Copy(fullPath, fullBackupFilePath);
        }

        /// <summary>
        /// Copies a directory, all sub-folders, and all files to another location, effectively a backup method.
        /// </summary>
        /// <param name="sourceDirName">Name of the source directory.</param>
        /// <param name="destDirName">Name of the destination directory.</param>
        public static void DeepDirectoryCopy(string sourceDirName, string destDirName)
        {
            string fullSourceDir = Path.GetFullPath(sourceDirName);
            string fullDestDir = Path.GetFullPath(destDirName);


            // Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(fullSourceDir, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(fullSourceDir, fullDestDir));
            }

            // Copy all the files
            foreach (string newPath in Directory.GetFiles(fullSourceDir, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(fullSourceDir, fullDestDir));
            }
        }
    }
}
