using System.Diagnostics;

/// <summary>
/// Android resources Class retrived from aapt2 application
/// </summary>
public class AndroidResources
{

    /// <summary>
    /// Android resources extraction
    /// </summary>
    /// <param name="pathApk">The <see cref="string"/> path to the target Apk.</param>
    public AndroidResources(string pathApk)
    {
        _resources = new Dictionary<int, string>();

        Process myProcess = new Process();
        myProcess.StartInfo.RedirectStandardOutput = true;
        myProcess.StartInfo.UseShellExecute = false;
        myProcess.StartInfo.FileName = AndroidXml.DirectoryPath.Instance.CurrentProject() + "/resource/aapt2";
        myProcess.StartInfo.Arguments = "dump resources " + pathApk;

        myProcess.Start();
        string result = myProcess.StandardOutput.ReadToEnd();
        myProcess.WaitForExit();
        myProcess.Close();

        foreach (var myString in result.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
        {
            int index = -1;
            if ((index = myString.IndexOf("resource")) != -1)
            {
                var mySubString = myString.Substring(index);
                var splitLine = mySubString.Split(" ");

                // There must be only tree value <"resource", "0x*****", "name_resource">

                Debug.Assert((splitLine.Count() == 3) || (splitLine.Count() == 4));
                if (splitLine.Count() == 3)
                {
                    int value = Convert.ToInt32(splitLine[1], 16);
                    _resources.Add(value, splitLine[2]);
                }
                else
                {
                    int value = Convert.ToInt32(splitLine[1], 16);
                    _resources.Add(value, splitLine[2] + " " + splitLine[3]);
                }


            }
        }
    }

    /// <summary>
    /// Get the <see cref="string"/> value of a resource Id
    /// </summary>
    /// <param name="keyString">The Key id value as a <see cref="string"/> representation.</param>
    /// <returns>The <see cref="string"/> value attach corresponding to the key Id.</returns>
    public string? Get(string keyString)
    {
        int keyInt = Convert.ToInt32("0x" + keyString.Substring(1), 16);

        string? result = null;
        _resources.TryGetValue(keyInt, out result);

        return result;
    }

    /// <summary>
    /// Dictionary of resources with <<see cref="int"/> -id, <see cref="string"/> -value>
    /// </summary>
    private readonly Dictionary<int, string> _resources;
}