using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace utau_overflags
{
    public class PresetController
    {

        private const string PresetFolder = "preset/";
        private const string PresetExtension = ".xml";

        public string FindPath(string presetName)
        {
            if (File.Exists(GetSystemPresetFilePath(presetName)))
            {
                return GetSystemPresetFilePath(presetName);
            }
            return GetPresetFilePath(presetName);
        }

        public IList<FileInfo> FetchPresets()
        {
            var list = new List<FileInfo>();
            foreach (FileInfo file in new DirectoryInfo(AppDataPath()).GetFiles())
            {
                if (IsPresetFile(file))
                {
                    list.Add(file);
                }
            }
            foreach (FileInfo file in new DirectoryInfo(PresetFolder).GetFiles())
            {
                if (IsPresetFile(file) && !list.Contains(file))
                {
                    list.Add(file);
                }
            }
            list.Sort((a, b) => a.Name.CompareTo(b.Name));
            return list;
        }

        private static bool IsPresetFile(FileInfo file)
        {
            return Path.GetExtension(file.Name) == PresetExtension;
        }

        public void Write<T>(string fn, T list)
        {
            if (fn == "")
            {
                throw new ArgumentException("ファイル名が指定されていません");
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            //try
            //{
            //    using (FileStream fs = new FileStream(GetPresetFilePath(fn), FileMode.Create))
            //    {
            //        serializer.Serialize(fs, list);
            //    }
            //}
            //catch
            //{
            using (FileStream fs = new FileStream(GetSystemPresetFilePath(fn), FileMode.Create))
            {
                serializer.Serialize(fs, list);
            }
            //}
        }

        public bool Exists(string fn)
        {
            if (File.Exists(GetSystemPresetFilePath(fn)))
            {
                return true;
            }
            return File.Exists(GetPresetFilePath(fn));
        }

        private string GetPresetFilePath(string fileName)
        {
            if (fileName == "")
            {
                throw new ArgumentException("ファイル名が指定されていません");
            }
            return PresetFolder + fileName + PresetExtension;
        }

        private string GetSystemPresetFilePath(string fileName)
        {
            return AppDataPath() + fileName + PresetExtension;
        }

        private static string AppDataPath()
        {
            return GetFileSystemPath(Environment.SpecialFolder.ApplicationData);
        }

        private static string GetFileSystemPath(Environment.SpecialFolder folder)
        {
            // パスを取得
            string path = String.Format(@"{0}\{1}\{2}",
              Environment.GetFolderPath(folder),
              Application.ProductName,
              PresetFolder
            );
            // パスのフォルダを作成
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
    }
}
