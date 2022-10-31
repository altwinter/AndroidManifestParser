namespace AndroidXml
{
    public class DirectoryPath
    {
        public static DirectoryPath Instance { get { return Nested.instance; } }

        private DirectoryPath()
        {
            string dir = System.IO.Directory.GetCurrentDirectory();
            string name = "android-manifest-parser";
            var index = dir.IndexOf(name);

            _projectPath = dir.Substring(0, index + name.Length);
        }

        public string CurrentProject() => _projectPath;

        private readonly string _projectPath;

        private class Nested
        {
            static Nested()
            {
            }

            internal static readonly DirectoryPath instance = new DirectoryPath();
        }
    }
}