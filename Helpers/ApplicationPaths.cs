using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CK2ModTests.Helpers
{
    public sealed class ApplicationPaths
    {
        static string rootDirectory;
        static IList<string> mods;

        /// <summary>
        /// The executing directory.
        /// </summary>
        public static string RootDirectory
        {
            get
            {
                if (rootDirectory == null)
                {
                    string executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                    rootDirectory = new DirectoryInfo(executingDirectory).Parent.Parent.Parent.Parent.FullName;
                }

                return rootDirectory;
            }
        }

        public static IEnumerable<string> Mods
        {
            get
            {
                if (mods == null)
                {
                    IEnumerable<string> rootFiles = Directory.GetFiles(RootDirectory);
                    mods = new List<string>();

                    foreach (string file in rootFiles)
                    {
                        if (file.EndsWith(".mod"))
                        {
                            string mod = Path.GetFileNameWithoutExtension(file);
                            mods.Add(mod);
                        }
                    }
                }

                return mods;
            }
        }

        public static string TestsDirectory => Path.Combine(RootDirectory, "ck2-mod-tests");

        public static string TestDataDirectory => Path.Combine(TestsDirectory, "Data");

        public static string DescriptorFile => Path.Combine(RootDirectory, $"{Mods.First()}.mod");

        public static string ModDirectory => Path.Combine(RootDirectory, Mods.First());

        public static string CommonDirectory => Path.Combine(ModDirectory, "common");
        
        public static string CulturesDirectory => Path.Combine(CommonDirectory, "cultures");

        public static string DynastiesDirectory => Path.Combine(CommonDirectory, "dynasties");

        public static string LandedTitlesDirectory => Path.Combine(CommonDirectory, "landed_titles");

        public static string LocalisationDirectory => Path.Combine(ModDirectory, "localisation");
    }
}
