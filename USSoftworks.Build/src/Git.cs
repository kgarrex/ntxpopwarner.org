using LibGit2Sharp;
using System;
using System.Linq;
using System.IO;

public class GitInit : Microsoft.Build.Utilities.Task
{
  public enum VersionControlStrategy {
    Gitflow,
    Trunk
  }

  public override bool Execute()
  {
    try
    {
      string workingDir = Repository.Init(Directory.GetCurrentDirectory());
      using Repository repo = new Repository(workingDir);
      // TODO We need to prompt who the person is before initial commit
      Identity id = new Identity("Ken Garrett", "ken.garrett@ussoftworks.com");
      Signature sign = new Signature(id, DateTimeOffset.UtcNow);
      CommitOptions opts = new CommitOptions {
        AmendPreviousCommit = false,
        AllowEmptyCommit = true,
        CommentaryChar = '#'
      };
      repo.Commit("Initial commit", sign, sign, opts);
      /*
      if(null == repo.Branches["master"]) {
        repo.CreateBranch("master");
      }
      else {
        Log.LogMessage(MessageImportance.High, $"Branch 'master' already exists");
      }
      */
      //repo.CreateBranch("prod");
      //Log.LogMessage(MessageImportance.High, $"Branch Count: {repo.Branches.Count()}");
      /*
      repo.Branches.Select(b =>
      {
        Log.LogMessage(MessageImportance.High, $"Branch: {b.CanonicalName}");
	return b;
      });
      */
      //repo.branches.Add("dev");
    }
    catch(Exception ex)
    {
      Log.LogErrorFromException(ex);
    }
    return !Log.HasLoggedErrors;
  }
}
