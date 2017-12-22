using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CauldronMinimal
{
    class Program
    {
        static void Main(string[] args)
        {
            var testClass = new ClassToSerialize {Test = "Hi"};
            testClass.StartHistory();
            Save(testClass);
        }

        static void Save(ClassToSerialize classToSave)
        {
            FileStream file = File.Open("test.data", FileMode.Create);
            var serializer = new BinaryFormatter();

            serializer.Serialize(file, classToSave);
            file.Close();
        }
    }
}
