using System.Runtime.InteropServices;

namespace Task5;

class AnElephantOutOfAFly
{
    static void Main(string[] args)
    {
        TransformToElephant();
        Console.WriteLine("Муха");
        //... custom application code
    }

    static void TransformToElephant()
    {
        string str1 = "Муха";
        string str2 = "Слон";
        GCHandle handle = GCHandle.Alloc(str1, GCHandleType.Pinned);
        IntPtr arrAddress = handle.AddrOfPinnedObject();
        for (int i = 0; i < str1.Length; i++)   
        {
            Marshal.WriteInt64(arrAddress + i * sizeof(char), str2[i]);
        }
        handle.Free();
    }
}