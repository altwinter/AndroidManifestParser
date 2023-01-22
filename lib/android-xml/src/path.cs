namespace AndroidXml
{
    /// <summary>
    /// Main Directory path Class
    /// </summary>
    public class DirectoryPath
    {

        /// <summary>
        /// DirectoryPath Instance
        /// </summary>
        /// <returns>An instance of the <see cref="DirectoryPath"/> class.</returns>
        public static DirectoryPath Instance { get { return Nested.instance; } }

        /// <summary>
        /// DirectoryPath private instance
        /// </summary>
        private DirectoryPath()
        {
            string dir = System.IO.Directory.GetCurrentDirectory();
            string name = "android-manifest-parser";
            var index = dir.IndexOf(name);

            _projectPath = dir.Substring(0, index + name.Length);
        }

        /// <summary>
        /// Get the path to the current project
        /// </summary>
        /// <returns>The <see cref="string"/> path to the current project.</returns>
        public string CurrentProject() => _projectPath;

        /// <summary>
        /// Save the path to the current project
        /// </summary>
        private readonly string _projectPath;

        /// <summary>
        /// Nested class
        /// </summary>
        private class Nested
        {
            /// <summary>
            /// Private Nested instance
            /// </summary>
            static Nested()
            {
            }

            /// <summary>
            /// Singleton of DirectoryPath class
            /// </summary>
            internal static readonly DirectoryPath instance = new DirectoryPath();
        }
    }
}