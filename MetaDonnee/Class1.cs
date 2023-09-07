using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace MetaDonnee
{
    public class Class1
    {
        public void utiliser ()
        {
            string path = "F:\\mp3\\Flac\\Joan Baez\\Joan_Baez-BD_Music_Presents_Joan_Baez\\01-05-Joan_Baez-Lowlands-LLS.flac";
            using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var peReader = new PEReader(fs);

            // Display PE header information
            PEHeader? header = peReader.PEHeaders.PEHeader;
            if (header is null) return;
            Console.WriteLine($"Image base:     0x{header.ImageBase.ToString("X")}");
            Console.WriteLine($"File alignment: 0x{header.FileAlignment.ToString("X")}");
            Console.WriteLine($"Subsystem:      {header.Subsystem}");

            // Display .NET metadata information
            if (!peReader.HasMetadata)
            {
                Console.WriteLine("Image does not contain .NET metadata");
                return;
            }

            MetadataReader mr = peReader.GetMetadataReader();
            AssemblyDefinition ad = mr.GetAssemblyDefinition();
            Console.WriteLine($"Assembly name:  {ad.GetAssemblyName().ToString()}");
            Console.WriteLine();
            Console.WriteLine("Assembly attributes:");

            foreach (CustomAttributeHandle attrHandle in ad.GetCustomAttributes())
            {
                CustomAttribute attr = mr.GetCustomAttribute(attrHandle);

                // Display the attribute type full name
                if (attr.Constructor.Kind == HandleKind.MethodDefinition)
                {
                    MethodDefinition mdef = mr.GetMethodDefinition((MethodDefinitionHandle)attr.Constructor);
                    TypeDefinition tdef = mr.GetTypeDefinition(mdef.GetDeclaringType());
                    Console.WriteLine($"{mr.GetString(tdef.Namespace)}.{mr.GetString(tdef.Name)}");
                }
                else if (attr.Constructor.Kind == HandleKind.MemberReference)
                {
                    MemberReference mref = mr.GetMemberReference((MemberReferenceHandle)attr.Constructor);

                    if (mref.Parent.Kind == HandleKind.TypeReference)
                    {
                        TypeReference tref = mr.GetTypeReference((TypeReferenceHandle)mref.Parent);
                        Console.WriteLine($"{mr.GetString(tref.Namespace)}.{mr.GetString(tref.Name)}");
                    }
                    else if (mref.Parent.Kind == HandleKind.TypeDefinition)
                    {
                        TypeDefinition tdef = mr.GetTypeDefinition((TypeDefinitionHandle)mref.Parent);
                        Console.WriteLine($"{mr.GetString(tdef.Namespace)}.{mr.GetString(tdef.Name)}");
                    }
                }
            }
        }
    }
}