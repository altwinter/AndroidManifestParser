using System.Diagnostics;

public class AndroidResources
{
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

    public string? Get(string keyString)
    {
        int keyInt = Convert.ToInt32("0x" + keyString.Substring(1), 16);

        string? result = null;
        _resources.TryGetValue(keyInt, out result);

        return result;
    }

    private readonly Dictionary<int, string> _resources;
}