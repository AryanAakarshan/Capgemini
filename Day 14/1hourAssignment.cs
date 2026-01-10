using System;
using System.IO;
using System.Xml.Serialization;

using FileIO.TextHandling;
using FileIO.BinaryHandling;
using FileIO.SystemManagement;
using Serialization.XML;

namespace FileIO.TextHandling
{
    class UserTextManager
    {
        private string filePath = "user.txt";

        public void WriteUserToFile(string name, int age)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Name: " + name);
                writer.WriteLine("Age: " + age);
            }
        }

        public string ReadUserFromFile()
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                return reader.ReadToEnd();
            }
        }
    }
}

namespace FileIO.BinaryHandling
{
    class UserBinaryManager
    {
        private string filePath = "user.dat";

        public void SaveUserBinary(int id, string name)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                writer.Write(id);
                writer.Write(name);
            }
        }

        public string LoadUserBinary()
        {
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                int id = reader.ReadInt32();
                string name = reader.ReadString();
                return $"Id: {id}\nName: {name}";
            }
        }
    }
}

namespace FileIO.SystemManagement
{
    class FileSystemManager
    {
        private string baseDirectory = "BaseFolder";

        public void CreateDirectory(string folderName)
        {
            baseDirectory = folderName;
            if (!Directory.Exists(baseDirectory))
                Directory.CreateDirectory(baseDirectory);
            Console.WriteLine("Directory created");
        }

        public void CreateFile(string fileName)
        {
            string filePath = Path.Combine(baseDirectory, fileName);
            if (!File.Exists(filePath))
                File.Create(filePath).Close();
            Console.WriteLine("File created");
        }

        public bool CheckFileExists(string fileName)
        {
            string filePath = Path.Combine(baseDirectory, fileName);
            return File.Exists(filePath);
        }
    }
}

namespace Serialization.XML
{
    public class User
    {
        public int Id;
        public string Name;
    }

    class UserXmlSerializer
    {
        private string filePath = "user.xml";

        public void SerializeToXml(User user)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(User));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, user);
            }
        }

        public User DeserializeFromXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(User));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (User)serializer.Deserialize(fs);
            }
        }
    }
}


class Program
{
    static void Main()
    {
        UserTextManager textManager = new UserTextManager();
        textManager.WriteUserToFile("Alice", 25);
        Console.WriteLine("User Data Loaded:");
        Console.WriteLine(textManager.ReadUserFromFile());

        UserBinaryManager binaryManager = new UserBinaryManager();
        binaryManager.SaveUserBinary(101, "Bob");
        Console.WriteLine("User Loaded:");
        Console.WriteLine(binaryManager.LoadUserBinary());

        FileSystemManager fileSystemManager = new FileSystemManager();
        fileSystemManager.CreateDirectory("Users");
        fileSystemManager.CreateFile("data.txt");
        Console.WriteLine("File exists: " + fileSystemManager.CheckFileExists("data.txt"));

        User user = new User { Id = 1, Name = "Alice" };
        UserXmlSerializer xmlSerializer = new UserXmlSerializer();
        xmlSerializer.SerializeToXml(user);
        User restoredUser = xmlSerializer.DeserializeFromXml();
        Console.WriteLine("Id: " + restoredUser.Id);
        Console.WriteLine("Name: " + restoredUser.Name);
    }
}
